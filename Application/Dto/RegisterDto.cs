namespace Application.Dto
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterDto(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
