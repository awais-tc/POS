
using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IUserService
    {
        Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> Create(UserDto user);
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByUsername(string username);
        Task Update(UserDto user);
    }
}
