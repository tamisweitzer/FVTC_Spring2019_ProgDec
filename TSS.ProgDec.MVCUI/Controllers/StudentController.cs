using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentList students = new StudentList();
            students.Load();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = new Student();
            student.Id = id;
            student.LoadById();
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                student.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = new Student();
            student.Id = id;
            student.LoadById();
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                student.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = new Student();
            student.Id = id;
            student.LoadById();
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                student.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }
    }
}
