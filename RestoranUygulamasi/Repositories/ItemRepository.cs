using RestoranUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranUygulamasi.Repositories
{
    public class ItemRepository
    {
        private RestoranDBEntities2 objRestoranDBEntities;

        public ItemRepository()
        {
            objRestoranDBEntities = new RestoranDBEntities2();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestoranDBEntities.Item
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = false
                                  }).ToList();

            return objSelectListItems;
        }
    }
}