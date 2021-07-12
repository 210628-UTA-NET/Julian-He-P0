using StorefrontModels;
using System.Collections.Generic;
using System;
namespace StorefrontDL{
    public interface IOrderRepository{

        ///returns all customers in repo
        List<Order> GetAllOrders();
        Order GetOrder(Order order);
        Order AddOrder(Order order);
    }
}