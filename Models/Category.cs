using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }
        [StringLength(100)]
        public string? Name { set; get; }

        [Column(TypeName = "ntext")]
        public string? Description { set; get; }

        public virtual List<Product>? Products { set; get; }
    }
}