using CemPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CemPattern.Models;
using CemPattern.Service;
using GridMvc;
namespace CemPattern.Controllers
{
    public class HomeController : Controller
    {
        private  LUCA_DBEntities _context;
        private IUnitOfWork _uow;
        private ILucaDataService _lucaServis;
        // GET: Home

        public HomeController()
            {
                _context = new LUCA_DBEntities();
                _uow = new UnitOfWork(_context);
                _lucaServis = new LucaDataService(_uow);
            }
        public ActionResult Index()
        {
          
           var model = _lucaServis.GetAll().OrderBy(_=>_.DefterID);
            return View(model);
        }
    }
}