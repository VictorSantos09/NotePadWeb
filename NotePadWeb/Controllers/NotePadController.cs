using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NotePadWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotePadController : ControllerBase
    {
        private readonly NotePadService _notePadService;
    }
}
