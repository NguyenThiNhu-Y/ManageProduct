using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ManageProduct.Banners
{
    public class Banner : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public bool SetBanner { get; set; }
    }
}
