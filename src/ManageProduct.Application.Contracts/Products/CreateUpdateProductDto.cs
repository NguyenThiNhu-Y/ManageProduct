using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManageProduct.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public Guid IdCategory { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Describe { get; set; }
    }
}
