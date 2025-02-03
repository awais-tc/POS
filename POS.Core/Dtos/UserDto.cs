
namespace POS.Core.Dtos;
public class UserDto
{
    
    public string UserId { get; set; } = null!;

    
    public string Name { get; set; } = null!;

    
    public string Username { get; set; } = null!;

    
    public string Password { get; set; } = null!;

    
    public string ContactInfo { get; set; } = null!;

    
    public string RoleId { get; set; } = null!;

    public virtual RoleDto Role { get; set; } = null!;

    public virtual ICollection<SaleDto> Sales { get; set; } = new List<SaleDto>();

    public virtual ICollection<UserPaymentDto> UserPayments { get; set; } = new List<UserPaymentDto>();
}
