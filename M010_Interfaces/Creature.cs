namespace M009_Types_Poly
{
    public abstract class Creature
    {
        public string Name { get; set; }

        public string FavoriteFood { get; set; }

        public abstract void Eat();
    }

    public class Cat : Creature
    {
        public override void Eat()
        {
            Console.WriteLine($"{Name} frisst {FavoriteFood}");
        }
    }
}
