using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NotePadWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderController : ControllerBase
    {
        private readonly FolderService _folderService;

        public FolderController(FolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost]
        [Route("newFolder")]
        public IActionResult NewFolder(NewFolderDto folderDto)
        {
            var result = _folderService.CreateFolderAndFile(folderDto.Name);

            return StatusCode(result._StatusCode, new { result._Message });
        }
        [HttpPost]
        [Route("MoveTo")]
        public IActionResult Move(MoveToFolderDto folderDto)
        {
            var result = _folderService.Move(folderDto.OwnerID, folderDto.Tittle, folderDto.FolderName);

            return StatusCode(result._StatusCode, new { result._Message });
        }
    }
}
