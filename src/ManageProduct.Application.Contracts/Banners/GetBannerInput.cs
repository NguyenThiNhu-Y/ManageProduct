using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Banners
{
    public class GetBannerInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string Name { get; set; }
    }
}
