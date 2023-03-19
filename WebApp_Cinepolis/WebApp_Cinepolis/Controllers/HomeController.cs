using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web;
using System.Web.Mvc;
using WebApp_Cinepolis.Models;


namespace WebApp_Cinepolis.Controllers
{
    public class HomeController : Controller
    {
        private Database_CinepolisEntities db = new Database_CinepolisEntities();
        public ActionResult Index()
        {
            
            return View(db.Cine.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DBVacia()
        {
            return View();
        }
    }
}