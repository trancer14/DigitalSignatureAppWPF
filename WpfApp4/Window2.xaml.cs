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
    /// Window2.xaml etkileşim mantığı
    /// </summary>
    public partial class Window2 : Window
    {
        public string str11;
        public string str22;
        public string str33;
        public string str44;
        public string str55;
        public string str66;
        public static string imgclock = "numerals.jpg";

        public Window2()
        {

            InitializeComponent();
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();


            SqlCommand k5 = new SqlCommand("select top 1 textin from text where textdeger=1  order by textid desc", baglanti);
            SqlDataReader dr1 = k5.ExecuteReader();
            string str1 = null;
            while (dr1.Read())
            {
                str1 = dr1[0].ToString();
            }
            txt1.Text = str1;
            str11 = str1;

            baglanti.Close();
            baglanti.Open();


            SqlCommand k6 = new SqlCommand("select top 1 textin from text where textdeger=2  order by textid desc", baglanti);
            SqlDataReader dr2 = k6.ExecuteReader();
            string str2 = null;
            while (dr2.Read())
            {
                str2 = dr2[0].ToString();
            }
            txt2.Text = str2;
            str22 = str2;

            baglanti.Close();
            baglanti.Open();


            SqlCommand k7 = new SqlCommand("select top 1 textin from text where textdeger=3  order by textid desc", baglanti);
            SqlDataReader dr3 = k7.ExecuteReader();
            string str3 = null;
            while (dr3.Read())
            {
                str3 = dr3[0].ToString();
            }
            txt3.Text = str3;
            str33 = str3;

            baglanti.Close();
            baglanti.Open();


            SqlCommand k1 = new SqlCommand("select top 1 textin from text where textdeger=4  order by textid desc", baglanti);
            SqlDataReader dr4 = k1.ExecuteReader();
            string str4 = null;
            while (dr4.Read())
            {
                str4 = dr4[0].ToString();
            }
            txt4.Text = str4;
            str44 = str4;

            baglanti.Close();

            baglanti.Open();


            SqlCommand k2 = new SqlCommand("select top 1 textin from text where textdeger=5  order by textid desc", baglanti);
            SqlDataReader dr5 = k2.ExecuteReader();
            string str5 = null;
            while (dr5.Read())
            {
                str5 = dr5[0].ToString();
            }
            txt5.Text = str5;
            str55 = str5;

            baglanti.Close();
            baglanti.Open();


            SqlCommand k3 = new SqlCommand("select top 1 textin from text where textdeger=0  order by textid desc", baglanti);
            SqlDataReader dr6 = k3.ExecuteReader();
            string str6 = null;
            while (dr6.Read())
            {
                str6 = dr6[0].ToString();
            }
            txthos.Text = str6;
            str66 = str6;

            baglanti.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                SqlCommand k1 = new SqlCommand("insert into img(imgdeger,imgkac) values (@deger,'1')", baglanti);
                k1.Parameters.AddWithValue("@deger", filename);
                k1.ExecuteNonQuery();
            }
            baglanti.Close();
        }

        private void Bt2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                SqlCommand k1 = new SqlCommand("insert into img(imgdeger,imgkac) values (@deger,'2')", baglanti);
                k1.Parameters.AddWithValue("@deger", filename);
                k1.ExecuteNonQuery();
            }
            baglanti.Close();
        }

        private void Bt3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                SqlCommand k1 = new SqlCommand("insert into img(imgdeger,imgkac) values (@deger,'3')", baglanti);
                k1.Parameters.AddWithValue("@deger", filename);
                k1.ExecuteNonQuery();
            }
            baglanti.Close();
        }

        private void Btkaydet_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            if (txt1.Text != "" && txt1.Text != str11)
            {
                baglanti.Open();

                SqlCommand k1 = new SqlCommand("insert into text(textin,textdeger) values (@deger,'1')", baglanti);
                k1.Parameters.AddWithValue("@deger", txt1.Text);
                k1.ExecuteNonQuery();

                baglanti.Close();
            }
            if (txt2.Text != "" && txt2.Text != str22)
            {
                baglanti.Open();

                SqlCommand k2 = new SqlCommand("insert into text(textin,textdeger) values (@deger,'2')", baglanti);
                k2.Parameters.AddWithValue("@deger", txt2.Text);
                k2.ExecuteNonQuery();
                baglanti.Close();
            }
            if (txt3.Text != "" && txt3.Text != str33)
            {
                baglanti.Open();
                SqlCommand k3 = new SqlCommand("insert into text(textin,textdeger) values (@deger,'3')", baglanti);
                k3.Parameters.AddWithValue("@deger", txt3.Text);
                k3.ExecuteNonQuery();
                baglanti.Close();
            }
            if (txt4.Text != "" && txt4.Text != str44)
            {
                baglanti.Open();
                SqlCommand k4 = new SqlCommand("insert into text(textin,textdeger) values (@deger,'4')", baglanti);
                k4.Parameters.AddWithValue("@deger", txt4.Text);
                k4.ExecuteNonQuery();
                baglanti.Close();
            }
            if (txt5.Text != "" && txt5.Text != str55)
            {
                baglanti.Open();
                SqlCommand k5 = new SqlCommand("insert into text(textin,textdeger) values (@deger,'5')", baglanti);
                k5.Parameters.AddWithValue("@deger", txt5.Text);
                k5.ExecuteNonQuery();
                baglanti.Close();
            }
            if (txthos.Text != "" && txthos.Text != str66)
            {
                baglanti.Open();
                SqlCommand k6 = new SqlCommand("insert into text(textin,textdeger) values (@deger,'0')", baglanti);
                k6.Parameters.AddWithValue("@deger", txthos.Text);
                k6.ExecuteNonQuery();
                baglanti.Close();
            }
            MainWindow yeni = new MainWindow();
            yeni.Show();

        }

        private void Btlogo_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                SqlCommand k1 = new SqlCommand("insert into img(imgdeger,imgkac) values (@deger,'0')", baglanti);
                k1.Parameters.AddWithValue("@deger", filename);
                k1.ExecuteNonQuery();
            }
            baglanti.Close();
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb.SelectedItem == od1)
            {
                Button.Visibility = Visibility.Visible;
                bt2.Visibility = Visibility.Hidden;
                bt3.Visibility = Visibility.Hidden;
                bt4.Visibility = Visibility.Hidden;
                bt5.Visibility = Visibility.Hidden;
                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Hidden;
                txt3.Visibility = Visibility.Hidden;
                txt4.Visibility = Visibility.Hidden;
                txt5.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Visible;
                lbll2.Visibility = Visibility.Hidden;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Hidden;
                lbl5.Visibility = Visibility.Hidden;
            }

               else if (cb.SelectedItem == od2)
            {
                Button.Visibility = Visibility.Hidden;
                bt2.Visibility = Visibility.Visible;
                bt3.Visibility = Visibility.Hidden;
                bt4.Visibility = Visibility.Hidden;
                bt5.Visibility = Visibility.Hidden;
                txt1.Visibility = Visibility.Hidden;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Hidden;
                txt4.Visibility = Visibility.Hidden;
                txt5.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbll2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Hidden;
                lbl5.Visibility = Visibility.Hidden;
            }else if (cb.SelectedItem == od3)
            {
                Button.Visibility = Visibility.Hidden;
                bt2.Visibility = Visibility.Hidden;
                bt3.Visibility = Visibility.Visible;
                bt4.Visibility = Visibility.Hidden;
                bt5.Visibility = Visibility.Hidden;
                txt1.Visibility = Visibility.Hidden;
                txt2.Visibility = Visibility.Hidden;
                txt3.Visibility = Visibility.Visible;
                txt4.Visibility = Visibility.Hidden;
                txt5.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbll2.Visibility = Visibility.Hidden;
                lbl3.Visibility = Visibility.Visible;
                lbl4.Visibility = Visibility.Hidden;
                lbl5.Visibility = Visibility.Hidden;
            }else if( cb.SelectedItem == od4)
            {
                Button.Visibility = Visibility.Hidden;
                bt2.Visibility = Visibility.Hidden;
                bt3.Visibility = Visibility.Hidden;
                bt4.Visibility = Visibility.Visible;
                bt5.Visibility = Visibility.Hidden;
                txt1.Visibility = Visibility.Hidden;
                txt2.Visibility = Visibility.Hidden;
                txt3.Visibility = Visibility.Hidden;
                txt4.Visibility = Visibility.Visible;
                txt5.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbll2.Visibility = Visibility.Hidden;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Visible;
                lbl5.Visibility = Visibility.Hidden;
            }else if (cb.SelectedItem == od5)
            {
                Button.Visibility = Visibility.Hidden;
                bt2.Visibility = Visibility.Hidden;
                bt3.Visibility = Visibility.Hidden;
                bt4.Visibility = Visibility.Hidden;
                bt5.Visibility = Visibility.Visible;
                txt1.Visibility = Visibility.Hidden;
                txt2.Visibility = Visibility.Hidden;
                txt3.Visibility = Visibility.Hidden;
                txt4.Visibility = Visibility.Hidden;
                txt5.Visibility = Visibility.Visible;
                lbl1.Visibility = Visibility.Hidden;
                lbll2.Visibility = Visibility.Hidden;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Hidden;
                lbl5.Visibility = Visibility.Visible;
            }
            else
            {
                Button.Visibility = Visibility.Hidden;
                bt2.Visibility = Visibility.Hidden;
                bt3.Visibility = Visibility.Hidden;
                bt4.Visibility = Visibility.Hidden;
                bt5.Visibility = Visibility.Hidden;
                txt1.Visibility = Visibility.Hidden;
                txt2.Visibility = Visibility.Hidden;
                txt3.Visibility = Visibility.Hidden;
                txt4.Visibility = Visibility.Hidden;
                txt5.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbll2.Visibility = Visibility.Hidden;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Hidden;
                lbl5.Visibility = Visibility.Hidden;
            }

        }

        private void Bt4_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                SqlCommand k1 = new SqlCommand("insert into img(imgdeger,imgkac) values (@deger,'4')", baglanti);
                k1.Parameters.AddWithValue("@deger", filename);
                k1.ExecuteNonQuery();
            }
            baglanti.Close();
        }

        private void Bt5_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                SqlCommand k1 = new SqlCommand("insert into img(imgdeger,imgkac) values (@deger,'5')", baglanti);
                k1.Parameters.AddWithValue("@deger", filename);
                k1.ExecuteNonQuery();
            }
            baglanti.Close();
        }

        private void Rd1_Checked(object sender, RoutedEventArgs e)
        {
            imgclock = "numerals.jpg";
        }

        private void Rd2_Checked(object sender, RoutedEventArgs e)
        {
            imgclock = "29ee068.jpg";
        }
    }
}

