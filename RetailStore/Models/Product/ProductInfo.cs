using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailStore.Models.Product
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Last_Updated { set; get; }
    }
}