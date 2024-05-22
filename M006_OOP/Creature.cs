namespace M006_OOP
{
    public class Creature
    {
        #region Members

        // FELDER (Membervariablen) sind die Variablen einzelner Objekte welche die Zustaende dieser Objekte definieren
        // Felder sollten IMMER private sein weil wir ansonsten die Kontrolle des Programmflusses verlieren
        private string name = "Unnamed";

        #endregion

        #region Properties

        // EIGENSCHAFTEN (Propertiers) definieren mittels Getter/Setter den Lese-/Schreibzugriff fuer jeweils ein Feld
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                //if (value != null && value.Length > 0)
                // IsNullOrEmpty ist eine helper function welche den oberen Ausdruck lesbarer darstellt
                if (!string.IsNullOrEmpty(value))
                {
                    // Das Keyword VALUE beschreibt in einer Set-Methode den uebergebenen Wert
                    name = value;
                }
            }
        }

        // Wenn wir Properties auf diese Weise deklarieren, generiert der Compiler das entsprechende Feld unsichtbar im Hintergrund
        // Snippet: prop
        public string FavoriteFood { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Wir weisen hier einen initialen Standardwert zu. Koennte auch im Constructor gemacht werden
        public int Size { get; set; } = 0;

        public int Age
        {
            get
            {
                return ((DateTime.Now - DateOfBirth).Days / 365);
            }
        }

        public Creature Parent { get; private set; } // Default value ist null

        #endregion

        #region Constructors

        // Snippet: ctor
        // Das ist der Default Constructor welcher immer keine Parameter enthaelt.
        // Wenn kein Constructor in der Klasse definiert wird, generiert der Compiler diesen Constructor automatisch.
        public Creature()
        {
            
        }

        // Seit neueren C# Versionen muessen wir ein ? hinter den Typen setzen um es "Nullable" zu machen. Frueher geschah das implizit
        public Creature(string name, DateTime dateOfBirth, string favoriteFood, Creature? parent = null)
        {
            // C# kann nicht zwischen Parameter 'name' und Feld 'name' unterscheiden. 
            // Deshalb benutzen wir das Keyword 'this' welches auf die eigene Instanz der Klasse zeigt.
            this.name = name;
            DateOfBirth = dateOfBirth;
            FavoriteFood = favoriteFood;
            Parent = parent;

        }

        public Creature(string name, DateTime dateOfBirth, string favoriteFood, int size) 
            : this(name, dateOfBirth, favoriteFood)
        {
            Size = size;
        }

        #endregion

        #region Methods

        public void Grow()
        {
            Size += 1;
        }

        public Creature Reproduce(string childName)
        {
            var newCreature = new Creature(childName, DateTime.Now, "Babynahrung", this);
            return newCreature;
        }

        #endregion
    }
}
