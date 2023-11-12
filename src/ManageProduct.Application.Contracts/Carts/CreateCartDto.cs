using System;
using System.Collections.Generic;
using System.Text;

namespace ManageProduct.Carts
{
    public class CreateCartDto
    {
        public Guid IdProduct { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
