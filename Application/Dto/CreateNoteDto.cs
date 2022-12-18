namespace Application.Dto
{
    public class CreateNoteDto
    {
        public string Text { get; set; }
        public string Tittle { get; set; }
        public Guid UserID { get; set; }

        public CreateNoteDto(string text, string tittle, Guid userID)
        {
            Text = text;
            Tittle = tittle;
            UserID = userID;
        }
    }
}
