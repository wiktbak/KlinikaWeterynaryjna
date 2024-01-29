using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaWeterynaryjna
{
    public class Zwierze : ICloneable, IComparable<Zwierze>, IEquatable<Zwierze>
    {
        static int licznik;
        public string identyfikator;
        public string imie;
        public string gatunek;
        public int wiek;
        public string imieWlasciciela;
        public string nazwiskoWlasciciela;
        public string telefonKontaktowy;
        
        public string Imie { get => imie; set => imie = value; }
        public string Gatunek { get => gatunek; set => gatunek = value; }
        public int Wiek { get => wiek; set => wiek = value; }
        public string ImieWlasciciela { get => imieWlasciciela; set => imieWlasciciela = value; }
        public string NazwiskoWlasciciela { get => nazwiskoWlasciciela; set => nazwiskoWlasciciela = value; }
        public string TelefonKontaktowy { get => telefonKontaktowy; set => telefonKontaktowy = value; }
        public string Identyfikator { get => identyfikator; set => identyfikator = value; }
        public static int Licznik { get => licznik; set => licznik = value; }

        public bool Equals(Zwierze other)
        {
            if (other == null)
                return false;

            return this.Identyfikator == other.Identyfikator && this.Imie == other.Imie;
          
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Zwierze);
        }


        static Zwierze()
        {
            licznik = 1; 
        }

        public Zwierze()
        {
            identyfikator = $"{licznik++:D5}";
        }
        
        public Zwierze(string imieWlasciciela, string nazwiskoWlasciciela, string telefonKontaktory, string gatunek) :this()
        {
            ImieWlasciciela = imieWlasciciela;
            NazwiskoWlasciciela = nazwiskoWlasciciela;
            TelefonKontaktowy = telefonKontaktory;
            Gatunek = gatunek;
        }

        public Zwierze(string imie, string imieWlasciciela, string nazwiskoWlasciciela, string telefonKontaktory, string gatunek, int wiek) : this(imieWlasciciela, nazwiskoWlasciciela, telefonKontaktory, gatunek)
        {
            Wiek = wiek;
            Imie = imie;
        }

        public string WypiszZwierze()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{identyfikator}] {imie} Gatunek: {gatunek} wiek: {wiek}");
            sb.AppendLine($"Dane Właściciela: {imieWlasciciela} {NazwiskoWlasciciela} tel:{telefonKontaktowy}");
            return sb.ToString();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(Zwierze? other)
        {
            if (other == null) { return -1; }
            return imie.CompareTo(other.imie);
        }


        public override string ToString()
        {
           return WypiszZwierze();
        }

    }
}
