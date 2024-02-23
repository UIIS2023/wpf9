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
using System.Data.SqlClient;
using System.Data;
using Aerodrom.Forme;

namespace Aerodrom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        #region
        private static string LetSelect = @"select letID as ID, letNaziv as Naziv, kapacitet, vremePoletanja as Poletanje, vremeSletanja as Sletanje, destinacija, cena, model, nazivAerodroma, prezimePilota  from TabelaLet join TabelaAvion on TabelaLet.avionID = TabelaAvion.avionID
                                            join TabelaAerodrom on TabelaLet.aerodromID = TabelaAerodrom.aerodromID join TabelaPilot on TabelaLet.pilotID = TabelaPilot.pilotID";
        private static string AvionSelect = @"select avionID as ID, model as Model, nazivKom as Kompanija from TabelaAvion join TabelaAvioKompanija on TabelaAvion.avioKompanijaID = TabelaAvioKompanija.avioKompanijaID ";
        private static string AvioKompanijaSelect = @"select avioKompanijaID as ID, nazivKom as Naziv, drzavaKom as Drzava from TabelaAvioKompanija";
        private static string AerodromSelect = @"select aerodromID as ID, nazivAerodroma as Naziv, drzava as Drzava from TabelaAerodrom";
        private static string PutniciSelect = @"select PutniciID as ID, imePutnika as Ime, prezimePutnika as Prezime, jmbgPutnika as JMBG, kontakt, letNaziv as Let from TabelaPutnici join TabelaLet on TabelaPutnici.letID = TabelaLet.letID";
        private static string KartaSelect = @"select kartaID as ID, brojKarte as Broj, brojLeta as 'Broj leta', letNaziv as Let, brojRezervacije as Rezervacija from TabelaKarta join TabelaLet on TabelaKarta.letID = TabelaLet.letID join TabelaRezervacijeLeta on TabelaKarta.rezervacijaID = TabelaRezervacijeLeta.rezervacijaID;";
        private static string RezervacijaSelect = @"select rezervacijaID as ID, brojRezervacije as rezervacija from TabelaRezervacijeLeta";
        private static string PilotSelect = @"select pilotID as ID, imePilota as Ime, prezimePilota as Prezime, kontaktPilota as Kontakt from TabelaPilot";
        #endregion

        #region select naredbe
        private static string selectUslovLet = @"select * from TabelaLet where letID=";
        private static string selectUslovAvion = @"select * from TabelaAvion where avionID=";
        private static string selectUslovAvioKompanija = @"select * from TabelaAvioKompanija where avioKompanijaID=";
        private static string selectUslovAerodrom = @"select * from TabelaAerodrom where AerodromID=";
        private static string selectUslovPutnici = @"select * from TabelaPutnici where putniciID=";
        private static string selectUslovKarta = @"select * from TabelaKarta where kartaID=";
        private static string selectUslovRezervacija = @"select * from TabelaRezervacijeLeta where rezervacijaID=";
        private static string selectUslovPilot = @"select * from TabelaPilot where pilotID=";
        #endregion

        #region delete naredbe
        private static string letDelete = @"delete from TabelaLet where letID=";
        private static string avionlDelete = @"delete from TabelaAvion where avionID=";
        private static string avioKompanijaDelete = @"delete from TabelaAvioKompanija where avioKompanijaID=";
        private static string aerodromDelete = @"delete from TabelaAerodrom where AerodromID=";
        private static string putniciDelete = @"delete from TabelaPutnici where putniciID=";
        private static string kartaDelete = @"delete from TabelaKarta where kartaID=";
        private static string rezervacijaDelete = @"delete from TabelaRezervacijeLeta where rezervacijaID=";
        private static string pilotDelete = @"delete from TabelaPilot where pilotID=";
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            
        }

        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno uneti podaci", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }


        private void btnLet_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, LetSelect);
        }

        private void btnAvion_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, AvionSelect);
        }

        private void btnAvioKompanija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, AvioKompanijaSelect);
        }

        private void btnAerodrom_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, AerodromSelect);
        }

        private void btnPutnici_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, PutniciSelect);

        }

        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, KartaSelect);
        }

        private void btnRezervacijaLeta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, RezervacijaSelect);
        }

        private void btnPilot_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, PilotSelect);
        }

        //*****************************KOMANDA DODAJ***********************************//

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(LetSelect))
            {
                prozor = new FrmLet();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, LetSelect);
            }
            else if (ucitanaTabela.Equals(AvionSelect))
            {
                prozor = new FrmAvion();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, AvionSelect);
            }
            else if (ucitanaTabela.Equals(AerodromSelect))
            {
                prozor = new FrmAerodrom();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, AerodromSelect);
            }
            else if (ucitanaTabela.Equals(AvioKompanijaSelect))
            {
                prozor = new FrmAvioKompanija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, AvioKompanijaSelect);
            }
            else if (ucitanaTabela.Equals(PutniciSelect))
            {
                prozor = new FrmPutnici();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni,PutniciSelect);
            }
            else if (ucitanaTabela.Equals(KartaSelect))
            {
                prozor = new FrmKarta();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni,KartaSelect);
            }
            else if (ucitanaTabela.Equals(RezervacijaSelect))
            {
                prozor = new FrmRezervacijaLeta();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, RezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(PilotSelect))
            {
                prozor = new FrmPilot();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni,PilotSelect);
            }
        }

        //********************************************IZMENI**************************************************
        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(LetSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovLet);
                UcitajPodatke(dataGridCentralni,LetSelect);
            }
            else if (ucitanaTabela.Equals(AvionSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovAvion);
                UcitajPodatke(dataGridCentralni,AvionSelect);
            }
            else if(ucitanaTabela.Equals(AvioKompanijaSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovAvioKompanija);
                UcitajPodatke(dataGridCentralni, AvioKompanijaSelect);
            }
            else if (ucitanaTabela.Equals(AerodromSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovAerodrom);
                UcitajPodatke(dataGridCentralni,AerodromSelect);
            }
            else if (ucitanaTabela.Equals(PutniciSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovPutnici);
                UcitajPodatke(dataGridCentralni,PutniciSelect);
            }
            else if (ucitanaTabela.Equals(KartaSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovKarta);
                UcitajPodatke(dataGridCentralni,KartaSelect);
            }
            else if(ucitanaTabela.Equals(RezervacijaSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovRezervacija);
                UcitajPodatke(dataGridCentralni,RezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(PilotSelect))
            {
                PopuniFormu(dataGridCentralni,selectUslovPilot);
                UcitajPodatke(dataGridCentralni,PilotSelect);
            }
        }


        private void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();  // cita naredbe
                cmd.Dispose();

                if (citac.Read()) // ako ima sta da cita
                {
                    if (ucitanaTabela.Equals(LetSelect))
                    {
                        FrmLet prozorLet = new FrmLet(azuriraj, red);

                        prozorLet.txtNazivLeta.Text = citac["letNaziv"].ToString();
                        prozorLet.txtKapacitet.Text = citac["kapacitet"].ToString();  // ide to string jer je text box
                        prozorLet.txtVrPoletanja.Text = citac["vremePoletanja"].ToString();
                        prozorLet.txtVrSletanja.Text = citac["vremeSletanja"].ToString();
                        prozorLet.txtDestinacija.Text = citac["destinacija"].ToString();
                        prozorLet.txtCena.Text = citac["cena"].ToString();
                        prozorLet.cbAvion.SelectedValue = citac["avionID"].ToString();
                        prozorLet.cbAerodrom.SelectedValue = citac["aerodromID"].ToString();
                        prozorLet.cbPilot.SelectedValue = citac["pilotID"].ToString();

                        prozorLet.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(AvionSelect))
                    {
                        FrmAvion prozorAvion = new FrmAvion(azuriraj, red);

                        prozorAvion.txtModelAviona.Text = citac["model"].ToString();
                        prozorAvion.cbKompanija.SelectedValue = citac["avioKompanijaID"].ToString();

                        prozorAvion.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(AvioKompanijaSelect))
                    {
                        FrmAvioKompanija prozorAvioKom = new FrmAvioKompanija(azuriraj, red);

                        prozorAvioKom.txtNazivKompanije.Text = citac["nazivKom"].ToString();
                        prozorAvioKom.txtDrzavaKompanije.Text = citac["drzavaKom"].ToString();
                        prozorAvioKom.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(AerodromSelect))
                    {
                        FrmAerodrom prozorAerodrom = new FrmAerodrom(azuriraj, red);

                        prozorAerodrom.txtNazivAerodroma.Text = citac["nazivAerodroma"].ToString();
                        prozorAerodrom.txtDrzavaAerodroma.Text = citac["drzava"].ToString();

                        prozorAerodrom.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(PutniciSelect))
                    {
                        FrmPutnici prozorPutnici = new FrmPutnici(azuriraj, red);
                        prozorPutnici.txtImePutnika.Text = citac["imePutnika"].ToString();
                        prozorPutnici.txtPrezimePutnika.Text = citac["prezimePutnika"].ToString();
                        prozorPutnici.txtJMBGPutnika.Text = citac["jmbgPutnika"].ToString();
                        prozorPutnici.txtKontaktPutnika.Text = citac["kontakt"].ToString();
                        prozorPutnici.cbLet.SelectedValue = citac["letID"].ToString();
                        prozorPutnici.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(KartaSelect))
                    {
                        FrmKarta prozorKarta = new FrmKarta(azuriraj, red);
                        prozorKarta.txtBrojKarte.Text = citac["brojKarte"].ToString();
                        prozorKarta.txtBrojLeta.Text = citac["brojLeta"].ToString();
                        prozorKarta.cbLetKarta.SelectedValue = citac["letID"].ToString();
                        prozorKarta.cbRezervacija.SelectedValue = citac["rezervacijaID"].ToString();
                        prozorKarta.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(RezervacijaSelect))
                    {
                        FrmRezervacijaLeta prozorRezLeta = new FrmRezervacijaLeta(azuriraj, red);
                        prozorRezLeta.txtBrojRezervacije.Text = citac["brojRezervacije"].ToString();
                        prozorRezLeta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(PilotSelect))
                    {
                        FrmPilot prozorPilota = new FrmPilot(azuriraj, red);
                        prozorPilota.txtImePilota.Text = citac["imePilota"].ToString();
                        prozorPilota.txtPrezimePilota.Text = citac["prezimePilota"].ToString();
                        prozorPilota.txtKontaktPilota.Text = citac["kontaktPilota"].ToString();
                        prozorPilota.ShowDialog();
                    }
                } 
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        
        }



        //****************************************BRISANJE*****************************************************************
        void ObrisiZapis(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand()
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u nekim drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(LetSelect))
            {
                ObrisiZapis(dataGridCentralni, letDelete);
                UcitajPodatke(dataGridCentralni, LetSelect);
            }
            else if (ucitanaTabela.Equals(AvionSelect))
            {
                ObrisiZapis(dataGridCentralni, avionlDelete);
                UcitajPodatke(dataGridCentralni, AvionSelect);

            }
            else if (ucitanaTabela.Equals(AvioKompanijaSelect))
            {
                ObrisiZapis(dataGridCentralni, avioKompanijaDelete);
                UcitajPodatke(dataGridCentralni, AvioKompanijaSelect);

            }
            else if (ucitanaTabela.Equals(AerodromSelect))
            {
                ObrisiZapis(dataGridCentralni, aerodromDelete);
                UcitajPodatke(dataGridCentralni, AerodromSelect);

            }
            else if(ucitanaTabela.Equals(PutniciSelect)) 
            {
                ObrisiZapis(dataGridCentralni, putniciDelete);
                UcitajPodatke(dataGridCentralni, PutniciSelect);
            }
            else if(ucitanaTabela.Equals(KartaSelect))
            {
                ObrisiZapis(dataGridCentralni, kartaDelete);
                UcitajPodatke(dataGridCentralni, KartaSelect);

            }
            else if (ucitanaTabela.Equals(RezervacijaSelect))
            {
                ObrisiZapis(dataGridCentralni, rezervacijaDelete);
                UcitajPodatke(dataGridCentralni, RezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(PilotSelect)) 
            {
                ObrisiZapis(dataGridCentralni, pilotDelete);
                UcitajPodatke(dataGridCentralni, PilotSelect);
            }
            
        }
    }
}
