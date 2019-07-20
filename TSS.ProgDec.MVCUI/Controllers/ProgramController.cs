using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;
using TSS.ProgDec.MVCUI.ViewModels;
using TSS.ProgDec.MVCUI.Models;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class ProgramController : Controller
    {
        // class level variable
        ProgramList programs;

        #region NonWebAPI

        // GET: Program
       
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())   
            {
                // get model : instantiate obj > load it > return it  also, remember to make a view (right click on Index())
                programs = new ProgramList();
                programs.Load();
                ViewBag.Source = "Get";
                return View(programs);
            }
            else
            {
                return RedirectToAction("Create", "Login", new { returnurl = HttpContext.Request.Url });
            }
            
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
                if (pdtl.File != null)
                {
                    pdtl.Program.ImagePath = pdtl.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(pdtl.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        pdtl.File.SaveAs(target);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    else
                    {
                        ViewBag.Message = "File already exists";
                    }
                }

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
                if (pdtl.File != null)
                {
                    pdtl.Program.ImagePath = pdtl.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(pdtl.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        pdtl.File.SaveAs(target);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    else
                    {
                        ViewBag.Message = "File already exists";
                    }
                }

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

        #endregion

        #region WebAPI
        
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://tssprogdecapi.azurewebsites.net/api/");
            return client;
        }

        public ActionResult Get()
        {
            HttpClient client = InitializeClient();

            HttpResponseMessage response =  client.GetAsync("Program").Result;

            string result = response.Content.ReadAsStringAsync().Result;

            dynamic items = (JArray)JsonConvert.DeserializeObject(result);

            ProgramList programs = items.ToObject<ProgramList>();

            ViewBag.Source = "Get";

            return View("Index", programs);
        }

        public ActionResult GetOne(int id)
        {
            HttpClient client = InitializeClient();

            HttpResponseMessage response = client.GetAsync("Program/" + id).Result;

            string result = response.Content.ReadAsStringAsync().Result;

            Program program = JsonConvert.DeserializeObject<Program>(result);

            return View("Details", program);
        }

        public ActionResult Remove(int id)
        {
            HttpClient client = InitializeClient();
           
            HttpResponseMessage response = client.GetAsync("Program/" + id).Result;

            string result = response.Content.ReadAsStringAsync().Result;

            Program  program = JsonConvert.DeserializeObject<Program>(result);

            return View("Delete", program);
        }

        [HttpPost]
        public ActionResult Remove(int id, Program program)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync("Program/" + id).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", program);

            }
        }

        public ActionResult Update(int id)
        {
            HttpClient client = InitializeClient();
            ProgramDegreeTypeList pdts = new ProgramDegreeTypeList();

            pdts.DegreeTypeList = new DegreeTypeList();
            HttpResponseMessage response = client.GetAsync("DegreeType").Result;

            string result = response.Content.ReadAsStringAsync().Result;

            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            pdts.DegreeTypeList = items.toObject<DegreeTypeList>();

            //pdts.Program = new Program();

            response = client.GetAsync("Program/" + id).Result;

            result = response.Content.ReadAsStringAsync().Result;

            pdts.Program = JsonConvert.DeserializeObject<Program>(result);

            return View("Edit", pdts);
        }

        [HttpPost]
        public ActionResult Update(int id, ProgramDegreeTypeList pdts)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Program/" + id, pdts.Program).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", pdts);

            }
        }

        public ActionResult Insert()
        {
            HttpClient client = InitializeClient();
            ProgramDegreeTypeList pdts = new ProgramDegreeTypeList();

            pdts.DegreeTypeList = new DegreeTypeList();
            HttpResponseMessage response = client.GetAsync("DegreeType").Result;

            string result = response.Content.ReadAsStringAsync().Result;

            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            pdts.DegreeTypeList = items.toObject<DegreeTypeList>(); // check this. exception when nav'd to http://localhost:52763/Program/Insert

            pdts.Program = new Program();
            return View("Create", pdts);
        }

        [HttpPost]
        public ActionResult Insert(ProgramDegreeTypeList pdts)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Program", pdts.Program).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex )
            {
                ViewBag.Error = ex.Message;
                return View("Create", pdts);
                
            }
        }



        #endregion 
    }
}
