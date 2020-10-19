using System;
using System.Collections.Generic;
using System.Text;

namespace Code7.WeChip.Domain.Entities.ValueObjects
{
    public class Phone : ValueObject
    {
        public int CountryCode { get; set; }
        public int Ddd { get; set; }
        public int PhoneNumber { get; set; }

        public Phone() { }

        public Phone(int countrycode, int ddd, int phonenumber)
        {
            CountryCode = countrycode;

            Ddd = ddd;

            PhoneNumber = phonenumber;
        }

        public override string ToString()
            => $"({Ddd}) {PhoneNumber}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CountryCode;
            yield return Ddd;
            yield return PhoneNumber;
        }
    }
}
