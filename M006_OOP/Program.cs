namespace M006_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Wenn wir ein Datum aus einem string initialisieren wollen, muessen wir es parsen.
            // Allerdings ist es schwierig da wir laenderspezifische Formatierungen beachten muessen
            var whatDateOfBirth = "2000-01-01";
            if (DateTime.TryParse(whatDateOfBirth, out var date))
            {
                // Wir erzeugen eine neue Instanz vom "Bauplan" der Klasse Creature.
                var instanceOfCreature = new Creature("Hugo", date, "Pizza");

                // Hier wird eine neue Instanz erzeugt mittels der Methode Reproduce
                var juniorInstance = instanceOfCreature.Reproduce("Junior");

                // Properties werden ohne Klammern gesetzt. Sie koennen zudem auf der linken Seite der Operation stehen.
                juniorInstance.FavoriteFood = "Lasagne";

                // Methoden werden grundsaetzlich mit Klammern aufgerufen. Sie koennen nur ausschliesslich auf der Rechten Seite der Operation stehen.
                juniorInstance.Grow();

                Console.WriteLine($"Lebewesen 1 heisst {instanceOfCreature.Name} und isst gerne {instanceOfCreature.FavoriteFood}.");
                Console.WriteLine($"Lebewesen 2 heisst {juniorInstance.Name} und isst gerne {juniorInstance.FavoriteFood}.");

                // false weil beide Objekte unterschiedliche Referenzen enthalten
                bool isNotEqual = juniorInstance == instanceOfCreature;

                // true weil Parent die Referenz von der Variablen instanceOfCreature enthaelt
                // Wir vergleichen hier immer Adressen, niemals den Inhalt von Objekten
                bool isEqual = juniorInstance.Parent == instanceOfCreature; 

            
            }

        }
    }
}
