using M009_Types_Poly;

namespace M010_Interfaces
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            // Ich kann keine Instanz von einem Interface erzeugen.
            // Interfaces koennen nur von Klassen implementiert werden
            //var worker = new IWorkable();

            // IWorkable ist der Typ zur Compile-Zeit
            IWorkable worker1 = CreateInstance();

            // Mit GetType() fragen wir den Typ zur Laufzeit ab: HomoSapiens
            Console.WriteLine("Was bin ich (worker1): " + worker1.GetType().Name);
            worker1.DoWork();
            worker1.Payout();

            Console.WriteLine("Was isst unser Arbeiter gerne?");
            if (worker1 is Creature creature)
            {
                creature.Eat();
            }

            IWorkable worker2 = new Robot()
            {
                Job = "Arbeiter",
                Salery = 100
            };

            Console.WriteLine("Was ist worker2: " + worker2.GetType().Name);
            worker2.DoWork();
            worker2.Payout();

            if (worker2 is ICloneable origin)
            {
                var worker2Copy = (IWorkable)origin.Clone();
                Console.WriteLine("Was ist worker2Copy: " + worker2Copy.GetType().Name);

                worker2Copy.DoWork();
                worker2Copy.Payout();
            }
        }

        // Typischerweise wurede diese Methode in einem entfernten Klasse oder sogar Objekt liegen
        static IWorkable CreateInstance()
        {
            var worker = new HomoSapiens
            {
                Name = "Karl",
                Job = "Arbeiter",
                Salery = 2000,
                FavoriteFood = "nix"
            };
            return worker;
        }
    }
}
