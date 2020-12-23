using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library.Data.Database
{
    class DBStructureManager
    {
        private static int _currentDBVersion = -1;
        private static Library.Language lang = Library.Language.GetInstance();

        /*
         PRE: chiamare SOLO se ALMENO 1 database presente
         */
        public static void ControlloDBSettings()
        {
            Library.Data.Database.DBConnector dbCurrent = new Library.Data.Database.DBConnector();
            DataTable dt = dbCurrent.SQLQuerySelect("SELECT datname FROM pg_database;");
            bool bDBFound = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["datname"].ToString() == "ef_settings") { bDBFound = true; }
            }
            if (!bDBFound) 
            { 
                dbCurrent.SQLQuery_AffectedRows("CREATE DATABASE ef_settings;");

                Library.Data.Database.DBConnector dbSettings = new Library.Data.Database.DBConnector(GVar.ServerIP, "ef_settings");
                dbSettings.SQLQuery_AffectedRows("CREATE TABLE IF NOT EXISTS base_settings (key varchar(255), value varchar(255), value_data bytea); ALTER TABLE base_settings ADD UNIQUE (\"key\");");

                Dictionary<string, string> dicValues1;
                Dictionary<string, object> dicValues2;
                DataTable dt_data = dbCurrent.SQLQuerySelect("SELECT * FROM settings");
                if (dt_data != null)
                {
                    foreach (DataRow dr in dt_data.Rows)
                    {
                        dicValues1 = new Dictionary<string, string>();
                        dicValues1.Add("key", "'" + dr["key"].ToString() + "'");
                        dicValues1.Add("value", "'" + dr["value"].ToString() + "'");
                        object oKey = dbSettings.QueryInsert("base_settings", dicValues1, "key");
                        dicValues2 = new Dictionary<string, object>();
                        dicValues2.Add("value_data", dr["value_data"]);
                        dbSettings.QueryUpdate("base_settings", dicValues2, "key = '" + oKey.ToString() + "'");
                    }
                }
                dbSettings.CloseConnection();
            }
            dbCurrent.CloseConnection();
        }

        public static void ControlloVersioneDB(int maxUpdateVersion = 9999999)
        {
            Library.Data.Database.DBConnect_Npgsql dbc = null;
            NpgsqlDataReader risultatiole = null;

            string queryUpdateVersion = "UPDATE versione SET id = id + 1;";
            try
            {
                dbc = new Library.Data.Database.DBConnect_Npgsql();
                dbc.connect(Library.GVar.Database);
                try
                {
                    dbc.sqlview("SELECT MAX(id) AS id FROM versione ", ref risultatiole);
                    if (risultatiole.Read())
                    {
                        _currentDBVersion = Convert.ToInt32(risultatiole["id"]);
                    }
                    risultatiole.Close();
                }
                catch (Exception)
                {
                    string sql = "CREATE TABLE versione(id integer NOT NULL)";
                    dbc.SQLExe(sql);
                    sql = "INSERT INTO versione(id) VALUES (0)";
                    dbc.SQLExe(sql);
                    _currentDBVersion = 0;
                    if (risultatiole != null) if (!risultatiole.IsClosed) risultatiole.Close();
                }
                if (_currentDBVersion <= -1) throw new Exception(lang.GetWord("dblib04"));

                if (_currentDBVersion == 0 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella base
                    string sql = "CREATE SEQUENCE base_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE base (id int4 NOT NULL primary key DEFAULT nextval('base_id_seq'), base varchar(255) ,density float8, fcbase float8); ";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 1 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella formule
                    string sql = "CREATE SEQUENCE formule_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE formule (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('formule_id_seq'), de float8, decmc float8, nw varchar(10), " +
                        "template varchar(255), dateformula date, notetxt text, colorname varchar(255), base varchar(255), unit varchar(50), " +
                        "oncetype varchar(50), formulasize varchar(50), p1 varchar(255), q1 float8, p2 varchar(255), q2 float8, p3 varchar(255), " +
                        "q3 float8, p4 varchar(255), q4 float8, p5 varchar(255), q5 float8, colorcharts varchar(255), system varchar(255), " +
                        "use varchar(255), r int4, g int4, b int4, ciel float8, ciea float8, cieb float8, ordersystem int4); ";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 2 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella history
                    string sql = "CREATE SEQUENCE history_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE history (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('history_id_seq'), de float8, decmc float8, nw varchar(10), " +
                        "template varchar(255), dateformula date, notetxt text, colorname varchar(255), base varchar(255), unit varchar(50), oncetype varchar(50), " +
                        "formulasize varchar(50), p1 varchar(255), q1 float8, p2 varchar(255), q2 float8, p3 varchar(255), q3 float8, p4 varchar(255), q4 float8, " +
                        "p5 varchar(255), q5 float8, colorcharts varchar(255), system varchar(255), use varchar(255), r int4, g int4, b int4, ciel float8, " +
                        "ciea float8, cieb float8, ordersystem int4, cloud varchar(10));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 3 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella pigmenti
                    string sql = "CREATE SEQUENCE pigmenti_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE pigmenti (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('pigmenti_id_seq'), fullname varchar(255), " +
                        "code varchar(255), family varchar(255), density float8, pr int4, pg int4, pb int4);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 4 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella sqc_color
                    string sql = "CREATE SEQUENCE sqc_color_idcolore_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE sqc_color (idcolore int4 NOT NULL PRIMARY KEY DEFAULT nextval('sqc_color_idcolore_seq'), nome_colore varchar(255) UNIQUE NOT NULL, " +
                        "x float8, y float8, z float8, l float8, a float8, b float8, cod_dir int4 NOT NULL);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 5 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella sqc_dir
                    string sql = "CREATE SEQUENCE directory_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE sqc_dir (iddir int4  NOT NULL PRIMARY KEY DEFAULT nextval('directory_id_seq'), idparent int4, nomedir varchar(255));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 6 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella standardfandeck
                    string sql = "CREATE TABLE standardfandeck (Nomecartella varchar(255), " +
                        "CIEL varchar(255), CIEa varchar(255), CIEb varchar(255), R varchar(255), G varchar(255), B varchar(255), " +
                        "Nome varchar(255));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 7 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella formule_personali
                    string sql = "CREATE SEQUENCE personal_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE formule_personali (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('personal_id_seq'), de float8, decmc float8, nw varchar(10), " +
                        "template varchar(255), dateformula date, notetxt text, colorname varchar(255), base varchar(255), unit varchar(50), oncetype varchar(50), " +
                        "formulasize varchar(50), p1 varchar(255), q1 float8, p2 varchar(255), q2 float8, p3 varchar(255), q3 float8, p4 varchar(255), q4 float8, " +
                        "p5 varchar(255), q5 float8, colorcharts varchar(255), system varchar(255), use varchar(255), r int4, g int4, b int4, ciel float8, " +
                        "ciea float8, cieb float8, client_id int4, directory_id int4, cloud varchar(10));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 8 && _currentDBVersion <= maxUpdateVersion)
                {
                    //aggiunta densita
                    string sql = "ALTER TABLE history ADD densita float8;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 9 && _currentDBVersion <= maxUpdateVersion)
                {
                    /*
                     * DEPRECATED table country from 29/06/2015
                     * 
                        StreamReader streamReader = new StreamReader(System.Windows.Forms.Application.StartupPath + "/include/Country.sql");
                        string text = streamReader.ReadToEnd();
                        streamReader.Close();
                        string sql = text;
                     *
                     */
                    dbc.SQLExe(queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 10 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella formule_personali
                    string sql = "CREATE SEQUENCE customer_id START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE clienti (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('customer_id')," +
                        "nome varchar(255), cognome varchar(255), azienda varchar(255), indirizzo text, nomepaese varchar(255), codicepaese varchar(255)," +
                        "tel1 varchar(255), tel2 varchar(255), fax varchar(255), email varchar(255), partitaiva varchar(255), note text, cloud varchar(255));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 11 && _currentDBVersion <= maxUpdateVersion)
                {
                    //update history.dateofrmula type
                    string sql = "ALTER TABLE history ALTER COLUMN dateformula TYPE timestamp;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 12 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella associazioni Cliente --> Formula personale --> Listini --> Formule Default
                    string sql = "CREATE SEQUENCE id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE clienti_seq (id_seq int4 NOT NULL PRIMARY KEY DEFAULT nextval('id_seq')," +
                        "id_fpersonale int4, id_listino int4, id_fdefault int4);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 13 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella associazioni Cliente --> Formula personale --> Listini --> Formule Default
                    string sql = "ALTER TABLE clienti_seq ADD id_cliente int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 14 && _currentDBVersion <= maxUpdateVersion)
                {
                    //aggiunta densita
                    string sql = "ALTER TABLE formule_personali ADD createdby varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 15 && _currentDBVersion <= maxUpdateVersion)
                {
                    //update history.dateofrmula type
                    string sql = "ALTER TABLE formule_personali ALTER COLUMN dateformula TYPE timestamp;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 16 && _currentDBVersion <= maxUpdateVersion)
                {
                    //update history.dateofrmula type
                    string sql = "ALTER TABLE formule_personali ADD directory_txt varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 17 && _currentDBVersion <= maxUpdateVersion)
                {
                    //update history.dateofrmula type
                    string sql = "ALTER TABLE formule_personali RENAME COLUMN id TO idp;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 18 && _currentDBVersion <= maxUpdateVersion)
                {
                    //tabella settings
                    string sql = "CREATE TABLE IF NOT EXISTS settings (key varchar(255), value varchar(255)); ALTER TABLE settings ADD UNIQUE (\"key\");";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                //Listini Table
                if (_currentDBVersion == 19 && _currentDBVersion <= maxUpdateVersion)
                {
                    //Listini
                    string sql = "CREATE SEQUENCE id_list START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE listino (id_list int4 NOT NULL PRIMARY KEY DEFAULT nextval('id_list')," +
                        "nome_listino varchar(255));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 20 && _currentDBVersion <= maxUpdateVersion)
                {
                    //Listini
                    string sql = "CREATE SEQUENCE id_pig_costi START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE pig_costi (id_pig_costi int4 NOT NULL PRIMARY KEY DEFAULT nextval('id_pig_costi')," +
                        "nome_pigmento varchar(255), costo float8, unita varchar(255), id_listino int4);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 21 && _currentDBVersion <= maxUpdateVersion)
                {
                    //Listini
                    string sql = "CREATE SEQUENCE id_base_costi START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE base_costi (id_base_costi int4 NOT NULL PRIMARY KEY DEFAULT nextval('id_base_costi')," +
                        "nome_base varchar(255), costo_base float8, unita_base varchar(255), id_listino int4);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 22 && _currentDBVersion <= maxUpdateVersion)
                {
                    //Listini
                    string sql = "CREATE SEQUENCE id_lattaggi START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE lattaggi (id_lattaggi int4 NOT NULL PRIMARY KEY DEFAULT nextval('id_lattaggi')," +
                        "nome_base_latt varchar(255), lattaggio float8, unita_lattaggio varchar(255), costo_lattaggio float8, riempimento float8, id_listino int4);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 23 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE listino ADD valuta varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 24 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE base ADD barcode varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 25 && _currentDBVersion <= maxUpdateVersion)
                {
                    //Listini
                    string sql = "CREATE SEQUENCE id_machine START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " +
                        "CREATE TABLE machine (id_machine int4 NOT NULL PRIMARY KEY DEFAULT nextval('id_machine')," +
                        "tipo_driver varchar(255), PathFile text,  ExeFile text, OnceType text);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 26 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE machine ADD name varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 27 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti_seq ADD date_seq timestamp;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 28 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti_seq ADD size varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 29 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti ADD idlistino int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 30 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE history ADD id_formula int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 31 && _currentDBVersion <= maxUpdateVersion)
                {
                    //update history.dateofrmula type
                    string sql = "ALTER TABLE machine ADD CONSTRAINT name_unique UNIQUE (name);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 32 && _currentDBVersion <= maxUpdateVersion)
                {
                    //update history.dateofrmula type
                    string sql = "ALTER TABLE formule ADD hvalue float8; ALTER TABLE formule ADD cvalue float8;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 33 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "DROP TABLE IF EXISTS clienti_seq;";
                    dbc.SQLExe(sql);
                    sql = "ALTER TABLE history ADD idcliente int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 34 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE history DROP COLUMN id_formula;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 35 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE settings ADD COLUMN value_data bytea;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 36 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE lattaggi ADD barcode varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 37 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE machine ADD tipo int4;";
                    sql += "UPDATE machine SET tipo = 0;UPDATE machine SET tipo = 1 WHERE tipo_driver LIKE 'Manual%';";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 38 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "UPDATE formule_personali AS f_per SET system = ( " +
                                    "SELECT system FROM ( " +
                                        "SELECT A.idp AS idp, B.system AS system " +
                                        "FROM formule_personali AS A " +
                                        "INNER JOIN " +
                                        "(select DISTINCT base, system from formule) AS B " +
                                        "ON A.base = B.base " +
                                    ") AS temp_id_system " +
                                    "WHERE temp_id_system.idp = f_per.idp " +
                                ");";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 39 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti ADD tipo int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 40 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti ADD COLUMN city varchar(255), ADD COLUMN cap varchar(255), ADD COLUMN country varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 41 && _currentDBVersion <= maxUpdateVersion)
                {
                    StreamReader streamReader = new StreamReader(System.Windows.Forms.Application.StartupPath + "/include/regioni.sql");
                    string sql = streamReader.ReadToEnd();
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 42 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE machine ADD COLUMN machine_type int4;";
                    dbc.SQLExe(sql);

                    #region set value for machine_type
                    sql = "";
                    NpgsqlDataReader dr = null;
                    dbc.sqlview("SELECT * FROM machine;", ref dr);
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["id_machine"]);
                        string sql_temp = "UPDATE machine SET machine_type = ";
                        switch (dr["tipo_driver"].ToString())
                        {
                            case "Hero standard driver": { sql_temp += ((int)Library.Data.Machine.eMacchina.Auto_Hero).ToString(); break; }
                            case "Edel Painter Driver": { sql_temp += ((int)Library.Data.Machine.eMacchina.Auto_Edel).ToString(); break; }
                            case "Corob FLINK standard": { sql_temp += ((int)Library.Data.Machine.eMacchina.Auto_Corob).ToString(); break; }
                            case "Tecmec Driver 4": { sql_temp += ((int)Library.Data.Machine.eMacchina.Auto_Tecmec).ToString(); break; }
                            case "Santint Driver": { sql_temp += ((int)Library.Data.Machine.eMacchina.Auto_Santint).ToString(); break; }
                            case "Fast & Fluid PPD": { sql_temp += ((int)Library.Data.Machine.eMacchina.Auto_FastFluid).ToString(); break; }
                            case "Manual Y - 1/48 - 1/192": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_48_192).ToString(); break; }
                            case "Manual Y - 1/48 - 1/384": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_48_384).ToString(); break; }
                            case "Manual Y - 1/96 - 1/192": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_96_192).ToString(); break; }
                            case "Manual Y - 1/96 - 1/384": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_96_384).ToString(); break; }
                            case "Manual Y - 1/48": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_48).ToString(); break; }
                            case "Manual Y - 1/96": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_96).ToString(); break; }
                            case "Manual Y - 1/192": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_192).ToString(); break; }
                            case "Manual Y - 1/48 - drops8": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_48_drops8).ToString(); break; }
                            case "Manual Y - 1/96 - drops8": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_96_drops8).ToString(); break; }
                            case "Manual Y - 1/48 - drops4": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_48_drops4).ToString(); break; }
                            case "Manual Y - 1/96 - drops4": { sql_temp += ((int)Library.Data.Machine.eMacchina.Manual_Y_96_drops4).ToString(); break; }
                            default: { sql_temp = ""; break; }
                        }
                        if (sql_temp != "")
                        {
                            sql_temp += " WHERE id_machine = " + id.ToString() + ";";
                            sql += sql_temp;
                        }
                    }
                    dr.Close();
                    if (sql != "")
                    {
                        dbc.SQLExe(sql);
                    }
                    #endregion

                    dbc.SQLExe("ALTER TABLE machine DROP COLUMN tipo_driver;");

                    dbc.SQLExe(queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 43 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti ADD COLUMN barcode varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 44 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE history ADD COLUMN riempimento float8;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 45 && _currentDBVersion <= maxUpdateVersion)
                {
                    //nothing
                    dbc.SQLExe(queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 46 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE formule ADD COLUMN ciel_cubecc float8, ADD COLUMN ciea_cubecc float8, ADD COLUMN cieb_cubecc float8;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 47 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "";
                    NpgsqlDataReader drBarcode = null;
                    dbc.sqlview("SELECT EXISTS(SELECT column_name FROM information_schema.columns WHERE table_name='clienti' and column_name='barcode');", ref drBarcode);
                    if (drBarcode.Read())
                    {
                        if (drBarcode["exists"].ToString().ToUpper().Trim() == "FALSE")
                        {
                            sql = "ALTER TABLE clienti ADD COLUMN barcode varchar(255);";
                        }
                    }
                    if (drBarcode != null) { drBarcode.Close(); }

                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 48 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "CREATE TABLE IF NOT EXISTS fcpig (basi varchar(255), coloranti varchar(255), fcor float8);";

                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 49 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE base ADD COLUMN deletable int4; UPDATE base SET deletable = 0;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 50 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti ADD COLUMN idcloud int4, ADD COLUMN deleted int4, ADD COLUMN lastupdate varchar(255), ADD COLUMN servertimesync int4;" +
                        " UPDATE clienti SET servertimesync = 0; UPDATE clienti SET deleted = 0;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 51 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE base DROP COLUMN barcode;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 52 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE settings ALTER COLUMN value TYPE text; ALTER TABLE history ADD COLUMN idcloudcliente int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 53 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE base ADD barcode varchar(255);";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 54 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "ALTER TABLE clienti ADD codef4 int4;";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 55 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "CREATE TABLE formule_prev (id int4 NOT NULL PRIMARY KEY, de float8, nw varchar(10), " +
                        "dateformula date, notetxt text, colorname varchar(255), base varchar(255), unit varchar(50), " +
                        "oncetype varchar(50), formulasize varchar(50), p1 varchar(255), q1 float8, p2 varchar(255), q2 float8, p3 varchar(255), " +
                        "q3 float8, p4 varchar(255), q4 float8, p5 varchar(255), q5 float8, colorcharts varchar(255), system varchar(255), " +
                        "use varchar(255), r int4, g int4, b int4, ciel float8, ciea float8, cieb float8); ";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 56 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "CREATE SEQUENCE ordine_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " + "CREATE TABLE IF NOT EXISTS ordine (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('ordine_id_seq'), fkemail int4 NOT NULL, executed int4 NOT NULL, ciel float8 NOT NULL, ciea float8 NOT NULL, cieb float8 NOT NULL, destinazione VARCHAR(255), colorname varchar(255), colorchart varchar(255),  system varchar(255), use varchar(255), codcard varchar(255));";
                    sql += "CREATE SEQUENCE email_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1; " + "CREATE TABLE IF NOT EXISTS email (id int4 NOT NULL PRIMARY KEY DEFAULT nextval('email_id_seq'), mittente varchar(255) NOT NULL, data timestamp NOT NULL, oggetto varchar(255), corpo text);";
                    
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
                if (_currentDBVersion == 57 && _currentDBVersion <= maxUpdateVersion)
                {
                    string sql = "SELECT setval('id_lattaggi', (SELECT MAX(id_lattaggi) FROM lattaggi));";
                    dbc.SQLExe(sql + queryUpdateVersion);
                    _currentDBVersion++;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            try { if (dbc != null) dbc.disconnect(); }
            catch (Exception) { }
        }

        public static int VersioneDB
        {
            get { return _currentDBVersion; }
        }

        public static void DropDatabase(string sDBRealName)
        {
            DBConnector db = new DBConnector("postgres");
            db.SQLQuery_AffectedRows("drop database " + sDBRealName);
            db.CloseConnection();
        }
    }
}
