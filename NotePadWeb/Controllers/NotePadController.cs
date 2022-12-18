using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NotePadWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotePadController : ControllerBase
    {
        private readonly NotePadService _notePadService;

        public NotePadController(NotePadService notePadService)
        {
            _notePadService = notePadService;
        }
        [HttpPost]
        [Route("NewNote")]
        public IActionResult NewNote(CreateNoteDto noteDto)
        {
            var result = _notePadService.CreateNote(noteDto.Text, noteDto.Tittle, noteDto.UserID);

            return StatusCode(result._StatusCode, new { Message = result._Message });
        }

        [HttpDelete]
        [Route("DeleteNote")]
        public IActionResult Delete(DeleteNoteDto deleteDto)
        {
            var result = _notePadService.RemoveNote(deleteDto.Tittle.ToUpper(), deleteDto.UserID, deleteDto.Confirmed);

            return StatusCode(result._StatusCode, new { Message = result._Message });
        }
        [HttpPost]
        [Route("ViewNotes")]
        public IActionResult ViewNotes(UserIdDto idDto)
        {
            var result = _notePadService.GetNotes(idDto.UserID);

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
        [HttpPost]
        [Route("UpdateNote")]
        public IActionResult UpdateNote(UpdateNoteDto noteDto)
        {
            var result = _notePadService.UpdateNote(noteDto.NewText, noteDto.UserID, noteDto.Tittle);

            return StatusCode(result._StatusCode, new { Message = result._Message });
        }
    }
}
