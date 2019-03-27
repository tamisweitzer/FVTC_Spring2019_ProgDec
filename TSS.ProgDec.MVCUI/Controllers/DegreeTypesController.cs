using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class DegreeTypesController : Controller
    {
        DegreeTypeList degreeTypes;

        // GET: DegreeTypes
        public ActionResult Index()
        {
            degreeTypes = new DegreeTypeList();
            degreeTypes.Load();
            return View(degreeTypes);
        }

        // GET: DegreeTypes/Details/5
        public ActionResult Details(int id)
        {
            DegreeType degreeType = new DegreeType();
            degreeType.Id = id;
            degreeType.LoadById();
            return View(degreeType);
        }

        // GET: DegreeTypes/Create
        public ActionResult Create()
        {
            DegreeType degreeType = new DegreeType();
            return View(degreeType);
        }

        // POST: DegreeTypes/Create
        [HttpPost]
        public ActionResult Create(DegreeType degreeType)
        {
            try
            {
                // TODO: Add insert logic here
                degreeType.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(degreeType);
            }
        }

        // GET: DegreeTypes/Edit/5
        public ActionResult Edit(int id)
        {
            DegreeType degreeType = new DegreeType();
            degreeType.Id = id;
            degreeType.LoadById();
            return View(degreeType);
        }

        // POST: DegreeTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DegreeType degreeType)
        {
            try
            {
                // TODO: Add update logic here
                degreeType.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(degreeType);
            }
        }

        // GET: DegreeTypes/Delete/5
        public ActionResult Delete(int id)
        {
            DegreeType degreeType = new DegreeType();
            degreeType.Id = id;
            degreeType.LoadById();
            return View(degreeType);
        }

        // POST: DegreeTypes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DegreeType degreeType)
        {
            try
            {
                // TODO: Add delete logic here
                degreeType.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(degreeType);
            }
        }
    }
}
