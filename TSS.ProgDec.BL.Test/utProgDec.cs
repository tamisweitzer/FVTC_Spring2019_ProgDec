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
            ProgDecList progDecs = new ProgDecList();
            progDecs.Load();
            Assert.AreEqual(4, progDecs.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            ProgDec progdec = new ProgDec();
            progdec.ChangeDate = DateTime.Now;
            progdec.StudentId = -99;
            progdec.ProgramId = 4;

            bool result = progdec.Insert();
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void UpdateTest()
        {
            ProgDec progDec = new ProgDec();

            ProgDecList progDecs = new ProgDecList();
            progDecs.Load();

            progDec = progDecs.Where(p => p.StudentId == -99).FirstOrDefault();
            
            progDec.ProgramId = 5;
            progDec.Update();

            ProgDec updatedProgDec = new ProgDec();
            updatedProgDec.Id = progDec.Id;
            updatedProgDec.LoadById();

            Assert.AreEqual(progDec.ProgramId, updatedProgDec.ProgramId);

        }


        [TestMethod]
        public void DeleteTest()
        {
            ProgDec progDec = new ProgDec();

            ProgDecList progDecs = new ProgDecList();
            progDecs.Load();

            progDec = progDecs.Where(p => p.StudentId == -99).FirstOrDefault();

            int result = progDec.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
