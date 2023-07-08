using System.Xml.Linq;
using WebAppContosoApi.Models;

namespace WebAppContosoApi
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Nigerian Pizza", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Dodo Pizza", IsGlutenFree = true },
                new Pizza { Id = 3, Name = "Texas Dodo Pizza", IsGlutenFree = false },
            };
        }
        public static List<Pizza> GetPizzas() => Pizzas;
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }
        public static bool Delete(int id)
        {
            var pizza = Get(id);
            return (pizza != null) ? Pizzas.Remove(pizza) : false;
        }
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index != -1)
            {
                return;
            }
            else
            {
                Pizzas[index] = pizza;
            }
        }
    }
}
