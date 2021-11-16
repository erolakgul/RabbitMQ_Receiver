using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_Receiver.Models
{
    public class Category
    {
        private static Category _instance;
        private Category()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }

        public Category Fill(Category cat)
        {
            cat.Name = "Beverage";
            cat.Description = "Soft drinks, coffees, teas, beers, and ales";
            return cat;
        }

        public static Category GetInstance()
        {
            if (_instance == null)
                _instance = new Category();

            return _instance;
        }
    }
}
