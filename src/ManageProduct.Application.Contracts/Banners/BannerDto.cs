using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Banners
{
    public class BannerDto: AuditedEntityDto<Guid>
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool SetBanner { get; set; }
    }
}
