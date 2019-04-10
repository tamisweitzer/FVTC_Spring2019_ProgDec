using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;
using TSS.ProgDec.MVCUI.ViewModels;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class ProgDecController : Controller
    {
        // GET: ProgDec
        public ActionResult Index()
        {
            ProgDecList progdecs = new ProgDecList();
            progdecs.Load();
            if (ViewBag.Message == null)
            {
                ViewBag.Message = "Declarations";
            }
            return View(progdecs);
        }
        
        public ActionResult Load(int id)
        {
            ProgDecList progdecs = new ProgDecList();
            progdecs.Load(id);

            Program program = new Program();
            program.Id = id;
            program.LoadById();

            ViewBag.Message = "Declarations for " + program.Description;
            return View("Index", progdecs);
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
            ProgDecProgramsStudents pps = new ProgDecProgramsStudents();
            BL.ProgDec progdec = new BL.ProgDec();
            pps.ProgDec = progdec;

            pps.Programs = new ProgramList();
            pps.Programs.Load();

            pps.Students = new StudentList();
            pps.Students.Load();

            return View(pps);
        }

        // POST: ProgDec/Create
        [HttpPost]
        public ActionResult Create(ProgDecProgramsStudents pps)
        {
            try
            {
                pps.ProgDec.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pps);
            }
        }

        // GET: ProgDec/Edit/5
        public ActionResult Edit(int id)
        {
            ProgDecProgramsStudents pps = new ProgDecProgramsStudents();
            BL.ProgDec progdec = new BL.ProgDec();
            progdec.Id = id;
            //////////////
            pps.Programs = new ProgramList();
            pps.Programs.Load();

            pps.Students = new StudentList();
            pps.Students.Load();

            return View(pps);
        }

        // POST: ProgDec/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgDecProgramsStudents pps)
        {
            try
            {
                pps.ProgDec.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pps);
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
