using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Code7.WeChip.SharedKernel.Models
{
    public class CustomerModel
    {

        public CustomerModel()
        {
            Id = Guid.NewGuid();
            Errors = new List<string>();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }

        private string _cardid { get; set; }
        public string CardId
        {
            get
            {
                return _cardid;
            }
            set
            {
                if (!ValidaCPF(value))
                    throw new Exception("Cpf Inválido");

                _cardid = value;
            }
        }
        public PhoneModel Phone { get; set; }
        public AddressModel Address { get; set; }

        public string Status { get; set; }
        public decimal CreditAmmount { get; set; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    Errors.Add("Nome não informado.");
                    return false; 
                }

                if (string.IsNullOrEmpty(CardId))
                {
                    Errors.Add("Cpf Não Informado.");
                    return false; 
                }

                if (!ValidaCPF(CardId))
                {
                    Errors.Add("Cpf Inválido");
                    return false; 
                }

                if(Address == null)
                {
                    Errors.Add("Endereço Nâo Informado");
                    return false;
                }

                if (string.IsNullOrEmpty(Address.State))
                {
                    Errors.Add("Estado Nâo Informado");
                    return false;
                }

                if (string.IsNullOrEmpty(Address.City))
                {
                    Errors.Add("Cidade Nâo Informada");
                    return false;
                }

                if (string.IsNullOrEmpty(Address.ZipCode.ToString()))
                {
                    Errors.Add("Cep Nâo Informado");
                    return false;
                }

                if (string.IsNullOrEmpty(Address.Number.ToString()))
                {
                    Errors.Add("Número Nâo Informado");
                    return false;
                }

                return true;
            }
        }

        public string GetErrors
            => string.Join(", ", Errors.ToArray());

        public List<string> Errors { get; set; }

        #region Validação Cpf

        private bool ValidaCPF(string cpf)
        {
            if (cpf.Length < 11)
                return false;

            var new_cpf = "";

            for (int i = 0; i < cpf.Length; i++)
                if (IsDigito(cpf.Substring(i, 1)))
                    new_cpf += cpf.Substring(i, 1);

            new_cpf = Convert.ToInt64(new_cpf).ToString("D11");

            if (new_cpf.Length > 11)
                return false;

            if (CalculaDigCPF(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
                return true;

            return false;
        }

        private string CalculaDigCPF(string cpf)
        {
            var new_cpf = "";
            var digito = "";

            for (int i = 0; i < cpf.Length; i++)
                if (IsDigito(cpf.Substring(i, 1)))
                    new_cpf += cpf.Substring(i, 1);

            new_cpf = Convert.ToInt64(new_cpf).ToString("D9");

            if (new_cpf.Length > 9)
                return null;

            int Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);

            int Aux2 = 11 - Aux1 % 11;

            if (Aux2 > 9)
                digito += "0";

            else
                digito += Aux2.ToString();

            new_cpf += digito;

            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);

            Aux2 = 11 - (Aux1 % 11);

            if (Aux2 > 9)
                digito += "0";

            else
                digito += Aux2.ToString();

            return digito;
        }

        private static bool IsDigito(string digito)
            => int.TryParse(digito, out _);

        #endregion

    }

    public class PhoneModel
    {
        public int Ddd { get; set; }
        public int PhoneNumber { get; set; }

        public PhoneModel() { }

        public PhoneModel(int ddd, int phonenumber)
        {
            Ddd = ddd;

            PhoneNumber = phonenumber;
        }

        public override string ToString()
            => $"({Ddd}) {PhoneNumber}";
    }

    public class AddressModel
    {
        public long ZipCode{ get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string MoreInfo { get; set; }
    }


}
