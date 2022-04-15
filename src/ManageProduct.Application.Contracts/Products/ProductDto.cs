using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public Guid? IdCategory { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Describe { get; set; }

        public string CategoryName { get; set; }
    }
}
