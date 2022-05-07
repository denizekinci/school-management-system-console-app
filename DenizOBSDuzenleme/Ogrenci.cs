using System;
using System.Collections.Generic;
using System.Text;

namespace DenizOBSDuzenleme

{
    public class Ogrenci : Kisi
    {

        public bool devam = false;



        public int NotSayısı = 0;



        public List<int> Notlar { get; private set; }

        public List<string> Kitaplar { get; private set; }

        public int KitapSayisi = 0;
        public Adres Adresi { get; set; }

        public float Ortalama
        {
            get
            {
                float ogrOrtalama = 0;
                foreach (int not in this.NotGetir())
                {
                    ogrOrtalama += not;
                }
                ogrOrtalama = ogrOrtalama / this.NotGetir().Count;
                return ogrOrtalama;
            }
        }

        public Ogrenci()
        {

        }

        public Ogrenci(int no, string ad, string soyad, DateTime dogumTarihi, SUBE subesi, CINSIYET cins)
        {
            this.No = no;
            this.Ad = ad;
            this.Soyad = soyad;
            this.DogumTarihi = dogumTarihi;
            this.Subesi = subesi;
            this.Cins = cins;
        }

        public string Degerlendirme { get; set; }

        public List<int> NotGetir()
        {
            return this.Notlar;
        }


        public void NotGir(int not)
        {
            if (this.Notlar == null)
            {
                this.Notlar = new List<int>();
            }

            this.Notlar.Add(not);
        }

        public void KitapGir(string kitap)
        {
            if (this.Kitaplar == null)
            {
                this.Kitaplar = new List<string>();
            }

            this.Kitaplar.Add(kitap);
            KitapSayisi = Kitaplar.Count;
        }


        public void AdresGir(string il, string ilce, string mahalle, string sokakAdi, int binaNo, int daireNo)
        {
            if (this.Adresi == null)
            {
                this.Adresi = new Adres();
            }
        }
    }
    public enum CINSIYET
    {
        Kiz,
        Erkek
    }


}
