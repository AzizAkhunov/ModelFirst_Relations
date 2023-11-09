namespace ModelFirst.Models
{
    public class Child
    {
        public int Id { get; set; }
        public int FatherId { get; set; }
        public Father Father { get; set; }
    }
}
