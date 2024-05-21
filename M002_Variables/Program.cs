#region Variablen

// Kommentar

/*
 * Mehrzeilige Kommentare
 */

int number;
number = 45;

Console.WriteLine(number);

var number2 = 56;

char c = 'a';
var text = "Das ist ein Text";
var textMitZeilenumbruch = "Das ist \r\nein Test";

var mergedText = "Text mit Variable " + number2 + "!";
var formattedText = string.Format("Text mit Variablen {0} und {1}", number2, number);
var formattedTextJustBetter = $"Text mit Variablen {number2} und {number}!";

string pathToFile = "C:\\my path\\";
string simplerPath = @"C:\my path\"; // so koennen wir pfade einfacher darstellen

#endregion

#region Eingabe

string eingabe = Console.ReadLine(); // Rueckgabe der Funktion steht in der Variablen
Console.WriteLine($"Du hast {eingabe} eingegeben.");

var info = Console.ReadKey(true);
Console.WriteLine($"Du hast {info.Key} getippt.");

#endregion

#region Konvertierung

int number0845 = 123;
var number0846AsString = number0845.ToString();
number0846AsString = $"{number0845}";

var parsedNumber = int.Parse(number0846AsString);
var doppelt = parsedNumber * 2;
Console.WriteLine(doppelt);

double doubleNumber = 2.5;
float singlePrecision = 2.4f;

// Cast, Typecast, Casting: Umwandlung von einer Variable in einen anderen Typen erzwingen
int x = (int)doubleNumber; // x waere jetzt 2 (ungerundet, nur Nachkommastellen abgeschnitten)
Console.WriteLine(x);

double y = x; // impliziter Cast da int immer in double hinein passt

#endregion

#region Arithmetik
// Grundrechenarten +, -, *, /, %

var even = 42 % 2; // Rest waere 0 also ist die Zahl gerade
var uneven = 67 % 2; // Rest waere 1 also ist die Zahl ungerade

number++; // erhoehe Zahl um 1
++number; // erhoehe Zahl um 1
number--; // verringere Zahl um 1

Math.Floor(4.56); // immer Abrunden, unabhaengig von den Nachkommastellen!
Math.Ceiling(4.5); // immer Aufrunden, unabhaengig von den Nachkommastellen!
Math.Round(4.5); // Auf- oder abrunden, abhaengig von den Nachkommastellen

#endregion