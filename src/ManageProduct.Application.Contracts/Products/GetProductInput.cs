using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Products
{
    public class GetProductInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string Name { get; set; }

        public Guid? IdCategory { get; set; }
    }
}
