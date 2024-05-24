
// Wir verwenden fuer die MathExtensions einen eigenen Namespace um nicht unerwuenschte Nebeneffekte zu verursachen!

namespace M016_Misc.Extensions
{
    public static class MathExtensions
    {
        public static double Round(this double value, int digits)
        {
            return Math.Round(value, digits);
        }
    }
}
