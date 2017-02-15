

using apicalisma.Services;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Mvc;

namespace apicalisma.API
{
    public class ProductController : ApiController
    {
        private IProductService _service;

        public ProductController(IProductService servis)
        {
            _service = servis;
        }
       
        public string GetProductlist()
        {
            _service = new ProductService();
            JsonSerializer serializer = new JsonSerializer();
            var result =JsonConvert.SerializeObject(_service.GetData());
            return result;
        }
    }
}
