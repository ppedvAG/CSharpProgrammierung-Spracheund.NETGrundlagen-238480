using System.Collections.Generic;
using System.Drawing;

internal class Program
{
    #region Enums

    enum Weekday
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
    }

    // Wird haufig im Embedded Bereich (systemnahe Programmierung) eingesetzt
    enum WeekdayFlags
    {
        Monday = 0b00000,
        Tuesday = 0b00001,
        Wednesday = 0b00010,
        Thursday = 0b00100,
        Friday = 0b01000,
        Saturday = 0b10000,
    }

    #endregion

    private static void Main(string[] args)
    {
        #region Loops

        // Kommentar mit Emojis 🐲🐉

        int start = 0;
        int end = 10;

        while (start < end)
        {
            Console.WriteLine("while " + start);
            start++;
        }

        start = 0;

        while (true)
        {
            // Hier geht es bei 'continue' weiter

            // Das Statement in geschweiften Klammern nennt sich Block
            {
                start++;
            }

            if (start == 5)
            {
                // Ueberspringt den Output von 5 und faengt wieder am Anfang des Blocks an
                continue;
            }

            Console.WriteLine("Index of current endless loop " + start);

            if (start >= end)
                // Bei break ueberspringt das Programm den aktuellen Block
                break;
        }
        // Hier geht es nach 'break' weiter

        ConsoleKeyInfo endLoop;
        do
        {

            Console.WriteLine("Press Escape to quite infinite loop.");

            endLoop = Console.ReadKey(true);
        } while (endLoop.Key != ConsoleKey.Escape);

        // Iterate through arrays
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("Current Index of for loop: " + i);
        }

        string[] names = new[] { "Hugo", "Max", "Julia" };

        foreach (string name in names)
        {
            Console.WriteLine("Current name is " + name);
        }

        foreach (Weekday day in Enum.GetValues<Weekday>())
        {
            Console.WriteLine($"Current day of the week is '{day}' with value '{(int)day}'.");
        }

        #endregion

        #region

        Console.WriteLine("Bitte Wochentag (0-6) eingeben");
        string dayOfWeekString = Console.ReadLine();
        var switchOnDay = (DayOfWeek)int.Parse(dayOfWeekString);

        Console.WriteLine($"Sie haben {switchOnDay} gewaehlt.");

        switch (switchOnDay)
        {
            case DayOfWeek.Monday:
                Console.WriteLine("I hate Mondays!");
                break; // break; ist pflicht, ansonsten Fehlercode CS0163

            case DayOfWeek.Tuesday:
            case DayOfWeek.Thursday:
                Console.WriteLine("Day names starting with 'T'!");
                break;

            case DayOfWeek.Friday:
                Console.WriteLine("Almost weekend!");
                break; // Bei break ueberspringt das Programm den aktuellen Block

            case DayOfWeek.Sunday or DayOfWeek.Saturday:
                Console.WriteLine("Wochenende!");
                break;

            default: // wie else bei if-else
                Console.WriteLine("No case specified");
                break;
        }
        // Hier setzt das Programm bei 'break' fort

        #endregion


        _ = Console.ReadKey(true);
    }
}