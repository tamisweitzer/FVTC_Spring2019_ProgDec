using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;
using TSS.ProgDec.MVCUI.ViewModels;
using TSS.ProgDec.MVCUI.Models;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class ProgDecController : Controller
    {
        // GET: ProgDec
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                ProgDecList progdecs = new ProgDecList();
                progdecs.Load();
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Declarations";
                }
                return View(progdecs);
            }
          else
            {
                return RedirectToAction("Create", "Login", new { returnurl = HttpContext.Request.Url });
            }  
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

            ProgramList programs = new ProgramList();
            programs.Load();
            pps.Programs = programs;

            StudentList students = new StudentList();
            students.Load();
            pps.Students = students;

            pps.Advisors = new AdvisorList();
            pps.Advisors.Load();

            return View(pps);
        }

        // POST: ProgDec/Create
        [HttpPost]
        public ActionResult Create(ProgDecProgramsStudents pps)
        {
            try
            {
                pps.ProgDec.Insert();
                int id = pps.ProgDec.Id;
                pps.AdvisorIds.ToList().ForEach(a => ProgDecAdvisor.Add(id, a));
                              
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
            progdec.LoadById();
           
            pps.ProgDec = progdec;

            ProgramList programs = new ProgramList();
            programs.Load();
            pps.Programs = programs;

            StudentList students = new StudentList();
            students.Load();
            pps.Students = students;

            // Load all
            pps.Advisors = new AdvisorList();
            pps.Advisors.Load();

            // Deal with the existing advisors
            IEnumerable<int> existingAdvisorsIds = new List<int>();

            // Select only the Ids
            existingAdvisorsIds = pps.ProgDec.Advisors.Select(a => a.Id);
            pps.AdvisorIds = existingAdvisorsIds;

            Session["advisorids"] = existingAdvisorsIds;

            return View(pps);
        }


      
        // POST: ProgDec/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgDecProgramsStudents pps)
        {
            try
            {
                // Deal with the advisors
                IEnumerable<int> oldadvisorsid = new List<int>();
                if (Session["advisorids"] != null)
                {
                    oldadvisorsid = (IEnumerable<int>)Session["advisorids"];
                }

                IEnumerable<int> newadvisorids = new List<int>();
                if (pps.AdvisorIds != null)
                {
                    newadvisorids = pps.AdvisorIds;
                }

                // Identify the deletes
                IEnumerable<int> deletes = oldadvisorsid.Except(newadvisorids);

                // Identify the adds
                IEnumerable<int> adds = newadvisorids.Except(oldadvisorsid);

                // Do the deletes
                deletes.ToList().ForEach(d => ProgDecAdvisor.Delete(id, d));

                // Do the adds
                adds.ToList().ForEach(a => ProgDecAdvisor.Add(id, a));


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
