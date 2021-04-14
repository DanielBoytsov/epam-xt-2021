using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    internal class Pizzeria : IReadyable
    {
        public event Action<Customer> YourOrderNumber = delegate { };
        public int OrderNumber { get; protected set; }
        
        
        public void PizzaReady()
        {
            Console.WriteLine($"Order number {Order} is ready. Please pick it up at the checkout");
            
        }
    }
}
