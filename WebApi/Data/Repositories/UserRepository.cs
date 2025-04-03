using WebApi.Data.Contexts;
using WebApi.Data.Entites;

namespace WebApi.Data.Repositories
{
    public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context)
    {
    }
}
