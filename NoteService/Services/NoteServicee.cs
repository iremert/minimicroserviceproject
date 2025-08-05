using NoteService.Models;

namespace NoteService.Services
{
    public class NoteServicee
    {
        private readonly List<Note> _notes = new();
        private int _nextId = 1;

        public List<Note> GetAll() => _notes;

        public Note Add(Note note)
        {
            note.Id = _nextId++;
            _notes.Add(note);
            return note;
        }

        public bool Delete(int id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _notes.Remove(note);
                return true;
            }
            return false;
        }
    }
}
