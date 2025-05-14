namespace st10161149_prog7311_part2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int FarmerId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public Farmer Farmer { get; set; }
        public string? Category { get; set; }

    }
}
