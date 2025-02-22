using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IRoleService
    {
        Task<RoleDto> CreateRole(RoleDto roleDto);
        Task<RoleDto> UpdateRole(RoleDto roleDto);
        Task<RoleDto> DeleteRole(string roleId);
        Task<RoleDto> GetRole(string roleId);
        Task<IEnumerable<RoleDto>> GetRoles();
    }
}
