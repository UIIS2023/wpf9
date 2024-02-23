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
    /// Interaction logic for FrmAerodrom.xaml
    /// </summary>
    public partial class FrmAerodrom : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;
        public FrmAerodrom()
        {
            InitializeComponent();
           txtNazivAerodroma.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmAerodrom(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNazivAerodroma.Focus();
            konekcija = kon.KreirajKonekciju();

            this.azuriraj = azuriraj;
            this.red = red;
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
                cmd.Parameters.Add("@nazivAerodroma", SqlDbType.NVarChar).Value = txtNazivAerodroma.Text; // preko .Text se pristupa textu
                cmd.Parameters.Add("@drzava", SqlDbType.NVarChar).Value = txtDrzavaAerodroma.Text; // preko .Text se pristupa textu

                if (this.azuriraj)
                {
                    DataRowView red = this.red;
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update TabelaAerodrom 
                                        set nazivAerodroma = @nazivAerodroma, drzava = @drzava 
                                        where aerodromID = @id";
                }
                else
                {
                    cmd.CommandText = @"insert into TabelaAerodrom (nazivAerodroma, drzava)
                                         values (@nazivAerodroma, @drzava)";
                }
                
                cmd.ExecuteNonQuery();  // ovo sluzi da bi se izvrsila insert naredba, catch se vata posle ove komande
                cmd.Dispose(); // oslobadja resurse
                this.Close(); // da se zatvori forma



            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska prilikom konverzije podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
