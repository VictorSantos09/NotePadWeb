namespace Application.Dto
{
    public class UpdateNoteDto
    {
        public Guid UserID { get; set; }
        public string NewText { get; set; }
        public string Tittle { get; set; }
    }
}
