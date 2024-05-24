using M016_Misc.Extensions;
using System.Drawing;

namespace M016_Misc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UseExtensionMethods();

            ShowLinqExample();

            var result = FibonacciRecursive(12);
            Console.WriteLine("Fibonacci Sequenz fuer 12 => " + result);
        }

        private static long FibonacciRecursive(int n) 
        { 
            // Grundsaetzlich koennen wir einen "iterativen" Ansatz mit Schleifen verwenden.
            // Alternativ koennen wir Algorithmen auch "rekursiv" implementieren, d. h. eine Funktion
            // welche sich immer wieder selber aufruft. Vorsicht: StackOverflowException wenn der Alogorithmus
            // einen Fehler hat. Zudem braucht ein rekursiver Ansatz mehr Speicher.

            if (n <= 1)
            {
                return n;
            }
            else
            {
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
            }
        }

        private static long FibonacciIterative(int n)
        {
            if (n <= 1)
            {
                return n;
            } 
            else
            {
                long current = 0;
                long next = 1;

                for (int i = 0; i <= n; i++)
                {
                    long temp = current;
                    current += next;
                    next = temp;
                }

                return current;
            }
        }

        private static void UseExtensionMethods()
        {
            double pi = Math.PI;
            Console.WriteLine("PI ist " + pi);

            double rounded = Math.Round(pi, 2);

            Console.WriteLine("PI gerundet auf 2 Stellen: " + rounded);

            // Die Methode Round ist eine Extension aus der statischen Klasse MathExtensions
            Console.WriteLine("PI gerundet auf 2 Stellen: " + pi.Round(2));
        }

        /// <summary>
        /// Linq ist eine Sammlung von sog. Extensions-Methods. Sie arbeiten alle auf dem Interface <see cref="IEnumerable{T}"/>.
        /// Erst durch die Methoden <see cref="ToList()"/> oder <see cref="ToArray()"/> wird die <see cref="System.Collections"/> tatsaechlich erzeugt!
        /// </summary>
        private static void ShowLinqExample()
        {
            IEnumerable<Vehicle> carsToBeCreated = Enumerable.Range(0, 200)
                .Select(i => VehicleFactory.CreateVehicle(i));

            Console.WriteLine("Jetzt wird der Code von IEnumerable ausgefuehrt\n");

            Console.WriteLine("Selektiert die ersten fuenf Elememente");
            var result = carsToBeCreated
                .Take(5);
            PrintArray(result.ToArray());

            Console.WriteLine("Selektiere die Elemente 5 bis 10");
            result = carsToBeCreated
                .Skip(5)
                .Take(5);
            PrintArray(result.ToArray());

            Console.WriteLine("Selektiere nur 8 Audis");
            result = carsToBeCreated
                .Where(v => v.Brand == Brand.Audi)
                .Take(8);
            PrintArray(result.ToArray());

            Console.WriteLine("Gib mir das erste Orangene Auto zurueck oder nichts.");
            var car = carsToBeCreated
                .FirstOrDefault(v => v.Color.Name.StartsWith("Orange"));
            Console.WriteLine($"Orangenes Auto: {car?.GetInfo()}");
            Console.WriteLine();

            var anyGreen = carsToBeCreated.Any(v => v.Color == Color.LimeGreen);
            Console.WriteLine("Gibt es ein Auto mit der Farbe LimeGreen? " + anyGreen);
            Console.WriteLine();

            var opelCount = carsToBeCreated.Count(v => v.Brand == Brand.Opel);
            Console.WriteLine($"Wieviele {Brand.Opel} wurden erzeugt?\n{opelCount} Opels");
            Console.WriteLine();

            Console.WriteLine("Selektiere die ersten 8 und sortiere nach Farbe und Automarke.");
            result = carsToBeCreated
                .OrderBy(v => v.Color.Name)
                .ThenBy(v => v.Brand)
                .Take(8);
            PrintArray(result.ToArray());
        }

        private static void PrintArray(Vehicle[] array)
        {
            // Jede einzelne Zeile ausgeben
            //Console.WriteLine(array[0].GetInfo());
            //Console.WriteLine(array[1].GetInfo());
            //Console.WriteLine(array[2].GetInfo());
            //Console.WriteLine(array[3].GetInfo());
            //Console.WriteLine(array[4].GetInfo());

            // Oder mittels Aggregate eine liste von strings erzeugen
            var infos = array.Select(v => v.GetInfo());

            // und zusammenfuegen, siehe https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate
            string info = infos.Aggregate(
                (accumulate, current) => $"{accumulate}{Environment.NewLine}{current}"
                );

            Console.WriteLine(info);
            Console.WriteLine();
        }
    }
}
