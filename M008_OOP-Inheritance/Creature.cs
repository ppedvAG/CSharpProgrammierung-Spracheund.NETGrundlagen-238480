namespace M008_OOP_Inheritance
{
    public class Creature
    {
        protected string firstAppeareanceOnEarth;

        public int Age { get; set; }

        // Kann von abgeleiteten Klassen NICHT ueberschrieben werden
        public void WhoAmIFix()
        {
            Console.WriteLine("Ich bin ein Lebewesen");
        }

        // Kann von abgeleiteten Klassen ueberschrieben werden
        public virtual void WhoAmI()
        {
            Console.WriteLine("Ich bin ein Lebewesen");
        }

        public Creature(int age)
        {
            Age = age;
        }
    }
}
