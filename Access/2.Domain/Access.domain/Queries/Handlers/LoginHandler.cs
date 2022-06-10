using System;
using Access.domain.Interfaces;

namespace Access.domain.Queries.Handlers
{
    public class LoginHandler : IQueryHandler
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;

        public LoginHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public LoginResponse Handle(LoginRequest query)
        {
            //Validações
            if (string.IsNullOrEmpty(query.Username) || query.Username.Length < 3 || query.Username.Length > 40)
                throw new Exception("Usuário inválido");

            if (query.Password.Length < 6 && query.Password.Length > 100)
                throw new Exception("Senha inválida");

            //Verifica se o usuário existe
            var user = _userRepository.FindUser(query.Username);
            if (user is null)
                throw new Exception("Usuário não existente");

            //Verifica a senha
            if (query.Password != user.Password)
                throw new Exception("Senha incorreta");

            //Gera token
            var token = _tokenService.GenerateToken(user);

            //Retorna resposta
            return new LoginResponse() { Username = user.Username, Role = user.Role, Token = token };
        }
    }
}