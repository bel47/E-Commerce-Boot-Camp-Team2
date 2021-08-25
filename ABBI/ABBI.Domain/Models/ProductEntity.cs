using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPICompleted.Models
{
    [Table("Products", Schema = "dbo")]
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        
        [Required]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "SupplierId")]
        public string SupplierId { get; set; }

        [Required]
        [Display(Name = "CategoryId")]
        public string CategoryId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public float Quantity { get; set; }
        [Required]
        [Display(Name = "UnitPrice")]
        public float UnitPrice { get; set; }

    }
}
