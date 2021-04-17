using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    internal class CashRegister : IOrderable
    {
        public int OrderNumber { get; set; }

        public List<Pizza> OrderedPizzas { get; set; } = new List<Pizza>();

        Random rnd = new Random();

        public void ChoosePizza(Pizzas menu)
        {
            Console.WriteLine(@"Hello! Choose your pizza: " +
                                  "\n1. Pepperoni" +
                                  "\n2. Ceasar" +
                                  "\n3. Margarita" +
                                  "\n4. Carbonara");

            string action = Console.ReadLine();

            Enum.TryParse<Pizzas>(action, out Pizzas actionResult);

            switch (actionResult)
            {
                case Pizzas.Pepperoni:
                    OrderedPizzas.Add(new Pepperoni());
                    break;
                case Pizzas.Ceasar:
                    OrderedPizzas.Add(new Ceasar());
                    break;
                case Pizzas.Margarita:
                    OrderedPizzas.Add(new Margarita());
                    break;
                case Pizzas.Carbonara:
                    OrderedPizzas.Add(new Carbonara());
                    break;
                default:
                    throw new InvalidOperationException("The selected pizza does not exist");
            }
        }

        public void GenerateOrderNumber()
        {
            OrderNumber = OrderedPizzas.GetHashCode() / 2 + rnd.Next(0, 100);
        }
    }
}
