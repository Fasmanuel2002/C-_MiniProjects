using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductosCRUD.Domain;
namespace ProductosCRUD.Infrastructure
{
    internal class InMemoryProductRepository : IProductRepository
    {
        private List<Product> _products;
        private int _nextId = 0;
        public InMemoryProductRepository() { 
            _products = new List<Product>();
        }
        public Product AddProduct(string name, double price)
        {
            var product = new Product
            {
                Id = _nextId++,
                Name = name,
                Price = price
            };
            return product;

        }

        public Product FindByName(string name)
        {
            Product productoNuevo = new Product();
            foreach(var producto in GetAll())
            {
                if(producto.Name == name)
                {
                    productoNuevo = producto;
                }
               
            }
            return productoNuevo;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            foreach(var product in _products)
            {
                products.Add(product);
            }
            return products;

        }
    }
}
