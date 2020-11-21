using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime CurrentDateAndTime { get; set; }
        public string api = "3e29e62e2ddf6dd3d2ebd28aed069215";
        public MainWindow()
        {
            InitializeComponent();

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/" + Window2.imgclock));
            e6.Fill = myBrush;
            e1.Fill = myBrush;
            e2.Fill = myBrush;
            e3.Fill = myBrush;
            e4.Fill = myBrush;
            e5.Fill = myBrush;

            DispatcherTimer dayTimer = new DispatcherTimer();
            DispatcherTimer ph = new DispatcherTimer();
            dayTimer.Interval = TimeSpan.FromMilliseconds(500);
            dayTimer.Tick += new EventHandler(dayTimer_Tick);
            dayTimer.Start();
            ph.Interval = TimeSpan.FromHours(1);
            ph.Tick += new EventHandler(ph_Tick);
            ph.Start();

            string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);
            string usd = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'USD'] / BanknoteBuying").InnerXml;
            string eur = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'EUR'] / BanknoteBuying").InnerXml;
            string gbp = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'GBP'] / BanknoteBuying").InnerXml;
            string sar = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'SAR'] / BanknoteBuying").InnerXml;
            string jpy = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'JPY'] / BanknoteBuying").InnerXml;
            string rub = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'RUB'] / ForexBuying").InnerXml;
            string irr = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'IRR'] / ForexBuying").InnerXml;
            string qar = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'QAR'] / ForexBuying").InnerXml;

            string usdkısa = usd.Substring(0, 4);
            string eurkısa = eur.Substring(0, 4);
            string gbpkısa = gbp.Substring(0, 4);
            string sarkısa = sar.Substring(0, 4);
            string jpykısa = jpy.Substring(0, 4);
            string rubkısa = rub.Substring(0, 4);
            string irrkısa = irr.Substring(0, 4);
            string qarkısa = qar.Substring(0, 4);

            label1.Content = "USD/TRY =" + usdkısa;
            label2.Content = "EUR/TRY =" + eurkısa;
            label3.Content = "GBP/TRY =" + gbpkısa;
            label4.Content = "SAR/TRY =" + sarkısa;
            //label5.Content = "RUB/TRY =" + rubkısa;
            //label6.Content = "IRR/TRY =" + irrkısa;
            //label7.Content = "QAR/TRY =" + qarkısa;
            string istanbul = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul,tr&mode=xml&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(istanbul);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblist.Content = sicaklik.ToString().Substring(0, 2) + "°";
            string imgist1 = hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgist.Source = new BitmapImage(
    new Uri("http://openweathermap.org/img/wn/" + imgist1 + "@2x.png"));
            string ny = "http://api.openweathermap.org/data/2.5/weather?id=5128581&mode=xml&units=metric&appid=" + api;
            XDocument havany = XDocument.Load(ny);
            var sicaklikny = havany.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblny.Content = sicaklikny.ToString().Substring(0, 2) + "°";
            string imgny1 = havany.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgny.Source = new BitmapImage(
    new Uri("http://openweathermap.org/img/wn/" + imgny1 + "@2x.png"));
            string lon = "http://api.openweathermap.org/data/2.5/weather?id=2643743&mode=xml&units=metric&appid=" + api;
            XDocument havalon = XDocument.Load(lon);
            var sicakliklon = havalon.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lbllon.Content = sicakliklon.ToString().Substring(0, 2) + "°";
            string imglon1 = havalon.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imglon.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imglon1 + "@2x.png"));
            string dub = "http://api.openweathermap.org/data/2.5/weather?id=292223&mode=xml&units=metric&appid=" + api;
            XDocument havadub = XDocument.Load(dub);
            var sicaklikdub = havadub.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lbldub.Content = sicaklikdub.ToString().Substring(0, 2) + "°";
            string imgdub1 = havadub.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgdub.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imgdub1 + "@2x.png"));
            string mos = "http://api.openweathermap.org/data/2.5/weather?id=524901&mode=xml&units=metric&appid=" + api;
            XDocument havamos = XDocument.Load(mos);
            var sicaklikmos = havamos.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblmos.Content = sicaklikmos.ToString().Substring(0, 2) + "°";
            string imgmos1 = havamos.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgmos.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imgmos1 + "@2x.png"));
            string ber = "http://api.openweathermap.org/data/2.5/weather?id=2950159&mode=xml&units=metric&appid=" + api;
            XDocument havaber = XDocument.Load(ber);
            var sicaklikber = havaber.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblber.Content = sicaklikber.ToString().Substring(0, 2) + "°";
            string imgber1 = havaber.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgber.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imgber1 + "@2x.png"));
            //    string par = "http://api.openweathermap.org/data/2.5/weather?id=2988507&mode=xml&units=metric&appid=" + api;
            //    XDocument havapar = XDocument.Load(par);
            //    var sicaklikpar = havapar.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //    lblpar.Content = "PARIS:" + sicaklikpar.ToString() + "°";
            //    string imgpar1 = havapar.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            //    imgpar.Source = new BitmapImage(
            //new Uri("http://openweathermap.org/img/wn/" + imgpar1 + "@2x.png"));
            //    string rom = "http://api.openweathermap.org/data/2.5/weather?id=3169070&mode=xml&units=metric&appid=" + api;
            //    XDocument havarom = XDocument.Load(rom);
            //    var sicaklikrom = havarom.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //    lblrom.Content = "ROME:" + sicaklikrom.ToString() + "°";
            //    string imgrom1 = havarom.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            //    imgrom.Source = new BitmapImage(
            //new Uri("http://openweathermap.org/img/wn/" + imgrom1 + "@2x.png"));
            //    string tok = "http://api.openweathermap.org/data/2.5/weather?id=1850147&mode=xml&units=metric&appid=" + api;
            //    XDocument havatok = XDocument.Load(tok);
            //    var sicakliktok = havatok.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //    lbltok.Content = "TOKYO:" + sicakliktok.ToString() + "°";
            //    string imgtok1 = havatok.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            //    imgtok.Source = new BitmapImage(
            //new Uri("http://openweathermap.org/img/wn/" + imgtok1 + "@2x.png"));
            //    string ati = "http://api.openweathermap.org/data/2.5/weather?id=264371&mode=xml&units=metric&appid=" + api;
            //    XDocument havaati = XDocument.Load(ati);
            //    var sicaklikati = havaati.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //    lblati.Content = "ATHENS:" + sicaklikati.ToString() + "°";
            //    string imgati1 = havaati.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            //    imgati.Source = new BitmapImage(
            //new Uri("http://openweathermap.org/img/wn/" + imgati1 + "@2x.png"));
            //    string pek = "http://api.openweathermap.org/data/2.5/weather?id=1816670&mode=xml&units=metric&appid=" + api;
            //    XDocument havapek = XDocument.Load(pek);
            //    var sicaklikpek = havapek.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //    lblpek.Content = "BEIJING:" + sicaklikpek.ToString() + "°";
            //    string imgpek1 = havapek.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            //    imgpek.Source = new BitmapImage(
            //new Uri("http://openweathermap.org/img/wn/" + imgpek1 + "@2x.png"));
            //    string sel = "http://api.openweathermap.org/data/2.5/weather?id=1835848&mode=xml&units=metric&appid=" + api;
            //    XDocument havasel = XDocument.Load(sel);
            //    var sicakliksel = havasel.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //    lblsel.Content = "SEOUL:" + sicakliksel.ToString() + "°";
            //    string imgsel1 = havasel.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            //    imgsel.Source = new BitmapImage(
            //new Uri("http://openweathermap.org/img/wn/" + imgsel1 + "@2x.png"));
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            baglanti.Open();

            SqlCommand k2 = new SqlCommand("select top 1 imgdeger from img where imgkac=1 order by imgid desc", baglanti);
            SqlDataReader dr = k2.ExecuteReader();
            string str = null;
            while (dr.Read())
            {
                str = dr[0].ToString();
            }
            imgy1.Source = new BitmapImage(new Uri(str));
            baglanti.Close();
            baglanti.Open();
            SqlCommand k3 = new SqlCommand("select top 1 imgdeger from img where imgkac=2 order by imgid desc", baglanti);
            SqlDataReader dr2 = k3.ExecuteReader();
            string str2 = null;
            while (dr2.Read())
            {
                str2 = dr2[0].ToString();
            }
            imgy2.Source = new BitmapImage(new Uri(str2));
            baglanti.Close();
            baglanti.Open();
            SqlCommand k4 = new SqlCommand("select top 1 imgdeger from img where imgkac=3 order by imgid desc", baglanti);
            SqlDataReader dr3 = k4.ExecuteReader();
            string str3 = null;
            while (dr3.Read())
            {
                str3 = dr3[0].ToString();
            }
            imgy3.Source = new BitmapImage(new Uri(str3));

            baglanti.Close();
            baglanti.Open();
            SqlCommand k = new SqlCommand("select top 1 imgdeger from img where imgkac=4 order by imgid desc", baglanti);
            SqlDataReader drr = k.ExecuteReader();
            string strr = null;
            while (drr.Read())
            {
                strr = drr[0].ToString();
            }
            imgy4.Source = new BitmapImage(new Uri(strr));

            baglanti.Close();
            baglanti.Open();
            SqlCommand k0 = new SqlCommand("select top 1 imgdeger from img where imgkac=5 order by imgid desc", baglanti);
            SqlDataReader dr0 = k0.ExecuteReader();
            string str0 = null;
            while (dr0.Read())
            {
                str0 = dr0[0].ToString();
            }
            imgy5.Source = new BitmapImage(new Uri(str0));

            baglanti.Close();
            baglanti.Open();
            SqlCommand k5 = new SqlCommand("select top 1 textin from text where textdeger=1 order by textid desc", baglanti);
            SqlDataReader dr4 = k5.ExecuteReader();
            string str4 = null;
            while (dr4.Read())
            {
                str4 = dr4[0].ToString();
            }
            txtin1.Text = str4;

            baglanti.Close();
            baglanti.Open();
            SqlCommand k6 = new SqlCommand("select top 1 textin from text where textdeger=2 order by textid desc", baglanti);
            SqlDataReader dr5 = k6.ExecuteReader();
            string str5 = null;
            while (dr5.Read())
            {
                str5 = dr5[0].ToString();
            }
            txtin2.Text = str5;

            baglanti.Close();
            baglanti.Open();
            SqlCommand k7 = new SqlCommand("select top 1 textin from text where textdeger=3 order by textid desc", baglanti);
            SqlDataReader dr6 = k7.ExecuteReader();
            string str6 = null;
            while (dr6.Read())
            {
                str6 = dr6[0].ToString();
            }

            txtin3.Text = str6;
            baglanti.Close();
            baglanti.Open();
            SqlCommand k9 = new SqlCommand("select top 1 textin from text where textdeger=4 order by textid desc", baglanti);
            SqlDataReader dr8 = k9.ExecuteReader();
            string str8 = null;
            while (dr8.Read())
            {
                str8 = dr8[0].ToString();
            }

            txtin4.Text = str8;
            baglanti.Close();
            baglanti.Open();
            SqlCommand k10 = new SqlCommand("select top 1 textin from text where textdeger=5 order by textid desc", baglanti);
            SqlDataReader dr9 = k10.ExecuteReader();
            string str9 = null;
            while (dr9.Read())
            {
                str9 = dr9[0].ToString();
            }

            txtin5.Text = str9;
            baglanti.Close();
            baglanti.Open();
            SqlCommand k8 = new SqlCommand("select top 1 imgdeger from img where imgkac=0 order by imgid desc", baglanti);
            SqlDataReader dr7 = k8.ExecuteReader();
            string str7 = null;
            while (dr7.Read())
            {
                str7 = dr7[0].ToString();
            }
            imglogo.Source = new BitmapImage(new Uri(str7));
            imglogo2.Source = new BitmapImage(new Uri(str7));
            imglogo3.Source = new BitmapImage(new Uri(str7));
            baglanti.Close();
            baglanti.Open();
            SqlCommand a = new SqlCommand("select top 1 textin from text where textdeger=0 order by textid desc", baglanti);
            SqlDataReader dra = a.ExecuteReader();
            string stra = null;
            while (dra.Read())
            {
                stra = dra[0].ToString();
            }

            txthos.Text = stra;
            txthos2.Text = stra;
            baglanti.Close();

        }

        private void ph_Tick(object sender, EventArgs e)
        {

            string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);
            string usd = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'USD'] / BanknoteBuying").InnerXml;
            string eur = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'EUR'] / BanknoteBuying").InnerXml;
            string gbp = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'GBP'] / BanknoteBuying").InnerXml;
            string sar = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'SAR'] / BanknoteBuying").InnerXml;
            string jpy = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'JPY'] / BanknoteBuying").InnerXml;
            string rub = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'RUB'] / ForexBuying").InnerXml;
            string irr = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'IRR'] / ForexBuying").InnerXml;
            string qar = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod = 'QAR'] / ForexBuying").InnerXml;

            string usdkısa = usd.Substring(0, 4);
            string eurkısa = eur.Substring(0, 4);
            string gbpkısa = gbp.Substring(0, 4);
            string sarkısa = sar.Substring(0, 4);
            string jpykısa = jpy.Substring(0, 4);
            string rubkısa = rub.Substring(0, 4);
            string irrkısa = irr.Substring(0, 4);
            string qarkısa = qar.Substring(0, 4);

            label1.Content = "USD/TRY =" + usdkısa;
            label2.Content = "EUR/TRY =" + eurkısa;
            label3.Content = "GBP/TRY =" + gbpkısa;
            label4.Content = "SAR/TRY =" + sarkısa;
            //label5.Content = "RUB/TRY =" + rubkısa;
            //label6.Content = "IRR/TRY =" + irrkısa;
            //label7.Content = "QAR/TRY =" + qarkısa;

            string istanbul = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul,tr&mode=xml&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(istanbul);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblist.Content = sicaklik.ToString().Substring(0, 2) + "°";
            string imgist1 = hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgist.Source = new BitmapImage(
    new Uri("http://openweathermap.org/img/wn/" + imgist1 + "@2x.png"));
            string ny = "http://api.openweathermap.org/data/2.5/weather?id=5128581&mode=xml&units=metric&appid=" + api;
            XDocument havany = XDocument.Load(ny);
            var sicaklikny = havany.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblny.Content = sicaklikny.ToString().Substring(0, 2) + "°";
            string imgny1 = havany.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgny.Source = new BitmapImage(
    new Uri("http://openweathermap.org/img/wn/" + imgny1 + "@2x.png"));
            string lon = "http://api.openweathermap.org/data/2.5/weather?id=2643743&mode=xml&units=metric&appid=" + api;
            XDocument havalon = XDocument.Load(lon);
            var sicakliklon = havalon.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lbllon.Content =sicakliklon.ToString().Substring(0, 2) + "°";
            string imglon1 = havalon.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imglon.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imglon1 + "@2x.png"));
            string dub = "http://api.openweathermap.org/data/2.5/weather?id=292223&mode=xml&units=metric&appid=" + api;
            XDocument havadub = XDocument.Load(dub);
            var sicaklikdub = havadub.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lbldub.Content =  sicaklikdub.ToString().Substring(0, 2) + "°";
            string imgdub1 = havadub.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgdub.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imgdub1 + "@2x.png"));
            string mos = "http://api.openweathermap.org/data/2.5/weather?id=524901&mode=xml&units=metric&appid=" + api;
            XDocument havamos = XDocument.Load(mos);
            var sicaklikmos = havamos.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblmos.Content = sicaklikmos.ToString().Substring(0, 2) + "°";
            string imgmos1 = havamos.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgmos.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imgmos1 + "@2x.png"));
            string ber = "http://api.openweathermap.org/data/2.5/weather?id=2950159&mode=xml&units=metric&appid=" + api;
            XDocument havaber = XDocument.Load(ber);
            var sicaklikber = havaber.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            lblber.Content = sicaklikber.ToString().Substring(0, 2) + "°";
            string imgber1 = havaber.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            imgber.Source = new BitmapImage(
        new Uri("http://openweathermap.org/img/wn/" + imgber1 + "@2x.png"));
        }

        public void dayTimer_Tick(object sender, EventArgs e)
        {

            RotateTransform hourtransform = new RotateTransform((DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5));
            lnhour.RenderTransform = hourtransform;
            RotateTransform mintransform = new RotateTransform(DateTime.Now.Minute * 6);
            lnmin.RenderTransform = mintransform;
            RotateTransform sectransform = new RotateTransform(DateTime.Now.Second * 6);
            lnsec.RenderTransform = sectransform;
            RotateTransform hourNYtransform = new RotateTransform(((DateTime.Now.Hour - 7) * 30) + (DateTime.Now.Minute * 0.5));
            lnhourNY.RenderTransform = hourNYtransform;
            lnminNY.RenderTransform = mintransform;
            lnsecNY.RenderTransform = sectransform;
            RotateTransform hourLONtransform = new RotateTransform(((DateTime.Now.Hour - 2) * 30) + (DateTime.Now.Minute * 0.5));
            lnhourLON.RenderTransform = hourLONtransform;
            lnminLON.RenderTransform = mintransform;
            lnsecLON.RenderTransform = sectransform;
            RotateTransform hourDUBtransform = new RotateTransform(((DateTime.Now.Hour + 1) * 30) + (DateTime.Now.Minute * 0.5));
            lnhourDUB.RenderTransform = hourDUBtransform;
            lnminDUB.RenderTransform = mintransform;
            lnsecDUB.RenderTransform = sectransform;
            RotateTransform hourBERtransform = new RotateTransform(((DateTime.Now.Hour - 1) * 30) + (DateTime.Now.Minute * 0.5));
            lnhourBER.RenderTransform = hourBERtransform;
            lnminBER.RenderTransform = mintransform;
            lnsecBER.RenderTransform = sectransform;
            RotateTransform hourTOKtransform = new RotateTransform(((DateTime.Now.Hour) * 30) + (DateTime.Now.Minute * 0.5));
            lnhourTOK.RenderTransform = hourTOKtransform;
            lnminTOK.RenderTransform = mintransform;
            lnsecTOK.RenderTransform = sectransform;
            LBLTARIH.Content = DateTime.Now.Day + "/" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + "/" + DateTime.Now.Year;
            LBLsaat.Content = DateTime.Now.ToString("HH:mm:ss");

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                
            }
        }


    }
}
