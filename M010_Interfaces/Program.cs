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
            if (worker1 is AbstractCreature creature)
            {
                creature.Eat();
            }
            Console.WriteLine(); // Leerzeile

            IWorkable worker2 = new Robot()
            {
                Job = "Arbeiter",
                Salery = 100
            };

            Console.WriteLine("Was ist worker2: " + worker2.GetType().Name);
            worker2.DoWork();
            worker2.Payout();
            Console.WriteLine(); // Leerzeile

            if (worker2 is ICloneable origin)
            {
                var worker2Copy = (IWorkable)origin.Clone();
                Console.WriteLine("Was ist worker2Copy: " + worker2Copy.GetType().Name);

                worker2Copy.DoWork();
                worker2Copy.Payout();
            }

            Console.WriteLine("\n\nPolymorphismus\n==============\n");
            ExplainPolymorphism();

            Console.WriteLine(); // Leerzeile

            // Wir koennen zwar diese Anweisung schreiben, aber es wird zur Laufzeit eine InvalidCastException auftreten!
            //var homoSapiens = (HomoSapiens)worker2;
            //homoSapiens.Eat();

            // Deshalb muessen wir vorher ueberpruefen, ob worker2 ein HomoSapiens ist
            if (worker2 is HomoSapiens)
            {
                var homoSapiens = (HomoSapiens)worker2;
                homoSapiens.Eat();
            } else
            {
                Console.WriteLine("Eat() konnte nicht ausgefuehrt werden weil worker2 kein HomoSapiens ist.");
            }
        }

        private static void ExplainPolymorphism()
        {
            // Vererbungskette: HomoSapiens >> AbstractCreature >> IWorkable
            HomoSapiens sam1 = new HomoSapiens("Sam");
            AbstractCreature sam2 = new HomoSapiens("Sam");
            IWorkable sam3 = new HomoSapiens("Sam");

            Console.WriteLine($"Ist HomoSapiens ein HomoSapiens? {sam1.GetType() == typeof(HomoSapiens)}");
            Console.WriteLine($"Ist Creature ein HomoSapiens? {sam2.GetType() == typeof(HomoSapiens)}");
            Console.WriteLine($"Ist Creature eine Creature? {sam2.GetType() == typeof(AbstractCreature)}");
            Console.WriteLine($"Ist IWorkable ein HomoSapiens? {sam3.GetType() == typeof(HomoSapiens)}");
            Console.WriteLine($"Ist IWorkable ein IWorkable? {sam3.GetType() == typeof(IWorkable)}");

            Console.WriteLine(@"
          Sam ist und bleibt ein HomoSapiens zur Laufzeit.
    ABER: Sam kann zur Kompilierzeit verschiedene Typen annehmen.
          Wir tun das, um uns auf wesentliche Fähigkeiten zu beschränken wie IWorkable.DoWork()");

            HomoSapiens sam3specific = (HomoSapiens)sam3;
            sam3specific.Eat(); // Eat() ist nicht bestandteil von IWorkable
        }

        // Typischerweise wurede diese Methode in einem entfernten Klasse oder sogar Objekt liegen
        static IWorkable CreateInstance()
        {
            var worker = new HomoSapiens("Karl")
            {
                Job = "Arbeiter",
                Salery = 2000,
                FavoriteFood = "nix"
            };
            return worker;
        }
    }
}
