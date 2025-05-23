using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Jatek
    {
        private Segitsegeek segitségek = new Segitsegeek();
        private Kerdesek kerdesek;
        private int szint = 1;
        private int nyeremeny = 0;
        private int[] nyeremenyek = { 10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 15000000, 25000000, 50000000 };
        int garantalt = 0;
        List<char> valaszok = new List<char> { 'A', 'B', 'C', 'D' };

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
                Console.WriteLine($"{valaszok[i]}. {sorkerdes.Valaszok[i]}");
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
                Console.Write("Adja meg a helyes valaszt (A/B/C/D) vagy alljon meg (STOP) vagy kerjen segitséget: 50(felezo) T(telefon) K(kozonseg): ");
                Console.WriteLine(k.HelyesValasz);
                valasz = Console.ReadLine()?.Trim().ToUpper();

                if (valasz == "50" && !segitségek.FelezoHasznalva)
                {
                    segitségek.HasznalFelezo();
                    List<string> lehetosegek = new List<string>{"A", "B", "C", "D"};
                    lehetosegek.Remove(k.HelyesValasz.ToUpper());
                    Random rand = new Random();
                    string torlendo1 = lehetosegek[rand.Next(lehetosegek.Count)];
                    lehetosegek.Remove(torlendo1 );
					string torlendo2 = lehetosegek[rand.Next(lehetosegek.Count)];
					lehetosegek.Remove(torlendo2);

                    Console.WriteLine($"Eltvolitott valaszok: {torlendo1}, {torlendo2}.");
					valasz = Console.ReadLine()?.Trim().ToUpper();
                }
                else if (valasz == "50" && segitségek.FelezoHasznalva)
                {
                    Console.WriteLine("Nincs felezoje!");
					valasz = Console.ReadLine()?.Trim().ToUpper();
				}

				if (valasz == "T" && !segitségek.TelefonHasznalva)
                {
                    segitségek.HasznalTelefon();
                    Console.WriteLine($"A telefonos segito szerint a helyes válasz a {k.HelyesValasz}");
					valasz = Console.ReadLine()?.Trim().ToUpper();
				}
				else if(valasz == "T" && segitségek.TelefonHasznalva)
				{
					Console.WriteLine("Nincs telefonos segitsége!");
					valasz = Console.ReadLine()?.Trim().ToUpper();
				}

				if (valasz == "K" && !segitségek.KozonsegHasznalva)
                {
                    segitségek.HasznalKozonseg();
                    Random rand = new Random();

                    int helyesSzazalek = rand.Next(50, 90);
                    int maradek = 100 - helyesSzazalek;

                    Console.WriteLine($"A közönseg szerint a helyes valasz: {k.HelyesValasz} {helyesSzazalek}-al");
                    Console.WriteLine($"A többi valasz megoszlik a maradek {maradek} szazalek kozt");
					valasz = Console.ReadLine()?.Trim().ToUpper();
				}
				else if (valasz == "K" && segitségek.KozonsegHasznalva)
				{
					Console.WriteLine("Nincs kozonseseg segitseged!");
					valasz = Console.ReadLine()?.Trim().ToUpper();
				}


				if (valasz == "STOP")
                {
                    Console.WriteLine($"Kilép a játékbol és {nyeremenyek[szint-2]} Ft nyert");
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
