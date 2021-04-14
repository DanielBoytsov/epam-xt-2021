using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    internal class Customer : IOrderable

    {
        public event Action<Pizzeria> TookYourPizza = delegate { };
        public int OrderNumber { get; private set; }
        //public Customer(int orderNumber)

        //OrderNumber = orderNumber;

        
        public void GetOrderNumber(Pizzeria number)
        {
            if (number is not null)
                OrderNumber = number.Order;
        }
        private void PizzaReady(Pizzeria pizza)
        {
            
        }


    }
}
