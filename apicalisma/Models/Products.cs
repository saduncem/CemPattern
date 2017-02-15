using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace apicalisma.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string ProductImage { get; set; }
    }
}