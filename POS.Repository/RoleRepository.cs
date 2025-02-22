using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Repository.Context;

namespace POS.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly POSDbContext _context;

        public RoleRepository(POSDbContext context)
        {
            _context = context;
        }

        public async Task<RoleDto> CreateRole(RoleDto roleDto)
        {
            var role = new Role
            {
                RoleId = roleDto.RoleId,
                RoleName = roleDto.RoleName,
                Permissions = roleDto.Permissions
            };

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return roleDto;
        }

        public async Task<RoleDto> UpdateRole(RoleDto roleDto)
        {
            var role = await _context.Roles.FindAsync(roleDto.RoleId);
            if (role == null) return null;

            role.RoleName = roleDto.RoleName;
            role.Permissions = roleDto.Permissions;

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();

            return roleDto;
        }

        public async Task<RoleDto> DeleteRole(string roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null) return null;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Permissions = role.Permissions
            };
        }

        public async Task<RoleDto> GetRole(string roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null) return null;

            return new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Permissions = role.Permissions
            };
        }

        public async Task<IEnumerable<RoleDto>> GetRoles()
        {
            return await _context.Roles
                .Select(role => new RoleDto
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Permissions = role.Permissions
                })
                .ToListAsync();
        }
    }
}
