using System;

namespace Code7.WeChip.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }


        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
