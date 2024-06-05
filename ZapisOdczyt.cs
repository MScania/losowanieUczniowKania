using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace losowanieUczniowKania
{
    public static class ZapisOdczyt
    {
        private static readonly string SciezkaKlas = @"C:\Users\Student\source\repos\los\losowanieUczniowKania\losowanieUczniowKania\dane.txt";

        public static void ZapiszKlasy(IEnumerable<string> klasy)
        {
            File.WriteAllLines(SciezkaKlas, klasy);
        }

        public static List<string> OdczytajKlasy()
        {
            return File.Exists(SciezkaKlas) ? File.ReadAllLines(SciezkaKlas).ToList() : new List<string>();
        }

        public static void ZapiszUczniow(string nazwaKlasy, IEnumerable<string> uczniowie)
        {
            var sciezkaUczniow = Path.Combine(FileSystem.AppDataDirectory, $"{nazwaKlasy}.txt");
            File.WriteAllLines(sciezkaUczniow, uczniowie);
        }

        public static List<string> OdczytajUczniow(string nazwaKlasy)
        {
            var sciezkaUczniow = Path.Combine(FileSystem.AppDataDirectory, $"{nazwaKlasy}.txt");
            return File.Exists(sciezkaUczniow) ? File.ReadAllLines(sciezkaUczniow).ToList() : new List<string>();
        }
    }
}