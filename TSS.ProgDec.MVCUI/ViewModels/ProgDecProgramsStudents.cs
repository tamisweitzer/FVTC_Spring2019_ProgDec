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
    }
}