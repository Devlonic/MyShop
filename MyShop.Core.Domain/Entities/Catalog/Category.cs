using MyShop.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Domain.Entities.Catalog {
    public class Category : PersonificatedEntity {
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
    }
}
