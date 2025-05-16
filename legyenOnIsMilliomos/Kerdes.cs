using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdes
    {
        public string Szint { get; set; }
        public string KerdesSzoveg { get; set; }
        public List<string> Valaszok { get; set; }
        public string HelyesValasz { get; set; }
        public string Kategoria { get; set; }

        public Kerdes(string szint, string kerdesSzoveg, List<string> valaszok, string helyesValasz, string kategoria)
        {
            Szint = szint;
            KerdesSzoveg = kerdesSzoveg;
            Valaszok = valaszok;
            HelyesValasz = helyesValasz;
            Kategoria = kategoria;
        }

    }
}
