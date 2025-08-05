using Xunit;
using UserService.Services;

namespace UserService.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetAll_ReturnsStaticUsers()
        {
            var svc = new UserServicee();
            var list = svc.GetAll();
            Assert.NotEmpty(list);
            Assert.Contains(list, u => u.FullName == "İrem Ertürk");
        }
    }
}
