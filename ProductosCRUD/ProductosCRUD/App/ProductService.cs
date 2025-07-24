using ProductosCRUD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductosCRUD.App
{
    internal class ProductService : IProductService
    {
        private List<Product> _productos = new List<Product>();
        public IEnumerable<Product> GetAll()
        {
            foreach (var p in _productos)
            {
                yield return p;
            }
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {

            foreach (Product p in GetAll())
            {
                try
                {
                    if (p.Name == name)
                    {
                        return p;
                    }
                }catch(Exception e) {
                    String message = e.GetBaseException().Message;
                    Console.WriteLine(message);
                }
                
            }

                return null;
        }

        public void Save(Product p)
        {
            p.Id = _productos.Count + 1;
            _productos.Add(p);
        }
    }
}
