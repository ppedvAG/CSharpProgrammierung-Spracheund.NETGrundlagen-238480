using System.Diagnostics;
using System.Drawing;

namespace M016_Misc
{
    public enum Brand
    {
        Audi,
        BMW,
        Opel,
        VW,
        //Trabant,
        //Toyota,
        //Pegeut,
        //Citroen,
        //Skoda,
        //Volvo,
        //Fiat,
        //Ford
    }

    [DebuggerDisplay("Id: {Id}, Brand: {Brand}, Model: {Model}, Speed: {TopSpeed}, Color: {Color.Name}")]
    public class Vehicle
    {
        public int Id { get; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public int TopSpeed { get; }

        public Color Color { get; set; }

        public DateTime YearBuilt { get; set; }

        public Vehicle() : this(0, Brand.Audi, "", 0)
        {            
        }

        public Vehicle(int id, Brand brand, string model, int topSpeed)
        {
            Id = id;
            Brand = brand;
            Model = model;
            TopSpeed = topSpeed;
        }

        public string GetInfo()
        {
            return $"{Id}. Das Model {Model} von {Brand} hat die Farbe '{Color.Name}' und fährt maximal {TopSpeed} km/h.";
        }

        // Wir koennen ToString() ueberschreiben um waehrend dem Debuggen den Inhalt der Instanz sichtbar zu machen.
        // Wird nicht empfohlen. Stattdessen das Attribut [DebuggerDisplay] verwenden. Es wird im Release-Build entfernt.
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
