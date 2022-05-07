using System;
using System.Collections.Generic;
using System.Text;

namespace DenizOBSDuzenleme
{
    public class Kisi
    {

    public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public string Telefon { get; set; }
        public int No { get; set; }
        public DateTime DogumTarihi { get; set; }


        public int Yas { get; private set; }
        public CINSIYET Cins { get; set; }
        public enum CINSIYET
        {
            Kiz,
            Erkek
        }
        public Adres Adresi { get; set; }
        public SUBE Subesi { get; set; }
        public Kisi()
        {

        }
        public Kisi(string ad, string soyad, string tcNo)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.TcNo = tcNo;
        }
        public enum SUBE
        {
            A,
            B,
            C
        }
    }
}
