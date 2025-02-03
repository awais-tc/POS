using System.ComponentModel.DataAnnotations;

public class Role
{
    [Key]
    public string RoleId { get; set; } = null!;

    [Required, MaxLength(50)]
    public string RoleName { get; set; } = null!;

    public string? Permissions { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
