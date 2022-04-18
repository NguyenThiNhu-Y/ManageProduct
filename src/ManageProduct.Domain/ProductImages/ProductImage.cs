using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ManageProduct.ProductImages
{
    public class ProductImage: AuditedAggregateRoot<Guid>
    {
        public Guid IdProduct { get; set; }
        public string Image { get; set; }
    }
}
