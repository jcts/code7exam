using Code7.WeChip.Application.Contracts;
using Code7.WeChip.SharedKernel.Models;
using System.Web.Http;

namespace Code7.WeChip.Services.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        readonly ICustomerApp _customerApp;

        public CustomerController(ICustomerApp customerApp)
        {
            _customerApp = customerApp;
        }

        [HttpGet]
        [Route("api/searchcustomerbycardid/{cardid}")]
        public CustomerModel SearchCustomerByCardId(string cardid)
        {
            return _customerApp.SearchByCardId(cardid);
        }
    }
}
