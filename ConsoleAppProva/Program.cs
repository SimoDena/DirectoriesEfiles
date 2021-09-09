using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleAppProva
{
    class Program
    {
        enum Colore
        {
            giallo,
            verde,
            rosso,
            blu,
            arancione
        }

        static void Main(string[] args)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\ciao"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\ciao");
            }

            string ciaoDir = Path.Combine(Directory.GetCurrentDirectory(), "ciao");
            string totlaCiaoDir = Path.Combine(Directory.GetCurrentDirectory(), "totale");

            List<string> files = FindFiles(ciaoDir);

            string totale = "";
            foreach (var f in files)
            {
                totale += " " + File.ReadAllText(f);
            }

            Directory.CreateDirectory(totlaCiaoDir);
            File.AppendAllText(Path.Combine(totlaCiaoDir, "totaleCiao.txt"), totale + "\n");

            ColoraConsole();
            Console.ReadKey();
        }

        static private List<string> FindFiles(string ciaoDir)
        {
            List<string> ciaoFilestxt = new List<string>();

            var fileTrovati = Directory.EnumerateFiles(ciaoDir, "*" ,SearchOption.AllDirectories);

            foreach (var file in fileTrovati)
            {
                if (Path.GetExtension(file) == ".txt")
                {
                    ciaoFilestxt.Add(file);
                }
            }

            return ciaoFilestxt;
        }

        static void ColoraConsole()
        {
            List<Colore> colores = new List<Colore>() { Colore.giallo, Colore.verde, Colore.rosso, Colore.blu, Colore.arancione, Colore.giallo, Colore.verde, Colore.rosso, Colore.blu, Colore.arancione, Colore.giallo, Colore.verde, Colore.rosso, Colore.blu, Colore.arancione };
            foreach (var colore in colores)
            {
                switch (colore)
                {
                    case Colore.giallo:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Colore.verde:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Colore.rosso:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Colore.blu:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Colore.arancione:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                }

                Console.WriteLine("CIAONE COLORONE");
            }

            Console.WriteLine("\nInserire dimensione 1 della matrice:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nInserire dimensione 2 della matrice:");
            int y = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();
            int indexColore = 0;
            Colore[,] matrix = new Colore[x,y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    indexColore = rnd.Next(colores.Count());
                    matrix[i, j] = colores[indexColore];
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nMatrice Colorata: \n\n");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    switch (matrix[i,j])
                    {
                        case Colore.giallo:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case Colore.verde:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case Colore.rosso:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case Colore.blu:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case Colore.arancione:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.Write(" " + "O");
                }
                Console.WriteLine();
            }
        }
    }
}
