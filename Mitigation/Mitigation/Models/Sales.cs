using System.ComponentModel.DataAnnotations.Schema;

namespace Mitigation.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int StoreItemId { get; set; }
        public int SalesNumber { get; set; } = 0;

        [ForeignKey("StoreItemId")]
        public StoreItem StoreItem { get; set; } = null!;

    }
}
