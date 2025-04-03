using WebApi.Data.Contexts;
using WebApi.Data.Entites;

namespace WebApi.Data.Repositories
{
    public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context)
    {
    }
}
