using Code7.WeChip.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code7.WeChip.Application.Contracts
{
    public interface ICustomerApp : IApplicationBase<CustomerModel>
    {
        ICollection<CustomerModel> SearchByParam(string param);
        CustomerModel SearchByCardId(string cardId);
        void MakeOffer(string cardId, decimal value);
    }
}
