using System.ComponentModel.DataAnnotations;
namespace POS.Core.Dtos;
public class RoleDto
{
    
    public string RoleId { get; set; } = null!;

    
    public string RoleName { get; set; } = null!;

    public string? Permissions { get; set; }

    public virtual ICollection<UserDto> Users { get; set; } = new List<UserDto>();
}
