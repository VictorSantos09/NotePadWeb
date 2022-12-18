namespace Application.Dto
{
    public class DeleteNoteDto
    {
        public Guid UserID { get; set; }
        public bool Confirmed { get; set; }
        public string Tittle { get; set; }

        public DeleteNoteDto(Guid userID, bool confirmed, string tittle)
        {
            UserID = userID;
            Confirmed = confirmed;
            Tittle = tittle;
        }
    }
}
