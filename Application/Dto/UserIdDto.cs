namespace Application.Dto
{
    public class UserIdDto
    {
        public Guid UserID { get; set; }

        public UserIdDto(Guid userID)
        {
            UserID = userID;
        }
    }
}
