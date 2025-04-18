using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Data.Contexts;
using WebApi.Data.Entites;

namespace WebApi.Data.Repositories
{
    public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
    {

        public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.User)
                .Include(p => p.Status)
                .ToListAsync();

        }

        public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> predicate)
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.User)
                .Include(p => p.Status) // 👈 NYCKELN!
                .FirstOrDefaultAsync(predicate);
        }

    }
}
