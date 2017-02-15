using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apicalisma.Services;
namespace apicalisma.Services
{
    public class Client
    {
        private  IProductService  _service;
        public void Start()
        {
            Console.WriteLine("Service Started");
            this._service.GetData();
            //To Do: Some Stuff
        }
    }

}
