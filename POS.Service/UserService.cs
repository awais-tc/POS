using AutoMapper;
using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

namespace POS.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);
            if (user == null || !VerifyPassword(user.Password, password))
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var createdUser = await _userRepository.Create(userEntity);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByUsername(string username)
        {
            var user = await _userRepository.GetByUsername(username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task Update(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.Update(userEntity);
        }

        private bool VerifyPassword(string storedPassword, string enteredPassword)
        {
            // Implement password hashing and verification logic here.
            return storedPassword == enteredPassword; // Replace with proper hashing check.
        }
    }
}
