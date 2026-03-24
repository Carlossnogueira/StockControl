using Mapster;
using StockControl.Communication.Request.User;
using StockControl.Domain;
using StockControl.Domain.Entities;
using StockControl.Domain.Repositories;
using StockControl.Domain.Service;

namespace StockControl.Service.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IPasswordEncrypter _passwordEncrypter;

        public UserService(
            IUserRepository userRepository, 
            IUnityOfWork unityOfWork,
            IPasswordEncrypter passwordEncrypter)
        {
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<Domain.Entities.User> CreateUserAsync(CreateUserDto userDto)
        {
            var userWithSameLogin = _userRepository.GetByLoginAsync(userDto.Login);
           
            if(userWithSameLogin == null)
            {
                // TODO : Create custom exception for this case
                throw new Exception("Login already exists.");
            }

            var passwordHash = _passwordEncrypter.EncryptPassword(userDto.Password);

            var user = userDto.Adapt<Domain.Entities.User>();
            user.Password = passwordHash;

            var result = await _userRepository.CreateAsync(user);
            await _unityOfWork.Commit();

            return result;
        }

        public Task<Domain.Entities.User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.User?> GetbyName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
