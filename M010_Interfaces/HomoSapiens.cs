namespace M009_Types_Poly
{
    public class HomoSapiens : AbstractCreature, IWorkable
    {
        public int Salery { get; set; }

        public string Job { get; set; } = string.Empty;

        public HomoSapiens(string name)
        {
            Name = name;
        }

        public override void Eat()
        {
            Console.WriteLine($"{Name} konsumiert {FavoriteFood}");
        }

        public void DoWork()
        {
            Console.WriteLine($"{Name} geht als {Job} arbeiten.");
        }

        public void Payout()
        {
            Console.WriteLine($"{Name} hat {Salery} Euro als {Job} bekommen.");
        }
    }
}
