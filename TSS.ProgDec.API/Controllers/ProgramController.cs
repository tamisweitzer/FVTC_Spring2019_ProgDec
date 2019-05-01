using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.API.Controllers
{
    public class ProgramController : ApiController
    {
        public ProgramList Get()
        {
            ProgramList programs = new ProgramList();
            programs.Load();
            return programs;
        }

        public Program Get(int id)
        {
            Program program = new Program();
            program.Id = id;
            program.LoadById();
            return program;
        }

        public void Post([FromBody] Program program)
        {
            program.Insert();
        }

        public void Put(int id, [FromBody] Program program)
        {
            program.Update();
        }

        public void Delete(int id)
        {
            Get(id).Delete();
        }
    }
}
