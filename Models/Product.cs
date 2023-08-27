using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]

        [Column("ProductName", TypeName = "ntext")]
        public string? ProductName { get; set; }
        [Required]
        [Column(TypeName = "money")]

        public decimal ProductPrice { get; set; }

        public int? CategoryId { set; get; }

        public virtual Category? Category { set; get; } //Foreign key
        public int? CategoryId2 { set; get; }

        public virtual Category? Category2 { set; get; } //Foreign key



        public void PrintInfo()
        {
            Console.WriteLine($"{ProductId} - {ProductName} - {ProductPrice}");
        }
    }


}