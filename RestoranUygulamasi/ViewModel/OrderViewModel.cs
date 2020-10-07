using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranUygulamasi.ViewModel
{
    public class OrderViewModel
    {

        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }

        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int FinalTotal { get; set; }

        public IEnumerable<OrderDetailViewModel> ListOfOrderDetailViewModel { get; set; }

    }
}