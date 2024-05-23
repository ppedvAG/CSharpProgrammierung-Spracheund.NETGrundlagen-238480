namespace M009_Types_Poly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creature hugo = CreateCreature(true, "Hugo");
            hugo.Eat();

            // Mit GetType() fragen wir den Typ zur Laufzeit ab: HomoSapiens
            Console.WriteLine("Was bin ich: " + hugo.GetType().Name);

            Creature garfield = CreateCreature(false, "Garfield");
            garfield.Eat();

            // Mit GetType() fragen wir den Typ zur Laufzeit ab: Cat
            Console.WriteLine("Was bin ich: " + garfield.GetType().Name);


            // Das wurede zur Laufzeit zu einer InvalidCastException fuehren weil Cat != HomoSapiens!
            //var human = (HomoSapiens)garfield;
            //human.DoWork();

            //if (hugo.GetType() == typeof(HomoSapiens)) 
            // oder kuerzer
            if (hugo is HomoSapiens)
            {
                var human = (HomoSapiens)hugo;
                human.DoWork();
            }

            if (hugo is HomoSapiens homo)
            {
                homo.DoWork();
            }

        }

        static Creature CreateCreature(bool shouldDoWork, string name)
        {
            if (shouldDoWork)
            {
                //var human = new HomoSapiens();
                //human.Name = name;
                //human.FavoriteFood = "Pizza";

                // Objektinitialisierung kann vereinfacht werden, aber entspricht der oberen Deklaration
                var human = new HomoSapiens
                {
                    Name = name,
                    FavoriteFood = "Pizza",
                    Job = "Komiker"
                };

                return human;
            } 
            else
            {
                var cat = new Cat
                {
                    Name = name,
                    FavoriteFood = "Lasagne"
                };
                return cat;
            }
        }
    }
}
