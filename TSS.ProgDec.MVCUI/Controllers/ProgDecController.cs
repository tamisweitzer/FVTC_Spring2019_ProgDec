using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class ProgDecController : Controller
    {
        // GET: ProgDec
        public ActionResult Index()
        {
            ProgDecList progdecs = new ProgDecList();
            progdecs.Load();
            return View();
        }

        // GET: ProgDec/Details/5
        public ActionResult Details(int id)
        {
            BL.ProgDec progdec = new BL.ProgDec();
            progdec.Id = id;
            progdec.LoadById();
            return View(progdec);
        }

        // GET: ProgDec/Create
        public ActionResult Create()
        {
            BL.ProgDec progdec = new BL.ProgDec();
            return View(progdec);
        }

        // POST: ProgDec/Create
        [HttpPost]
        public ActionResult Create(BL.ProgDec progdec)
        {
            try
            {
                progdec.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(progdec);
            }
        }

        // GET: ProgDec/Edit/5
        public ActionResult Edit(int id)
        {
            BL.ProgDec progdec = new BL.ProgDec();
            progdec.Id = id;
            progdec.LoadById();
            return View(progdec);
        }

        // POST: ProgDec/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BL.ProgDec progdec)
        {
            try
            {
                progdec.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(progdec);
            }
        }

        // GET: ProgDec/Delete/5
        public ActionResult Delete(int id)
        {
            BL.ProgDec progdec = new BL.ProgDec();
            progdec.Id = id;
            progdec.LoadById();
            return View(progdec);
        }

        // POST: ProgDec/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BL.ProgDec progdec)
        {
            try
            {
                progdec.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(progdec);
            }
        }
    }
}
