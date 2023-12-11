using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab1_ado2.Models
{
    public class Catalog
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Cloth")]
        public int cloth_id { get; set; }
        public decimal price { get; set; }
    }
}
