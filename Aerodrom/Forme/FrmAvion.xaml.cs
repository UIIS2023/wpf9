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
    /// Interaction logic for FrmAvion.xaml
    /// </summary>
    public partial class FrmAvion : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;  // oznacava da je u pitanju red

        public FrmAvion()
        {
            InitializeComponent();
            txtModelAviona.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmAvion(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtModelAviona.Focus();
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
                string vrati = @"select avioKompanijaID, nazivKom from TabelaAvioKompanija";
                DataTable data = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(vrati, konekcija);
                da.Fill(data);
                cbKompanija.ItemsSource = data.DefaultView;
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
                
                cmd.Parameters.Add("@model", SqlDbType.NVarChar).Value = txtModelAviona.Text; // preko .Text se pristupa textu
                cmd.Parameters.Add("@avioKompanijaID", SqlDbType.Int).Value = cbKompanija.SelectedValue;
                if(this.azuriraj)
                {
                    DataRowView red = this.red;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update TabelaAvion 
                                        Set model = @model, avioKompanijaID = @avioKompanijaID
                                        where avionID = @id";
                }
                else
                {
                    cmd.CommandText = @"insert into TabelaAvion(model, avioKompanijaID)
                                    values (@model, @avioKompanijaID)";
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
