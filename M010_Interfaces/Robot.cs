using M009_Types_Poly;
using System.Xml.Linq;

namespace M010_Interfaces
{
    internal partial class Program
    {
        public class Robot : IWorkable, System.ICloneable
        {
            public Robot? Parent { get; set; }

            public int Salery {  get; set; }
            public string Job { get; set; }

            public object Clone()
            {
                var clone = (Robot)MemberwiseClone();
                clone.Parent = this;
                return clone;
            }

            public void DoWork()
            {
                Console.WriteLine($"Robter geht als {Job} arbeiten.");
            }

            public void Payout()
            {
                Console.WriteLine($"Der Robter als {Job} hat Wartungskosten von {Salery} Credits.");
            }
        }
    }
}
