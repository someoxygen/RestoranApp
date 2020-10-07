using RestoranUygulamasi.Models;
using RestoranUygulamasi.Repositories;
using RestoranUygulamasi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        private RestoranDBEntities2 objRestoranDBEntities;

        public HomeController()
        {
            objRestoranDBEntities = new RestoranDBEntities2();
        }

        public ActionResult Index()
        {
            MusteriRepository objMustetiRepository = new MusteriRepository();
            ItemRepository objItemRepository = new ItemRepository();
            OdemeTipiRepository objOdemeTipiRepository = new OdemeTipiRepository();


            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objMustetiRepository.GetAllCustomers(), objItemRepository.GetAllItems(),objOdemeTipiRepository.GetAllPaymentType()) ;
            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            int unitPrice = objRestoranDBEntities.Item.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);

            return Json("Your transaction has been completed successfully.", JsonRequestBehavior.AllowGet);
        } 



    }
}