using WebApi.Data.Contexts;
using WebApi.Data.Entites;

namespace WebApi.Data.Repositories
{
    public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
    {
    }
}
