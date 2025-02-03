using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;
using POS.Core.Service;

namespace POS.Service
{
    internal class UserService : IUserService
    {
        public Task<UserDto> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Create(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
