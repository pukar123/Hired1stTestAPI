using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace HiredFirst.Domain.DbEntities
{
    [CollectionName("AppRole")]
    public class AppRole : MongoIdentityRole<Guid>
    {
    }
}
