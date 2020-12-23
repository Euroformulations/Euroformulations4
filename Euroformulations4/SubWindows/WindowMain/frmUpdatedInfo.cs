using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmUpdatedInfo : Form
    {
        private bool bDontShow = false;
        private string versione;
        private Library.Language lang = Library.Language.GetInstance();

        public frmUpdatedInfo(string versione)
        {
            InitializeComponent();
            this.versione = versione;
        }

        public bool DontShowAgain { get { return bDontShow; } }

        private void frmUpdatedInfo_Load(object sender, EventArgs e)
        {
            try
            {
                lbl01.Text = lang.GetWord("update01");
                lbl02.Text = lang.GetWord("main14");
                lbl03.Text = lang.GetWord("update03");
                chkDontShow.Text = lang.GetWord("update04");
                btnContinue.Text = lang.GetWord("update05");

                //traduzioni specializzate per aggiornamenti
                switch (lang.GetCodeLanguage())
                {
                    case "it":
                        {
                            ItalianUpdate();
                            break;
                        }
                    case "ru":
                        {
                            RussianUpdate();
                            break;
                        }
                    default:
                        {
                            EnglishUpdate();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region UPDATE TEXT
        private void ItalianUpdate()
        {
            switch (this.versione)
            {
                case "4.0.0.1": { break; }
                case "4.0.0.2": { break; }
                case "4.0.0.3": { break; }
                case "4.0.0.6": { break; }
                case "4.0.0.9": { break; }
                case "4.0.0.10": { break; }
                case "4.0.0.11": { break; }
                case "4.0.0.12": { break; }
                case "4.0.0.13": { break; }
                case "4.1.0.0": 
                    {
                        txtData.Text = "- impostazioni generali: aggiunta password di protezione impostazioni" + Environment.NewLine +
                            "- dettaglio lcienti: spostate qui le tab cronologia e formule personali" + Environment.NewLine +
                            "- MySearch: valori CIELab da tastiera" + Environment.NewLine +
                            "- edit formula in oncia: in base a tipo di macchina manuale scelta" + Environment.NewLine +
                            "- DEMO: utilizzo senza activation code" + Environment.NewLine +
                            "- impostazioni dispositivi: aggiunto XRite SP62" + Environment.NewLine +
                            "- aggiunta erogazione multipla";
                        break; 
                    }
                case "4.1.1.1": 
                    {
                        txtData.Text = "- impostazioni generali: aggiunta area Product Management (inserire o eliminare prodotti)" + Environment.NewLine +
                            "- impostazioni macchine: aggiunto tipo Dromont";
                        break; 
                    }
                case "4.1.1.2": 
                    {
                        txtData.Text = "- versione DEMO: aggiunta etichetta nella Home 'per informazioni scrivere a euroformulations@eurocolori.com'" + Environment.NewLine +
                            "- MySearch: sempre 10 risultati di ricerca;" + Environment.NewLine +
                            "- MySearch: rimossa selezione DE, usando sempre quello standard;" + Environment.NewLine +
                            "- MySearch: aggiunta selezione listino, che popola i costi sui risultati a partire dal costo standard colorante, costo standard base, quantità di base 1 Litro;" + Environment.NewLine +
                            "- MySearch: aggiunto pulsante per salvataggio tinta letta.";
                        break; 
                    }
                default: { break; }  //error no imfo available at the moment
            }
        }
        private void EnglishUpdate()
        {
            switch (this.versione)
            {
                case "4.0.0.1": { break; }
                case "4.0.0.2": { break; }
                case "4.0.0.3": { break; }
                case "4.0.0.6": { break; }
                case "4.0.0.9": { break; }
                case "4.0.0.10": { break; }
                case "4.0.0.11": { break; }
                case "4.0.0.12": { break; }
                case "4.0.0.13": { break; }
                case "4.1.0.0":
                    {
                        txtData.Text = "- impostazioni generali: aggiunta password di protezione impostazioni" + Environment.NewLine +
                            "- dettaglio lcienti: spostate qui le tab cronologia e formule personali" + Environment.NewLine +
                            "- MySearch: valori CIELab da tastiera" + Environment.NewLine +
                            "- edit formula in oncia: in base a tipo di macchina manuale scelta" + Environment.NewLine +
                            "- DEMO: utilizzo senza activation code" + Environment.NewLine +
                            "- impostazioni dispositivi: aggiunto XRite SP62" + Environment.NewLine +
                            "- aggiunta erogazione multipla";
                        break;
                    }
                case "4.1.1.1":
                    {
                        txtData.Text = "- impostazioni generali: aggiunta area Product Management (inserire o eliminare prodotti)" + Environment.NewLine +
                            "- impostazioni macchine: aggiunto tipo Dromont";
                        break;
                    }
                case "4.1.1.2":
                    {
                        txtData.Text = "- versione DEMO: aggiunta etichetta nella Home 'per informazioni scrivere a euroformulations@eurocolori.com'" + Environment.NewLine +
                            "- MySearch: sempre 10 risultati di ricerca;" + Environment.NewLine +
                            "- MySearch: rimossa selezione DE, usando sempre quello standard;" + Environment.NewLine +
                            "- MySearch: aggiunta selezione listino, che popola i costi sui risultati a partire dal costo standard colorante, costo standard base, quantità di base 1 Litro;" + Environment.NewLine +
                            "- MySearch: aggiunto pulsante per salvataggio tinta letta.";
                        break;
                    }
                default: { break; }  //error no imfo available at the moment
            }
        }
        private void RussianUpdate()
        {
            switch (this.versione)
            {
                case "4.0.0.1": { break; }
                case "4.0.0.2": { break; }
                case "4.0.0.3": { break; }
                case "4.0.0.6": { break; }
                case "4.0.0.9": { break; }
                case "4.0.0.10": { break; }
                case "4.0.0.11": { break; }
                case "4.0.0.12": { break; }
                case "4.0.0.13": { break; }
                case "4.1.0.0": 
                    {
                        txtData.Text = "- Общая настройка : добавить пароль для защиты  установленного" + Environment.NewLine +
                            "- Просмотр клиента: перенесена сюда таблица хронологии и персональные формулы" + Environment.NewLine +
                            "- MySearch:  значение CIELab с клавиатуры" + Environment.NewLine +
                            "- Выведение формулы в унции: выбор  в зависимости от типа  мануальной машины" + Environment.NewLine +
                            "- DEMO: пользование без кода  активации" + Environment.NewLine +
                            "- Устройства : добавлен XRite SP 62" + Environment.NewLine +
                            "- Добавлено множественное выведение на дозатор";
                        break; 
                    }
                case "4.1.1.1": 
                    {
                        txtData.Text = "- Общая настройка:  добавлен раздел « перечень продуктов» (ввести или удалить продукт)" + Environment.NewLine +
                               "- Настройка дозатора: добавлен тип Dromont";
                        break; 
                    }
                case "4.1.1.2": 
                    {
                        txtData.Text = "- Версия DEMO :добавлена этикетка в Home “ для получения дополнительной информации пишите на электронный адрес euroformulations@eurocolori.com»" + Environment.NewLine +
                    "- MySearch : 10 результатов поиска" + Environment.NewLine +
                    "- MySearch : удалены варианты выбора DE, оставлен только стандартный" + Environment.NewLine +
                    "- MySearch : добавлен выбор прайса, показывающий стоимость результатов  начиная со стоимости колорантов, стоимость базы, на 1 литр базы" + Environment.NewLine +
                    "- MySearch : добавлена клавиша для сохранения считанных цветов ";
                        break; 
                    }
                default: { break; }  //error no imfo available at the moment
            }
        }
        #endregion

        public static bool HasNews(string sVersione)
        {
            switch (sVersione)
            {
                case "4.1.0.0":
                case "4.1.1.1":
                case "4.1.1.2":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private void frmUpdatedInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            bDontShow = chkDontShow.Checked;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
