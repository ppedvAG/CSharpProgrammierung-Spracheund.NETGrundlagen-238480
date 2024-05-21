#region Arrays
var arrayOfNumbers = new int[] { 2, 4, 6, 8 };
var emptyArrayFor10Elements = new double[10];

var thirdEntry = arrayOfNumbers[2]; // Index von 0 bis n-1

Console.WriteLine("Laenge des arrays: " + arrayOfNumbers.Length);

var sum = arrayOfNumbers.Sum();
Console.WriteLine("Summe des arrays: " + sum);
var avg = arrayOfNumbers.Average();
Console.WriteLine("Durchschnittswert des arrays: " + avg);

// Statt arrays koennen auch Listen verwendet werden
// Unterschied zum Array ist, dass Listen in ihrer Groesse dynamisch wachsen koennen
var listOfNumbers = new List<int>() { 1, 2, 4 };
listOfNumbers.Add(42);
listOfNumbers.Add(37);
//listOfNumbers.Remove(42);

var firstEntry = listOfNumbers[0];

Console.WriteLine("Leange der Liste: " + listOfNumbers.Count());

var foundResult = listOfNumbers.FindIndex((x) => x == 42);
Console.WriteLine("Found 42? Position: " + foundResult);

string greeting = "Hello World"; // string ist ein array vom Typ char
char[] chars1 = new char[] { 'H', 'e', 'l', 'l', 'l' };
char[] chars2 = new[] { 'H', 'e', 'l', 'l', 'l' };
var chars3 = new[] { 'H', 'e', 'l', 'l', 'l' };

//chars1[42] = '7'; // System.OutOfRangeException

Console.WriteLine("4th letter of \"Hello World\": " + greeting[3]);

// Array mit 3 Zeilen und zwei Spalten als Matrix
// Es muss auch immer "rechteckig" sein, also immer gleich viele Spalten haben
var array2d = new int[,] { { 1, 2 }, { 3, 4 }, { 4, 5 }, /* { 1, 2, 3 } */ };

// Aneinander gehaengtes Array: Ein Array von arrays
// Auch wenn es die selbe Groesse hat wie das vorherige Array, so sind sie nicht miteinander kombinierbar
var array2dSq = new int[3][];

#endregion

#region Bedingungen
// Booleschen Operatoren
// ==, !=, <, >, <=, >=
// Logische Operatoren 
// &&, ||, !

int n1 = 4, n2 = 5;

if (n1 == n2)
{
    Console.Write("n1 und n2 sind gleich" + Environment.NewLine);
}
else
{
    Console.WriteLine("n1 und n2 sind ungleich");
}

if (n1 > 0 ^ n2 > 0)
{
    Console.WriteLine("n1 oder n2 aber nicht beide groesser als 0 sind");
}

// Usw. siehe Folien :-)

#endregion