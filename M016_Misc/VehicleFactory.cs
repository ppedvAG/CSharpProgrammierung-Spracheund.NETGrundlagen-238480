using System.Drawing;

namespace M016_Misc
{
    public class VehicleFactory
    {
        private static readonly Random random = new Random();
        private static readonly int BrandCount = Enum.GetValues(typeof(Brand)).Length;
        private static readonly int ColorCount = Enum.GetValues(typeof(KnownColor)).Length;

        public static Vehicle CreateVehicle(int id)
        {
            // Zufaellige Automarke
            var brand = (Brand)random.Next(0, BrandCount);
            
            // Zufaellige Farbe (die ersten 27 Eintraege sind Systemfarben)
            var color = (KnownColor)random.Next(27, ColorCount);

            var modelNumber = random.Next(0, 10);
            var topSpeed = random.Next(10, 25) * 10;
            var car = new Vehicle(id, brand, "model_" + modelNumber, topSpeed)
            {
                Color = Color.FromKnownColor(color),
            };
            return car;
        }
    }
}
