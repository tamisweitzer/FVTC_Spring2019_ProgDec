using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSS.ProgDec.BL;
using System.Linq;

namespace TSS.ProgDec.BL.Test
{
    [TestClass]
    public class utStudent
    {
        [TestMethod]
        public void LoadTest()
        {
            StudentList students = new StudentList();
            students.Load();
            Assert.AreEqual(5, students.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Student student = new Student();
            student.FirstName = "Bart";
            student.LastName = "Simpson";
            student.StudentId = "123456789";

            int result = student.Insert();
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void  UpdateTest()
        {
            Student student = new Student();

            StudentList students = new StudentList();
            students.Load();

            student = students.Where(s => s.FirstName == "Bart").FirstOrDefault();

            student.FirstName = "Bobby";
            student.LastName = "Jackson";
            student.StudentId = "123666666";
            student.Update();

            Student updatedStudent = new Student();
            updatedStudent.Id = student.Id;
            updatedStudent.LoadById();

            Assert.AreEqual(student.Id, updatedStudent.StudentId);

        }


        [TestMethod]
        public void DeleteTest()
        {
            Student student = new Student();

            StudentList students = new StudentList();
            students.Load();

            student = students.Where(s => s.FirstName == "Bobby").FirstOrDefault();

            int result = student.Delete();
            Assert.IsTrue(result > 0);
        }
    }
}
