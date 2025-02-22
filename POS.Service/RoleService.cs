using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

namespace POS.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> CreateRole(RoleDto roleDto)
        {
            var role = new RoleDto
            {
                RoleId = roleDto.RoleId,
                RoleName = roleDto.RoleName,
                Permissions = roleDto.Permissions
            };

            return await _roleRepository.CreateRole(role);
        }

        public async Task<RoleDto> UpdateRole(RoleDto roleDto)
        {
            var existingRole = await _roleRepository.GetRole(roleDto.RoleId);
            if (existingRole == null) return null;

            existingRole.RoleName = roleDto.RoleName;
            existingRole.Permissions = roleDto.Permissions;

            return await _roleRepository.UpdateRole(existingRole);
        }

        public async Task<RoleDto> DeleteRole(string roleId)
        {
            return await _roleRepository.DeleteRole(roleId);
        }

        public async Task<RoleDto> GetRole(string roleId)
        {
            return await _roleRepository.GetRole(roleId);
        }

        public async Task<IEnumerable<RoleDto>> GetRoles()
        {
            return await _roleRepository.GetRoles();
        }
    }
}
