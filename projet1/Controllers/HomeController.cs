using projet1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProprietaire()
        {
            ModelBD db = new ModelBD();
            //DateTime mydate = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy"+ " 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
            //Console.WriteLine(mydate);
            var prpActue = db.proprietaires.OrderBy(x => x.id).Where(x=>x.dateAjout.Day.Equals(DateTime.Now.Day) && x.dateAjout.Month.Equals(DateTime.Now.Month) && x.dateAjout.Year.Equals(DateTime.Now.Year)).ToList();
            return Json(new { data = prpActue }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetClient()
        {
            ModelBD db = new ModelBD();
        
        var prpActue = db.clients.OrderBy(x => x.id).Where(x => x.dateAjout.Day.Equals(DateTime.Now.Day) && x.dateAjout.Month.Equals(DateTime.Now.Month) && x.dateAjout.Year.Equals(DateTime.Now.Year)).ToList();
            return Json(new { data = prpActue}, JsonRequestBehavior.AllowGet);
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
    }
}