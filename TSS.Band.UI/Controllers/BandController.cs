using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.Band.UI.Models;   // this references the BandModel.cs in Models/

namespace TSS.Band.UI.Controllers
{
    public class BandController : Controller
    {
        // An array of bands
        BandModel[] bands = new BandModel[]
        {
            new BandModel { Id = 1, Name = "Metallica", Genre = "Metal", YearFounded = 1984 },
            new BandModel { Id = 2, Name = "5FDP", Genre = "Metal", YearFounded = 1985 },
            new BandModel { Id = 3, Name = "Anthrax", Genre = "Metal", YearFounded = 1982 }
        };

               
        // GET: Band
        public ActionResult Index()
        {
            // Index  = list of things 
            if (Session["bands"] != null)
                bands = (BandModel[])Session["bands"];

            return View(bands);
        }

        public ActionResult Details(int id)
        {
            var band = bands.FirstOrDefault(p => p.Id == id);
            return View(band);
        }


        // POST/GET Create()
        // GET; default
        public ActionResult Create()
        {
            BandModel band = new BandModel();
            return View(band);
        }

        // POST
        [HttpPost]
        public ActionResult Create(BandModel band)
        {
            // Add the new band to the array of Bands 
            Array.Resize(ref bands, bands.Length + 1);
            //band.Id = bands.Max(b => b.Id + 1);
            band.Id = bands.Length + 1;
            bands[bands.Length - 1] = band;
            Session["bands"] = bands;
            return RedirectToAction("Index");
        }


        // POST/GET Edit()
        public ActionResult Edit(int id)
        {
            var band = bands.FirstOrDefault(b => b.Id == id);
            return View(band);
        }

        [HttpPost]
        public ActionResult Edit(int id, BandModel band)
        {
            bands[id - 1] = band;
            Session["bands"] = bands;
            return RedirectToAction("Index");
        }


        // POST/GET Delete()
        public ActionResult Delete(int id)
        {
            var band = bands.FirstOrDefault(b => b.Id == id);
            return View(band);
        }

        [HttpPost]
        public ActionResult Delete (int id, BandModel band)
        {
            if (Session["bands"] != null)
                bands = (BandModel[])Session["bands"];
            var newbands = bands.Where(b => b.Id != id);
            bands = newbands.ToArray();
            Session["bands"] = bands;
            return RedirectToAction("Index");
        }
    }
}

