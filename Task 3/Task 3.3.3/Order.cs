using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    class Order : Pizzeria,IOrderable
    {
        Random rnd = new Random();
        public void CreateOrderNumber()
        {
            OrderNumber = rnd.Next(1, 100);
        }
    }
}
