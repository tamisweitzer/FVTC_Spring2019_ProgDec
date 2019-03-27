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
            return View(bands);
        }

        public ActionResult Details(int id)
        {
            var band = bands.FirstOrDefault(p => p.Id == id);
            return View(band);
        }
    }
}

