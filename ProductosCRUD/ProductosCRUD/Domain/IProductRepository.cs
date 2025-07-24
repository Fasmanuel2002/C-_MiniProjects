using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCRUD.Domain
{
    internal interface IProductRepository
    {
        Product AddProduct(String name, Double price);

        List<Product> GetAll();

        Product FindByName(String name);


    }
}
