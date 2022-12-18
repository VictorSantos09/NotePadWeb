namespace Application.Dto
{
    public class MoveToFolderDto
    {
        public string Tittle { get; set; }
        public string FolderName { get; set; }
        public Guid OwnerID { get; set; }

        public MoveToFolderDto(string tittle, string folderName, Guid ownerID)
        {
            Tittle = tittle;
            FolderName = folderName;
            OwnerID = ownerID;
        }
    }
}
