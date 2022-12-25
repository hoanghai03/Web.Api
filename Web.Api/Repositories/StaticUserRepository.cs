using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                Username = "readonly@user.com",
                Password= "12345678",
                EmailAddress = "readonly@user.com",
                FirstName = "Read Only",
                LastName = "User",
                Roles = new List<string> {"reader"}
            },
            new User()
            {
                Id = Guid.NewGuid(),
                Username = "readwrite@user.com",
                Password= "12345678",
                EmailAddress = "readonly@user.com",
                FirstName = "Read write",
                LastName = "User",
                Roles = new List<string> {"reader","writer"}
            }
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            return user;
        }
    }
}
