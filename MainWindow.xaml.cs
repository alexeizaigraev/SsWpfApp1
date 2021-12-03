using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SsWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        delegate void delegateMemu();

        void WorkMenu(delegateMemu parDelegate)
        {
            #region
            ClearMe();
            try
            {
                parDelegate();
                textBox1.Text = Papa.info;
            }
            catch (Exception ex) { textBox1.Text = ex.Message; }

            #endregion
        }



        public MainWindow()
        {
            #region
            InitializeComponent();
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var items = new List<string>() { "item1", "item2" };
            listBox1.ItemsSource = items;
            listBoxPartners.ItemsSource = items;
            
            #endregion
        }



        private void ClearMe()
        {
            #region
            textBox1.Text = "";
            Papa.info = "";
            #endregion
        }

        private void Priem_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Priem.MainPriem;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Otpusk_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Otpusk.MainOtpusk;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Perevod_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Perevod.MainPerevod;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void PostAll_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = PostAll.MainPostAll;
            WorkMenu(myDelegatemenu);
            #endregion
        }


        private void Term_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Term.MainTerm;
            WorkMenu(myDelegatemenu);
            #endregion
        }


        private void Monitor_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Monitor.MainMonitor;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Rasklad_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Rasklad.MainRasklad;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void AccBack_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = AccessBackUp.MainAccessBackUp;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Rro_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Rro.MainRro;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Pereezd_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Pereezd.MainPereezd;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void PereezdNew_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = PereezdNew.MainPereezd;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Otmena.MainOtmena;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Prro_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Prro.MainPrro;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void Knigi_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Knigi.MainKnigi;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void ButtonOtborListTerm_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            Papa.selectedItems = new List<string[]>();
            var terms = listBox1.SelectedItems;
            foreach (var item in terms)
            {
                var term = item.ToString();
                var dep = term.Substring(0, 7);
                var line = $"{term};{dep}".Split(';'); ;

                Papa.selectedItems.Add(line);
                //textBox1.Text += dep + "\n";
            }
            DbOtborMet.AddManyOtbor(Papa.selectedItems);
            textBox1.Text = Papa.info;
            //listBox1.SelectedItems.Clear();

            #endregion
        }

        private void ButtonOtborInputDep_Click(object sender, RoutedEventArgs e)
        {
            #region
            //ClearMe();
            //Papa.selectedItems = new List<string[]>();
            var inputDeps = textBox1.Text;
            Otbor.MainOtbor(inputDeps);
            //ClearMe();
            textBox1.Text = Papa.info;
            //listBox1.SelectedItems.Clear();

            #endregion
        }

        private void ButtonPartner_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            if (Papa.Col1Partners)
            {
                Papa.partnerChoised = listBoxPartners.SelectedItem.ToString();
                textBox1.Text = Papa.partnerChoised;
                //HrDep.MainHrDep();
                textBox1.Text += "\n" + Papa.info;
                listBox1.ItemsSource = DbBase.GetTermsPartner(Papa.partnerChoised);
            }
            else
            {
                Papa.selectedFolder = listBoxPartners.SelectedItem.ToString();
                textBox1.Text = Papa.selectedFolder;
                try
                {
                    GetRpAll.MainGetRpAll();
                }
                catch
                {
                    Papa.info = " no-no :)";
                }
                textBox1.Text += "\n" + Papa.info;
                //listBox1.ItemsSource = PgBase.GetListTermPartner();
            }
            #endregion
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            Papa.info = "";
            #endregion
        }

        private void RefreshFull_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            ExternProcess.RefresFromAccessAll();
            textBox1.Text = Papa.info;
            listBox1.ItemsSource = DbTermMeth.GetLisTerm();
            listBoxPartners.ItemsSource = DbDepMeth.GetLisPartner();
            #endregion
        }

        
        private void Col1Partners_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            Papa.Col1Partners = true;
            listBoxPartners.ItemsSource = DbDepMeth.GetLisPartner();
            listBox1.ItemsSource = DbTermMeth.GetLisTerm();
            #endregion
        }


        private void Col1Folders_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            Papa.Col1Partners = false;
            listBoxPartners.ItemsSource = Papa.MkGdriveFolders();
            #endregion
        }


        private void Rp_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            try
            {
                GetRp.MainGetRp();
            }
            catch { Papa.info += " no-no :)"; }
            textBox1.Text = Papa.info;
            #endregion
        }

        private void HrOtbor_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = HrDep.MainHrDep;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void GnetzCopy_Click(object sender, RoutedEventArgs e)
        {
            #region
            Papa.gnetzKind = "copy";
            delegateMemu myDelegatemenu;
            myDelegatemenu = Gnetz.MainGnetz;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void GnetzMovy_Click(object sender, RoutedEventArgs e)
        {
            #region
            Papa.gnetzKind = "movy";
            delegateMemu myDelegatemenu;
            myDelegatemenu = Gnetz.MainGnetz;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void GdriveBackUp_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = GdriveBackUp.MainGdriveBackUp;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        
        /*
        private void ButtonShowDep_Click(object sender, RoutedEventArgs e)
        {
            #region
            WindowDep windowDep = new WindowDep();
            windowDep.Show();
            #endregion
        }

        private void ButtonShowTerm_Click(object sender, RoutedEventArgs e)
        {
            #region
            WindowTerm windowTerm = new WindowTerm();
            windowTerm.Show();
            #endregion
        }

        */

        private void RefreshActualFull_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            try { DbDepNewMeth.RefreshDepartment(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            textBox1.Text += Papa.info + "\n";
            textBox1.Text += "Актуальное обновлено";
            #endregion
        }

        private void RefreshActualOtbor_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            try { Actual.OtborToActua(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            textBox1.Text += Papa.info + "\n";
            textBox1.Text += "Выбранное обновлено";
            #endregion
        }

        private void ClearActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            Actual.ClearActualOtbor();
            textBox1.Text += "Актуальное очищено";
            #endregion
        }

        private void ButtonOtborShow_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            textBox1.Text += DbOtborMet.ShowtOtbor();
            #endregion
        }

        

        private void AnalisDep_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            try { Analis.AnalisMain(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            textBox1.Text = Papa.info + "\n";
            #endregion
        }

        private void ClearActualOtbor_Click(object sender, RoutedEventArgs e)
        {
            #region
            ClearMe();
            Actual.ClearActualOtbor();
            textBox1.Text = "\nАктуал отбор очищен";
            #endregion
        }

        private void HrOtborActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = HrDep.MainHrDep;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void SummuryAbActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = HrDepAb.MainHrDepAb;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void NatashaActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = Natasha.MainNatasha;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        private void SitActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            delegateMemu myDelegatemenu;
            myDelegatemenu = SiteNew.MainSiteMew;
            WorkMenu(myDelegatemenu);
            #endregion
        }

        
        private void ButtonOtborInputTermHard_Click(object sender, RoutedEventArgs e)
        {
            #region
            //ClearMe();
            //Papa.selectedItems = new List<string[]>();
            var inputDeps = textBox1.Text;
            OtborHardInput.MainOtborHard(inputDeps);
            //ClearMe();
            textBox1.Text = Papa.info;
            //listBox1.SelectedItems.Clear();
            #endregion
        }

        
    }
}
