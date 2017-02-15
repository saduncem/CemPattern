using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apicalisma.Services;
namespace apicalisma.Controllers
{
    public class HomeController : Controller
    {

       
        
        public ActionResult Index()
        {
          //  var data =_service.GetData();
            return View();
        }
    }
}