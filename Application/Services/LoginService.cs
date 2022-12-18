using Application.Dto;
using Repository.Repository;

namespace Application.Services
{
    public class LoginService
    {
        private readonly UserRepository _userRepository;

        public LoginService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto LoginProcess(string email, string password)
        {
            var user = _userRepository.GetByEmail(email.ToUpper(), password);
            
            if (user == null)
                return new BaseDto(404, "Usuario não encontrado");

            return new BaseDto(200, user.Id);
        }
    }
}