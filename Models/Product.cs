using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]

        [Column("ProductName", TypeName = "ntext")]
        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "money")]

        public decimal ProductPrice { get; set; }

        public int CategoryId { set; get; }

        [ForeignKey("CategoryId")]
        public Category? Category { set; get; } //Foreign key

        public void PrintInfo()
        {
            Console.WriteLine($"{ProductId} - {Name} - {ProductPrice}");
        }
    }


}