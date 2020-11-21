using System;
using System.Collections.Generic;
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

namespace WpfApp4
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
            


        }

        private void BtGiris_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();
            SqlCommand k1 = new SqlCommand("select userid from userlar where userad=@ad and usersifre=@sifre", baglanti);
            k1.Parameters.AddWithValue("@ad", txtuser.Text);
            k1.Parameters.AddWithValue("@sifre", txtpass.Password);
            var varmi = k1.ExecuteScalar();
            if (varmi != null)
            {
                MessageBox.Show("Hoşgeldiniz!");
                btMain.Visibility = Visibility.Visible;
                btYapi.Visibility = Visibility.Visible;
                btGiris.IsEnabled = false;

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı Tekrar Deneyiniz");
                btMain.Visibility = Visibility.Hidden;
                btYapi.Visibility = Visibility.Hidden;
                
            }
            baglanti.Close();
        }

        private void Txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtGiris_Click(this,e);
        }

        private void BtYapi_Click(object sender, RoutedEventArgs e)
        {
            Window2 yeni = new Window2();
            yeni.Show();
            this.Close();
        }

        private void BtMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow yeni = new MainWindow();
            yeni.Show();
            this.Close();
        }
    }
}
