using Code7.WeChip.Application;
using Code7.WeChip.Application.Contracts;
using Code7.WeChip.Infra.Contracts;
using Code7.WeChip.Infra.Repository;
using SimpleInjector;
using System;

namespace Code7.WeChip.IoC
{
    public class BootStrapper
    {

        public static void RegisterServices(Container container)
        {

            #region Application
            container.Register<ICustomerApp, CustomerApp>(Lifestyle.Scoped);
            container.Register<IProductApp, ProductApp>(Lifestyle.Scoped);
            #endregion

            #region Services

            #endregion

            #region Repositories
            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
            #endregion
        }
    }
}
