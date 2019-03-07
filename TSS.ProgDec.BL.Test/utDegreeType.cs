using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSS.ProgDec.BL;
using System.Linq;

namespace TSS.ProgDec.BL.Test
{
    [TestClass]
    public class utDegreeType
    {
        [TestMethod]
        public void LoadTest()
        {
            DegreeTypeList degreeType = new DegreeTypeList();
            degreeType.LoadById();
            Assert.AreEqual(5, degreeType.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            DegreeTypeList degreeType = new DegreeTypeList();
            degreeType.Id = 1;
            
            int result = degreeType.Insert();
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void UpdateTest()
        {
            DegreeTypeList degreeType = new DegreeTypeList();

            DegreeTypeList degreeTypes = new DegreeTypeList();
            DegreeTypes.Load();

            degreeType = progDecs.Where(s => s.StudentId == 1).FirstOrDefault();

            degreeType.StudentId = 1;
            degreeType.ProgramId = 1;
            degreeType.Update();

            DegreeTypeList updatedProgDec = new DegreeTypeList();
            updatedProgDec.Id = degreeType.Id;
            updatedProgDec.LoadById();

            Assert.AreEqual(degreeType.Id, updatedProgDec.Id);

        }


        [TestMethod]
        public void DeleteTest()
        {
            DegreeTypeList degreeType = new DegreeTypeList();

            ProgDecList progDecs = new ProgDecList();
            progDecs.Load();

            degreeType = progDecs.Where(s => s.StudentId == 1).FirstOrDefault();

            int result = degreeType.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
