using Application.Dto;
using Domain.Entities;
using Repository.Repository;

namespace Application.Services
{
    public class NotePadService
    {
        private readonly NoteRepository _noteRepository;

        public NotePadService(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public BaseDto CreateNote(string text, string tittle, Guid userID)
        {
            var note = new NoteEntity(text, DateTime.Today.Date, userID, null, tittle);

            _noteRepository.Add(note);

            return new BaseDto(200, "Anotação criada!");
        }
        public BaseDto UpdateNote(string newText, Guid userID, string tittle)
        {
            var newNote = new NoteEntity(newText, null, userID, DateTime.Today.Date, tittle);

            var oldNote = _noteRepository.GetNote(tittle, userID);

            _noteRepository.Update(oldNote.Id, newNote);

            return new BaseDto(200, "Anotação alterada!");
        }
        public BaseDto RemoveNote(string tittle, Guid userID)
        {
            var note = _noteRepository.GetNote(tittle, userID);

            _noteRepository.Remove(note.Id);

            return new BaseDto(200, "Anotação deletada!");
        }
    }
}
