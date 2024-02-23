using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Aerodrom.Forme
{
    /// <summary>
    /// Interaction logic for FrmLet.xaml
    /// </summary>
    public partial class FrmLet : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;  // oznacava da je u pitanju red

      
        public FrmLet()
        {
            InitializeComponent();
            txtNazivLeta.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmLet(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNazivLeta.Focus();
            konekcija = kon.KreirajKonekciju();

            this.azuriraj = azuriraj;
            this.red = red;
            PopuniPadajuceListe();
        }


        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vrati = @"select avionID, model from TabelaAvion";
                DataTable data = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(vrati, konekcija);
                da.Fill(data);
                cbAvion.ItemsSource = data.DefaultView;
                data.Dispose();
                data.Dispose();

                string vrati2 = @"select aerodromID, nazivAerodroma from TabelaAerodrom";
                DataTable data2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(vrati2, konekcija);
                da2.Fill(data2);
                cbAerodrom.ItemsSource = data2.DefaultView;
                data2.Dispose();
                data2.Dispose();

                string vrati3 = @"select pilotID, prezimePilota from TabelaPilot";
                DataTable data3 = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(vrati3, konekcija);
                da3.Fill(data3);
                cbPilot.ItemsSource = data3.DefaultView;
                data3.Dispose();
                data3.Dispose();




            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@letNaziv", SqlDbType.NVarChar).Value = txtNazivLeta.Text;
                cmd.Parameters.Add("@kapacitet", SqlDbType.Int).Value = int.Parse(txtKapacitet.Text);
                cmd.Parameters.Add("@vremePoletanja", SqlDbType.NVarChar).Value = txtVrPoletanja.Text;
                cmd.Parameters.Add("@vremeSletanja", SqlDbType.NVarChar).Value = txtVrSletanja.Text;
                cmd.Parameters.Add("@destinacija", SqlDbType.NVarChar).Value = txtDestinacija.Text;
                cmd.Parameters.Add("@cena", SqlDbType.Int).Value = int.Parse(txtCena.Text);
                cmd.Parameters.Add("@avionID", SqlDbType.Int).Value = cbAvion.SelectedValue;
                cmd.Parameters.Add("@aerodromID", SqlDbType.Int).Value = cbAerodrom.SelectedValue;
                cmd.Parameters.Add("@pilotID", SqlDbType.Int).Value = cbPilot.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update TabelaLet set letNaziv = @letNaziv, kapacitet = @kapacitet, vremePoletanja = @vremePoletanja, vremeSletanja = @vremeSletanja, destinacija = @destinacija, cena = @cena, avionID = @avionID, aerodromID = @aerodromID, pilotID = @pilotID
                                         where letID = @id";
                }

                else
                {
                    cmd.CommandText = @"insert into TabelaLet(letNaziv, kapacitet, vremePoletanja, vremeSletanja, destinacija, cena, avionID , aerodromID, pilotID) 
                                    values (@letNaziv, @kapacitet, @vremePoletanja, @vremeSletanja, @destinacija, @cena, @avionID, @aerodromID, @pilotID)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch(SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)  //zbog convertovanja
            {
                MessageBox.Show("Greska prilikom konverzije podataka!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close(); 
                }
            }

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
