using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.ProductImages
{
    public class ProductImageDto : AuditedEntityDto<Guid>
    {
        public Guid IdProduct { get; set; }
        public string Image { get; set; }
    }
}
