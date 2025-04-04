namespace Autoapp;

internal class Auto
{
    public static List<Auto> Autok = [];

    public int Sorszam { get; set; }
    public string Marka { get; set; } = default!;
    public string Modell { get; set; } = default!;
    public int GyartasiEv { get; set; }
    public string Szin { get; set; } = default!;
    public int EladottDarabSzam { get; set; }
    public int AtlagosEladasiAr { get; set; }

    public Auto(string[] data)
    {
        Sorszam = Convert.ToInt32(data[0]);
        Marka = data[1];
        Modell = data[2];
        GyartasiEv = Convert.ToInt32(data[3]);
        Szin = data[4];
        EladottDarabSzam = Convert.ToInt32(data[5]);
        AtlagosEladasiAr = Convert.ToInt32(data[6]);

        Autok.Add(this);
    }

    public static void LoadCsv(string path)
    {
        File.ReadAllLines(path)
                .Skip(1)
                .ToList()
                .ForEach(G => new Auto(G.Split(';')));
    }
}
