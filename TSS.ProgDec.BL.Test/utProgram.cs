using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TSS.ProgDec.BL.Test
{
    [TestClass]
    public class utProgram
    {
        [TestMethod]
        public void LoadTest()
        {
            ProgramList programs = new ProgramList();
            programs.Load();
            Assert.AreEqual(5, programs.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Program program = new Program();
            program.Description = "description";
            program.DegreeTypeId = 1;

            int result = program.Insert();
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void UpdateTest()
        {
            Program program = new Program();

            ProgramList programs = new ProgramList();
            programs.Load();
///////////////// left off here with doing the UT Tests. Commit at this point and start looking at Webform project
            program = programs.Where(p=> p.Description == "description").FirstOrDefault();

            program.Description = "description"
            program.DegreeTypeId = 1;
            program.Update();

            Program updatedProgram = new Program();
            updatedProgram.Id = program.Id;
            updatedProgram.LoadById();

            Assert.AreEqual(program.Id, updatedProgram.ProgramId);

        }


        [TestMethod]
        public void DeleteTest()
        {
            Program program = new Program();

            ProgramList programs = new ProgramList();
            programs.Load();

            program = programs.Where(s => s.Description == "Bobby").FirstOrDefault();

            int result = program.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
