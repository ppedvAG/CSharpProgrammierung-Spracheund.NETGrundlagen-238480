namespace M009_Types_Poly
{
    public abstract class Creature
    {
        public string Name { get; set; }

        public string FavoriteFood { get; set; }

        public abstract void Eat();
    }

    public class HomoSapiens : Creature
    {
        public string Job { get; set; }

        public override void Eat()
        {
            Console.WriteLine($"{Name} konsumiert {FavoriteFood}");
        }

        public void DoWork()
        {
            Console.WriteLine($"{Name} geht als {Job} arbeiten.");
        }
    }

    public class Cat : Creature
    {
        public override void Eat()
        {
            Console.WriteLine($"{Name} frisst {FavoriteFood}");
        }
    }
}
