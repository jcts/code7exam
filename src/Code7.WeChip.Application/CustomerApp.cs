using AutoMapper;
using Code7.WeChip.Application.AutoMapper;
using Code7.WeChip.Application.Contracts;
using Code7.WeChip.Domain.Entities;
using Code7.WeChip.Infra.Contracts;
using Code7.WeChip.SharedKernel.Models;
using System;
using System.Collections.Generic;

namespace Code7.WeChip.Application
{
    public class CustomerApp : ICustomerApp
    {
        readonly ICustomerRepository _customerRepository;

        public CustomerApp(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerModel Create(CustomerModel model)
        {
            var entity = AutoMapperConfig.mapper.Map<Customer>(model);

            _customerRepository.Create(entity);

            return model;
        }

        public void Delete(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    
        public ICollection<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetById(Guid id)
        {
            var entity = _customerRepository.GetById(id);

            return AutoMapperConfig.mapper.Map<CustomerModel>(entity);
        }

        public void MakeOffer(string cardId, decimal value)
        {
            _customerRepository.MakeOffer(cardId, value);
        }

        public CustomerModel SearchByCardId(string cardId)
        {
            var entity = _customerRepository.SearchByCardId(cardId);

            return AutoMapperConfig.mapper.Map<CustomerModel>(entity);
        }

        public ICollection<CustomerModel> SearchByParam(string param)
        {
            var entity = _customerRepository.GetCustomerByNameOrCardId(param);

            return AutoMapperConfig.mapper.Map<List<CustomerModel>>(entity);
        }

        public CustomerModel Update(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    }
}
