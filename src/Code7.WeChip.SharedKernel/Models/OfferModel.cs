using System;
using System.Collections.Generic;
using System.Text;

namespace Code7.WeChip.SharedKernel.Models
{
    public class OfferModel
    {
        public CustomerModel Customer { get; set; }
        public ICollection<ProductModel> Products { get; set; }
        public bool IsEnable { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Ammount { get; set; }
    }
}
