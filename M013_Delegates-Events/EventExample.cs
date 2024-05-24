namespace M013_Delegates_Events
{
    public class FinishedEventArguments
    {
        public string Message { get; }

        public int LuckyNumber { get; set; }

        public FinishedEventArguments(string message)
        {
            Message = message;
        }
    }


    public class Publisher
    {
        public event EventHandler FinishedEvent;

        public event EventHandler<FinishedEventArguments> FinishedEventWithArgs;

        public void TriggerFinishedEvent()
        {
            // Wenn es keine Abonennten gibt ist FinishedEvent == null
            if (FinishedEvent != null)
            {
                //FinishedEvent.Invoke(this, EventArgs.Empty);

                // oder
                FinishedEvent(this, EventArgs.Empty);
            }
        }

        public void TriggerFinishedEventWithArgs()
        {
            var args = new FinishedEventArguments("Hallo mein Abonennt!\nDie Aufgabe wurde erledigt.");
            args.LuckyNumber = 7;

            // Das Fragezeichen ist die Kurzschreibweise fuer eine Null-Ueberpruefung
            FinishedEventWithArgs?.Invoke(this, args);
        }
    }

    public class Subscriber
    {
        public Subscriber(Publisher publisher)
        {
            // Hier haengen wir uns an das Event dran
            publisher.FinishedEvent += OnFinishedEvent;
            publisher.FinishedEventWithArgs += OnFinishedEventWithArgs;
        }

        public void OnFinishedEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Event wurde von {sender.GetType().Name} ausgeloest!");
        }

        public void OnFinishedEventWithArgs(object sender, FinishedEventArguments e)
        {
            Console.WriteLine($"Event wurde von {sender.GetType().Name} ausgeloest und teilt uns mit: " + e.Message);
        }
    }
}
