using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for FrmPutnici.xaml
    /// </summary>
    public partial class FrmPutnici : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;
       
        public FrmPutnici()
        {
            InitializeComponent();
            txtImePutnika.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmPutnici(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtImePutnika.Focus();
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
                string vrati = @"select letID, letNaziv from TabelaLet";
                DataTable data = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(vrati, konekcija);
                da.Fill(data);
                cbLet.ItemsSource = data.DefaultView;
                data.Dispose();
                data.Dispose();

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
                cmd.Parameters.Add("@imePutnika", SqlDbType.NVarChar).Value = txtImePutnika.Text;
                cmd.Parameters.Add("@prezimePutnika", SqlDbType.NVarChar).Value = txtPrezimePutnika.Text;
                cmd.Parameters.Add("@jmbgPutnika", SqlDbType.NVarChar).Value = txtJMBGPutnika.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontaktPutnika.Text;
                cmd.Parameters.Add("@letID", SqlDbType.Int).Value = cbLet.SelectedValue;
                if (this.azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update TabelaPutnici set imePutnika = @imePutnika, prezimePutnika = @prezimePutnika, jmbgPutnika = @jmbgPutnika, kontakt = @kontakt, letID = @letID where putniciID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into TabelaPutnici(imePutnika, prezimePutnika, jmbgPutnika, kontakt, letID)
                                    values (@imePutnika, @prezimePutnika, @jmbgPutnika, @kontakt, @letID)";
                }
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (FormatException)  //zbog convertovanja
            {
                MessageBox.Show("Greska prilikom konverzije podataka!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
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
