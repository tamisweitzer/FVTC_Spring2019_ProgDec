using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class ProgramController : Controller
    {
        // class level variable
        ProgramList programs;

        // GET: Program
        public ActionResult Index()
        {
            // get model : instantiate obj > load it > return it  also, remember to make a view (right click on Index())
            programs = new ProgramList();
            programs.Load();
      
            return View(programs);
        }

        // GET: Program/Details/5
        public ActionResult Details(int id)
        {
            Program program = new Program();
            program.Id = id;
            program.LoadById();
            return View(program);
            
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            Program program = new Program();
            return View(program);
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(Program program)
        {
            try
            {
                // TODO: Add insert logic here
                program.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(program);
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            Program program = new Program();
            program.Id = id;
            program.LoadById();
            return View(program);
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Program program)
        {
            try
            {
                // TODO: Add update logic here
                program.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(program);
            }
        }

        // GET: Program/Delete/5
        public ActionResult Delete(int id)
        {
            Program program = new Program();
            program.Id = id;
            program.LoadById();
            return View(program);
        }

        // POST: Program/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Program program)
        {
            try
            {
                // TODO: Add delete logic here
                program.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(program);
            }
        }
    }
}
