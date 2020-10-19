using AutoMapper;
using Code7.WeChip.Domain.Entities;
using Code7.WeChip.Domain.Entities.ValueObjects;
using Code7.WeChip.SharedKernel.Models;

namespace Code7.WeChip.Application.AutoMapper
{
    public class EntityModelProfile : Profile
    {
        public EntityModelProfile()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();
            
            CreateMap<Phone, PhoneModel>();
            CreateMap<PhoneModel, Phone>();
            
            CreateMap<Address, AddressModel>();
            CreateMap<AddressModel, Address>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<ProductTypeModel, ProductType>();
            CreateMap<ProductType, ProductTypeModel>();
        }

    }
}
