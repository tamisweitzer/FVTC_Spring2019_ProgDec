using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.MVCUI.ViewModels
{
    public class ProgDecProgramsStudents
    {
        public BL.ProgDec ProgDec { get; set; }
        public StudentList Students { get; set; }
        public ProgramList Programs { get; set;  }

        // List of all advisors 
        public AdvisorList Advisors { get; set; }

        // list of all pre-existing advisors (Ids)
        public IEnumerable<int> AdvisorIds { get; set; }

    }
}