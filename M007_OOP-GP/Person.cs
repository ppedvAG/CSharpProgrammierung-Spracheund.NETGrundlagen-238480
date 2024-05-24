namespace M007_OOP_GP
{
    public class Person
    {
        #region Feld, Get- und Set-Methode

        // Kann nur von innerhalb der Klasse zugegriffen werden
        private string _vorname = string.Empty;

        public string GetVorname()
        {
            return _vorname;
        }

        public void SetVorname(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _vorname = value;
            }
            else
            {
                Console.WriteLine("Fehler: Vorname darf nicht leer sein");
            }
        }

        #endregion

        #region Properties

        public string Vorname { get => _vorname; set => _vorname = value; }

        private string _nachname = "";

        public string Nachname
        {
            get { return _nachname; }
            set 
            { 
                if (!string.IsNullOrEmpty(value)) 
                {
                    _nachname = value;
                }
                else
                {
                    Console.WriteLine("Fehler: Nachname darf nicht leer sein");
                }
            }
        }

        public int Alter { get; private set; }

        // Alle Varianten sind identisch. Mit neueren C#-Sprachversionen wurden kuerzere Schreibweisen eingefuehrt.
        public string VollerName1 
        { 
            get
            {
                return _vorname + " " + _nachname;
            } 
        }

        public string VollerName2 { get => _vorname + " " + _nachname; }

        public string VollerName3 => _vorname + " " + _nachname;

        public string Initialen 
        { 
            get
            {
                // Wenn _vorname == null wuerde hier eine NullReferenceException fliegen weil _vorname noch nicht initialisiert wurde
                // Wir koennen hier auf null pruefen oder den string auf einen Leerstring mit string.Empty setzen, aber uns bleibt die Pruefung nicht erspart ob Zeichen vorhanden sind
                if (_vorname.Length > 0 && _nachname.Length > 0)
                {
                    return _vorname[0] + " " + _nachname[0];
                }
                return string.Empty;
            }
        }

        #endregion

        #region static Properties

        // Ein static Property (oder auch static Methoden) gelten ueber alle Klassen-Instanzen hinweg.
        public static int TotalPersonCount { get; private set; } = 0;

        #endregion

        #region Constructors

        public Person()
        {
            TotalPersonCount++;
        }

        public Person(string vorname, string nachname, int age)
            : this() // Default Konstruktor ohne Parameter aufrufen
        {
            Console.WriteLine(TotalPersonCount + ". Person wurde erstellt.");

            _vorname = vorname;
            _nachname = nachname;
            Alter = age;
        }

        #endregion

        // Dekonstruktor wird unmittelbar vor der zerstoeren aufgerufen
        ~Person() 
        {
            Console.WriteLine(_vorname + " ist von uns gegangen.");
            TotalPersonCount--;
        }

        #region Methoden

        // Wenn die Methode keinen Rueckgabewert haben soll, so geben wir das mit dem Keyword 'void' an
        public void Print()
        {
            Console.WriteLine($"Mein Name ist {VollerName1} und ich bin {Alter} Jahre alt.");
        }

        public static void ShowCount()
        {
            // Es kann nicht auf nicht-statische Member zugegriffen werden
            // Mit Members sind alle Felder, Properties und Methoden gemeint
            //Console.WriteLine(VollerName1);

            // Weil TotalPersonCount statisch ist koennen wir darauf zugreifen
            Console.WriteLine("Aktuelle Anzahl an Instanzen: " + TotalPersonCount);
        }

        #endregion

    }
}
