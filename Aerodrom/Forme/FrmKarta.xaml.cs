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
    /// Interaction logic for FrmKarta.xaml
    /// </summary>
    public partial class FrmKarta : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmKarta()
        {
            InitializeComponent();
            txtBrojKarte.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmKarta(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtBrojKarte.Focus();
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
                string vrati2 = @"select letID, letNaziv from TabelaLet";
                DataTable data2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(vrati2, konekcija);
                da2.Fill(data2);
                cbLetKarta.ItemsSource = data2.DefaultView;
                data2.Dispose();
                data2.Dispose();


                string vrati = @"select rezervacijaID, brojRezervacije from TabelaRezervacijeLeta";
                DataTable data = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(vrati, konekcija);
                da.Fill(data);
                cbRezervacija.ItemsSource = data.DefaultView;
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
                cmd.Parameters.Add("@brojKarte", SqlDbType.NVarChar).Value = txtBrojKarte.Text;
                cmd.Parameters.Add("@brojLeta", SqlDbType.NVarChar).Value = txtBrojLeta.Text;
                cmd.Parameters.Add("@letID", SqlDbType.Int).Value = cbLetKarta.SelectedValue;
                cmd.Parameters.Add("@rezervacijaID", SqlDbType.Int).Value = cbRezervacija.SelectedValue;

                if (this.azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update TabelaKarta
                                        Set brojKarte = @brojKarte, brojLeta = @brojLeta, letID = @letID, rezervacijaID = @rezervacijaID
                                        where kartaID = @id";
                    red = null;
                }
                
                
              else
                {
                    cmd.CommandText = @"insert into TabelaKarta(brojKarte, brojLeta, letID, rezervacijaID)
                                    values (@brojKarte, @brojLeta, @letID, @rezervacijaID)";
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
