using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ManageProduct.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public Guid? IdParen { get; set; }
        public string Image { get; set; }
        public string Describe { get; set; }
        public int CountProduct { get; set; }
        public Status Status { get; set; }
    }
}
