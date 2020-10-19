using Code7.WeChip.Domain.Entities.ValueObjects;

namespace Code7.WeChip.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string CardId { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public decimal CreditAmmount { get; set; }
        public string Status { get; set; }
    }
}
