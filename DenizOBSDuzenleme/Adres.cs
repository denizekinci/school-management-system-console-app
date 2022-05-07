using System;
using System.Collections.Generic;
using System.Text;

namespace DenizOBSDuzenleme
{
    public class Adres
    {
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string SokakAdi { get; set; }
        public int BinaNo { get; set; }
        public int KapiNo { get; set; }
        public Adres()
        {


        }
        public Adres(string il, string ilce, string mahalle, string sokakAdi, int binaNo, int kapiNo)
        {
            Il = il;
            Ilce = ilce;
            Mahalle = mahalle;
            SokakAdi = sokakAdi;
            BinaNo = binaNo;
            KapiNo = kapiNo;
        }
    }
}
