using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Code7.WeChip.Domain.Entities.ValueObjects
{
    public class Address : ValueObject
    {
        public long ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MoreInfo { get; set; }

        public Address() { }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
