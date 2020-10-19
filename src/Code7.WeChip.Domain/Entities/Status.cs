namespace Code7.WeChip.Domain.Entities
{
    public class Status : EntityBase
    {
        public long CodeValue { get; set; }
        public bool SalesScored { get; set; }
        public bool CloseCustomer { get; set; }
        public string Description { get; set; }

    }
}