using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IUserRepository
    {
        Task<UserDto> Authenticate(string username, string password);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> Create(UserDto user);
        Task Update(UserDto user);
        Task Delete(int id);
        Task<UserDto> GetByUsername(string username);

    }
}
