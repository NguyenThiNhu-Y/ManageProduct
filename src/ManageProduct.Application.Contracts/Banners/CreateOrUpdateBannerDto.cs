using System;
using System.Collections.Generic;
using System.Text;

namespace ManageProduct.Banners
{
    public class CreateOrUpdateBannerDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool SetBanner { get; set; }
    }
}
