using ConsumeDTOS.CDTOS;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.ShoppingTools
{
    public class OrderVM //bu class'ı sepetle alakalı olduğu için shoppingTools içerisine açtık
    {
        public PaymentDTO PaymentDTO { get; set; }
        public Order Order { get; set; }
    }
}