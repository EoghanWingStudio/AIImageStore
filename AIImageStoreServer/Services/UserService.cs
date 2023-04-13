using AIImageStoreServer.Models;

namespace AIImageStoreServer.Services
{
    public interface IUserService
    {
        Task<ServiceResult<string>> Login(string username, string password);
        Task<ServiceResult<string>> Logout(string username);
        Task<ServiceResult<string>> CreateUser(CreateUser createUser);
        Task<User?> GetUserAsync(string username);
    }
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<string>> Login(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return new ServiceResult<string> { Success = false, Message = "Invalid username or password." };
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return new ServiceResult<string> { Success = false, Message = "Invalid username or password." };
            }
            return new ServiceResult<string> { Success = true, Message = "Login successful." };
        }

        public async Task<ServiceResult<string>> Logout(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return new ServiceResult<string> { Success = false, Message = "User not found." };
            }
            return new ServiceResult<string> { Success = true, Message = "Logout successful." };
        }

        public async Task<ServiceResult<string>> CreateUser(CreateUser createUser)
        {
            if (await _userRepository.GetUserByUsername(createUser.Username) != null)
            {
                return new ServiceResult<string> { Success = false, Message = "Username is already taken." };
            }

            var user = new User { Username = createUser.Username };
            CreatePasswordHash(createUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = createUser.Email;

            await _userRepository.AddUserAsync(user);

            return new ServiceResult<string> { Success = true, Message = "User created successfully." };
        }

        public async Task<User?> GetUserAsync(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);

            if (user != null)
                return user;
            return null;
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
 
