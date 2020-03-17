using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<JobItem> Jobs { get; set; }
        public DbSet<CategoryItem> Categories { get; set; }
        public DbSet<SuburbItem> Suburbs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
