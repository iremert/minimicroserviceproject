using Xunit;
using NoteService.Services;
using NoteService.Models;

namespace NoteService.Tests
{
    public class NoteServiceTests
    {
        [Fact]
        public void Initially_NoNotes()
        {
            var svc = new NoteServicee();
            Assert.Empty(svc.GetAll());
        }

        [Fact]
        public void Add_AssignsIdAndStores()
        {
            var svc = new NoteServicee();
            var n = svc.Add(new Note { Title = "T", Content = "C" });
            Assert.Equal(1, n.Id);
            Assert.Single(svc.GetAll());
        }

        [Fact]
        public void Delete_Existing_ReturnsTrue()
        {
            var svc = new NoteServicee();
            var n = svc.Add(new Note());
            var result = svc.Delete(n.Id);
            Assert.True(result);
            Assert.Empty(svc.GetAll());
        }

        [Fact]
        public void Delete_NonExisting_ReturnsFalse()
        {
            var svc = new NoteServicee();
            Assert.False(svc.Delete(999));
        }
    }
}
