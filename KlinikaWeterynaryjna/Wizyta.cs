using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KlinikaWeterynaryjna
{
  
    public class Wizyta : IComparable<Wizyta>
    {
        static int licznik_wizyt;
        string id_wizyty;
        Lekarz lekarz;
        Zwierze zwierze;
        DateTime data_wizyty;
        string powod;

        public string Id_wizyty { get => id_wizyty; set => id_wizyty = value; }
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        public Zwierze Zwierze { get => zwierze; set => zwierze = value; }
        public DateTime Data_wizyty { get => data_wizyty; set => data_wizyty = value; }
        public static int Licznik_wizyt { get => licznik_wizyt; set => licznik_wizyt = value; }
        public string Powod { get => powod; set => powod = value; }

        static Wizyta()
        {
            licznik_wizyt = 1;
        }

        public Wizyta()
        {
            Id_wizyty = $"{licznik_wizyt++:D7}";
        }

        public Wizyta(Lekarz lekarz, Zwierze zwierze, DateTime data_wizyty, string powod) : this()
        {
            this.lekarz = lekarz;
            this.zwierze = zwierze;
            this.data_wizyty = data_wizyty;
            this.powod = powod;
        }

        public string WypiszWizyte()
        {
            StringBuilder sb_wizyty = new StringBuilder();
            sb_wizyty.AppendLine($"[{id_wizyty}] Dnia:{data_wizyty}");
            sb_wizyty.AppendLine($"Dr:  {lekarz.ImieLekarza} {lekarz.NazwiskoLekarza}");
            sb_wizyty.AppendLine($"Zwierze: [{zwierze.Identyfikator}] {zwierze.Imie}");
            sb_wizyty.AppendLine($"Powód: {powod}");
            sb_wizyty.AppendLine("=======================");
            return sb_wizyty.ToString();
        }

        public int CompareTo(Wizyta other)
        {
            if (other == null)
            { return -1; }
            else
            {
                return this.data_wizyty.CompareTo(other.data_wizyty);
            }
        }

        public override string ToString()
        {
            return WypiszWizyte();
        }
    }
}
