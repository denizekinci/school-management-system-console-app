using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DenizOBSDuzenleme
{
    class Program
    {

        static List<Ogrenci> Ogrenciler;
        static Ogrenci ogr;



        static bool programCikis = false; //programda çıkış yazıldığında çıkış yapılabilmesi için. bkz:OgrenciYonetimSistemiApp()

        static void Main(string[] args)
        {
            OgrenciYonetimSistemiApp();
        }

        static void OgrenciYonetimSistemiApp()
        {
            SahteVeriGir(); //test yapmak için 4 adet sahte veri girişi ekledim, öğrenci noları 15 25 35 45
            try
            {

                Menu();

                while (programCikis == false)
                {
                    MenuGiris();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Hata Gerçekleşti.");
                Console.WriteLine(e.Message);
                //  throw e;
            }
            finally
            {
                Console.WriteLine();
                Menu();

            }

        }

        #region MENU ISLEMLERI
        static public void Menu() //MenuIslem, Menu() içerisinde çağırılıyor.
        {
            Console.WriteLine("------Öğrenci Yönetim Sistemi  -----                              ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine(" 1 - Öğrenci Gir                                                  ");
            Console.WriteLine(" 2 - Not Gir                                                      ");
            Console.WriteLine(" 3 - Öğrencinin ortalamasını gör                                  ");
            Console.WriteLine(" 4 - Öğrencinin adresini gir                                      ");
            Console.WriteLine(" 5 - Bütün Öğrencileri Listele                                    ");
            Console.WriteLine(" 6 - Şubeye Göre Öğrencileri Listele                              ");
            Console.WriteLine(" 7 - Öğrencinin notlarını görüntüle                               ");
            Console.WriteLine(" 8 - Sınıfın Not Ortalamasını Gör                                 ");
            Console.WriteLine(" 9 - Cinsiyetine göre öğrenci listele                             ");
            Console.WriteLine("10 - Şu tarihten sonra doğan öğrencileri listele                  ");
            Console.WriteLine("11 - Tüm öğrencileri semtlerine göre gruplayarak öğrenci listele  ");
            Console.WriteLine("12 - Okuldaki En başarılı 5 öğrenciyi listele                     ");
            Console.WriteLine("13 - Okuldaki En başarısız 3 öğrenciyi listele                    ");
            Console.WriteLine("14 - Sınıftaki En başarılı 5 öğrenciyi listele                    ");
            Console.WriteLine("15 - Sınıftaki En başarısız 3 öğrenciyi listele                   ");
            Console.WriteLine("16 - Öğrenci için değerlendirme gir                               ");
            Console.WriteLine("17 - Öğrencinin değerlendirmesini gör                             ");
            Console.WriteLine("18 - Öğrencinin okuduğu kitabı gir                                ");
            Console.WriteLine("19 - Öğrencinin okuduğu kitapları listele                         ");
            Console.WriteLine("20 - Öğrencinin okuduğu son kitabı görüntüle                      ");
            Console.WriteLine("21 - Öğrenci sil                                                  ");
            Console.WriteLine("22 - Öğrenci güncelle                                             ");
            Console.WriteLine("23 - Öğrenci Bilgilerini görüntüle                                ");
            Console.WriteLine("                                                                  ");
            MenuIslem();

        }

        static public void MenuGiris() //menüye dön / çıkış yap kısmı için olan liste
        {
            Console.WriteLine();
            Console.WriteLine("Çıkış yapmak için “çıkış” yazıp “enter”a basın.                 ");
            Console.WriteLine("Menüyü tekrar listelemek için “menu” yazıp “enter”a basın.");
            Console.Write("Yapmak istediğiniz işlemi seçiniz: ");

            string menusecim = Console.ReadLine();
            Console.WriteLine();
            if (menusecim.ToUpper() == "ÇIKIŞ")
            {
                programCikis = true;
                Console.WriteLine("Çıkış yapılıyor...");
            }
            else if (menusecim.ToUpper() == "MENU")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir giriş yapın.");
            }
        }

        public static void MenuIslem() //22 seçenekli menü için işlem listesi
        {
            int secim = SecimAl();
            Console.WriteLine();
            switch (secim)
            {
                case 1:
                    OgrenciGir1();
                    break;
                case 2:
                    NotGir2();
                    break;
                case 3:
                    OgrenciOrtalama3();
                    break;
                case 4:
                    AdresGir4();
                    break;
                case 5:
                    ButunOgrencileriListele5();
                    break;
                case 6:
                    SubeyeGoreListele6();
                    break;
                case 7:
                    NotlarıGor7();
                    break;
                case 8:
                    SınıfınNotOrtalama8();
                    break;
                case 9:
                    CinsiyetineGoreListele9();
                    break;
                case 10:
                    TariheGoreListele10();
                    break;
                case 11:
                    SemtlereGoreListele11();
                    break;
                case 12:
                    OkulEnBasariliBesOgrenci12();
                    break;
                case 13:
                    OkulEnBasarisizUcOgrencisi13();
                    break;
                case 14:
                    SınıfEnBasarılıBesOgrenci14();
                    break;
                case 15:
                    SınıfBasarisizUcOgrenci15();
                    break;
                case 16:
                    DegerlendirmeGir16Try();
                    break;
                case 17:
                    DegerlendirmeGor17();
                    break;
                case 18:
                    KitapGir18Try();
                    break;
                case 19:
                    KitaplariListele19();
                    break;
                case 20:
                    KitaplarSonOkunan20();
                    break;
                case 21:
                    OgrenciSil21();
                    break;
                case 22:
                    OgrenciGuncelle22();
                    break;
                case 23:
                    OgrencininButunBilgileriniGor23();
                    break;
                default:

                    return;

            }

        }

        #endregion

        #region ANA MENU METODLARI
        public static void OgrenciGir1() //Menüdeki metotların rahat bulunabilmesi için sonlarına sayılarını yazdım. Siz de böyle yapabilirsiniz.
        {
            Console.Write("Kaç adet öğrenci girişi yapılacağını girin: ");
            int adet = SayiAl();
            Console.WriteLine();

            if (Ogrenciler == null)
            {
                Ogrenciler = new List<Ogrenci>();
            }
            for (int i = 0; i < adet; i++)
            {
                OgrenciEkle(i + 1);
            }
            return;
        }

        public static void NotGir2()
        {
            int girilenNot;
            bool cikis = false;
            while (cikis == false)
            {
                Console.Write("Not gireceğiniz öğrencinin numarasını giriniz: ");
                int noBul = SayiAl();
                Console.WriteLine();
                foreach (Ogrenci ogre in Ogrenciler)
                {

                    if (ogre.No == noBul)
                    {
                        Console.Write("Kaç adet not girmek istediğinizi belirtin: ");
                        int girilecekNotSayisi = SayiAl();
                        for (int i = 0; i < girilecekNotSayisi; i++)
                        {
                            if (girilecekNotSayisi == 0)
                            {
                                MenuGiris();
                            }

                            Console.Write((i + 1) + ". notu girin: ");
                            girilenNot = SayiAl();
                            if (girilenNot >= 0 && girilenNot <= 100)
                            {
                                ogre.NotGir(girilenNot);
                                Console.WriteLine((i + 1) + ". not başarıyla girilmiştir.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Lütfen 0 ile 100 arasında bir sayı girin.");
                                i = i - 1;
                            }
                            cikis = true;

                        }

                    }
                }
                if (cikis == false)
                {
                    Console.WriteLine("Girdiğiniz öğrenci numarası ile kayıtlı öğrenci bulunmamaktadır.");
                    return;
                }
            }
        }

        public static void OgrenciOrtalama3()
        {

            bool cikis = false;

            Console.Write("Ortalamasını görmek istediğiniz öğrencinin numarasını giriniz: ");
            int noBul = SayiAl();
            Console.WriteLine();

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.No == noBul)
                {
                    cikis = true;
                    if (ogre.Notlar == null)
                    {
                        Console.WriteLine(ogre.No + " Numaralı öğrencinin not girişi bulunmamaktadır.");
                    }

                    else if (ogre.Notlar != null)
                    {
                        Console.WriteLine(noBul + " numaralı öğrencinin notları ortalaması: " + ogre.Ortalama);
                    }
                }
            }
            if (cikis == false)
            {

                Console.WriteLine("Girdiğiniz öğrenci numarası ile kayıtlı öğrenci bulunmamaktadır.");

                return;

            }

        }

        public static void AdresGir4()
        {
            Adres girilecekAdres = new Adres();

            bool cikis = false;
            while (cikis == false)
            {
                Console.Write("Adresini gireceğiniz öğrencinin numarasını giriniz: ");
                int noBul = SayiAl();

                Console.WriteLine();
                foreach (Ogrenci ogre in Ogrenciler)
                {
                    if (ogre.No == noBul)
                    {
                        Console.Write("İl: ".PadLeft(15));
                        girilecekAdres.Il = Console.ReadLine().ToUpper();

                        Console.Write("İlçe: ".PadLeft(15));
                        girilecekAdres.Ilce = Console.ReadLine().ToUpper();

                        Console.Write("Mahalle: ".PadLeft(15));
                        girilecekAdres.Mahalle = Console.ReadLine().ToUpper();

                        Console.Write("SokakAdi: ".PadLeft(15));
                        girilecekAdres.SokakAdi = Console.ReadLine().ToUpper();

                        Console.Write("Bina No: ".PadLeft(15));
                        girilecekAdres.BinaNo = SayiAl();

                        Console.Write("Kapı No: ".PadLeft(15));
                        girilecekAdres.KapiNo = SayiAl();

                        Console.WriteLine();
                        ogre.Adresi = girilecekAdres;
                        Console.WriteLine("Adres bilgileri sisteme girilmiştir.");
                        cikis = true;
                    }
                }
                if (cikis == false)
                {
                    Console.WriteLine("Girdiğiniz öğrenci numarası ile kayıtlı öğrenci bulunmamaktadır.");
                    return;
                }

            }
        }

        public static void ButunOgrencileriListele5()
        {
            OgrenciYazmaFormati();

            foreach (Ogrenci ogre in Ogrenciler.OrderBy(o => o.No).ToList())
            {
                OgrenciSiralama(ogre);
            }
        }

        public static void SubeyeGoreListele6()
        {
            Ogrenciler = Ogrenciler.OrderBy(o => o.No).ToList();

            Console.Write("Şube Giriniz: ");
            string sube = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (sube == "A")
            {
                Console.WriteLine("A şubesinin öğrencileri: ");
                Console.WriteLine();
                OgrenciYazmaFormati();

                foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.A).ToList())
                {
                    OgrenciSiralama(ogre);
                }
            }

            if (sube == "B")
            {
                Console.WriteLine("B şubesinin öğrencileri: ");
                Console.WriteLine();
                OgrenciYazmaFormati();

                foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.B).ToList())
                {
                    OgrenciSiralama(ogre);
                }
            }

            if (sube == "C")
            {
                Console.WriteLine("C şubesinin öğrencileri: ");
                Console.WriteLine();
                OgrenciYazmaFormati();

                foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.C).ToList())
                {
                    OgrenciSiralama(ogre);
                }
            }
        }

        public static void NotlarıGor7()
        {
            bool cikis = false;

            Console.Write("Notlarını görmek istediğiniz öğrencinin numarasını giriniz: ");
            int noBul = SayiAl();
            Console.WriteLine();

            foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.No == noBul).ToList())
            {
                cikis = true;

                if (ogre.Notlar != null)
                {

                    Console.WriteLine("Notları:");
                    for (int i = 0; i < ogre.Notlar.Count; i++)
                    {
                        Console.WriteLine(((i + 1) + ". not:").PadRight(15) + ogre.Notlar[i]);
                    }
                }
                else if (ogre.Notlar == null)
                {
                    Console.WriteLine("Ögrencinin not bilgisi bulunmamaktadır.");
                }
            }
            if (cikis == false)
            {

                Console.WriteLine("Girdiğiniz öğrenci numarası ile kayıtlı öğrenci bulunmamaktadır.");

                return;
            }
        }

        static public void SınıfınNotOrtalama8()
        {
            bool cikis = false;
            while (cikis == false)
            {

                float ortalama = 0;
                Console.Write("Şube Giriniz: ");
                string sube = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (sube == "A")
                {
                    List<Ogrenci> ASubesiOgrenciler = Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.A).ToList();//Beyza:list ile tanımlamazsak diğer subeler kaybolur

                    foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.A).ToList())
                    {
                        if (ogre.Notlar == null)
                        {
                            Console.WriteLine("Sistemde eksik not bulunmaktadır.");
                            return;
                        }

                        else
                        {
                            ortalama = ortalama + ogre.Ortalama;
                        }
                    }

                    ortalama = ortalama / ASubesiOgrenciler.Count;
                    Console.WriteLine("A şubesinin öğrencilerinin not ortalaması: {0}".PadLeft(15), ortalama);
                    return;
                }

                if (sube == "B")
                {
                    List<Ogrenci> BSubesiOgrenciler = Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.B).ToList();//Beyza:list ile tanımlamazsak diğer subeler kaybolur

                    foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.B).ToList())
                    {

                        if (ogre.Notlar == null)
                        {
                            Console.WriteLine("Sistemde eksik not bulunmaktadır.");
                            return;
                        }

                        else
                        {
                            ortalama = ortalama + ogre.Ortalama;
                        }

                    }
                    ortalama = ortalama / BSubesiOgrenciler.Count;
                    Console.WriteLine("B şubesinin öğrencilerinin not ortalaması: {0}".PadLeft(15), ortalama);
                    return;
                }

                if (sube == "C")
                {
                    List<Ogrenci> CSubesiOgrenciler = Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.C).ToList();//Beyza:list ile tanımlamazsak diğer subeler kaybolur

                    foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.C).ToList())
                    {

                        if (ogre.Notlar == null)
                        {
                            Console.WriteLine("Sistemde eksik not bulunmaktadır.");
                            return;
                        }

                        else
                        {
                            ortalama = ortalama + ogre.Ortalama;
                        }
                    }

                    ortalama = ortalama / CSubesiOgrenciler.Count;
                    Console.WriteLine("C şubesinin öğrencilerinin not ortalaması: {0}".PadLeft(15), ortalama);
                    return;
                }
            }

        }

        public static void CinsiyetineGoreListele9()
        {
            Console.Write("Kız öğrencileri sıralamak için “K”; erkek öğrencileri sıralamak için “E” yazın: ");
            string secim = Console.ReadLine().ToUpper();
            Console.WriteLine();

            bool kontrol = true;
            while (kontrol)
            {
                if (secim == "K")
                {
                    Console.WriteLine("Okuldaki kız öğrencilerin listesi: ");
                    Console.WriteLine();

                    Console.WriteLine();
                    OgrenciYazmaFormati();
                    foreach (Ogrenci ogre in Ogrenciler)
                    {
                        if (ogre.Cins == Kisi.CINSIYET.Kiz)
                        {
                            OgrenciSiralama(ogre);
                        }
                    }
                    kontrol = false;

                }
                else if (secim == "E")
                {
                    Console.WriteLine("Okuldaki erkek öğrencilerin listesi: ");
                    Console.WriteLine();
                    OgrenciYazmaFormati();
                    foreach (Ogrenci ogre in Ogrenciler)
                    {

                        if (ogre.Cins == Kisi.CINSIYET.Erkek)
                        {
                            OgrenciSiralama(ogre);
                        }
                    }
                    kontrol = false;
                }

                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                    kontrol = false;
                    CinsiyetineGoreListele9();

                }
            }
        }

        public static void TariheGoreListele10()
        {
            Console.WriteLine("Tarih giriniz");
            DateTime tarih = Convert.ToDateTime(Console.ReadLine());
            var query = from ogre in Ogrenciler
                        where ogre.DogumTarihi > tarih
                        select ogre;

            Console.WriteLine();
            OgrenciYazmaFormati();

            //foreach (var result in query)
            {
                foreach (Ogrenci ogre in query)
                {
                    OgrenciSiralama(ogre);
                }
            }
        }

        public static void SemtlereGoreListele11()
        {
            foreach (Ogrenci m in Ogrenciler)
            {
                if (m.Adresi == null)
                {
                    Console.WriteLine("{0} adlı öğrencinin adresi girilmedi", m.Ad + " " + m.Soyad);
                }
            }

            var groupedResult = from s in Ogrenciler
                                where s.Adresi != null
                                group s by s.Adresi.Ilce;


            foreach (var semt in groupedResult)
            {
                Console.WriteLine("Semt: {0}", semt.Key);

                foreach (Ogrenci s in semt)
                    Console.WriteLine("Öğrenci isimleri: {0}", s.Ad + " " + s.Soyad);
            }
        }

        public static void OkulEnBasariliBesOgrenci12()
        {
            bool not = false;

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.Notlar == null)
                {
                    not = true;
                    Console.WriteLine(ogre.No + " Numaralı öğrencinin not girişi bulunmamaktadır.");
                }

            }
            if (not == true)
            {
                return;
            }

            else
            {
                {
                    Console.WriteLine("Okulun en basarılı beş ögrencisi:");
                    Console.WriteLine();
                    OgrenciYazmaFormati();
                    foreach (Ogrenci ogre in Ogrenciler.OrderByDescending(o => o.Ortalama).Take(5).ToList())
                    {
                        OgrenciSiralama(ogre);
                    }
                }
            }
        }

        public static void OkulEnBasarisizUcOgrencisi13()
        {
            bool not = false;

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.Notlar == null)
                {
                    not = true;
                    Console.WriteLine(ogre.No + " Numaralı öğrencinin not girişi bulunmamaktadır.");
                }

            }
            if (not == true)
            {
                return;
            }

            else
            {
                {
                    Console.WriteLine("En başarısız 3 öğrenci:");
                    Console.WriteLine();
                    OgrenciYazmaFormati();
                    foreach (Ogrenci ogre in Ogrenciler.OrderBy(o => o.Ortalama).Take(3).ToList())
                    {
                        OgrenciSiralama(ogre);
                    }
                }
            }
        }

        public static void SınıfEnBasarılıBesOgrenci14()
        {

            bool not = false;

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.Notlar == null)
                {
                    not = true;
                    Console.WriteLine(ogre.No + " Numaralı öğrencinin not girişi bulunmamaktadır.");
                }

            }
            if (not == true)
            {
                return;
            }

            else
            {
                {
                    Console.Write("Şube Giriniz: ");
                    string sube = Console.ReadLine().ToUpper();

                    if (sube == "A")
                    {
                        Console.WriteLine("A şubesinin en basarılı beş ögrencisi:");
                        Console.WriteLine();
                        OgrenciYazmaFormati();

                        foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.A).OrderByDescending(o => o.Ortalama).Take(5).ToList())
                        {
                            OgrenciSiralama(ogre);
                        }
                    }

                    else if (sube == "B")
                    {
                        Console.WriteLine("B şubesinin en basarılı beş ögrencisi:");
                        Console.WriteLine();
                        OgrenciYazmaFormati();

                        foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.B).OrderByDescending(o => o.Ortalama).Take(5).ToList())
                        {
                            OgrenciSiralama(ogre);
                        }
                    }

                    else if (sube == "C")
                    {
                        Console.WriteLine("C şubesinin en basarılı beş ögrencisi: ");
                        Console.WriteLine();
                        OgrenciYazmaFormati();

                        foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.C).OrderByDescending(o => o.Ortalama).Take(5).ToList())
                        {
                            OgrenciSiralama(ogre);
                        }
                    }
                }

            }
        }

        public static void SınıfBasarisizUcOgrenci15()
        {

            bool not = false;

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.Notlar == null)
                {
                    not = true;
                    Console.WriteLine(ogre.No + " Numaralı öğrencinin not girişi bulunmamaktadır.");
                }

            }
            if (not == true)
            {
                return;
            }

            else
            {
                {
                    Console.Write("Şube Giriniz: ");
                    string sube = Console.ReadLine().ToUpper();

                    if (sube == "A")
                    {
                        Console.WriteLine("A şubesinin en basarısız üç ögrencisi: ");
                        Console.WriteLine();
                        OgrenciYazmaFormati();

                        foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.A).OrderBy(o => o.Ortalama).Take(3).ToList())
                        {
                            OgrenciSiralama(ogre);
                        }
                    }

                    else if (sube == "B")
                    {
                        Console.WriteLine("B şubesinin en basarısız üç ögrencisi: ");
                        Console.WriteLine();
                        OgrenciYazmaFormati();

                        foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.B).OrderBy(o => o.Ortalama).Take(3).ToList())
                        {
                            OgrenciSiralama(ogre);
                        }
                    }

                    else if (sube == "C")
                    {
                        Console.WriteLine("C şubesinin en basarısız üç ögrencisi: ");
                        Console.WriteLine();
                        OgrenciYazmaFormati();

                        foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.Subesi == Kisi.SUBE.C).OrderBy(o => o.Ortalama).Take(3).ToList())
                        {
                            OgrenciSiralama(ogre);
                        }
                    }
                }

            }
        }

        public static void DegerlendirmeGir16()
        {
            bool cikis = false;

            Console.WriteLine();

            while (cikis == false)
            {
                Console.Write("Öğrencinin numarasını giriniz:");
                int no = SayiAl();
                foreach (Ogrenci ogre in Ogrenciler)
                {
                    if (no == ogre.No)
                    {
                        Console.WriteLine("Değerlendirme metnini giriniz:");
                        string degerlendirme = Console.ReadLine();

                        ogre.Degerlendirme = IlkHarfBuyuk02(degerlendirme);

                        cikis = true;
                        return;
                    }
                }
                if (cikis == false)
                {
                    Console.WriteLine("Girdiğiniz öğrenci numarası ile kayıtlı öğrenci bulunmamaktadır.");

                }
            }
        }

        public static void DegerlendirmeGir16Try()
        {
            try
            {
                DegerlendirmeGir16();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Hata Gerçekleşti.");
                Console.WriteLine(e.Message);
                DegerlendirmeGir16();
            }
        }

        public static void DegerlendirmeGor17()
        {
            Console.Write("Değerlendirmesini görmek istedğiniz öğrencinin numarasını girin:");
            int no = SayiAl();

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (no == ogre.No)
                {
                    Console.WriteLine(ogre.Degerlendirme);
                }
            }
        }

        public static void KitapGir18()
        {
            string girilenKitap;
            bool cikis = false;
            while (cikis == false)
            {
                Console.Write("Kitap bilgisi gireceğiniz öğrencinin numarasını giriniz: ");
                int noBul = SayiAl();
                Console.WriteLine();
                foreach (Ogrenci ogre in Ogrenciler)
                {

                    if (ogre.No == noBul)
                    {
                        Console.Write("Kaç adet not kitap girmek istediğinizi belirtin: ");
                        int girilecekNotSayisi = SayiAl();
                        int i;
                        for (i = 0; i < girilecekNotSayisi; i++)
                        {

                            Console.Write((i + 1) + ". kitap adını girin: ");
                            girilenKitap = Console.ReadLine().Trim();
                            girilenKitap = IlkHarfBuyuk(girilenKitap);

                            ogre.KitapGir(girilenKitap);

                            cikis = true;


                        }
                        Console.WriteLine("Kitaplar başarıyla eklenmiştir.");
                        return;
                    }
                }
            }
        }

        public static void KitapGir18Try()
        {
            try
            {
                KitapGir18();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Hata Gerçekleşti.");
                Console.WriteLine(e.Message);
                KitapGir18();
            }
        }

        public static void KitaplariListele19()
        {
            Console.Write("Kitap bilgilerini görmek istediğiniz öğrencinin numarasını giriniz: ");
            int noBul = SayiAl();
            Console.WriteLine();

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.No == noBul)
                {
                    Console.WriteLine(noBul + " numaralı öğrencinin okudğu kitaplar:");
                    Console.WriteLine();
                    for (int i = 0; i < ogre.Kitaplar.Count; i++)
                    {
                        Console.WriteLine(((i + 1) + ".Kitap: ") + ogre.Kitaplar[i]);
                    }
                }
            }
        }

        public static void KitaplarSonOkunan20()
        {
            Console.Write("Son okuduğu kitabı görmek istediğiniz öğrencinin öğrenci numarasını girin: ");
            int noBul = SayiAl();
            Console.WriteLine();

            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.No == noBul)
                {
                    int kitapSayisi = ogre.Kitaplar.Count;
                    Console.Write(ogre.No + " nolu öğrencinin okuduğu son kitap: ");
                    Console.WriteLine(ogre.Kitaplar[kitapSayisi - 1]);
                }
            }
        }

        public static void OgrenciSil21()
        {

            Console.Write("Kaldırmak istediğiniz öğrencinin numarasını girin:");
            int no = SayiAl();
            foreach (Ogrenci Ogre in Ogrenciler)
            {
                if (no == Ogre.No)
                {
                    Ogrenciler.Remove(Ogre);
                    break;
                }
            }
            Console.WriteLine("İşleminiz gerçekleştirildi.");
            Console.WriteLine();
        }

        public static void OgrenciGuncelle22()
        {

            Console.Write("Bilgilerini güncellemek istediğiniz öğrencinin numarasını girin:");
            int noBul = SayiAl();

            foreach (Ogrenci ogre2 in Ogrenciler)
            {

                foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.No == noBul).ToList())
                {


                    ButunBilgileriniGor(ogre);
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine();


                    Console.WriteLine(noBul + ". Numaralı öğrenci için: ");
                    Console.WriteLine();

                    Console.WriteLine("1_ Ad");
                    Console.WriteLine("2_Soyad");
                    Console.WriteLine("3_Doğum Tarihi");
                    Console.WriteLine("4_Şubesi");
                    Console.WriteLine("5_Cinsiyeti");
                    Console.WriteLine("6_Ders Notları");
                    Console.WriteLine("7_Çıkış");
                    Console.WriteLine("Güncellemek istediğiniz bilginin yanında yazan rakamı girin:");

                    Guncelleme(ogre);

                    return;
                }

                if (noBul != ogre2.No)
                {
                    Console.WriteLine("Bu numarayla kayıtlı bir öğrenci bulunmamaktadır.");
                    return;
                }

            }
        }

        public static void OgrencininButunBilgileriniGor23()
        {

            bool cikis = false;
            while (cikis == false)
            {
                Console.Write("Bilgilerini görmek istediğiniz öğrencinin numarasını giriniz: ");
                int noBul = SayiAl();

                Console.WriteLine();

                foreach (Ogrenci ogre in Ogrenciler.Where(ogre => ogre.No == noBul).ToList())
                {
                    ButunBilgileriniGor(ogre);

                    return;
                }
            }

        }
        #endregion

        #region YARDIMCI METODLAR

        public static void OgrenciEkle()
        {
            Console.WriteLine(". Öğrencinin: ");
            Ogrenci ogr = new Ogrenci();

            Console.Write("Numarası: ".PadLeft(15));
            ogr.No = SayiAl();
            ogr.No = OgrenciNumarasıKontrolu(ogr.No);

            Console.Write("Adı: ".PadLeft(15));
            ogr.Ad = Console.ReadLine().Trim();
            ogr.Ad = IlkHarfBuyuk(ogr.Ad);

            Console.Write("Soyadı: ".PadLeft(15));
            ogr.Soyad = Console.ReadLine().Trim();
            ogr.Soyad = IlkHarfBuyuk(ogr.Soyad);

            Console.Write(" Doğum Tarihi: ".PadLeft(15));
            ogr.DogumTarihi = TarihAl();
            Ogrenciler.Add(ogr);

            SubeAta();

            CinsiyetAta();
        }

        public static void ButunBilgileriniGor(Ogrenci ogre)
        {
            Console.WriteLine(ogre.No + " numaralı öğrencinin bilgileri: ");
            Console.WriteLine();
            Console.WriteLine("Şubesi:".PadRight(15) + ogre.Subesi);
            Console.WriteLine("Numarası: ".PadRight(15) + ogre.No);
            Console.WriteLine("Adı:".PadRight(15) + ogre.No);
            Console.WriteLine("Soyadı:".PadRight(15) + ogre.No);

            Console.WriteLine("Doğum tarihi:".PadRight(15) + ogre.DogumTarihi);
            Console.WriteLine("Cinsiyeti:".PadRight(15) + ogre.Cins);

            Console.WriteLine();
            Console.WriteLine("Adres Bilgisi:");
            if (ogre.Adresi != null)
            {
                Console.WriteLine();
                Console.WriteLine("İl: ".PadRight(15) + ogre.Adresi.Il);

                Console.WriteLine("İlçe: ".PadRight(15) + ogre.Adresi.Ilce);

                Console.WriteLine("Mahalle: ".PadRight(15) + ogre.Adresi.Mahalle);

                Console.WriteLine("SokakAdi: ".PadRight(15) + ogre.Adresi.SokakAdi);

                Console.WriteLine("Bina No: ".PadRight(15) + ogre.Adresi.BinaNo);

                Console.WriteLine("Kapı No: ".PadRight(15) + ogre.Adresi.KapiNo);
            }
            else if (ogre.Adresi == null)
            {
                Console.WriteLine("Ogrencinin adres bilgisi bulunmamaktadır.");
            }

            Console.WriteLine();
            Console.WriteLine("Not Bilgisi:");
            if (ogre.Notlar != null)
            {
                Console.WriteLine();
                Console.WriteLine("Not Ortalaması:" + ogre.Ortalama);
                Console.WriteLine("Notları:");
                Console.WriteLine();
                for (int i = 0; i < ogre.Notlar.Count; i++)
                {
                    Console.WriteLine(((i + 1) + ". not:").PadRight(15) + ogre.Notlar[i]);
                }
            }
            else if (ogre.Notlar == null)
            {
                Console.WriteLine("Ogrencinin not bilgisi bulunmamaktadır.");
            }

            Console.WriteLine();
            Console.WriteLine("Kitap Bilgisi:");
            if (ogre.Kitaplar != null)
            {
                Console.WriteLine();
                Console.WriteLine("Ogrencinin Okuduğu Kitap sayısı:".PadRight(15) + ogre.KitapSayisi);
                Console.WriteLine("Ogrencinin Okuduğu Kitaplar:");
                Console.WriteLine();
                for (int i = 0; i < ogre.KitapSayisi; i++)
                {
                    Console.WriteLine(((i + 1) + ". kitap:").PadRight(15) + ogre.Kitaplar[i]);
                }
            }

            else if (ogre.KitapSayisi == 0)
            {
                Console.WriteLine("Ogrencinin kitap bilgisi bulunmamaktadır.");
            }

            Console.WriteLine();
            Console.WriteLine("Değerlendirme:");
            if (ogre.Degerlendirme != null)
            {
                Console.WriteLine(ogre.Degerlendirme);
            }

            else if (ogre.Degerlendirme == null)
            {
                Console.WriteLine("Ogrencinin değerlendirme bilgisi bulunmamaktadır.");
            }

        }

        public static void OgrenciEkle(int siraNumarasi)
        {
            Console.WriteLine(siraNumarasi + ". Öğrencinin: ");
            Ogrenci ogr = new Ogrenci();

            Console.Write("Numarası: ".PadLeft(15));
            ogr.No = SayiAl();
            ogr.No = OgrenciNumarasıKontrolu(ogr.No);

            Console.Write("Adı: ".PadLeft(15));
            ogr.Ad = Console.ReadLine().Trim();
            ogr.Ad = IlkHarfBuyuk(ogr.Ad);

            Console.Write("Soyadı: ".PadLeft(15));
            ogr.Soyad = Console.ReadLine().Trim();
            ogr.Soyad = IlkHarfBuyuk(ogr.Soyad);

            Console.Write(" Doğum Tarihi: ".PadLeft(15));
            ogr.DogumTarihi = TarihAl();
            Ogrenciler.Add(ogr);

            bool kontrol = true;
            while (kontrol)
            {
                Console.Write("Şubesi: ".PadLeft(15));
                string sube = Console.ReadLine().ToUpper();

                if (sube == "A")
                {
                    ogr.Subesi = Kisi.SUBE.A;
                    kontrol = false;
                }
                else if (sube == "B")
                {
                    ogr.Subesi = Kisi.SUBE.B;
                    kontrol = false;
                }
                else if (sube == "C")
                {
                    ogr.Subesi = Kisi.SUBE.C;
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Mevcut şubeler A, B ve C'dir. ".PadLeft(15));

                }
            }

            kontrol = true;
            while (kontrol)
            {
                Console.WriteLine("Cinsiyeti".PadLeft(13));
                Console.Write("(E veya K): ".PadLeft(15));
                string cinsiyet = Console.ReadLine().ToUpper();

                if (cinsiyet == "E")
                {
                    ogr.Cins = Kisi.CINSIYET.Erkek;
                    kontrol = false;
                }
                else if (cinsiyet == "K")
                {
                    ogr.Cins = Kisi.CINSIYET.Kiz;
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hatalı giriş yaptınız.");

                }
            }
        }

        public static void SubeAta()
        {
            bool kontrol = true;
            while (kontrol)
            {
                Console.Write("Şubesi: ".PadLeft(15));
                string sube = Console.ReadLine().ToUpper();


                if (sube == "A")
                {
                    ogr.Subesi = Kisi.SUBE.A;
                    kontrol = false;
                }
                else if (sube == "B")
                {
                    ogr.Subesi = Kisi.SUBE.B;
                    kontrol = false;
                }
                else if (sube == "C")
                {
                    ogr.Subesi = Kisi.SUBE.C;
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Mevcut şubeler A, B ve C'dir. ".PadLeft(15));
                }
            }
        }

        public static void CinsiyetAta()
        {
            bool kontrol = true;

            while (kontrol)
            {
                Console.WriteLine("Cinsiyeti".PadLeft(13));
                Console.Write("(E veya K): ".PadLeft(15));
                string cinsiyet = Console.ReadLine().ToUpper();
                if (cinsiyet == "E")
                {
                    ogr.Cins = Kisi.CINSIYET.Erkek;
                    kontrol = false;
                }
                else if (cinsiyet == "K")
                {
                    ogr.Cins = Kisi.CINSIYET.Kiz;
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hatalı giriş yaptınız.");

                }
            }
        }

        public static void SahteVeriGir()
        {
            if (Ogrenciler == null)
            {
                Ogrenciler = new List<Ogrenci>();
            }

            Ogrenci ogr1 = new Ogrenci(15, "Erdem", "Durgun", new DateTime(2000, 5, 6), Kisi.SUBE.C, Kisi.CINSIYET.Erkek);
            Ogrenci ogr2 = new Ogrenci(25, "Ali", "Bardakçı", new DateTime(2000, 3, 2), Kisi.SUBE.B, Kisi.CINSIYET.Erkek);
            Ogrenci ogr3 = new Ogrenci(35, "Ayşe", "Eroğlu", new DateTime(2000, 6, 1), Kisi.SUBE.A, Kisi.CINSIYET.Kiz);
            Ogrenci ogr4 = new Ogrenci(45, "Buse", "Görgün", new DateTime(2000, 6, 7), Kisi.SUBE.C, Kisi.CINSIYET.Kiz);
            Ogrenci ogr5 = new Ogrenci(55, "Talat", "Sahici", new DateTime(2000, 7, 3), Kisi.SUBE.A, Kisi.CINSIYET.Erkek);
            Ogrenci ogr6 = new Ogrenci(65, "Yaren", "Acı", new DateTime(2000, 6, 1), Kisi.SUBE.A, Kisi.CINSIYET.Kiz);
            Ogrenci ogr7 = new Ogrenci(75, "Can", "Atılgan", new DateTime(2000, 3, 5), Kisi.SUBE.B, Kisi.CINSIYET.Erkek);
            Ogrenci ogr8 = new Ogrenci(85, "Isıl", "Ozturk", new DateTime(2000, 4, 8), Kisi.SUBE.A, Kisi.CINSIYET.Kiz);
            Ogrenciler.Add(ogr1);
            Ogrenciler.Add(ogr2);
            Ogrenciler.Add(ogr3);
            Ogrenciler.Add(ogr4);
            Ogrenciler.Add(ogr5);
            Ogrenciler.Add(ogr6);
            Ogrenciler.Add(ogr7);
            Ogrenciler.Add(ogr8);
        }

        #endregion

        #region FORMAT VE VERI ALMA METODLARI

        static public int SayiAl()
        {
            int sayi;


            while (true)
            {
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                Console.WriteLine();
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                Console.Write("Değer girin: ".PadLeft(15));
            }
        }

        static public DateTime TarihAl()
        {
            DateTime tarih;
            while (true)
            {
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarih))
                {
                    return tarih;
                }
                Console.WriteLine();
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                Console.Write("Geçerli bir tarih girin: ");
            }
        }

        public static int SecimAl()
        {
            int secim;
            do
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                secim = SayiAl();
            }
            while (secim < 1 || secim > 23);
            return secim;
        }

        public static string IlkHarfBuyuk(string yazi)  // Girilen metnin kelimelerinin hepsinin ilk harfini büyük harfe çevirir.
        {
            string[] arrYazi = yazi.Split(' ');

            for (int i = 0; i < arrYazi.Length; i++)
            {
                arrYazi[i] = BuyukHarf(arrYazi[i]);
            }

            yazi = string.Join(" ", arrYazi);

            return yazi;
        }

        public static string IlkHarfBuyuk02(string metin) // Girilen paragrafın cümlelerinin hepsinin ilk harfini büyük harfe çevirir.
        {
            string[] dizi = metin.Split(".");

            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = dizi[i].Trim();
                dizi[i] = BuyukHarf(dizi[i]);

            }
            metin = string.Join(". ", dizi);

            return metin;

        }

        public static string BuyukHarf(string kelime)
        {
            string ilkHarfBuyuk = kelime.Substring(0, 1).ToUpper();
            string kelimeKalani = kelime.Substring(1).ToLower();
            return (ilkHarfBuyuk + kelimeKalani);
        }

        public static void OgrenciYazmaFormati() // Öğrenci listelemenin başlık şablonudur.
        {
            Console.WriteLine("  {0}  {1}  {2}  {3}  {4}  {5}", "Sube".PadRight(6), "No".PadRight(6), "Ad".PadRight(20), "Soyad".PadRight(20), "Ortalama".PadRight(10), "Okuduğu Kitap Say");
            Console.WriteLine("-------------------------------------------------------------");
        }

        public static void OgrenciYazmaFormati(string sube, string no, string ad, string soyad, string ortalama, string kitapSayisi)// Öğrencileri listelemenin öğrenci şablonudur.
        {
            Console.WriteLine("  {0}  {1}  {2}  {3}  {4}  {5} ", sube.PadRight(6), no.PadRight(6), ad.PadRight(20), soyad.PadRight(20), ortalama.PadRight(10), kitapSayisi);
        }

        public static void OgrenciSiralama(Ogrenci ogre) // Ogrenci bilgilerini ogrenci yazma formatına göre yazdırır
        {
            if (ogre.Notlar == null && ogre.KitapSayisi != 0)
            {
                OgrenciYazmaFormati(ogre.Subesi.ToString(), ogre.No.ToString(), ogre.Ad, ogre.Soyad, "NA", ogre.KitapSayisi.ToString());
            }

            else if (ogre.KitapSayisi == 0 && ogre.Notlar != null)
            {
                OgrenciYazmaFormati(ogre.Subesi.ToString(), ogre.No.ToString(), ogre.Ad, ogre.Soyad, ogre.Ortalama.ToString(), "0");
            }

            else if (ogre.KitapSayisi == 0 && ogre.Notlar == null)
            {
                OgrenciYazmaFormati(ogre.Subesi.ToString(), ogre.No.ToString(), ogre.Ad, ogre.Soyad, "NA", "0");
            }

            else
            {
                OgrenciYazmaFormati(ogre.Subesi.ToString(), ogre.No.ToString(), ogre.Ad, ogre.Soyad, ogre.Ortalama.ToString(), ogre.KitapSayisi.ToString());
            }
        }

        static public int OgrenciNumarasıKontrolu(int ogrencinumarasi) // Öğrenci Numarasının tekrar etmesini engeller
        {
            bool devam = true;
            foreach (Ogrenci ogre in Ogrenciler)
            {
                if (ogre.No != ogrencinumarasi)
                {
                    devam = true;
                }

                else if (ogre.No == ogrencinumarasi)
                {
                    foreach (Ogrenci ogre2 in Ogrenciler)
                    {
                        while (ogre2.No == ogrencinumarasi)
                        {
                            ogrencinumarasi++;
                        }
                    }
                    Console.WriteLine("Bu öğrenci numarası başka bir öğrenciye aittir.".PadLeft(15));
                    Console.WriteLine(("Atanan yeni öğrenci numarası: " + ogrencinumarasi).PadLeft(15));
                    devam = false;

                }
            }


            return ogrencinumarasi;
        }


        #endregion

        #region GUNCELLEME METODLARI

        public static void Guncelleme(Ogrenci ogre)
        {
            int secim;
            do
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                secim = SayiAl();
            }
            while (secim < 1 || secim > 10);

            switch (secim)
            {
                case 1:
                    Console.Write("Adı: ".PadLeft(15));
                    ogre.Ad = Console.ReadLine().Trim();
                    ogre.Ad = IlkHarfBuyuk(ogre.Ad);
                    break;

                case 2:
                    Console.Write("Soyadı: ".PadLeft(15));
                    ogre.Soyad = Console.ReadLine().Trim();
                    ogre.Soyad = IlkHarfBuyuk(ogre.Soyad);
                    break;
                case 3:
                    Console.Write(" Doğum Tarihi: ".PadLeft(15));
                    ogre.DogumTarihi = TarihAl();
                    break;

                case 4:
                    SubeGuncelleme(ogre);
                    break;

                case 5:
                    CinsiyetGuncelle(ogre);
                    break;

                case 6:
                    NotGuncelleme(ogre);
                    break;

                case 7:
                    Menu();
                    break;
            }
        }

        public static void CinsiyetGuncelle(Ogrenci ogre)
        {
            bool kontrol = true;

            while (kontrol)
            {
                Console.WriteLine("Cinsiyeti".PadLeft(13));
                Console.Write("(E veya K): ".PadLeft(15));
                string cinsiyet = Console.ReadLine().ToUpper();
                if (cinsiyet == "E")
                {
                    ogre.Cins = Kisi.CINSIYET.Erkek;
                    kontrol = false;
                }
                else if (cinsiyet == "K")
                {
                    ogre.Cins = Kisi.CINSIYET.Kiz;
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hatalı giriş yaptınız.");

                }
            }
        }

        public static void SubeGuncelleme(Ogrenci ogre)
        {
            bool kontrol = true;
            while (kontrol)
            {
                Console.Write("Şubesi: ".PadLeft(15));
                string sube = Console.ReadLine().ToUpper();


                if (sube == "A")
                {
                    ogre.Subesi = Kisi.SUBE.A;
                    kontrol = false;
                }
                else if (sube == "B")
                {
                    ogre.Subesi = Kisi.SUBE.B;
                    kontrol = false;
                }
                else if (sube == "C")
                {
                    ogre.Subesi = Kisi.SUBE.C;
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Mevcut şubeler A, B ve C'dir. ".PadLeft(15));
                }
            }
        }

        public static void NotGuncelleme(Ogrenci ogre)
        {
            Console.WriteLine();
            Console.WriteLine("Not Bilgisi:");
            if (ogre.Notlar != null)
            {
                Console.WriteLine();
                for (int i = 0; i < ogre.Notlar.Count; i++)
                {

                    Console.Write(((i + 1) + ". notu girin:").PadLeft(8));
                    ogre.Notlar[i] = SayiAl();
                }
            }
            else if (ogre.Notlar == null)
            {
                Console.WriteLine("Ogrencinin not bilgisi bulunmamaktadır.");
            }
        }

        #endregion
    }
}
