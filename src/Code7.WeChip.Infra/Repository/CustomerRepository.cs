using Code7.WeChip.Domain.Entities;
using Code7.WeChip.Infra.Context;
using Code7.WeChip.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Code7.WeChip.SharedKernel.Enums;

namespace Code7.WeChip.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer Create(Customer entity)
        {
            using (var ctx = WeChipContext.Context)
            {
                var insertquery = "INSERT INTO CUSTOMERS (ID, NAMECUSTOMER,CARDID, PHONE, STREET, NEIGHBORDHOOD, CITY, ZIPCODE, NUMBERADDRESS, MOREINFO, STATE, STATUS)" +
                    "VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                using (var cmd = new OleDbCommand(insertquery, ctx))
                {
                    cmd.Parameters.Add("ID", entity.Id.ToString().Replace('{', ' ').Replace('}', ' '));
                    cmd.Parameters.Add("NAMECUSTOMER", entity.Name);
                    cmd.Parameters.Add("CARDID", entity.CardId);
                    cmd.Parameters.Add("PHONE", entity.Phone.ToString());
                    cmd.Parameters.Add("STREET", entity.Address.Street);
                    cmd.Parameters.Add("NEIGHBORDHOOD", entity.Address.Neighborhood);
                    cmd.Parameters.Add("CITY", entity.Address.City);
                    cmd.Parameters.Add("ZIPCODE", entity.Address.ZipCode);
                    cmd.Parameters.Add("NUMBERADDRESS", entity.Address.Number);
                    cmd.Parameters.Add("MOREINFO", entity.Address.MoreInfo);
                    cmd.Parameters.Add("STATE", entity.Address.State);
                    cmd.Parameters.Add("STATUS", StatusCliente.NomeLivre);

                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ICollection<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid id)
        {
            using (var ctx = WeChipContext.Context)
            {
                var queryselect = $"SELECT * FROM CUSTOMERS WHERE ID = {id.ToString().Replace('{', ' ').Replace('{', ' ')}";

                using (var cmd = new OleDbCommand(queryselect, ctx))
                {
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new Customer
                            {
                                Id = Guid.Parse(reader["ID"].ToString()),
                                Name = reader["NAMECUSTOMER"].ToString(),
                                CardId = reader["CARDID"].ToString(),
                                Phone = new Domain.Entities.ValueObjects.Phone
                                {
                                    Ddd = int.Parse(reader["PHONE"].ToString().Split(' ')[0].Replace('(', ' ').Replace(')', ' ')),
                                    PhoneNumber = int.Parse(reader["PHONE"].ToString().Split(' ')[1])
                                },
                                Address = new Domain.Entities.ValueObjects.Address
                                {
                                    City = reader["CITY"].ToString(),
                                    State = reader["STATE"].ToString(),
                                    MoreInfo = reader["MOREINFO"].ToString(),
                                    Neighborhood = reader["NEIGHBORDHOOD"].ToString(),
                                    Number = int.Parse(reader["NUMBERADDRESS"].ToString()),
                                    Street = reader["STREET"].ToString(),
                                    ZipCode = int.Parse(reader["ZIPCODE"].ToString()),
                                }
                            };
                        }
                    }

                }
            }

            return null;
        }

        public ICollection<Customer> GetCustomerByNameOrCardId(string param)
        {
            using (var ctx = WeChipContext.Context)
            {
                var queryselect = $"SELECT * FROM CUSTOMERS WHERE CARDID LIKE '%{param}%' OR NAMECUSTOMER LIKE '%{param}%' AND STATUS <> '{(int)StatusCliente.ClienteAceitouOferta}'";

                using (var cmd = new OleDbCommand(queryselect, ctx))
                {
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        var customers = new List<Customer>();

                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = Guid.Parse(reader["ID"].ToString()),
                                Name = reader["NAMECUSTOMER"].ToString(),
                                CardId = reader["CARDID"].ToString(),
                                Phone = new Domain.Entities.ValueObjects.Phone
                                {
                                    Ddd = int.Parse(reader["PHONE"].ToString().Split(' ')[0].Replace('(', ' ').Replace(')', ' ')),
                                    PhoneNumber = int.Parse(reader["PHONE"].ToString().Split(' ')[1])
                                },
                                Address = new Domain.Entities.ValueObjects.Address
                                {
                                    City = reader["CITY"].ToString(),
                                    State = reader["STATE"].ToString(),
                                    MoreInfo = reader["MOREINFO"].ToString(),
                                    Neighborhood = reader["NEIGHBORDHOOD"].ToString(),
                                    Number = int.Parse(reader["NUMBERADDRESS"].ToString()),
                                    Street = reader["STREET"].ToString(),
                                    ZipCode = int.Parse(reader["ZIPCODE"].ToString()),
                                }
                            });
                        }

                        return customers;
                    }

                }
            }

            return null;
        }

        public void MakeOffer(string cardId, decimal value)
        {
            var customer = SearchByCardId(cardId);

            using (var ctx = WeChipContext.Context)
            {
                var insertquery = $"INSERT INTO OFFERS (ID, CUSTOMERID, ISENABLE, AMMOUNT) VALUES(?,?,?,?)";

                using (var cmd = new OleDbCommand(insertquery, ctx))
                {
                    cmd.Parameters.Add("ID", Guid.NewGuid().ToString().Replace('{', ' ').Replace('}', ' '));
                    cmd.Parameters.Add("CUSTOMERID", customer.Id.ToString().Replace('{', ' ').Replace('}', ' '));
                    cmd.Parameters.Add("ISENABLE", true);
                    cmd.Parameters.Add("AMMOUT", value);

                    cmd.ExecuteNonQuery();
                }
            }

            using (var ctx = WeChipContext.Context)
            {
                var insertquery = $"UPDATE CUSTOMERS SET STATUS = '{(int)StatusCliente.ClienteAceitouOferta}'  WHERE CARDID = '{cardId}'";

                using (var cmd = new OleDbCommand(insertquery, ctx))
                    cmd.ExecuteNonQuery();
            }
        }

        public Customer SearchByCardId(string cardId)
        {
            using (var ctx = WeChipContext.Context)
            {
                var queryselect = $"SELECT * FROM CUSTOMERS WHERE CARDID = '{cardId}'";

                using (var cmd = new OleDbCommand(queryselect, ctx))
                {
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new Customer
                            {
                                Id = Guid.Parse(reader["ID"].ToString()),
                                Name = reader["NAMECUSTOMER"].ToString(),
                                CardId = reader["CARDID"].ToString(),
                                Phone = new Domain.Entities.ValueObjects.Phone
                                {
                                    Ddd = int.Parse(reader["PHONE"].ToString().Split(' ')[0].Replace('(', ' ').Replace(')', ' ')),
                                    PhoneNumber = int.Parse(reader["PHONE"].ToString().Split(' ')[1])
                                },
                                Address = new Domain.Entities.ValueObjects.Address
                                {
                                    City = reader["CITY"].ToString(),
                                    State = reader["STATE"].ToString(),
                                    MoreInfo = reader["MOREINFO"].ToString(),
                                    Neighborhood = reader["NEIGHBORDHOOD"].ToString(),
                                    Number = int.Parse(reader["NUMBERADDRESS"].ToString()),
                                    Street = reader["STREET"].ToString(),
                                    ZipCode = int.Parse(reader["ZIPCODE"].ToString()),
                                }
                            };
                        }
                    }

                }
            }

            return null;
        }

        public Customer Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
