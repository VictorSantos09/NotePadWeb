namespace Domain.Entities
{
    public class NoteEntity : BaseEntity
    {
        public string Text { get; set; }
        public string Tittle { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid OwnerID { get; set; }

        public NoteEntity(string text, DateTime? creationDate, Guid ownerID, DateTime? updateDate, string tittle)
        {
            Text = text;
            CreationDate = creationDate;
            OwnerID = ownerID;
            Id = Guid.NewGuid();
            UpdateDate = updateDate;
            Tittle = tittle.ToUpper();
        }
    }
}
