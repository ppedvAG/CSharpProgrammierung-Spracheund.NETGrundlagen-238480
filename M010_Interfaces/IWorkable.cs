namespace M009_Types_Poly
{
    public interface IWorkable
    {
        public int Salery { get; set; }

        public string Job { get; set; }

        public void DoWork();

        public void Payout();
    }
}
