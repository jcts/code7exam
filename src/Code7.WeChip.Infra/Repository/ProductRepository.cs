using Code7.WeChip.Domain.Entities;
using Code7.WeChip.Infra.Context;
using Code7.WeChip.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq.Expressions;
using System.Text;

namespace Code7.WeChip.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product AddOrUpdate(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(ICollection<Product> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public Product ExecuteQueryReturnObj(string query)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetAll()
        {
            using (var ctx = WeChipContext.Context)
            {
                var queryselect = "SELECT PRD.DESCRIPTION, PRD.PRICE, PRD.CODE, PRDTP.DESCRIPTION,PRDTP.ID FROM (PRODUCTS AS PRD INNER JOIN PRODUCTTYPES AS PRDTP" +
                    $" ON PRD.ProductTypeId = PRDTP.ID)";

                using (var cmd = new OleDbCommand(queryselect, ctx))
                {
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        var products = new List<Product>();

                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Description = reader[0].ToString(),
                                Price = decimal.Parse(reader[1].ToString(), System.Globalization.NumberStyles.Currency),
                                Code = long.Parse(reader[2].ToString()),
                                Type = new ProductType {
                                    Description = reader[3].ToString(),
                                    Id = Guid.Parse(reader[4].ToString())
                                },
                                
                            });
                        }

                        return products;
                    }
                }
            }

            return null;
        }

        public Product GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
