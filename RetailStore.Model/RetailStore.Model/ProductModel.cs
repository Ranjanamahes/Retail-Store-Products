using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Model
{
    public class ProductModel
    {
        public int? ProductId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime? Last_Updated { get; set; }
        public decimal Price { get; set; }
    }
}
