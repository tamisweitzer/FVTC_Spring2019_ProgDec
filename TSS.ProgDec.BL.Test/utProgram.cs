using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSS.ProgDec.BL;
using System.Linq;

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
            Assert.AreEqual(16, programs.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Program program = new Program();
            program.Description = "New Program Test";
            program.DegreeTypeId = 3;

            int result = program.Insert();
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void UpdateTest()
        {
            Program program = new Program();

            ProgramList programs = new ProgramList();
            programs.Load();
            program = programs.Where(p => p.Description == "New Program Test").FirstOrDefault();

            program.DegreeTypeId = 1;
            program.Update();

            Program updatedProgram = new Program();
            updatedProgram.Id = program.Id;
            updatedProgram.LoadById();

            Assert.AreEqual(program.DegreeTypeId, updatedProgram.DegreeTypeId);

        }


        [TestMethod]
        public void DeleteTest()
        {
            Program program = new Program();

            ProgramList programs = new ProgramList();
            programs.Load();

            program = programs.Where(s => s.Description == "New Program Test").FirstOrDefault();

            int result = program.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
