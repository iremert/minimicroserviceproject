using Microsoft.AspNetCore.Mvc;
using NoteService.Models;
using NoteService.Services;

namespace NoteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NoteServicee _noteService;

        public NotesController(NoteServicee noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetNotes() => Ok(_noteService.GetAll());

        [HttpPost]
        public IActionResult CreateNote(Note note) => Ok(_noteService.Add(note));

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            if (_noteService.Delete(id)) return NoContent();
            return NotFound();
        }
    }
}
