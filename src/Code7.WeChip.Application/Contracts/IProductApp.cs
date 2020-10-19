using Code7.WeChip.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code7.WeChip.Application.Contracts
{
    public interface IProductApp : IApplicationBase<ProductModel>
    {
        ICollection<ProductModel> GetAll();
    }
}
