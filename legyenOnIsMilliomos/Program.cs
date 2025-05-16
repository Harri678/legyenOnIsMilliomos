namespace legyenOnIsMilliomos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kerdesek kerdesek = new Kerdesek();

            kerdesek.BeolvasKerdes("kerdes.txt");
            kerdesek.BeolvasSorkerdes("sorkerdes.txt");

            Jatek jatek = new Jatek(kerdesek);
            jatek.Indit();
        }
    }
}
