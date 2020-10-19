namespace Code7.WeChip.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public bool IsEnable { get; set; }
        public long Code { get; set; }
    }
}