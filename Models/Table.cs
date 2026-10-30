using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopManagement.Models;

[Table("Tables")]
public class Table
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Area { get; set; } = "Tầng 1";

    /// <summary>
    /// 0: Trống (Empty), 1: Có khách (Occupied)
    /// </summary>
    public int Status { get; set; } = 0;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}

