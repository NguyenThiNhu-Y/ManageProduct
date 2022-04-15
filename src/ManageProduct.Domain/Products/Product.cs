using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ManageProduct.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public Guid? IdCategory { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Describe { get; set; }
    }
}
