using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopManagement.Models;

[Table("BillDetails")]
public class BillDetail
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int BillId { get; set; }

    [ForeignKey(nameof(BillId))]
    public virtual Bill Bill { get; set; } = null!;

    [Required]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    public int Quantity { get; set; } = 1;

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal LineTotal => Quantity * UnitPrice;
}
