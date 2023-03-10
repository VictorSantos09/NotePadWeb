using Domain.Entities;

namespace Repository.Repository
{
    public class NoteRepository : BaseRepository<NoteEntity>
    {
        public NoteRepository() : base("NotePad")
        {
        }
        public NoteEntity? GetNote(string tittle, Guid userID)
        {
            return GetAll().Find(x => x.Tittle == tittle && x.OwnerID == userID);
        }
        public List<NoteEntity> GetAllFromUser(Guid userID)
        {
            return GetAll().FindAll(x => x.OwnerID == userID);
        }
    }
}
