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
    /// Interaction logic for FrmRezervacijaLeta.xaml
    /// </summary>
    public partial class FrmRezervacijaLeta : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;  // oznacava da je u pitanju red

        public FrmRezervacijaLeta()
        {
            InitializeComponent();
            txtBrojRezervacije.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public FrmRezervacijaLeta(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtBrojRezervacije.Focus();
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
                cmd.Parameters.Add("@brojRezervacije", SqlDbType.NVarChar).Value = txtBrojRezervacije.Text; // preko .Text se pristupa textu
                if(this.azuriraj) 
                {
                    DataRowView red = this.red;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update TabelaRezervacijeLeta
                                        Set brojRezervacije = @brojRezervacije
                                        where rezervacijaID = @id";
                    this.red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into TabelaRezervacijeLeta(brojRezervacije) values (@brojRezervacije)";
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
                {
                if (konekcija != null)
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
