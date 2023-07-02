using Microsoft.EntityFrameworkCore;
using MyShop.Core.Application.Interfaces;
using MyShop.Core.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Persistence.DbContexts {
    public class CategoriesDbContext : DbContext, ICategoriesDbContext {
        public DbSet<Category> Categories { get; set; }

        public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options) : base(options) {
        }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(builder);
        }
        Task<int> ICategoriesDbContext.SaveChangesAsync(CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
