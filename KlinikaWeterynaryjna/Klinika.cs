using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KlinikaWeterynaryjna
{
    interface IZapisywalna
    {
        void ZapiszXML(string nazwa);
    }
    public class Klinika : IZapisywalna
    {
        string nazwa;
       List<Lekarz> lekarze;
       List<Zwierze> zwierzeta;
       List<Wizyta> wizyty;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }
        public List<Zwierze> Zwierzeta { get => zwierzeta; set => zwierzeta = value; }
        public List<Wizyta> Wizyty { get => wizyty; set => wizyty = value; }

        public Klinika() 
        {
            lekarze = new List<Lekarz>();
            zwierzeta = new List<Zwierze>();
            wizyty = new List<Wizyta>();
        }


        public Klinika(string nazwa) :this()
        {
            this.nazwa = nazwa;
        }

        public Klinika(string nazwa, List<Lekarz> lekarze, List<Zwierze> zwierzeta, List<Wizyta> wizyty) :this()
        {
            this.nazwa = nazwa;
            this.lekarze = lekarze;
            this.zwierzeta = zwierzeta;
            this.wizyty = wizyty;
        }


        public void DodawanieLekarza(Lekarz l)
        {
            if (l is not null)
            {
                lekarze.Add(l);
            }
        }

        public void DodawanieZwierzecia(Zwierze z)
        {
            if (z is not null)
            {
                zwierzeta.Add(z);
            }
        }

        public void DodawanieWizyty(Wizyta wizyta)
        {
            Termin? termin = wizyta.Lekarz.Harmonogram.Find(x => x.data == wizyta.Data_wizyty);

            if (termin != null)
            {
                termin.dostepny = false;
                wizyta.Lekarz.Harmonogram.Remove(termin);
                wizyta.Lekarz.Zajete.Add(termin);
                wizyty.Add(wizyta);
            }
            else 
            {
                Console.WriteLine($"Doktor ma już wizyte w tym czasie lub nie pracuje wtedy");
            }
            
        }
        


        public void SortujLekarzy()
        {
            lekarze.Sort();
        }
        public void SortujZwierzeta()
        {
            zwierzeta.Sort();
        }
        public void SortujWizyty()
        {
            wizyty.Sort();
        }

        public void UsuwanieLekarza(Lekarz lekarz)
        {
            lekarze.RemoveAll(x => x == lekarz);
        }

        public void UsuwanieZwierzecia(Zwierze zwierze)
        {
            zwierzeta.RemoveAll(x => x == zwierze);
        }

        public string WypiszZwierzeta()
        {
            StringBuilder sb_zwierzeta = new();
            if (zwierzeta == null)
            {
                sb_zwierzeta.AppendLine($"nie był jeszcze na żadnej wizycie");

            }
            else
            {
                sb_zwierzeta.AppendLine($"Zwierzeta");
                foreach (Zwierze zwierze in zwierzeta)
                {
                    sb_zwierzeta.AppendLine(zwierze.ToString());
                }


            }
            Console.WriteLine(sb_zwierzeta.ToString());
            return sb_zwierzeta.ToString();
        }

        public string WypiszWizyty()
        {
            StringBuilder sb_wizyty= new();
            if (zwierzeta == null)
            {
                sb_wizyty.AppendLine($"nie ma wizyt");

            }
            else
            {
                sb_wizyty.AppendLine($"Wizyty");
                foreach (Wizyta wizyta in wizyty)
                {
                    sb_wizyty.AppendLine(wizyta.ToString());
                }


            }
            Console.WriteLine(sb_wizyty.ToString());
            return sb_wizyty.ToString();
        }


        public string WypiszZaplanowaneWizytyZwierzecia(Zwierze zwierze)
        {

            List<Wizyta> zaplanowane = wizyty.FindAll(x => x.Data_wizyty >= DateTime.Now && x.Zwierze == zwierze).ToList();
            zaplanowane.OrderBy(x => x.Data_wizyty);
            StringBuilder sb_wizyty = new();
            if (zaplanowane.Count == 0)
            {
                sb_wizyty.AppendLine($"{zwierze.imie}Zwierze nie ma zaplanowanych żadnych wizyt");

            }
            else
            {
                sb_wizyty.AppendLine($"====Wizyty zaplanowane {zwierze.imie}====");
                foreach (Wizyta wizyta in zaplanowane)
                {
                    sb_wizyty.AppendLine(wizyta.ToString());
                }


            }
            Console.WriteLine(sb_wizyty.ToString());
            return sb_wizyty.ToString();
        }


        public string WypiszOdbyteWizytyZwierzecia(Zwierze zwierze)
        {
            List<Wizyta> stare = wizyty.FindAll(x => x.Data_wizyty < DateTime.Now && x.Zwierze == zwierze).ToList();

            if (stare.Count > 0)
            {
                stare.Sort((x, y) => x.Data_wizyty.CompareTo(y.Data_wizyty));
                StringBuilder sb_wizyty = new StringBuilder();
                sb_wizyty.AppendLine($"====Wizyty odbyte {zwierze.imie}====");

                foreach (Wizyta wizyta in stare)
                {
                    sb_wizyty.AppendLine(wizyta.ToString());
                }

                Console.WriteLine(sb_wizyty.ToString());
                return sb_wizyty.ToString();
            }
            else
            {
                Console.WriteLine($"{zwierze.imie} nie był jeszcze na żadnej wizycie");
                return $"{zwierze.imie} nie był jeszcze na żadnej wizycie";
            }
        }




        public override string ToString()
        {
            StringBuilder sb_klinika = new();
            sb_klinika.AppendLine($"{nazwa}");

            sb_klinika.AppendLine("LEKARZE:");
            foreach (Lekarz lekarz in lekarze)
            {
                sb_klinika.AppendLine(lekarz.ToString());
            }

            sb_klinika.AppendLine("ZWIERZETA:");
            foreach (Zwierze zwierze in zwierzeta)
            {
                sb_klinika.AppendLine(zwierze.ToString());
            }

            sb_klinika.AppendLine("WIZYTY:");
            foreach (Wizyta wizyta in wizyty)
            {
                sb_klinika.AppendLine(wizyta.ToString());
            }

            return sb_klinika.ToString();
        }

        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Klinika));
            xs.Serialize(sw, this);
        }
        public static Klinika? OdczytXml(string nazwa)
        {
            if (!File.Exists(nazwa))
            {
                return null;
            }
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Klinika));
            return xs.Deserialize(sw) as Klinika;
        }

    }
}
