using Repository.Repository;
using Application.Dto;

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
            if (!IsExistentUser(email, password))
                return new BaseDto(404, "Usuario não encontrado");

            var user = _userRepository.GetByEmail(email, password);

            return new BaseDto(200, user.Id);

        }
        public bool IsExistentUser(string email, string password)
        {
            return _userRepository.GetAll().Exists(x => x.Email == email.ToUpper() && x.Password == password);
        }
    }
}
