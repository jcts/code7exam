using Code7.WeChip.Domain.Entities;
using System.Collections.Generic;

namespace Code7.WeChip.Infra.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        ICollection<Customer> GetCustomerByNameOrCardId(string param);
        Customer SearchByCardId(string cardId);
        void MakeOffer(string cardId, decimal value);
    }
}
