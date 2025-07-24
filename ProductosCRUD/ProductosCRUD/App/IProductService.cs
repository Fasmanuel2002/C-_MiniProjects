using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductosCRUD.Domain;
namespace ProductosCRUD.App
{
    internal interface IProductService
    {
        void Save(Product p);

        IEnumerable<Product> GetAll();

        Product GetProductByName(String name);

    }
}
