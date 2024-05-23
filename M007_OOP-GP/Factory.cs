﻿namespace M007_OOP_GP
{
    public static class Factory
    {
        public readonly static string[] NamePool = new string[]
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
        private readonly static Random Generator = new Random();

        public static Person CreateRandomPerson()
        {
            // random.Next() erzeugt uns eine Zahl zwischen 0 und int.MaxValue welche wir mit Modulu zwischen 10 und 80 einschraenken
            int age = Generator.Next() % 70 + 10;

            // Wir erzeugen uns einen random Index um einen Namen aus dem Array zufaellig auszuwaehlen
            int nameIndex = Generator.Next() % NamePool.Length;

            var person = new Person(NamePool[nameIndex], "Smith", age);
            return person;
        }
    }
}
