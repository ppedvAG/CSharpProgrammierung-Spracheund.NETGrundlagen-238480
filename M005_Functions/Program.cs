internal class Program
{
    private static void Main(string[] args)
    {
        var sum1 = Add(1, 2);
        Console.WriteLine("Summiere integers a und b; c=0: " + sum1);

        var sum2 = Add(1f, .78, 1e-6);
        Console.WriteLine("Summiere doubles a und b; c=0: " + sum2);

        var sum3 = Sum(5, 34, 37, 9, -1, -25); // Parameter werden automatisch als Array an Sum() uebergeben da Methode das Keyword "params" enthaelt.
        Console.WriteLine("Summiere params: " + sum3);

        string error;
        var diff = Diff(1, 0, out error);
        Console.WriteLine("Dividiere durch 0: " + diff + " Fehler: " + error);

        var diff2 = Diff(1, 0, out string error2);
        Console.WriteLine("Dividiere durch 0: " + diff2 + " Fehler: " + error2);

        Console.WriteLine("Bitte Zahl eingeben");
        var stringNumber = Console.ReadLine();

        // Kann potentiell eine Exception werfen: ArgumentNullException wenn nichts eingegeben wurde und FormatException wenn Buchstaben eingegeben wurden
        //var maybeNumber = int.Parse(stringNumber); 

        // Wenn Benutzer Buchstaben statt Zahlen eingibt fliegt eine Exception
        // Um das zu vermeiden verwenden wir statt Parse() die Methode TryParse()
        bool success = int.TryParse(stringNumber, out var number);
        if (success)
        {
            Console.WriteLine($"Du hast die Zahl {number} korrekt eingegeben.");
        } 
        else
        {
            Console.WriteLine($"Eingabe '{stringNumber}' ist ungueltig.");
        }
    }

    static int Add(int a, int b, int c=0)
    {
        return a + b + c;
    }

    static double Add(double a, double b, double c =0)
    {
        return a + b + c;
    }

    static int Sum(params int[] numbers)
    {
        int sum = 0;

        Console.WriteLine($"Summiere {numbers.Length} Zahlen.");

        foreach (int i in numbers) 
        { 
            sum += i; // Kurzschreibweise fuer sum = sum + i
        }
        return sum;
    }

    static double Diff(double a, double b, out string error)
    {
        if (b == 0)
        {
            error = "Teilung durch 0 nicht erlaubt";
            return 0;
        }
        error = "";
        return a / b;
    }
}