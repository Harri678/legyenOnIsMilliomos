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
        int garantalt = 0;

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
            Console.WriteLine(sorkerdes.HelyesSorrend);

            string valasz = Console.ReadLine()?.Trim().ToUpper();

            if (valasz == sorkerdes.HelyesSorrend)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Helyes valasz!");
                Console.WriteLine("Megkezdheti a valodi jatekot.");
                Console.ReadLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Helytelen valasz! Jatek vege.");
                Console.ReadLine();
                Console.ResetColor();
                return;

            }

            while (szint <= 15)
            {

                Kerdes k = kerdesek.VeletlenKerdes(szint);
                if (k == null)
                {
                    Console.WriteLine("Nincs tobb kerdes.");
                    break;
                }

                Console.Clear();

                Console.WriteLine($"Szint: {szint}");
                Console.WriteLine($"Nyeremeny: {nyeremenyek[szint - 1]}");
                Console.WriteLine("Kovetkezo kerdes:");
                Console.WriteLine(k.KerdesSzoveg);
                Console.WriteLine($"A: {k.Valaszok[0]}");
                Console.WriteLine($"B: {k.Valaszok[1]}");
                Console.WriteLine($"C: {k.Valaszok[2]}");
                Console.WriteLine($"D: {k.Valaszok[3]}");
                Console.Write("Adja meg a helyes valaszt (A/B/C/D) vagy alljon meg (STOP): ");
                Console.WriteLine(k.HelyesValasz);
                valasz = Console.ReadLine()?.Trim().ToUpper();

                if(valasz.ToUpper() == "STOP")
                {
                    Console.WriteLine($"Kilép a játékbol és {nyeremenyek[szint-1]} Ft nyert");
                    break;
                }

                if (valasz == k.HelyesValasz.ToUpper())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Helyes válasz!");
                    Console.ReadLine();
                    Console.ResetColor();

                    if (szint == 5 || szint == 10)
                    {
                        garantalt = nyeremenyek[szint - 1];
                        Console.WriteLine($"A garantalt nyeremenyed {garantalt}");
                        Console.ReadLine();
                    }
                    if (szint == 15)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("GRATULÁLUNK! Megnyerted a fődíjat: 50 000 000 Ft!");
                        Console.ReadLine();
                        Console.ResetColor();
                        break;
                    }

                    szint++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Rossz válasz! A helyes: {k.HelyesValasz}");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine($"Nyereményed: {garantalt} Ft");
                    Console.ReadLine();
                    break;
                }

            }

        }

    }
}
