using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;

namespace Infrastructure.Persistence
{
    class ApplicationDbContext :DbContext, IApplicationDbContext
    {
        
        public DbSet<JobItem> Jobs { get; set; }
        public DbSet<CategoryItem> Categories { get; set; }
        public DbSet<SuburbItem> Suburbs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
               return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}

