using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library
{
    class Language
    {
        private static Language lingua = null;
        private static Dictionary<string, string> dicLingue = new Dictionary<string, string>();
        private IniFileUnicode langFile = null;
        private string codLingua = null;

        private Language()
        {
            string path = System.Windows.Forms.Application.StartupPath + "/include/language.ini";
            bool bPresente = true;
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.Create(path);
                bPresente = false;
            }
            langFile = new IniFileUnicode(System.Windows.Forms.Application.StartupPath + "/include/language.ini");

            //lista lnigue
            string[] vLingue = langFile.Read("LINGUE", "elenco_lingue").Split(';');
            foreach (string keyLang in vLingue)
            {
                string valueLang = langFile.Read("LINGUE", keyLang);
                if (!dicLingue.ContainsKey(keyLang))
                {
                    dicLingue.Add(keyLang, valueLang);
                }
                else
                {
                    dicLingue[keyLang] = valueLang;
                }
            }
            //
            if (!bPresente)
            {
                langFile.Write("DEFAULT", "linguapredefinita", "en");
            }
            codLingua = langFile.Read("DEFAULT", "linguapredefinita");
        }

        public static string CodLinguaFromIniFile()
        {
            IniFileUnicode langFile = new IniFileUnicode(System.Windows.Forms.Application.StartupPath + "/include/language.ini");
            return langFile.Read("DEFAULT", "linguapredefinita");
        }

        public static Language GetInstance()
        {
            if (lingua == null)
            {
                lingua = new Language();
            }
            return lingua;
        }

        public string GetWord(string code)
        {
            string defaultWord = GetDefault(code);
            try
            {
                string[] tokens = langFile.Read(this.codLingua, code).Split('\t');
                string word = tokens[0];
                if (word != "") return word;
                langFile.Write(this.codLingua, code, defaultWord + "\t" + "   //auto-generated");
                return defaultWord;
            }
            catch (Exception)
            {
                return defaultWord;
            }
        }

        private static string GetDefault(string code)
        {
            if (data.ContainsKey(code))
                return data[code];
            return "";
        }

        public void SetLanguage(string codLingua)
        {
            this.codLingua = codLingua;
        }

        public string GetCodeLanguage() { return codLingua; }

        public Dictionary<string, string> AllLanguages
        {
            get { return dicLingue; }
        }

        public Dictionary<string, string> AllSmartLanguages
        {
            get
            {
                Dictionary<string, string> dicLanguagesSmart = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in dicLingue)
                {
                    if (pair.Key == "ru" || pair.Key == "sr" || pair.Key == "al" || pair.Key == "en")
                    {
                        dicLanguagesSmart.Add(pair.Key, pair.Value);
                    }
                }
                return dicLanguagesSmart;
            }
        }

        public void GenerateAllLanguages()
        {
            string prevLang = this.codLingua;

            foreach (KeyValuePair<string, string> pair in dicLingue)
            {
                this.codLingua = pair.Key;
                foreach (KeyValuePair<string, string> pairData in data)
                {
                    GetWord(pairData.Key);
                }
            }

            this.codLingua = prevLang;
        }

        public static string GetCountryCode()
        {
            IniFileUnicode langFile = new IniFileUnicode(System.Windows.Forms.Application.StartupPath + "/include/language.ini");
            try
            {
                switch (langFile.Read("DEFAULT", "linguapredefinita"))
                {
                    case "en": { return "GB"; }
                    case "it": { return "IT"; }
                    case "cn": { return "CN"; }
                    case "cz": { return "CZ"; }
                    case "ru": { return "RU"; }
                    case "pl": { return "PL"; }
                    case "es": { return "ES"; }
                    case "sr": { return "RS"; }
                    case "de": { return "DE"; }
                    case "al": { return "AL"; }
                    default: { return ""; }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static Dictionary<string, string> data = new Dictionary<string, string>()
        {
            //Program.cs
            {"program01", "Load error: database"},
            {"program02", "does not exists"},
            {"program03", "Another instance is currently running. Close EuroFormulations process first"},
            {"program04", "Your License Key is going to expire"},
            {"program05", "days left"},
            {"program06", "Upgrade to Unlimited version"},
            {"program07", "Please contact our customer service at 0429899420 or send an email to euroformulations@eurocolori.com or info@eurocolori.com"},
          

            //frmEuroFormulationsNew
            {"main01" , "EuroFormulations 4"},
            {"main02", "License Key not set"},
            {"main03", "Bad Hash"},
            {"main04", "Hard Disk ID is different"},
            {"main05", "System Date/Time corrupted"},
            {"main06", "Expired Trial License"},
            {"main07", "Cloud send error"},
            {"main08","Internet connection is not available"},
            {"main09", "Config save error"},
            {"main10", "Updates Confirm"},
            {"main11", "Do you want to close your Euroformulation and install updates now?"},
            {"main12", "Software updates available. Click Here to install"},
            {"main13", "Activation file given is only for EuroFormulations 3 upgraded systems"},
            {"main14", "Your EuroFormulations4 has been updated with the latest version"},
            {"main15", "A new verion has been downloaded and is available. You must install this newer version in order to continue. Would you like to do this now?"},
            {"main16", "New updates available. Would you like to download now?"},

            //Menu
            {"menu01", "Formulation"},
            {"menu02", "Personal Formula"},
            {"menu03", "Insert New Formula"},
            {"menu04", "View Personal Formulas"},
            {"menu05", "MyQuality"},
            {"menu06", "Quality Control"},
            {"menu07", "MySearch"},
            {"menu08", "Color Search"},
            {"menu09", "Customer"},
            {"menu10", "New Customer"},
            {"menu11", "View Customers"},
            {"menu12", "Statistics"},
            {"menu13", "Prices"},
            {"menu14", "New Price List"},
            {"menu15", "Colorants/Paints"},
            {"menu16", "Packaging Size"},
            {"menu17", "Settings"},
            {"menu18", "General"},
            {"menu19", "License"},
            {"menu20", "Calibration"},
            {"menu21", "Remote Assistance"},
            {"menu22", "Classic Selection"},
            {"menu23", "Search Selection"},
            {"menu24", "History Selection"},
            {"menu25", "Insert/Edit formula"},
            {"menu26", "Insert/Edit customer"},
            {"menu27", "Formula selection"},
            {"menu28", "Database"},

            {"menu_deactivated", "Deactivated Function"},
            {"Formulation_menu", "Formulation Menu"},
            {"Personal Formula_menu", "Personal Formula Menu"},
            {"Insert New Formula_menu", "New Formula Menu"},
            {"View Personal Formulas_menu", "View Formula Menu"},
            {"MyQuality_menu", "Quality Control Menu"},
            {"Quality Control_menu", "Quality Control Menu"},
            {"MySearch_menu", "Search Menu"},
            {"Color Search_menu", "Color Search Menu"},
            {"Customer_menu", "Clients Management Menu"},
            {"New Customer_menu", "New Client Menu"},
            {"View Customers_menu", "View Client"},
            {"Statistics_menu", "Statistics Menu"},
            {"Prices_menu", "Cost"},
            {"New Price List_menu", "Price List"},
            {"Colorants/Paints_menu", "Colorant Cost"},
            {"Packaging Size_menu", "Packaging Size"},
            {"Settings_menu", "Settings"},
            {"General_menu", "General Settings Menu"},
            {"License_menu", "Euroformulation License"},
            {"Calibration_menu", "Calibration Menu"},
            {"Remote Assistance_menu", "Remote Assistance"},
            {"data_loading", "Data loading. Please retry later"},
            {"data_not_found", "Data not found"},
            {"devices_menu", "Devices menu"},
            {"machines_menu", "Dispensers menu"},
            {"database_menu", "Database menu"},

            //library:database
            {"dblib01", "database connection error:"},
            {"dblib02", "database disconnection error:"},
            {"dblib03", "database query error:"},
            {"dblib04", "DataBase version not found. Try again later"},
            {"dblib05", "Selected database is not valid for this zip file. Change selection"},
            {"dblib06", "Zip file given is not valid"},
            
            //library:spettro
            {"spettro01", "Color reading timeout. Check if your devide is connected"},
            {"spettro02", "Calibration timeout. Check if your devide is connected"},
            
            //subwindow: color search
            {"search01", "Color Search"},
            {"search02",  "Search"},
            {"search03","Color reference"},
            {"search04", "Filters"},
            {"search05", "General"},
            {"search06", "Products"},
            {"search07", "All Products"},
            {"search08", "Use"},
            {"search09", "DE Selection"},
            {"search10", "Row Result"},
            {"search11", "Internal"},
            {"search12", "External"},
            {"search13", "DE Standard"},
            {"search14", "DE CIE2000"},
            {"search15", "Max Row Result"},
            {"search16", "Similar Colors"},
            {"search17", "N."},
            {"search18", "Color"},
            {"search19", "DE*"},
            {"search20", "Product"},
            {"search21", "Fandeck"},
            {"search22", "Shade"},
            {"search23", "Menu Manager for color search not set"},
            {"search24", "Read Color First!"},
            {"search25", "Insert valid row number"},
            {"search26", "Select Product"},
            {"search27", "Calibration Confirm"},
            {"search28", "Select at least one between internal/esternal usage"},
            {"search29", "CIEDE2000"},
            {"search30", "Colorcharts"},
            {"search31", "All Colorcharts"},
            {"search32", "Input type"},
            {"search33", "Color not entirely reproducible with the system in use"},
            {"search34", "Device"},
            {"search35", "Select a valid device"},
            {"search36", "Colorant price per liter"},
            {"search37", "Select all"},
            {"search38", "Unselect all"},

            //subwindow: license
            {"lic01", "PRODUCT LICENSE"},
            {"lic02", "Your EuroFormulation has not been activated yet."},
            {"lic03", "Please visit"},
            {"lic04", "www.euroformulations.com/MyLicense"},
            {"lic05", "and type the following Installation Code:"},
            {"lic06", "Download your License file, close this program and double-click to your .eflic file"},
            {"lic07", "Identification"},
            {"lic08", "Installation code"},
            {"lic09", "Version"},
            {"lic10", "Activation date"},
            {"lic11", "Type"},
            {"lic12", "MyLicense area"},
            {"Unlimited", "Unlimited"},
            {"DEMO", "DEMO"},
            {"days_left", "days left"},
            {"lic_expired", "Your Euroformulation Key has been expired."},
            {"lic13", "Upgraded"},

            //subwindow: impostazioni generali
            {"settings01", "General settings"},
            {"settings02", "Machine"},
            {"settings03", "Barcode"},
            {"settings04", "Window"},
            {"settings05", "Automatic save window size and location?"},
            {"settings06", "Formula"},
            {"settings07", "Formula decimal digits"},
            {"settings08", "Hystory Formula numbers"},
            {"settings09", "Save Program Settings"},
            {"settings10", "Select dispenser type"},
            {"settings11", "File path of the formula"},
            {"settings12", "Identification"},
            {"settings13", "Path to the driver"},
            {"settings14", "Auto configure Driver"},
            {"settings15", "Delete machine"},
            {"settings16", "Save dispenser"},
            {"settings17", "Identification"},
            {"settings18", "Dispenser"},
            {"settings19", "Formula path"},
            {"settings20", "Driver path"},
            {"settings21", "Active control on the bases paints"},
            {"settings22", "Base cost"},
            {"settings23", "Base name"},
            {"settings24", "Barcode"},
            {"settings25", "Save settings"},
            {"settings26", "Data saved. For correct usage it's raccomanded to restart your Euroformulation"},
            {"settings27", "Driver registered"},
            {"settings28", "Driver"},
            {"settings29", "registered in the system"},
            {"settings30", "Update driver"},
            {"settings31", "Internal table error (machine)"},
            {"settings32", "Driver error"},
            {"settings33", "deleted from the system"},
            {"settings34", "Driver deleted"},
            {"settings35", "Data error"},
            {"settings36", "TintWise_POS not found"},
            {"settings37", "Database"},
            {"settings38", "Import"},
            {"settings39", "Load your database by clicking the following button"},
            {"settings40", "Options"},
            {"settings41", "Erase personal data"},
            {"settings42", "Don't close EuroFormulations while database import is running..."},
            {"settings43", "Import confirm"},
            {"settings44", "Do you confirm you want to proceed?"},
            {"settings45", "Data saved. Your Euroformulation will restart now"},
            {"settings46", "Languages"},
            {"settings47", "Select your system language"},
            {"settings48", "Price List"},
            {"settings49", "Select your default price list"},
            {"settings50", "Import / Export"},
            {"settings51", "Machine name duplicated.This is not possible."},
            {"settings52", "Template folder"},
            {"settings53", "Missing machine identification"},
            {"settings54", "Missing ounce type"},
            {"settings55", "Missing machine type"},
            {"settings56", "Ounce type"},
            {"settings57", "Devices"},
            {"settings58", "Default device"},
            {"settings59", "Device details"},
            {"settings60", "Bookmarks"},
            {"settings61", "Dispensers"},
            {"settings62", "Single reading"},
            {"settings63", "Multiple reading"},
            {"settings64", "Reading method"},
            {"settings65", "New Database"},
            {"settings66", "Select database destination"},
            {"settings67", "Insert database name"},
            {"settings68", "Database selection"},
            {"settings69", "Destination"},
            {"settings70", "Name"},
            {"settings71", "Select a valid database to delete"},
            {"settings72", "You can't delete database in use. Select another database"},
            {"settings73", "Delete database"},
            {"settings74", "Are you sure? This will delete selected database"},
            {"settings75", "Main window resizable"},
            {"settings76", "Do you want to erase all data?"},
            {"settings77", "Current price lists will be replaced by price lists into zip file"},
            {"settings78", "Current database"},
            {"settings79", "Selection"},
            {"settings80", "Confirm"},
            {"settings81", "Modify"},
            {"settings82", "Delete"},
            {"settings83", "Import"},
            {"settings84", "New database"},
            {"settings85", "Name"},
            {"settings86", "Import dispensers"},
            {"settings87", "Export dispensers"},
            {"settings88", "Template"},
            {"settings89", "Delta warning"},
            {"settings90", "Administrator password"},
            {"settings91", "Wrong password"},
            {"settings92", "Dispensing queue"},
            {"settings93", "Formula warning"},
            {"settings94", "Formula edit"},
            {"settings95", "Default in ounce"},
            {"settings96", "Select one row"},
            {"settings97", "This product is not deletable"},
            {"settings98", "Driver"},
            {"settings99", "Driver installer folder"},

            //subwindow: calibra strumento
            {"calibra01", "White calibration"},
            {"calibra02", "Black calibration"},
            {"calibra03", "Device calibration"},

            //subwindow: database import
            {"db01", "Import is currently running"},
            {"db02", "WELCOME TO EUROFORMULATIONS 4"},
            {"db03", "DATABASE IMPORT"},
            {"db04", "1. Download your personal database at"},
            {"db05", "www.euroformulations.com/MyLicense"},
            {"db06", "2. Load your database by clicking the following button"},
            {"db07", "Database file does not exists anymore. Reopen Database file."},
            {"db08", "Select valid EuroFormulation database"},
            {"db09", "database import version"},
            {"db10", "is incompatible with the version of this program"},
            {"db11", "DataBase load completed"},
            {"db12", "Select your database file"},
            {"db13", "Zip files"},
            {"db14", "All files"},
            {"db15", "Incompatible database. Do you confirm to completely destroy selected database?"},

            //subwindow: clienti
            {"customer01", "New Customer"},
            {"customer02", "Name"},
            {"customer03", "Surname"},
            {"customer04", "Company name"},
            {"customer05", "Address"},
            {"customer06", "Phone 1"},
            {"customer07", "Phone 2"},
            {"customer08", "Fax"},
            {"customer09", "E-Mail"},
            {"customer10", "VAT Number"},
            {"customer11", "Personal notes"},
            {"customer12", "The marked * are required"},
            {"customer13", "Save"},
            {"customer14", "New customer"},
            {"customer15", "New customer saved successfully"},
            {"customer16", "Edit customer"},
            {"customer17", "Customer updated successfully"},
            {"customer18", "Incorrect fields or fields missing"},
            {"customer19", "Customer details"},
            {"customer20", "View Customers"},
            {"customer21", "Filter by"},
            {"customer22", "Use '%' for all characters"},
            {"customer23", "Name"},
            {"customer24", "Surname"},
            {"customer25", "Company"},
            {"customer26", "Vat"},
            {"customer27", "E-Mail"},
            {"customer28", "History"},
            {"customer29", "Personal formulations"},
            {"customer30", "Price list"},
            {"customer31", "Preview"},
            {"customer32", "Date"},
            {"customer33", "Color"},
            {"customer34", "Size"},
            {"customer35", "Product"},
            {"customer36", "Colorcharts"},
            {"customer37", "Use"},
            {"customer38", "Delete customer"},
            {"customer39", "Are you sure you want to delete"},
            {"customer40", "Delete error:"},
            {"customer41", "Filter Error:"},
            {"customer42", "Double click to dispense"},
            {"customer43", "Related to..."},
            {"customer44", "History"},
            {"customer45", "Personal formulations"},
            {"customer46", "Edit customer"},
            {"customer47", "Delete customer"},
            {"customer48", "New customer"},
            {"customer49", "Type"},
            {"customer50", "Contacts"},
            {"customer51", "General"},
            {"customer52", "Private"},
            {"customer53", "Select customer type"},
            {"customer54", "Customer code"},
            {"customer55", "City"},
            {"customer56", "Cap"},
            {"customer57", "Country"},
            {"customer58", "CUSTOMERS LIST"},

            //subwindow: quality control
            {"quality01", "Standard Color"},
            {"quality02", "Read Standard"},
            {"quality19", "Sample Color"},
            {"quality20", "Read Sample"},
            {"quality21", "Illuminant: D65/10°"},
            {"quality22", "Color Differences"},
            {"quality23", "Standard Color"},
            {"quality24", "Sample Color"},
            {"quality31", "lighter"},
            {"quality32", "Darker"},
            {"quality33", "Redder"},
            {"quality34", "Greener"},
            {"quality35", "Yellower"},
            {"quality36", "Bluer"},
            {"quality37", "LOAD COLOR"},
            {"quality38", "SAVE COLOR"},
            {"quality39", "New Color"},
            {"quality40", "Saved Colors"},
            {"quality41", "Color Name"},
            {"quality42", "Search"},
            {"quality43", "Expand all"},
            {"quality44", "Collapse all"},
            {"quality45", "Selected Color"},
            {"quality46", "You must select one color"},
            {"quality47", "Color not set"},
            {"quality48", "Select one color folder"},
            {"quality49", "Save color"},
            {"quality50", "Insert Color Name"},
            {"quality51", "Save operation aborted"},
            {"quality52", "Max 2 levels allowed"},
            {"quality53", "Selected node must be one folder"},
            {"quality54", "New Folder"},
            {"quality55", "Insert Folder Name"},
            {"quality56", "New Folder aborted"},
            {"quality57", "Select one folder"},
            {"quality58", "Select one color"},
            {"quality59", "Are you sure you want to remove selected folder and all of it's colors?"},
            {"quality60", "Are you sure you want to remove selected color?"},
            {"quality61", "Delete Confirm"},
            {"quality62", "Error during delete operation"},
            {"quality63", "Print"},
            {"quality64", "Quality control analisys"},
            {"quality65", "Measured Values"},
            {"quality66", "Tolerances and differences"},
            {"quality67", "Standard and sample colors must be saved"},
            {"quality68", "Color type"},
            {"quality69", "Standard"},
            {"quality70", "Sample"},
            {"quality71", "Standard color must be saved"},
            {"quality72", "Sample color must be saved"},
            {"quality73", "Backup"},
            {"quality74", "Restore"},
            {"quality75", "Export successfully completed"},
            {"quality76", "Restore confirmation"},
            {"quality77", "Are you sure you want to restore selected quality controls? Previous data will be deleted"},
            {"quality78", "Quality controls successfully restored"},
            {"quality79", "Errors found while restoring. Replaced previous controls"},
            {"quality80", "Error during data import:"},
            //

            //subwindow:costi
            {"cost01", "Select price list"},
            {"cost02", "Colorant cost"},
            {"cost03", "Base cost"},
            {"cost04", "Colorant name"},
            {"cost05", "Price"},
            {"cost06", "Unit"},
            {"cost07", "Base name"},
            {"cost08", "1 - Select price list"},
            {"cost09", "2 - Select base paint"},
            {"cost10", "3 - Packaging size"},
            {"cost11", "Add"},
            {"cost12", "Delete"},
            {"cost13", "Base paint name"},
            {"cost14", "Packaging"},
            {"cost15", "Fill (1 = 100%)"},
            {"cost16", "Invalid value: it must be between 0 and 1 (0 = 0 %  ,  1 = 100 %)"},
            {"cost17", "Delete packaging size"},
            {"cost18", "Are you sure you delete"},
            {"cost19", "Error while deleting record:"},
            {"cost20", "Insert new price list"},
            {"cost21", "Price list name"},
            {"cost22", "Currency"},
            {"cost23", "Save price list"},
            {"cost24", "Price list created"},
            {"cost25", "Remove price list"},
            {"cost26", "Pricelist"},
            {"cost27", "inserted correctly."},
            {"cost28", "Error price list"},
            {"cost29", "Error while insert price list."},
            {"cost30", "Delete price list"},
            {"cost31", "Update price list"},
            {"cost32", "Price list updated"},
            {"cost33", "Right-click for list the function" },
            {"cost34", "Rename Price List" },
            {"cost35", "Export to Excel" },
            {"cost36", "Import from Excel" },
            {"cost37", "Barcode" },
            {"cost38", "Right click for more options" },
            {"cost39", "Create at least one price list before adding the package" },

            //subwindow: statistiche
            {"stat01", "Print"},
            {"stat02", "Colorants"},
            {"stat03", "Bases"},
            {"stat04", "Colors space"},
            {"stat05", "View graph"},
            {"stat06", "Base Paints"},
            {"stat07", "Color Charts"},
            {"stat08", "Use"},
            {"stat09", "From"},
            {"stat10", "To"},
            {"stat11", ". . PROCESSING . . PLEASE WAIT . ."},
            {"stat12", "Colorant name"},
            {"stat13", "Use ( % )"},
            {"stat14", "Quantity"},
            {"stat15", "Product"},
            {"stat16", "Base name"},
            {"stat17", "ALL BASE PAINTS"},
            {"stat18", "ALL PRODUCTS"},
            {"stat19", "ALL COLORCHARTS"},
            {"stat20", "ALL USE"},

            //subwindow: formule personali
            {"fper01", "Insert New Formula"},
            {"fper02", "Color name"},
            {"fper03", "Created by"},
            {"fper04", "Directory"},
            {"fper05", "Personal notes"},
            {"fper06", "Base paint quantity"},
            {"fper07", "Colorant quantity"},
            {"fper08", "ml"},
            {"fper09", "Colorant 1"},
            {"fper10", "Colorant 2"},
            {"fper11", "Colorant 3"},
            {"fper12", "Colorant 4"},
            {"fper13", "Colorant 5"},
            {"fper14", "The marked * are required"},
            {"fper15", "Get color by selection"},
            {"fper16", "Get color by device reading"},
            {"fper17", "Choose related customer"},
            {"fper18", "Personal formula"},
            {"fper19", "Personal formula inserted. Related to"},
            {"fper20", "Error in table \"clienti_seq\""},
            {"fper21", "Personal formula inserted"},
            {"fper22", "Incorrect formula or field is not filled"},
            {"fper23", "Edit Formula"},
            {"fper24", "View Personal Formulas"},
            {"fper25", "Filter by"},
            {"fper26", "( Use '%'  for all characters )"},
            {"fper27", "Preview"},
            {"fper28", "Data"},
            {"fper29", "Color name"},
            {"fper30", "Base"},
            {"fper31", "Customers"},
            {"fper32", "Created by"},
            {"fper33", "Directory"},
            {"fper34", "Delete personal formulations"},
            {"fper35", "Are you sure you want to delete"},
            {"fper36", "Error while deleting record:"},
            {"fper37", "Filter Error:"},
            {"fper38", "ALL FIELDS"},
            {"fper39", "Basic Information"},
            {"fper40", "Color value"},
            {"fper41", "Quantity"},
            {"fper42", "Dispense total"},
            {"fper43", "Base paint"},
            {"fper44", "Colorants / Base paint"},
            {"fper45", "Dispense add"},
            {"fper46", "Base Quantity"},
            {"fper47", "Colorant um"},
            {"fper48", "Current"},
            {"fper49", "Add"},
            {"fper50", "Dispenser"},
            {"fper51", "Dispense"},
            {"fper52", "Dispense add"},
            {"fper53", "Invalid data"},
            {"fper54", "There is nothing to dispense (empty quantity)"},
            {"fper55", "Select the tinting machine"},
            {"fper56", "Formula sent to the tinting machine"},
            {"fper57", "Customer"},
            {"fper58", "Dispense confirmation"},
            {"fper59", "Do you confirm to dispense add colorants only?"},
            {"fper60", "Do you confirm to dispense current formula colorants?"},
            {"fper61", "Quality control"},
            {"fper62", "Personal formula updated"},
            {"fper63", "Select use"},
            {"fper64", "Edit personal formula"},
            {"fper65", "Delete personal formula"},
            {"fper66", "Colorants"},
            {"fper67", "Base paint"},
            {"fper68", "Prices"},
            {"fper69", "Total price"},
            {"fper70", "Base name"},
            {"fper71", "Unit"},
            {"fper72", "Colorants unit"},
            {"fper73", "Use"},
            {"fper74", "Select"},
            {"fper75", "Read"},
            {"fper76", "New"},

            //subwindow: formulazione
            {"formula01", "Select the product"},
            {"formula02", "View formula"},
            {"formula03", "Classic selection"},
            {"formula04", "Search color"},
            {"formula05", "History"},
            {"formula06", "Select the product"},
            {"formula07", "Select the colorcharts"},
            {"formula08", "Select the use"},
            {"formula09", "Search color code"},
            {"formula10", "Search"},
            {"formula11", "Preview"},
            {"formula12", "Color"},
            {"formula13", "Product"},
            {"formula14", "Colorchart"},
            {"formula15", "Use"},
            {"formula16", "Formula history"},
            {"formula17", "Date"},
            {"formula18", "Size"},
            {"formula19", "Name"},
            {"formula20", "Color Information"},
            {"formula21", "Color Name/Preview"},
            {"formula22", "Selected details"},
            {"formula23", "Colocharts :"},
            {"formula24", "Use :"},
            {"formula25", "Select the price list"},
            {"formula26", "Colorant"},
            {"formula27", "Gr."},
            {"formula28", "Ml."},
            {"formula29", "Ounce"},
            {"formula30", "Cost"},
            {"formula31", "Print"},
            {"formula32", "Dispense"},
            {"formula33", "Dispenser selection"},
            {"formula34", "Missing or incorrect units of measurement. Please enter 'L' or 'KG'"},
            {"formula35", "Formula sent"},
            {"formula36", "Formula sent to the tinting machine"},
            {"formula37", "Please insert the value"},
            {"formula38", "Insert the correct base"},
            {"formula39", "Main Formula"},
            {"formula40", "Internal table error \"clienti_seq\""},
            {"formula41", "NOTES:"},
            {"formula42", "WARNING: this formula is not resistant for exterior"},
            {"formula43", "Base cost"},
            {"formula44", "Colorant cost"},
            {"formula45", "Total cost"},
            {"formula46", "Barcode"},
            {"formula47", "Scan with barcode"},
            {"formula48", "BASE PAINT :"},
            {"formula49", "COLORANT 1 :"},
            {"formula50", "COLORANT 2 :"},
            {"formula51", "COLORANT 3 :"},
            {"formula52", "COLORANT 4 :"},
            {"formula53", "COLORANT 5 :"},
            {"formula54", "TOTAL :"},
            {"formula55", "Edit formula"},
            {"formula56", "Select template"},
            {"formula57", "Template selection"},
            {"formula58", "Template not found"},
            {"formula59", "Select the correct tinting machine"},
            {"formula60", "Product :"},
            {"formula61", "Color harmonies"},
            {"formula62", "Harmonic colors"},
            {"formula63", "You need to create at least one price list to dispense"},
            {"formula64", "Warning"},
            {"formula65", "Dispensing"},
            {"formula66", "Fill level %"},
            {"formula67", "Dispensing numbers"},
            {"formula68", "Press Ok to dispense next"},
            {"formula69", "You must select a valid manual machine"},
            {"formula70", "Grams"},
            {"formula71", "Milliliters"},

            //formula prev
            {"formulaprev01", "Previous formula"},
            {"formulaprev02", "Select formula date"},
            {"formulaprev03", "Confirm"},

            //email
            {"email01", "sender"},
            {"email02", "date"},
            {"email03", "state"},
            {"email04", "intended use"},
            {"email05", "preview"},
            {"email06", "subject"},
            {"email07", "body"},
            {"email08", "details"},
            {"email09", "mark as dispensed"},
            {"email10", "delete email"},

            //subwindow:colori complementari
            {"complementary01", "Complementary colors"},
            {"complementary02", "1 - Select the product"},
            {"complementary03", "2 - Select the use"},
            {"complementary04", "3 - Select harmonic color"},

            //subwindow:importExportMachine
            {"mac01", "Import / Export dispenser"},
            {"mac02", "Select one function"},
            {"mac03", "Import dispensers"},
            {"mac04", "Export dispensers"},
            {"mac05", "Comma-separated values"},
            {"mac06", "Select your machine file"},
            {"mac07", "Import completed with errors"},
            {"mac08", "Import successfully completed"},
            {"mac09", "Export Completed"},
            {"mac10", "There are no machine configurated"},
            {"mac11", "The system will delete all current machines. Do you want to proceed?"},
            {"mac12", "Import confirm"},

            //subwindow:copy
            {"copy01", "Copy price list"},
            {"copy02", "Price list source"},
            {"copy03", "Price list destination"},
            {"copy04", "with the following updates:"},
            {"copy05", "Colorants:"},
            {"copy06", "Base paint:"},
            {"copy07", "Copy price list"},
            {"copy08", "Price list copy"},
            {"copy09", "Copy successfully completed"},
            {"copy10", "Price list copy error:"},

            //new product
            {"newproduct01", "Formula management"},
            {"newproduct02", "New product"},
            {"newproduct03", "1 - Select a product"},
            {"newproduct04", "2 - Insert new product name"},
            {"newproduct05", "3 - update base name and type density"},
            {"newproduct06", "Base name"},
            {"newproduct07", "Density"},
            {"newproduct08", "Insert new product name"},
            {"newproduct09", "Select existing product"},
            {"newproduct10", "This product name alredy exists. Please type another product name"},
            {"newproduct11", "Data not valid at row"},
            {"newproduct12", "successfully inserted"},
            {"newproduct13", "alresy exists. Please type another base name"},
            {"newproduct14", "Example: 1 = 100%; 1.5 = +50%; 0.5 = -50%"},
            {"newproduct15", "1 - Double click to edit corrective factor"},
            {"newproduct16", "Product management"},

            //corrective factor
            {"fcor01", "Corrective factor"},
            {"fcor02", "1 - Select base paint"},
            {"fcor03", "2 - Select colorant"},
            {"fcor04", "Base name"},
            {"fcor05", "Colorant name"},
            {"fcor08", "Data alredy inserted"},
            {"fcor09", "3 - Press Add button and type corrective factor"},

            //common
            {"relatedTo", "Related To..."},
            {"allFieldsCombo", "ALL FIELDS"},
            {"copyright", "Copyright © Nuova EuroColori s.r.l."},
            {"infoMessage", "Information Message"},
            {"calibration_message", "You need to (re)calibrate your device first. Would you like to perform it now?"},
            {"confirm", "Confirm"},
            {"save", "Save"},
            {"error", "Error"},
            {"information","Information"},
            {"search", "Search"},
            {"printTable", "Print table"},
            {"filters", "Filters"},
            {"for", "for"},
            {"yes", "yes"},
            {"no", "no"},
            {"save_header", "Save confirmation"},
            {"save_message", "Would you like to save changes before exit?"},
            {"date", "date"},
            {"time", "time"},
            {"close", "close"},
            {"Variance", "Variance"},
            {"Enter", "Enter"},
            {"Password", "Password"},
            {"fullscreen", "full screen"},
            {"ok", "ok" },

            //welcome page
            {"welcome01", "Welcome to the Future"},
            {"welcome02", "Select a function from the left menu"},
            {"welcome03", "for informations write to euroformulations@eurocolori.com"},

            //dispositivi
            {"device01", "Spyder"},
            {"device02", "Select"},
            {"device03", "Color Catch 3"},
            {"device04", "Connect"},
            {"device05", "Color reader"},
            {"device06", "Read color"},
            {"device07", "i1Pro"},
            {"device08", "Connected"},
            {"device09", "Your device is not connected"},
            {"device10", "Cube"},
            {"device11", "Edit COM port:"},
            {"device12", "Connect i1Pro"},
            {"device13", "Current"},
            {"device14", "Average"},
            {"device15", "End"},
            {"device16", "SP62"},
            {"d50", "Illuminant D50"},
            {"d65", "Illuminant D65"},
            {"keyboard", "Keyboard"},
            {"spectro", "Spectro"},

            //demo
            {"demo01", "Your Euroformulations is running under demo license"},
            {"demo02", "Days left:"},
            {"demo03", "Please activate with the following License Key:"},
            {"demo04", "Do you need help?"},
            {"demo05", "ACTIVATE NOW"},
            {"demo06", "ACTIVATE LATER"},
            {"demo07", "Click here"},

            //help
            {"help01", "Double click to one row to dispense the formula"},
            {"help02", "Double click to one row to dispense the formula; Right click to edit or delete"},
            {"help03", "Right click to edit or delete"},
            {"help04", "Double click to select the customer; Right click to insert"},
            {"help05", "Left click to edit; Right click to delete"},

            //db import
            {"dbimport01", "Initializing..."},
            {"dbimport02", "Data transfer"},
            {"dbimport03", "finalizing database (this may take several minutes)..."},
            {"dbimport04", "Getting license information..."},

            //update
            {"update01", "Congratulations!"},
            {"update03", "See the latest news here below:"},
            {"update04", "Don't show this message again"},
            {"update05", "Continue"},

            //errors
            {"err01", "Preview timeout exceeded. Retry later"},
        };

    }
}
