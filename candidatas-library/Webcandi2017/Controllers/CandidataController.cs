using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SiCandi2017.Controlador;



namespace SisCandidatasWeb_2017.Controllers
{
    public class CandidataController : Controller
    {
        // GET: Candidata
        public ActionResult Index(string word = "", string m = "")
        {
            ViewBag.DatosC = ManejoCandidata.Buscar(word,true, m);
            ViewBag.DatosM = ManejoMunicipio.getAll(true);
            ViewBag.word = word;
            return View();
        }

        public ActionResult Like(int pkCandidata)
        {
            ManejoCandidata.Like(pkCandidata);
            return RedirectToAction("");
        }
    }
}