using KlinikaWeterynaryjna;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaWeterynaryjna
{
    public enum EnumSpecjalizacja { chirurg, internista, kardiolog, fizjoterapeuta, Ogolny }

    public class Lekarz : IComparable<Lekarz>
    {
        string imieLekarza;
        string nazwiskoLekarza;
        EnumSpecjalizacja specjalizacja;
        private List<Termin> harmonogram;
        private List<Termin> zajete;
        private List<Termin> odbyte_lekarz;

        public string ImieLekarza { get => imieLekarza; set => imieLekarza = value; }
        public string NazwiskoLekarza { get => nazwiskoLekarza; set => nazwiskoLekarza = value; }
        public EnumSpecjalizacja Specjalizacja { get => specjalizacja; set => specjalizacja = value; }
        public List<Termin> Harmonogram { get => harmonogram; set => harmonogram = value; }
        public List<Termin> Zajete { get => zajete; set => zajete = value; }
        public List<Termin> Odbyte_lekarz { get => odbyte_lekarz; set => odbyte_lekarz = value; }

        public Lekarz()
        {
            harmonogram = new List<Termin>();
            zajete = new List<Termin>();
            odbyte_lekarz = new List<Termin>();
        }

        public Lekarz(string imieLekarza, string nazwiskoLekarza, EnumSpecjalizacja specjalizacja) : this()
        {
            this.imieLekarza = imieLekarza;
            this.nazwiskoLekarza = nazwiskoLekarza;
            this.specjalizacja = specjalizacja;
        }
        public void DodawanieTerminu(Termin termin)
        {
            Termin? znaleziony = harmonogram.Find(x => x.data == termin.data);
            Termin? znaleziono_zajety = zajete.Find(x => x.data == termin.data);

            if (znaleziony == null && znaleziono_zajety == null)
            {
                if (termin.dostepny == true)
                {
                    harmonogram.Add(termin);
                }
                else { zajete.Add(termin); }
            }

            else { Console.WriteLine("Błąd: Termin jest już został dodany do harmonogramu"); }
        }

        public void PrzeniesOdbyteTerminy()
        {
            DateTime currentDate = DateTime.Now;

            List<Termin> odbyte = Zajete.Where(termin => !termin.Dostepny && termin.Data < currentDate).ToList();

            odbyte_lekarz.AddRange(odbyte);
            Zajete.RemoveAll(termin => odbyte.Contains(termin));

        }


        public int CompareTo(Lekarz? other)
        {
            if (other == null) { return -1; }
            int cmp = nazwiskoLekarza.CompareTo(other.nazwiskoLekarza);
            if (cmp != 0) { return cmp; }
            return imieLekarza.CompareTo(other.imieLekarza);
        }

        public string WypiszLekarza()
        {
            StringBuilder sb_lekarz = new();
            sb_lekarz.AppendLine($"{imieLekarza} {nazwiskoLekarza}");
            sb_lekarz.AppendLine($"Specjalizacja: {specjalizacja}");
            return sb_lekarz.ToString();
        }


        public string WypiszHarmonogram()
        {
            List<Termin> aktualnyHarmonogram = harmonogram.Where(x => x.data >= DateTime.Now).ToList();
            StringBuilder sb_harmonogram = new();
            sb_harmonogram.AppendLine("Harmonogram Lekarza");
            foreach (Termin termin in aktualnyHarmonogram)
            {
                sb_harmonogram.AppendLine(termin.ToString());
            }
            Console.WriteLine(sb_harmonogram.ToString());
            return sb_harmonogram.ToString();

        }

        public string WypiszZaplanowaneWizytyLekarza()
        {
            PrzeniesOdbyteTerminy();
            StringBuilder sb_zajete = new();
            foreach (Termin termin in zajete)
            {
                sb_zajete.AppendLine(termin.ToString());
            }
            return sb_zajete.ToString();
        }


        public override string ToString()
        {
            return WypiszLekarza();
        }
    }
}