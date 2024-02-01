using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace HiredFirst.Domain.DbEntities
{
    [CollectionName("users")]
    public class AppUser : MongoIdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string ResetPasswordToken { get; set; } = string.Empty;
    }
}
