using M007_OOP_GP;
using System.Linq;
using System.Text.Json;

namespace M015_Files
{
    internal class Program
    {
        // README.md auslesen und ausgeben
        // Dazu in diesem Project als existierende Datei hinzufuegen
        // In den Eigenschaften festlegen, dass die Datei in das bin-Verzeichnis kopiert werden soll
        static void Main(string[] args)
        {
            ShowReadmeFile();

            WriteHelloWorldToFile();

            JsonExample();
        }

        private static void WriteHelloWorldToFile()
        {
            string binFolderOfExecutables = Environment.CurrentDirectory;
            var path = Path.Combine(binFolderOfExecutables, "Hello.txt");

            // FileInfo enthaelt Informationen ueber eine hypothetische Datei
            var file = new FileInfo(path);

            using(var stream = new StreamWriter(file.FullName))
            {
                stream.WriteLine("Hello World");

                // Wir muessen Close() nicht explizit aufrufen weil Dispose() bereits durch das using automatisch aufgerufen wird
                //stream.Close();
            }
        }

        private static void JsonExample()
        {
            Console.WriteLine("Beispieldaten generieren");

            //Person[] personArray = CreateSampleDataClassic(25);
            //Person[] personArray = CreateSampleDataLinq(25);

            IEnumerable<Person> persons = CreateSampleDataYieldReturn(25);

            Console.WriteLine("Erst jetzt werden die Personen erzeugt.");
            Person[] personArray = persons.ToArray();

            var path = Path.Combine(Environment.CurrentDirectory, "persons.json");

            WriteJsonFile(path, personArray);

            ReadJsonFile(path);
        }

        private static Person[] CreateSampleDataClassic(int count)
        {
            var array = new Person[count];
            for (int i = 0; i < count; i++)
            {
                var person = PersonFactory.CreateRandomPerson();
                array[i] = person;
            }
            return array;
        }

        private static IEnumerable<Person> CreateSampleDataYieldReturn(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return PersonFactory.CreateRandomPerson();
            }
        }

        private static Person[] CreateSampleDataLinq(int count)
        {
            return Enumerable.Range(0, count)
                .Select(i => PersonFactory.CreateRandomPerson())
                .ToArray();
        }

        // JSON Datei schreiben
        private static void WriteJsonFile(string path, Person[] personArray)
        {
            var options = new JsonSerializerOptions
            {
                // Inhalte auf mehrere Zeilen formatieren
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(personArray, options);
            using (var stream = new StreamWriter(path))
            {
                stream.WriteLine(jsonString);
            }

            Console.WriteLine("Json wurde geschrieben nach " + path);
            Console.WriteLine();
        }

        private static void ReadJsonFile(string path)
        {
            // JSON Datei lesen
            using (var stream = new StreamReader(path))
            {
                var jsonString = stream.ReadToEnd();
                if (jsonString != null)
                {
                    // Person MUSS einen Default Constructor haben, d. h. einen Constructor ohne Paramter
                    var personArray = JsonSerializer.Deserialize<Person[]>(jsonString);
                    if (personArray?.Length > 0)
                    {
                        Console.WriteLine($"Erste Person {personArray[0].VollerName1} wurde aus json Datei eingelesen.");
                    } 
                    else
                    {
                        Console.WriteLine("Personen konnten nicht deserialisiert werden!");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void ShowReadmeFile()
        {
            // Wir verwenden Path Combine um uns keine Gedanken machen zu muessen ob wir / oder \ verwenden muessen
            string filepath = Path.Combine(Environment.CurrentDirectory, "README.md");

            if (File.Exists(filepath))
            {
                using (var reader = new StreamReader(filepath))
                {
                    var content = reader.ReadToEnd();
                    var lines = content.Split(Environment.NewLine).Take(5);

                    Console.WriteLine("Die ersten 5 Zeilen der README-Datei");
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Dateipfad nicht gefunden: " + filepath);
            }
        }
    }
}
