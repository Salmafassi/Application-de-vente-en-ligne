using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static projet1.ModelBD;

namespace projet1.Controllers
{
    public class MesProduitController : Controller
    {
        // GET: MesProduit
        public ActionResult Mesproduits()
        {
            ModelBD db = new ModelBD();
            var product = db.produits.OrderBy(a => a.ref_Id).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult NouveauProduit()
        {


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NouveauProduit(produit p, int CategorieId)
        {
            string filename = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
            string extension = Path.GetExtension(p.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            p.ImagePath = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            p.ImageFile.SaveAs(filename);

            produit p1 = new produit();
            p1.title = p.title;
            p1.description = p.description;
            p1.prix = p.prix;
            p1.utilisateurId = 28;
            p1.dateAjout = DateTime.Now;
            p1.CategorieId = CategorieId;
            p1.statusP = produit.StatusProduit.NonVendu;
            p1.ImagePath = p.ImagePath;
            p1.ImageFile = p.ImageFile;
            using (var modbdel = new ModelBD())
            {
                if (ModelState.IsValid)
                {
                    if (Request["sub"] == "ajouter")
                    {
                        modbdel.produits.Add(p1);
                        modbdel.SaveChanges();

                        return RedirectToAction("MesProduits");
                    }
                    else if (Request["sub"] == "annuler")
                    {
                        return RedirectToAction("NouveuProduit");
                    }
                    else
                    {
                        return View("NouveauProduit");
                    }

                }
                ModelState.Clear();
                return View(p);
            }

        }
    }
}