namespace M008_OOP_Inheritance
{
    public class HomoSapiens : Creature
    {
        public string Name { get; set; }

        public HomoSapiens(string name, int age) : base(age)
        {
            Name = name;

            firstAppeareanceOnEarth = "12000 years ago";

            base.firstAppeareanceOnEarth = "12000 years ago";

            // this funktioniert nur, wenn in dieser Klasse ein Member mit gleichem Namen nicht existiert
            this.firstAppeareanceOnEarth = "12000 years ago";
        }

        public override void WhoAmI()
        {
            base.WhoAmI();
            Console.WriteLine(" und habe zwei Beine und kann sprechen.");
        }

        public void Speak()
        {
            Console.WriteLine("Hello World");
        }
    }
}
