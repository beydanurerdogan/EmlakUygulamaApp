namespace EmlakUygulamaApp
{
    class Ev
    {
        public int odasayisi { get; set; }
        public int katno { get; set; }
        public double alan { get; set; }
    }
    class SatilikEv : Ev
    {
        public double satisfiyati { get; set; }

    }
    class KiralikEv : Ev
    {
        public double kira { get; set; }
        public double depozito { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SatilikEv> satilik = new List<SatilikEv>();
            List<KiralikEv> kiralik = new List<KiralikEv>();

            Console.WriteLine("Emlakcı uygulamasına hoşgeldiniz\n");
            bool secim = true;
            while (secim)
            {
                Console.WriteLine("İşlem yapmak istediğiniz ev tipini seçiniz:\n1- Kiralık Ev\n2- Satılık Ev");
                byte tip = byte.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz:\n1- Kayıtlı ev bilgilerini getirme\n2- Yeni kayıt ekleme");
                byte islem = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                if (tip == 1 && islem == 1)
                {
                    string dosyayolu = "Kiralık_Ev.txt";
                    if (dosyakontrol(dosyayolu))
                    {
                        Console.WriteLine("Geçerli kayıt bulunamadı.");
                    }
                    else
                    {

                        string[] satirlar = File.ReadAllLines(dosyayolu);
                        foreach (string satir in satirlar)
                        {
                            Console.WriteLine(satir);
                        }
                    }

                }
                else if (tip == 1 && islem == 2)
                {
                    KiralikEv ke = Kbilgi();
                    kiralik.Add(ke);
                    kayit("Kiralık_Ev.txt", ke);
                }
                else if (tip == 2 && islem == 1)
                {
                    string dosyayolu = "Satılık_Ev.txt";
                    if (dosyakontrol(dosyayolu))
                    {
                        Console.WriteLine("Geçerli kayıt bulunamadı.");
                    }
                    else
                    {
                        string[] satirlar = File.ReadAllLines(dosyayolu);
                        foreach (string satir in satirlar)
                        {
                            Console.WriteLine(satir);
                        }

                    }

                }
                else if (tip == 2 && islem == 2)
                {
                    SatilikEv se = Sbilgi();
                    satilik.Add(se);
                    kayit("Satılık_Ev.txt", se);
                }
                while (true)
                {
                    Console.WriteLine("Başla bir işlem yapmak istermisiniz? evet/hayır");
                    string devam = Console.ReadLine().ToLower();
                    if (devam == "evet")
                    {
                        break;
                    }
                    else if (devam == "hayır")
                    {
                        secim = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz karakter girdiniz tekrar deneyiniz.");

                    }
                }
            }
        }
        static SatilikEv Sbilgi()
        {
            SatilikEv se = new SatilikEv();
            Console.WriteLine("Oda sayısını giriniz: ");
            se.odasayisi = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Kat numarasını giriniz: ");
            se.katno = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Alanını giriniz: ");
            se.alan = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Satış Fiyatını giriniz: ");
            se.satisfiyati = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Ev bilgileri kaydedildi");
            return se;
        }
        static KiralikEv Kbilgi()
        {
            KiralikEv ke = new KiralikEv();
            Console.WriteLine("Oda sayısını giriniz: ");
            ke.odasayisi = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Kat numarasını giriniz: ");
            ke.katno = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Alanını giriniz: ");
            ke.alan = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Kira Fiyatını giriniz: ");
            ke.kira = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Depozito Fiyatını giriniz: ");
            ke.depozito = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Ev bilgileri kaydedildi");
            return ke;
        }
        static void kayit(string dadi, SatilikEv sa)
        {
            using (StreamWriter yaz = File.AppendText(dadi))
            {
                yaz.WriteLine($"Oda Sayısı: {sa.odasayisi}");
                yaz.WriteLine($"Alan: {sa.alan}");
                yaz.WriteLine($"Kat No: {sa.katno}");
                yaz.WriteLine($"Satış Fiyatı: {sa.satisfiyati}");
                yaz.WriteLine();
            }
        }
        static void kayit(string dadi, KiralikEv ke)
        {

            using (StreamWriter yaz = File.AppendText(dadi))
            {
                yaz.WriteLine($"Oda Sayısı: {ke.odasayisi}");
                yaz.WriteLine($"Alan: {ke.alan}");
                yaz.WriteLine($"Kat No: {ke.katno}");
                yaz.WriteLine($"Kira Fiyatı: {ke.kira}");
                yaz.WriteLine($"Depozito: {ke.depozito}");
                yaz.WriteLine();
            }
        }
        static bool dosyakontrol(string dosyayolu)
        {
            if (File.Exists(dosyayolu))
            {
                string[] satirlar = File.ReadAllLines(dosyayolu);
                if (satirlar.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

    }

}
