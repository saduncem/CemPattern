using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apicalisma.Models;
namespace apicalisma.Services
{
    interface IProductService
    {
       List<Products> GetData();
    }
}
