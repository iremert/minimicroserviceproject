using UserService.Models;

namespace UserService.Services
{
    public class UserServicee
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, FullName = "İrem Ertürk", Email = "irem@example.com" },
            new User { Id = 2, FullName = "Ahmet Yılmaz", Email = "ahmet@example.com" }
        };

        public List<User> GetAll() => _users;
    }
}
