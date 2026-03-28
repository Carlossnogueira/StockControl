using StockControl.Communication.Request;
using StockControl.Communication.Response.Login;
using StockControl.Domain.Repositories;
using StockControl.Domain.Security;
using StockControl.Domain.Service;
using StockControl.Exception.User;

namespace StockControl.Service.Login
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _userRepository;
        private readonly IAcessTokenGenerator _tokenGenerator;
        private readonly IPasswordEncrypter _passwordEncrypter;

        public LoginService(
                IUserRepository userRepository, 
                IAcessTokenGenerator tokenGenerator, 
                IPasswordEncrypter passwordEncrypter
            )
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<JwtTokenResponse> Login(LoginRequest loginRequest)
        {
            var userWithThisLogin = await _userRepository.GetByLoginAsync(loginRequest.Login);

            if (userWithThisLogin == null) 
            {
                throw new UserUnauthorizedException();
            }

            var passwordMatches = _passwordEncrypter.VerifyPassword(loginRequest.Password, userWithThisLogin.Password);

            if (!passwordMatches)
            {
                throw new UserUnauthorizedException();
            }

            var token = _tokenGenerator.Generate(userWithThisLogin);

            return new JwtTokenResponse(userWithThisLogin.Name, token);
        }
    }
}
