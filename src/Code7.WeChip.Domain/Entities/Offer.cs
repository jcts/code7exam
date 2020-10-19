using System;
using System.Collections.Generic;

namespace Code7.WeChip.Domain.Entities
{
    public class Offer : EntityBase
    {
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsEnable { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Ammount { get; set; }
    }
}