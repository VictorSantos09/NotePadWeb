using Application.Dto;
using Domain.Entities;
using Repository.Repository;

namespace Application.Services
{
    public class NotePadService
    {
        private readonly NoteRepository _noteRepository;
        private readonly UserRepository _userRepository;

        public NotePadService(NoteRepository noteRepository, UserRepository userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        private bool HasExistentNoteTittle(Guid userID, string tittle)
        {
            return true ? _noteRepository.GetAll().FindAll(x => x.OwnerID == userID).Any(x => x.Tittle == tittle.ToUpper()) : false;
        }
        private string RenameExistNoteTittle(string tittle)
        {
            return $"{tittle}(1)";
        }

        public BaseDto CreateNote(string text, string tittle, Guid userID)
        {
            if (!_userRepository.GetAll().Exists(x => x.Id == userID))
                return new BaseDto(406, "Usuario não registrado");

            if (HasExistentNoteTittle(userID, tittle))
            {
                var newTittle = RenameExistNoteTittle(tittle);

                var noteNewTittle = new NoteEntity(text, DateTime.Today.Date, userID, null, newTittle);

                _noteRepository.Add(noteNewTittle);

                return new BaseDto(200, "Anotação criada!");
            }

            var note = new NoteEntity(text, DateTime.Today.Date, userID, null, tittle);

            _noteRepository.Add(note);

            return new BaseDto(200, "Anotação criada!");
        }
        public BaseDto UpdateNote(string newText, Guid userID, string tittle)
        {
            var oldNote = _noteRepository.GetNote(tittle.ToUpper(), userID);

            if (oldNote == null)
                return new BaseDto(404, "Anotação não encontrada");

            var newNote = new NoteEntity(newText, oldNote.CreationDate, userID, DateTime.Today.Date, tittle);

            _noteRepository.Update(oldNote.Id, newNote);

            return new BaseDto(200, "Anotação alterada!");
        }
        public BaseDto RemoveNote(string tittle, Guid userID, bool confirmed)
        {
            if (!confirmed)
                return new BaseDto(200, "Solicitação cancelada");

            var note = _noteRepository.GetNote(tittle.ToUpper(), userID);

            if (note == null)
                return new BaseDto(404, "Anotação não encontrada");

            _noteRepository.Remove(note.Id);

            return new BaseDto(200, "Anotação deletada!");
        }
        public BaseDto GetNotes(Guid userID)
        {
            if (!_userRepository.GetAll().Exists(x => x.Id == userID))
                return new BaseDto(404, "Usuario não encontrado");

            var notes = _noteRepository.GetAllFromUser(userID);

            if (notes.Count == 0)
                return new BaseDto(200, "Faça sua primeira anotação!");

            return new BaseDto(200, notes);
        }
    }
}