using MyShop.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Persistence {
    public class DbInitializer {
        public static void Initialize(CategoriesDbContext categoriesDbContext) {
            categoriesDbContext.Database.EnsureCreated();
        }
    }
}
