using WebApi.Data.Contexts;
using WebApi.Data.Entites;

namespace WebApi.Data.Repositories
{
    public class ClientRepository(DataContext context) : BaseRepository<ClientEntity>(context)
    {
    }
}
