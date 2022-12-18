using Application.Dto;
using Crosscutting.Validator;
using Domain.Entities;
using Repository.Repository;

namespace Application.Services
{
    public class RegisterService
    {
        private readonly UserRepository _userRepository;

        public RegisterService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto RegisterProcess(string name, string email, string password)
        {
            (bool valid, string message) = ValidationProcess(email, name, password);

            if (!valid)
                return new BaseDto(406, message);

            var user = CreateNewUser(name, email, password);

            _userRepository.Add(user);

            return new BaseDto(200, "Conta criada com sucesso");
        }
        private UserEntity CreateNewUser(string name, string email, string password)
        {
            return new UserEntity(name.ToUpper(), email.ToUpper(), password);
        }
        private (bool, string) ValidationProcess(string email, string name, string password)
        {
            if(IsExistentUser(email,password))
                return (false, "Usuario já cadastrado");


            if (!RegisterValidator.IsValidEmail(email))
                return (false, "Email inválido");

            if (!RegisterValidator.IsValidPassword(password))
                return (false, "Senha inválida");

            if (!RegisterValidator.IsValidName(name))
                return (false, "Nome inválido");

            return (true, "Dados válidos");
        }
        public bool IsExistentUser(string email, string password)
        {
            return _userRepository.GetAll().Exists(x => x.Email == email.ToUpper() && x.Password == password);
        }
    }
}
