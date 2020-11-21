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
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Window3.xaml etkileşim mantığı
    /// </summary>
    public partial class Window3 : Window
    {
        public static int lis = 0;
        public Window3()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myinics.SetValue("Lisans Anahtari", txtLisans.Text);
            bool lisans = Lisans.LisansKontrol(txtLisans.Text);
            if (lisans)
            {
                lis = 1;
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
