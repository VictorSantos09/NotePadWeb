using Application.Dto;
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
           var user = CreateNewUser(name, email, password);

            _userRepository.Add(user);

            return new BaseDto(200, "Conta criada com sucesso");
        }
        private UserEntity CreateNewUser(string name, string email, string password)
        {
            return new UserEntity(name.ToUpper(), email.ToUpper(), password);
        }
    }
}
