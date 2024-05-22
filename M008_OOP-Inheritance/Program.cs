namespace M008_OOP_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var max = new HomoSapiens("Max", 24);
            max.WhoAmI();

            var maxPet = new Tiger(4);
            maxPet.ColorOfFur = "Orange";
        }
    }
}
