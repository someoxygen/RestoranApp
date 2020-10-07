using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranUygulamasi.ViewModel
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }


    }
}