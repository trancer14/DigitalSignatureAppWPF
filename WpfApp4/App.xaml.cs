using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application a = new Application();

            var k = myinics.GetValue("Lisans Anahtari");


            bool lisans = WpfApp4.Lisans.LisansKontrol(k);

            if (string.IsNullOrEmpty(k) || !lisans)
            {
                Window3 yeni = new Window3();
                yeni.ShowDialog();

                if (Window3.lis == 0)
                {
                    MessageBox.Show("Hatalı Lisans Anahtarı Girdiniz");

                }
                else
                {
                    MessageBox.Show("Lisans Aktive Edilmiştir!");
                }
                return;
            }

            a.StartupUri = new Uri("Window1.xaml", System.UriKind.Relative);
            a.Run();
        }
    }
}
