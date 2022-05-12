using System;
using Access.domain.Entities;
using Access.domain.Interfaces;

namespace Access.domain.Commands.Handlers
{
    public class RegisterHandler : ICommandHandler
    {

        private IUserRepository _userRepository;

        public RegisterHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public RegisterResponse Handle(RegisterRequest command)
        {

            //Validações
            if (string.IsNullOrEmpty(command.Username) || string.IsNullOrEmpty(command.Password) || string.IsNullOrEmpty(command.Email))
                throw new Exception("Preencha todas as informações");

            if (command.Username.Length < 3 && command.Username.Length > 40)
                throw new Exception("Nome inválido");

            if (command.Password.Length < 6 && command.Password.Length > 100)
                throw new Exception("Senha inválida");

            if (!command.Email.Contains("@"))
                throw new Exception("Email inválido");

            //Verifica se o usuário existe
            var userExists = _userRepository.FindUser(command.Username);
            if (userExists is not null)
                throw new Exception("Usuário já existente");

            //Gera entidade
            var user = new User(command.Username, command.Password, command.Email);

            //Salva informação
            _userRepository.CreateUser(user);

            //Retorna resposta
            return new RegisterResponse();
        }
    }
}