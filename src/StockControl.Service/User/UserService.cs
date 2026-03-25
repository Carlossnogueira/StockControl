using Mapster;
using StockControl.Communication.Request.User;
using StockControl.Domain.Repositories;
using StockControl.Domain.Security;
using StockControl.Domain.Service;
using StockControl.Exception;
using StockControl.Exception.User;
using StockControl.Service.Validation;

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
            var userWithSameLogin = await _userRepository.GetByLoginAsync(userDto.Login);
           
            if(userWithSameLogin != null)
            {
                throw new UserAlreadyExistsException();
            }

           ValidateCreateUserDto(userDto);

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

        private void ValidateCreateUserDto(CreateUserDto userDto)
        {
            var validator = new UserValidator();
            var validationResult = validator.Validate(userDto);
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
            {
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
