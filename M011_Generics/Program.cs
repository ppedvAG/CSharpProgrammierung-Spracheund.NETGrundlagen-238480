using M007_OOP_GP;

namespace M011_Generics
{
    internal class Program
    {
        const string HUGO_KEY = "Hugo_Id1"; 

        // In Dependencies wurde M007_OOP-GP referenziert
        static void Main(string[] args)
        {
            // Listen: siehe M003 List<int>() und M007 List<Person>()

            var personDict = new Dictionary<string, Person>();
            personDict.Add(HUGO_KEY, new Person("Hugo", "Doe", 18));

            for (int i = 0; i < 10; i++)
            {
                personDict.Add($"Anonymous_{i}", Factory.CreateRandomPerson());
            }

            Console.WriteLine($"Unser Dictionary vom Typ Personen hat {personDict.Count} Eintraege.");
            Console.WriteLine();
            Console.WriteLine($"Element mit dem Schluessel via Index {HUGO_KEY}: ");
            personDict[HUGO_KEY].Print();
            Console.WriteLine();

            // Wenn Key ungueltig wird eine KeyNotFoundException geworfen
            //personDict["Ungueltig"].Print();

            Console.WriteLine($"Element mit dem Schluessel via GetValue {HUGO_KEY}: ");
            var found = personDict.TryGetValue(HUGO_KEY, out Person hugo);
            if (found && hugo != null)
            {
                hugo.Print();
            }

            Console.WriteLine();
            Console.WriteLine($"Ueber alle Personen im Dict iterieren.");
            foreach (KeyValuePair<string, Person> pair in personDict)
            {
                Console.WriteLine($"Wer steckt hinter dem Key {pair.Key}");
                var person = pair.Value;
                person.Print();
            }
        }
    }
}
