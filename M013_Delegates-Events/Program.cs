namespace M013_Delegates_Events
{
    // Definition eines eigenen Delegate-Datentypen
    public delegate int ComputeNumbersDelegate(int a, int b);

    public delegate void ComputeNumbersWithoutReturnDelegate(int a, int b, out int result);

    internal class Program
    {
        static void Main(string[] idontcareaboutthenameofthisparameter)
        {
            #region Delegates

            // Deklaration einer Delegate-Variablen
            ComputeNumbersDelegate compute = new ComputeNumbersDelegate(AddIntegers);

            // Aufruf der Methode
            int result1 = compute(42, 37);
            Console.WriteLine("Ergebnis des 1. Delegate-Aufrufs: " + result1);
            Console.WriteLine();

            // Neuzuweisung des Delegates
            compute = SubtractIntegers;
            int result2 = compute(42, 37);
            Console.WriteLine("Ergebnis des 2. Delegate-Aufrufs: " + result2);
            Console.WriteLine();

            // Mehr Methoden hinzufuegen - Reihenfolge nicht garantiert
            compute += AddIntegers;
            compute += AddIntegers;

            // Subtract wird 1x und Add wird 2x aufgerufen, weil unsere Delegate-Instanz insgesamt 3 Pointers zu Methoden enthaelt
            int result3 = compute(11, 11);
            Console.WriteLine("Ergebnis des 3. Delegate-Aufrufs: " + result3);
            Console.WriteLine();

            // Methode aus dem Delegate wieder loesen
            compute -= AddIntegers;

            foreach (Delegate item in compute.GetInvocationList())
            {
                Console.WriteLine(item.Method);
            }

            Console.WriteLine();
            var computeOut = new ComputeNumbersWithoutReturnDelegate(AddIntegers);
            computeOut(9, 4, out int resultOut);
            Console.WriteLine("Ergebnis des out delegates: " + resultOut);
            Console.WriteLine();

            #endregion

            #region FUNC, ACTION sind vordefinierte generische Delegate-Datentypen

            // aus System: public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
            Func<int, int, int> addFunc = AddIntegers;

            var funcResult1 = addFunc.Invoke(4, 7);
            Console.WriteLine("Ergebnis des 1. Func-Aufrufs: " + funcResult1);
            Console.WriteLine();

            var funcResult2 = Exectue(addFunc);
            Console.WriteLine("Ergebnis des 2. Func-Aufrufs: " + funcResult2);
            Console.WriteLine();

            // Eine Action hat kein Rueckgabeparaemter, aber mit dieser Kapselung koennen wir ihn ignorieren
            Action<int, int> action = (int a, int b) =>
            {
                // Wir verwerfen das Ergebnis; das signalisieren wir dem Compiler mit _
                _ = AddIntegers(a, b);
            };

            #endregion

            #region Events

            var publisher = new Publisher();

            var subscriber = new Subscriber(publisher);

            publisher.TriggerFinishedEvent();
            publisher.TriggerFinishedEventWithArgs();

            // Timer sollte ein Event "Elapsed" haben welches gefeuert wird wenn eine spezifizierte Zeit abgelaufen ist
            // Allerdings unterscheiden sich die APIs abhaengig von der verwendeten
            // .NET Variante (.NET Framework, .NET Core, .NET Standard, .NET)
            //var timer = new Timer((state) =>
            //{
            //    var t = (Timer)state;
            //    // Timer schliessen
            //    t.Dispose();
            //    Console.WriteLine("Das Callback des Timers wurde ausgefuehrt");
            //});
            //timer.Change(1000, Timeout.Infinite);

            #endregion
        }

        public static int AddIntegers(int a, int b)
        {
            Console.WriteLine("Addiere: " + a + ", " + b);
            return a + b;
        }

        public static int SubtractIntegers(int a, int b)
        {
            Console.WriteLine("Subtrahiere: " + a + ", " + b);
            return a - b;
        }

        public static int Exectue(Func<int, int, int> func)
        {
            return func(9, 22);
        }

        public static void AddIntegers(int a, int b, out int result)
        {
            Console.WriteLine("Addiere das in out: " + a + ", " + b);
            result = a + b;
        }
    }
}
