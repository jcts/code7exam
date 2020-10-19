using Code7.WeChip.Application.AutoMapper;
using Code7.WeChip.Application.Contracts;
using Code7.WeChip.SharedKernel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Code7.WeChip.Application.Text
{
    [TestClass]
    public class CustomerAppTest
    {
        [TestMethod]
        public void CreateCustomer()
        {
            var t = new Mock<ICustomerApp>();

            var obj = new CustomerModel
            {
                Name = "Julio",
                CardId = "00751872130",
                Phone = new PhoneModel
                {
                    Ddd = 62,
                    PhoneNumber = 32566758
                },
                Address = new AddressModel
                {
                    City = "Goiânia",
                    Neighborhood = "Cidade Jardim",
                    Number = 352,
                    State = "Goiás",
                    Street = "Rua José Gomes Bailão"
                }
            };

            t.Setup(c => c.Create(obj)).Returns(obj);
        }

        [TestInitialize]
        public void Bootstrap()
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}
