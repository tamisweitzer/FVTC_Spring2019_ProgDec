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
            DegreeTypeList degreeTypes = new DegreeTypeList();
            degreeTypes.Load();
            Assert.AreEqual(5, degreeTypes.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            DegreeType degreeType = new DegreeType();
            degreeType.Description = "Test Degree Type";
            
            bool result = degreeType.Insert();
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void UpdateTest()
        {
            DegreeType degreeType = new DegreeType();

            DegreeTypeList degreeTypes = new DegreeTypeList();
            degreeTypes.Load();

            degreeType = degreeTypes.Where(p => p.Description == "Test Degree Type").FirstOrDefault();

            degreeType.Update();

            DegreeType updatedDegreeType = new DegreeType();
            updatedDegreeType.Id = degreeType.Id;
            updatedDegreeType.LoadById();

            Assert.AreEqual(degreeType.Description, updatedDegreeType.Description);

        }


        [TestMethod]
        public void DeleteTest()
        {
            DegreeType degreeType = new DegreeType();

            DegreeTypeList degreeTypes = new DegreeTypeList();
            degreeTypes.Load();

            degreeType = degreeTypes.Where(p => p.Description == "Test Degree Type").FirstOrDefault();

            int result = degreeType.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
