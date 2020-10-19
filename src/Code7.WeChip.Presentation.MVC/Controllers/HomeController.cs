using Code7.WeChip.Application.Contracts;
using Code7.WeChip.SharedKernel.Models;
using System;
using System.Web.Mvc;

namespace Code7.WeChip.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ICustomerApp _customerApp;
        readonly IProductApp _productApp;
        public HomeController(ICustomerApp customerApp, IProductApp productApp)
        {
            _customerApp = customerApp;
            _productApp = productApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        public void MakeOffer(string cardId, decimal value)
        {
            _customerApp.MakeOffer(cardId, value);
        }

        public ActionResult SearchAddress(string cardId)
            => Json(new { _customerApp.SearchByCardId(cardId)?.Address }, JsonRequestBehavior.AllowGet);

        public ActionResult ListProducts()
            => Json(new { products = _productApp.GetAll() }, JsonRequestBehavior.AllowGet);

        public ActionResult SearchCustomer(string param)
            => Json(new { customers = _customerApp.SearchByParam(param) }, JsonRequestBehavior.AllowGet);

        public void RegisterCustomer(CustomerModel customer)
        {
            if (!customer.IsValid)
                throw new Exception($"Verifique os dados do cadastro", innerException: new ArgumentException(customer.GetErrors));

            else
                _customerApp.Create(customer);
        }

        public ActionResult NewOffer()
        {
            return View();
        }

        public ActionResult NewCustomer()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}