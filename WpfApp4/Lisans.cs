using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.ServiceReference2;

namespace WpfApp4
{
    class Lisans
    {
        static BasicHttpBinding Binding
        {
            get
            {
                return new BasicHttpBinding();
            }
        }
        static EndpointAddress EndPoint
        {
            get
            {
                return new EndpointAddress("http://servis.saferecharge.xyz/Lisans.asmx");
            }
        }
        static ServiceReference2.LisansSoapClient Client
        {
            get
            {
                return new LisansSoapClient(Binding, EndPoint);
            }
        }
        static string Metin
        {
            get
            {
                return "979bacd12cc81d1e61250d13936303a7";
            }
        }
        public static bool LisansKontrol(string key)
        {
            LisansTalep talep = new LisansTalep();
            talep.Key = key;
            talep.HDD = HDDNumber();
            talep.Tarih = DateTime.Now;
            talep.Hash = Hash(key + talep.HDD, Metin);
            var cevap = Client.LisansDogrulama(talep);
            return cevap.DogrulamaKodu == 1;
        }
        public static string HDDNumber()
        {
            ManagementObjectSearcher s = new ManagementObjectSearcher("Select * from Win32_Processor");
            var r = s.Get();
            string sn = "";
            foreach (var item in r)
            {
                sn = item["ProcessorId"].ToString();
                break;
            }
            return sn;
        }
        public static string Hash(string metin, string key)
        {
            HMACMD5 md = new HMACMD5(Encoding.UTF8.GetBytes(key));
            byte[] buffer = Encoding.UTF8.GetBytes(metin);
            byte[] hash = md.ComputeHash(buffer);
            string res = "";
            foreach (byte item in hash)
            {
                res += item.ToString("x2");
            }
            return res;
        }
    }
}
