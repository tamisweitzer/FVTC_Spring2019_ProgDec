using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.API.Controllers
{
    public class DegreeTypeController : ApiController
    {
        public DegreeTypeList Get()
        {
            DegreeTypeList degreetypes = new DegreeTypeList();
            degreetypes.Load();
            return degreetypes;
        }

        public DegreeType Get(int id)
        {
            DegreeType degreetype = new DegreeType();
            degreetype.Id = id;
            degreetype.LoadById();
            return degreetype;
        }

        public void Post([FromBody] DegreeType degreetype)
        {
            degreetype.Insert();
        }

        public void Put(int id, [FromBody] DegreeType degreetype)
        {
            degreetype.Update();
        }

        public void Delete(int id)
        {
            Get(id).Delete();
        }
    }
}
