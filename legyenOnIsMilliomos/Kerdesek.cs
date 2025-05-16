using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdesek
    {
        public List<Sorkerdes> SorkerdesLista { get; set; } = new List<Sorkerdes>();
        public List<Kerdes> KerdesLista { get; set; } = new List<Kerdes>();

        public void BeolvasSorkerdes(string path)
        {
            SorkerdesLista.Clear();
            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split(';');
                if (parts.Length == 7)
                {
                    var valaszok = new List<string> { parts[1], parts[2], parts[3], parts[4] };
                    var sorkerdes = new Sorkerdes(parts[0], valaszok, parts[5], parts[6]);
                    SorkerdesLista.Add(sorkerdes);
                }
            }
        }

        public void BeolvasKerdes(string path)
        {
            KerdesLista.Clear();
            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split(';');
                if (parts.Length == 8)
                {
                    var valaszok = new List<string> { parts[2], parts[3], parts[4], parts[5] };
                    var kerdes = new Kerdes(parts[0], parts[1], valaszok, parts[6], parts[7]);
                    KerdesLista.Add(kerdes);
                }
            }
        }
    }
}
