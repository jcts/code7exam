using Code7.WeChip.Application.AutoMapper;
using Code7.WeChip.Application.Contracts;
using Code7.WeChip.Infra.Contracts;
using Code7.WeChip.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Code7.WeChip.Application
{
    public class ProductApp : IProductApp
    {
        readonly IProductRepository _productRepository;

        public ProductApp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductModel AddOrUpdate(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public ProductModel Create(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(ICollection<ProductModel> models)
        {
            throw new NotImplementedException();
        }

        public int ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public ProductModel ExecuteQueryReturnObj(string query)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProductModel> GetAll()
        {
            var entity = _productRepository.GetAll();

            return AutoMapperConfig.mapper.Map<List<ProductModel>>(entity);
        }

        public ProductModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> Search(Expression<Func<ProductModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ProductModel Update(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
