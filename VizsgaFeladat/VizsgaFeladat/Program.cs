using static Autoapp.Auto;

namespace Autoapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto.LoadCsv("autok.csv");

            Console.WriteLine($"5. feladat: {Autok.Count} autó található a listában");

            Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám {Autok.Average(G => G.EladottDarabSzam):F1}");

            Console.WriteLine($"7. feladat: Az elmúlt évben gyártott autók:");
            Autok.Where(G => G.GyartasiEv >= DateTime.Now.Year - 5)
                .ToList()
                .ForEach(G => Console.WriteLine($"\t- {G.Marka} {G.Modell}: {G.GyartasiEv}"));

            Console.WriteLine($"8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
            Autok.GroupBy(G => G.Marka)
                .OrderByDescending(G => G.Sum(G => G.EladottDarabSzam))
                .ToList()
                .ForEach(G => Console.WriteLine($"\t- {G.Key}: {G.Sum(G => G.EladottDarabSzam)} darab"));
        }
    }
}
