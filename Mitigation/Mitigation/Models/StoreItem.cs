namespace Mitigation.Models
{
    public class StoreItem
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Price { get; set; }
    }
}
