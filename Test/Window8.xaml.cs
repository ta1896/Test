﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data.OleDb;

namespace Test
{
    /// <summary>
    /// Interaktionslogik für Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        Basisklasse bk = new Basisklasse();
        OleDbDataReader dr;
        private bool status;
        private bool BAktivE; // Ob Bonus Existiert oder nicht
        #region Timer
        private bool BlinkOn = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (BlinkOn)
            {
                tlWarning.Foreground = Brushes.White;
                tlWarning.Background = Brushes.Red;
            }
            else
            {
                tlWarning.Foreground = Brushes.Red;
                tlWarning.Background = Brushes.Yellow;
            }
            BlinkOn = !BlinkOn;
        }
        #endregion

        #region Methoden
        public class Bonus
        {
            public int bNr { get; set; }
            public string bBez { get; set; }
            public string bZuschlag { get; set; }
            public string bMonat { get; set; }
            public string bAktiv { get; set; }
        }
        private void ListViewLoad()
        {
            dr = bk.Select("SELECT * FROM Bonus");
            List<Bonus> items = new List<Bonus>();
            try
            {
                while (dr.Read())
                {
                    string _tmp = string.Format("{0} %", dr.GetDouble(2)); string _monat = ""; string _activ = "";
                    switch (dr.GetInt32(3))
                    {
                        case 0: break;
                        case 1: _monat = "Januar"; break;
                        case 2: _monat = "Februar"; break;
                        case 3: _monat = "März"; break;
                        case 4: _monat = "April"; break;
                        case 5: _monat = "Mai"; break;
                        case 6: _monat = "Juni"; break;
                        case 7: _monat = "Juli"; break;
                        case 8: _monat = "August"; break;
                        case 9: _monat = "September"; break;
                        case 10: _monat = "Oktober"; break;
                        case 11: _monat = "November"; break;
                        case 12: _monat = "Dezember"; break;
                    }
                    switch (dr.GetBoolean(4)) { case false: _activ = "Deaktiviert"; break; case true: _activ = "Aktiviert"; break; }
                    items.Add(new Bonus() { bNr = dr.GetInt32(0), bBez = dr.GetString(1), bZuschlag = _tmp, bMonat = _monat, bAktiv = _activ });
                }
            }
            catch (Exception a) { throw a; }
            lvBonus.ItemsSource = items;
        }
        #endregion
        public Window8()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ListView Laden
            try { bk.Connection(); try { ListViewLoad(); bk.CloseCon(); } catch { } }
            catch { MessageBox.Show("Verbindung konnte nicht hergestellt werden", "", MessageBoxButton.OK, MessageBoxImage.Error); bk.CloseCon(); }
            //ComboBox (Status)
            cbBStatus.Items.Insert(0, "Deaktiviert");
            cbBStatus.Items.Insert(1, "Aktiviert");
            //ComboBox (Monat)
            cbBMonat.Items.Insert(0, "Januar");
            cbBMonat.Items.Insert(1, "Februar");
            cbBMonat.Items.Insert(2, "März");
            cbBMonat.Items.Insert(3, "April");
            cbBMonat.Items.Insert(4, "Mai");
            cbBMonat.Items.Insert(5, "Juni");
            cbBMonat.Items.Insert(6, "Juli");
            cbBMonat.Items.Insert(7, "August");
            cbBMonat.Items.Insert(8, "September");
            cbBMonat.Items.Insert(9, "Oktober");
            cbBMonat.Items.Insert(10, "November");
            cbBMonat.Items.Insert(11, "Dezember");
            // Timer (Blinken)
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 180);
            timer.Start();
        }

        private void bMainWin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bUeStdErs_Click(object sender, RoutedEventArgs e)
        {
            string _Error = "";
            if (!string.IsNullOrWhiteSpace(tbBBez.Text) && !string.IsNullOrWhiteSpace(tbBSatz.Text))
            {
                if (cbBStatus.SelectedItem != null || cbBMonat.SelectedItem != null)
                {
                    if (bk.IsAllowed(tbBSatz.Text, false, true, true, "%,."))
                    {
                        try
                        {
                            bk.Connection();
                            try
                            {
                                // Ob ein Aktiver Bonus Existiert
                                dr = bk.Select("SELECT * FROM Bonus WHERE B_Aktiv = true");
                                dr.Read();
                                try
                                {
                                    BAktivE = dr.GetBoolean(4);
                                }
                                catch { BAktivE = false; }
                                //Eintrag in die Datenbank
                                if (BAktivE == false)
                                {
                                    int _mon = cbBMonat.SelectedIndex + 1;
                                    switch (cbBStatus.SelectedIndex) { case 0: status = false; break; case 1: status = true; break; }
                                    string _tmpstring1 = tbBSatz.Text.Replace("%", "").Replace(",", ".").Trim();
                                    bk.Insert($"INSERT INTO Bonus(B_Bez,B_Zuschlag,B_Monat,B_Aktiv) VALUES ('{tbBBez.Text}',{double.Parse(_tmpstring1)},{_mon},{status})");
                                    MessageBox.Show("Der Bonus wurde erfolgreich erstellt", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                    lvBonus.ItemsSource = null;
                                    lvBonus.Items.Clear();
                                    ListViewLoad();
                                    tbBBez.Text = ""; tbBSatz.Text = ""; cbBMonat.Text = ""; cbBStatus.Text = "";
                                    bk.CloseCon();
                                }
                                else
                                {
                                    if (cbBStatus.SelectedIndex == 0)
                                    {
                                        int _mon = cbBMonat.SelectedIndex + 1;
                                        switch (cbBStatus.SelectedIndex) { case 0: status = false; break; case 1: status = true; break; }
                                        bk.Insert($"INSERT INTO Bonus(B_Bez,B_Zuschlag,B_Monat,B_Aktiv) VALUES ({tbBBez.Text},{double.Parse(tbBSatz.Text)},{_mon},{status})");
                                        MessageBox.Show("Der Bonus wurde erfolgreich erstellt", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                        lvBonus.ItemsSource = null;
                                        lvBonus.Items.Clear();
                                        ListViewLoad();
                                        tbBBez.Text = ""; tbBSatz.Text = ""; cbBMonat.Text = ""; cbBStatus.Text = "";
                                        bk.CloseCon();
                                    }
                                    else MessageBox.Show("Es existiert schon ein Aktiver Bonus", "", MessageBoxButton.OK, MessageBoxImage.Error); bk.CloseCon();
                                }
                            }
                            catch { MessageBox.Show("Dieser Bonus konnte erstellt werden.", "", MessageBoxButton.OK, MessageBoxImage.Error); }
                        }
                        catch { MessageBox.Show("Die Verbindung konnte nicht hergestellt werden.", "", MessageBoxButton.OK, MessageBoxImage.Error); bk.CloseCon(); }
                    }
                    else _Error += "Der Prozentsatz darf keine ungewöhnlivhen Zeichen enthalten.\n";
                }
                else _Error += "Die ComboBoxen dürfen nicht leer sein.\n";
            }
            else { _Error += "Die Textfelder dürfen nicht leer sein"; MessageBox.Show(_Error, "", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void lvBonus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBonus.SelectedItem != null)
            {
                int _tmpNr = Convert.ToInt32(lvBonus.SelectedIndex) + 1;
                Window9 aB = new Window9(_tmpNr);
                aB.ShowDialog();
                try
                {
                    bk.Connection();
                    try { ListViewLoad(); bk.CloseCon(); }
                    catch { bk.CloseCon(); }
                }
                catch { MessageBox.Show("Die Verbindung konnte nicht hergestellt werden.", "", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
    }
}
