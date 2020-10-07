using RestoranUygulamasi.Models;
using RestoranUygulamasi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranUygulamasi.Repositories
{
    public class OrderRepository
    {
        private RestoranDBEntities2 objRestoranDBEntities;
        public int sayac;

        public OrderRepository()
        {
            objRestoranDBEntities = new RestoranDBEntities2();

        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;

           
            objRestoranDBEntities.Order.Add(objOrder);
            objRestoranDBEntities.SaveChanges();
            int OrderId = objOrder.OrderId;




            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;

                objRestoranDBEntities.OrderDetail.Add(objOrderDetail);
                objRestoranDBEntities.SaveChanges();

                Transactions objTransactions = new Transactions();
                objTransactions.ItemId = item.ItemId;
                objTransactions.Quantity = (-1) * item.Quantity;
                objTransactions.TransactionDate = DateTime.Now;
                objTransactions.TypeId = 2;

                objRestoranDBEntities.Transactions.Add(objTransactions);
                objRestoranDBEntities.SaveChanges();

            }

            


            return true;
        }

    }
}