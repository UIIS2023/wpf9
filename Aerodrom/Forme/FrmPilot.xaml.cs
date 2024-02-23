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
    /// Interaction logic for FrmPilot.xaml
    /// </summary>
    public partial class FrmPilot : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmPilot()
        {
            InitializeComponent();
            txtImePilota.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmPilot(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtImePilota.Focus();
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
                cmd.Parameters.Add("@imePilota", SqlDbType.NVarChar).Value = txtImePilota.Text; // preko .Text se pristupa textu
                cmd.Parameters.Add("@prezimePilota", SqlDbType.NVarChar).Value = txtPrezimePilota.Text; // preko .Text se pristupa textu
                cmd.Parameters.Add("@kontaktPilota", SqlDbType.NVarChar).Value = txtKontaktPilota.Text; // preko .Text se pristupa textu
                if (this.azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update TabelaPilot set imePilota = @imePilota, prezimePilota = @prezimePilota, kontaktPilota = @kontaktPilota where pilotID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into TabelaPilot (imePilota, prezimePilota, kontaktPilota)
                                         values (@imePilota, @prezimePilota, @kontaktPilota)";
                }
                
                cmd.ExecuteNonQuery();  // ovo sluzi da bi se izvrsila insert naredba, catch se vata posle ove komande
                cmd.Dispose(); // oslobadja resurse
                this.Close(); // da se zatvori forma
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
