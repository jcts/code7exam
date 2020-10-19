using System;
using System.Collections.Generic;
using System.Text;

namespace Code7.WeChip.SharedKernel.Models
{
    public class ProductModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductTypeModel Type { get; set; }
        public bool IsEnable { get; set; }
        public long Code { get; set; }
    }
}
