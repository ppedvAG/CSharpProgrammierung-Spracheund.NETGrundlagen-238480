namespace M012_Exceptionhandling
{
    public class ExceptionWhileParsingExample
    {
        public DateTime? ParseDateTime(string formattedDate)
        {
            if (formattedDate != null)
            {
                Console.WriteLine("Trying to process " + formattedDate);

                // Snippet: try
                try
                {
                    var date = DateTime.Parse(formattedDate);

                    Console.WriteLine("ProcessDateTime hat fehlerfrei funktioniert und wurde verarbeitet");
                    Console.WriteLine(date.ToString());

                    return date;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Das Datumsformat '{formattedDate}' ist ungueltig.");
                }
                finally
                {
                    // Hier koennten wir geoeffnete Dateien schliessen
                    // oder temporaere Dateien wieder loeschen.

                    // Wird auch ausgefuehrt obwohl weiter oben return true ausgefuehrt wurde
                    Console.WriteLine("Danke");
                }
            }

            return null;
        }

        public void ThrowAnExceptionJustForFun()
        {
            throw new MyAwesomeException();
        }
    }
}
