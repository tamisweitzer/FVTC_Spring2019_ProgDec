using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSS.ProgDec.BL;
using System.Linq;


namespace TSS.ProgDec.BL.Test
{
    [TestClass]
    public class utProgDec
    {
        [TestMethod]
        public void LoadTest()
        {
            ProgDecList progDec = new ProgDecList();
            progDec.Load();
            Assert.AreEqual(5, progDec.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            ProgDec progDec = new ProgDec();
            progDec.StudentId = 1;
            progDec.ProgramId = 1;

            int result = progDec.Insert();
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void UpdateTest()
        {
            ProgDec progDec = new ProgDec();

            ProgDecList progDecs = new ProgDecList();
            progDecs.Load();

            progDec = progDecs.Where(s => s.StudentId == 1).FirstOrDefault();

            progDec.StudentId = 1;
            progDec.ProgramId = 1;
            progDec.Update();

            ProgDec updatedProgDec = new ProgDec();
            updatedProgDec.Id = progDec.Id;
            updatedProgDec.LoadById();

            Assert.AreEqual(progDec.Id, updatedProgDec.Id);

        }


        [TestMethod]
        public void DeleteTest()
        {
            ProgDec progDec = new ProgDec();

            ProgDecList progDecs = new ProgDecList();
            progDecs.Load();

            progDec = progDecs.Where(s => s.StudentId == 1).FirstOrDefault();

            int result = progDec.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
