using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSS.ProgDec2.PL;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TSS.ProgDec.PL.Test
{
    [TestClass]
    public class utProgram
    {
        [TestMethod]
        public void LoadTest()
        {
            // data context
            // make var of data type of data context
            // [data type]  [data context]  = new [data type object]
            ProgDecEntities dc = new ProgDecEntities();

            var programs = from p in dc.tblPrograms
                           select p;
            dc = null; // clean up, because the same var name is being used elsewhere
            Assert.IsTrue(programs.Count() > 0);
        }

        //[TestMethod]
        //public void LoadTestFail()
        //{
        //    // This test is intended to fail
        //    ProgDecEntities dc = new ProgDecEntities();

        //    var programs = from p in dc.tblPrograms
        //                   select p;
        //    dc = null;
        //    Assert.IsTrue(programs.Count() < 0);
        //}

        [TestMethod]
        public void InsertTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            // Dimension and instatiate new row 
            tblProgram newrow = new tblProgram();

            // set properties for the new record
            newrow.Id = -99;
            newrow.Description = "New Program";
            newrow.DegreeTypeId = 2;

            // Insert the row into the database
            dc.tblPrograms.Add(newrow);

            // Commit the changes 
            dc.SaveChanges();

            tblProgram program = (from p in dc.tblPrograms
                                  where p.Id == -99
                                  select p).FirstOrDefault();

            Assert.AreSame(newrow, program);    // one way to test if a new row was successfully added 
        }

        [TestMethod]
        public void UpdateTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            tblProgram program = (from p in dc.tblPrograms
                                 where p.Id == -99
                                 select p).FirstOrDefault();

            program.Description = "Updated program";
            program.DegreeTypeId = 3;
            dc.SaveChanges();

            tblProgram updatedprogram = (from p in dc.tblPrograms
                                         where p.Id == -99
                                         select p).FirstOrDefault();

            Assert.AreEqual(program.Description, updatedprogram.Description);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            tblProgram program = (from p in dc.tblPrograms
                                  where p.Id == -99
                                  select p).FirstOrDefault();

            if (program != null)
            {
                dc.tblPrograms.Remove(program);
                dc.SaveChanges();
            }

            tblProgram deletedprogram = (from p in dc.tblPrograms
                                         where p.Id == -99
                                         select p).FirstOrDefault();

            Assert.IsNull(deletedprogram); // confirms the delete worked 
        }
    }
}
