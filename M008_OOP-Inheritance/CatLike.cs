namespace M008_OOP_Inheritance
{
    public class CatLike : Creature
    {
        public string ColorOfFur { get; set; }

        public CatLike(int age) : base(age)
        {

        }

        public override void WhoAmI()
        {
            Console.WriteLine("Ich bin ein katzenartiges Lebewesen.");
        }
    }

    public class Tiger : CatLike
    {
        public Tiger(int age) : base(age) { }
    }
}
