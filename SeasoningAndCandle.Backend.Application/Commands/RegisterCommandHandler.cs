using Mapster;
using MediatR;
using SeasoningAndCandle.Backend.Application.Services.Interfaces;
using SeasoningAndCandle.Backend.Application.ViewModels;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Application.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, TokenViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthentificationService _authentificationService;
        public RegisterCommandHandler(IUserRepository userRepository, IAuthentificationService authentificationService)
        {
            _userRepository = userRepository;
            _authentificationService = authentificationService;
        }
        public async Task<TokenViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //TODO: Validar la data que nos llega en el request

            // Verificamos si el usuario ya existe
            User existingUser = await _userRepository.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("El usuario indicado ya existe");
            }

            // Se Genera la contraseña encriptada (hash)
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            string hash = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            request.Password = hash;

            // Guardamos el usuario en la base de datos
            bool isCreated = await _userRepository.RegisterUserAsync(request.Adapt<User>());

            if (!isCreated)
            {
                throw new Exception("No se ha podido crear el usuario correctamente");
            }

            // Generamos el token de acceso
            (string token, DateTime expirationDate) = _authentificationService.GenerateToken(request.Adapt<User>());

            // Retornamos el token de acceso
            return new TokenViewModel
            {
                AccessToken = token,
                ExpirationDate = expirationDate
            };
        }
    }
}
