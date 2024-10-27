using MediatR;
using SeasoningAndCandle.Backend.Application.Services.Interfaces;
using SeasoningAndCandle.Backend.Application.ViewModels;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Application.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthentificationService _authentificationService;
        public LoginCommandHandler(IUserRepository userRepository, IAuthentificationService authentificationService)
        {
            _userRepository = userRepository;
            _authentificationService = authentificationService;
        }

        /// <summary>
        /// Use this method to handle the request
        /// </summary>
        /// <param name="request">The user crendentials to login successfully</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Token Credentials</returns>
        /// <exception cref="Exception">Throws user or password wrong error</exception>
        public async Task<TokenViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //TODO: Validar la data que nos llega en el request

            // Traer el usuario de la base de datos que corresponda al correo
            User user = await _userRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("El usuario o la contraseña es incorrecta");
            }

            // Comparar la contraseña que nos llega en el request con la contraseña encriptada del usuario
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (!isPasswordValid)
            {
                throw new Exception("El usuario o la contraseña es incorrecta");
            }

            // Si las contraseñas coinciden, generar un token de acceso
            (string token, DateTime expirationDate) = _authentificationService.GenerateToken(user);

            // Retornamos el token de acceso
            return new TokenViewModel()
            {                
                AccessToken = token,
                ExpirationDate = expirationDate
            };
        }
    }
}
