using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Jatek
    {
        private Kerdesek kerdesek;
        private int szint = 1;
        private int nyeremeny = 0;
        private int[] nyeremenyek = { 10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 15000000, 25000000, 50000000 };

        public Jatek(Kerdesek kerdesek)
        {
            this.kerdesek = kerdesek;
        }

        public void Indit()
        {
            Console.WriteLine("Legyen on is milliomos!"); Console.WriteLine();
            Console.WriteLine("Eloszor a sorkerdes: "); Console.WriteLine();

            Sorkerdes sorkerdes = kerdesek.VeletlenSorkerdes();

            Console.WriteLine($"Kategoria: {sorkerdes.Kategoria}");
            Console.WriteLine($"Kerdes: {sorkerdes.Kerdes}");
            Console.WriteLine("Valaszok:");
            for (int i = 0; i < sorkerdes.Valaszok.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sorkerdes.Valaszok[i]}");
            }
            Console.WriteLine("Adja meg a helyes sorrendet (pl. ABCD):");

            string valasz = Console.ReadLine()?.Trim().ToUpper();

            if (valasz == sorkerdes.HelyesSorrend)
            {
                Console.WriteLine("Helyes valasz!");
                Console.WriteLine("Megkezdheti a valodi jatekot.");
            }
            else
            {
                Console.WriteLine("Helytelen valasz! Jatek vege.");
            }

        }

    }
}
