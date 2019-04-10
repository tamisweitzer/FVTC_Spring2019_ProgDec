using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;
using TSS.ProgDec.MVCUI.ViewModels;

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


        // Load the Sidebar
        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            programs = new ProgramList();
            programs.Load();

            return PartialView(programs);
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
            ProgramDegreeTypeList pdtl = new ProgramDegreeTypeList();
            Program program = new Program();
            pdtl.Program = program;

            DegreeTypeList degreeTypes = new DegreeTypeList();
            degreeTypes.Load();
            pdtl.DegreeTypeList = degreeTypes;
            return View(pdtl);
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(ProgramDegreeTypeList pdtl)
        {
            try
            {
                pdtl.Program.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pdtl);
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            ProgramDegreeTypeList pdtl = new ProgramDegreeTypeList();
            pdtl.Program = new Program();
            pdtl.Program.Id = id;
            pdtl.Program.LoadById();

            pdtl.DegreeTypeList = new DegreeTypeList();
            pdtl.DegreeTypeList.Load();
            return View(pdtl);
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgramDegreeTypeList pdtl)
        {
            try
            {
                pdtl.Program.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pdtl.Program);
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
