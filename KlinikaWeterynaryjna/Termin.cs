using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaWeterynaryjna
{
    public class Termin
    {
        public DateTime data;
        public bool dostepny;

        public DateTime Data { get => data; set => data = value; }
        public bool Dostepny { get => dostepny; set => dostepny = value; }

        public Termin() { }

        public Termin(DateTime data, bool dostepny)
        {
            Data = data;
            Dostepny = dostepny;
        }

        public override string ToString()
        {
            return $"Termin: {data}";
        }
    }
   
}
