using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopManagement.Models;

[Table("Bills")]
public class Bill
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TableId { get; set; }

    [ForeignKey(nameof(TableId))]
    public virtual Table Table { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    public DateTime CheckInDate { get; set; } = DateTime.Now;

    public DateTime? CheckOutDate { get; set; }

    /// <summary>
    /// 0: Chưa thanh toán (Unpaid), 1: Đã thanh toán (Paid)
    /// </summary>
    public int Status { get; set; } = 0;

    public int DiscountPercent { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; } = 0;

    public virtual ICollection<BillDetail> Details { get; set; } = new List<BillDetail>();
}

