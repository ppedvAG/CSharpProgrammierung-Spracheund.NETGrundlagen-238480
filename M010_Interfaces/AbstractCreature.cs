namespace M009_Types_Poly
{
    public abstract class AbstractCreature
    {
        public string Name { get; set; }

        public string FavoriteFood { get; set; }

        public abstract void Eat();

        protected AbstractCreature()
        {
            Name = string.Empty;
            FavoriteFood = string.Empty;
        }
    }

    public class Cat : AbstractCreature
    {
        public override void Eat()
        {
            Console.WriteLine($"{Name} frisst {FavoriteFood}");
        }
    }
}
