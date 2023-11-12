using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Carts
{
    public class GetCartInput: PagedAndSortedResultRequestDto
    {
        public string filterText { get; set; }
        public string name { get; set; }
    }
}
