
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
