using RestoranUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranUygulamasi.Repositories
{
    public class MusteriRepository
    {
        private RestoranDBEntities2 objRestoranDBEntities;

        public MusteriRepository()
        {
            objRestoranDBEntities = new RestoranDBEntities2();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestoranDBEntities.Musteri
                                  select new SelectListItem()
                                  {
                                      Text = obj.Musteri_Adi,
                                      Value = obj.Musteri_id.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;
        }
    }
}