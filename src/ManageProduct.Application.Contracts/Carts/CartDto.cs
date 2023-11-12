using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Carts
{
    public class CartDto: AuditedEntityDto<Guid>
    {
        public Guid IdProduct { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public float  Total { get; set; }
    }
}
