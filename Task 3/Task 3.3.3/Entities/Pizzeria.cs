using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    internal class Pizzeria : IOrderable
    {
        public int OrderNumber { get; set; }

        public bool IsReady { get; private set; }

        public Pizzeria()
        {
            CashRegister order = new CashRegister();

            order.ChoosePizza(new Pizzas());

            if (order.OrderedPizzas is not null)
            {
                order.GenerateOrderNumber();

                OrderNumber = order.OrderNumber;
            }
        }


        public void OrderFeedback()
        {
            Console.WriteLine($"Your order number is {OrderNumber}. Please wait =)");
        }

        public void OrderIsReady()
        {
            Thread.Sleep(3000);

            IsReady = true;

            if (IsReady == true)
            {
                Console.WriteLine($"Order number {OrderNumber} is ready. Please pick it up at the checkout. " +
                    $"\nWe are waiting for you yet!");


            }
        }
    }
}
