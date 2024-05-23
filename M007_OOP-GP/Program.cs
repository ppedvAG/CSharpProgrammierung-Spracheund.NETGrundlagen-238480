namespace M007_OOP_GP
{
    internal class Program
    {
        const int TOTAL_PERSON_COUNT = 10;

        static void Main(string[] args)
        {
            var list = new List<Person>();

            for (int i = 0; i < TOTAL_PERSON_COUNT; i++)
            {
                Person person = Factory.CreateRandomPerson();
                person.Print();

                list.Add(person);
            }

            // Wir rufen die statische Methode ShowCount() auf.
            Person.ShowCount();
            Console.WriteLine();

            // Fange bei 0 an und entferne die ersten Haelfte Elemente
            list.RemoveRange(0, TOTAL_PERSON_COUNT / 2);

            // Wir muessen den Garbage Collector rufen, damit er explizit den Speicher frei raeumt.
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Person.ShowCount();
            Console.WriteLine();
        }
    }
}
