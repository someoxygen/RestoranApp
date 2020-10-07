using RestoranUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranUygulamasi.Repositories
{
    public class OdemeTipiRepository
    {
        private RestoranDBEntities2 objRestoranDBEntities; 

        public OdemeTipiRepository()
        {
            objRestoranDBEntities = new RestoranDBEntities2();
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestoranDBEntities.OdemeTipi
                                  select new SelectListItem()
                                  {
                                      Text = obj.OdemeTipiAdi,
                                      Value = obj.OdemeTipiID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;
        }
        
    }
}