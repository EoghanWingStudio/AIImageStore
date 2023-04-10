namespace AIImageStoreServer.Services
{
    public interface IUserService
    {

    }
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }


    }
}
