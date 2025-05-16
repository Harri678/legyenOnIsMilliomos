using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Sorkerdes
    {
        public string Kerdes { get; set; }
        public List<string> Valaszok { get; set; }
        public string HelyesSorrend { get; set; }
        public string Kategoria { get; set; }

        public Sorkerdes(string kerdes, List<string> valaszok, string helyesSorrend, string kategoria)
        {
            Kerdes = kerdes;
            Valaszok = valaszok;
            HelyesSorrend = helyesSorrend;
            Kategoria = kategoria;
        }
    }
}
