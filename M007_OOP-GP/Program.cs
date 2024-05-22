using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System;

namespace M007_OOP_GP
{
    internal class Program
    {
        const int TOTAL_PERSON_COUNT = 10;

        private static string[] namePool = new string[]
        {
            "Max",
            "Anna",
            "Lisa",
            "Thomas",
            "Julia",
            "Michael",
            "Sarah",
            "Daniel",
            "Laura",
            "Markus",
            "Katharina",
            "Stefan",
            "Nicole",
            "Christian",
            "Sabine",
            "Andreas",
            "Claudia",
            "Peter",
            "Monika",
            "Ralf",
            "Birgit",
            "Frank",
            "Annette",
            "Hans",
            "Ursula",
            "Wolfgang",
            "Marianne",
            "Günter",
            "Brigitte",
            "Horst",
            "Hannelore",
            "Heinz",
            "Gertrud",
            "Karl",
            "Margarethe",
            "Werner",
            "Ilse",
            "Fritz",
            "Elfriede",
            "Otto",
            "Maria",
            "Josef",
            "Elisabeth",
            "Heinrich",
            "Agnes",
            "Wilhelm",
            "Hedwig",
            "Friedrich",
            "Irmgard",
            "Adolf",
            "Emma",
            "August",
            "Martha",
            "Bruno",
            "Dorothea",
            "Ernst",
            "Luise",
            "Richard",
            "Mathilde",
            "Paul",
            "Helene",
            "Alfred",
            "Klara",
            "Ludwig",
            "Bertha",
            "Gustav",
            "Minna",
            "Robert",
            "Ottilie",
            "Carl",
            "Sophie",
            "Emil",
            "Frieda",
            "Konrad",
            "Paula",
            "Eduard",
            "Elise",
            "Hermann",
            "Therese",
            "Leo",
            "Rosa",
            "Oskar",
            "Adele",
            "Kurt",
            "Lydia",
            "Walter",
            "Alma",
            "Arthur",
            "Grete",
            "Hugo",
            "Berta",
            "Franz",
            "Else",
            "Bernhard",
            "Meta",
            "Rudolf",
            "Olga",
            "Albert",
            "Elsa",
            "Viktor",
        };

        static void Main(string[] args)
        {
            var random = new Random();
            var list = new List<Person>();

            for (int i = 0; i < TOTAL_PERSON_COUNT; i++)
            {
                // random.Next() erzeugt uns eine Zahl zwischen 0 und int.MaxValue welche wir mit Modulu zwischen 10 und 80 einschraenken
                int age = random.Next() % 70 + 10;

                // Wir erzeugen uns einen random Index um einen Namen aus dem Array zufaellig auszuwaehlen
                int nameIndex = random.Next() % namePool.Length;

                var person = new Person(namePool[nameIndex], "Smith", age);
                person.Print();

                list.Add(person);
            }

            // Wir rufen die statische Methode ShowCount() auf.
            Person.ShowCount();
            Console.WriteLine();

            // Fange bei 0 an und entferne die ersten Haelfte Elemente
            list.RemoveRange(0, TOTAL_PERSON_COUNT / 2);

            // Wir muessen den Garbage Collector rufen, damit er explizit den Speicher frei raeumt.
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Person.ShowCount();
            Console.WriteLine();

        }
    }
}
