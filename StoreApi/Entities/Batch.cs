using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Entities
{
    public class Batch
    {
        [Key]
        public int IdBatch { get; set; }
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool Active { get; set; } = true;
    }
}
