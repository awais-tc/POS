using POS.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public string UserId { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Password { get; set; } = null!;

    [MaxLength(200)]
    public string ContactInfo { get; set; } = null!;

    [Required]
    public string RoleId { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<UserPayment> UserPayments { get; set; } = new List<UserPayment>();
}
