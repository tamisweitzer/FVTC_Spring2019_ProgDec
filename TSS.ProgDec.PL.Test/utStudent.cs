using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TSS.ProgDec2.PL;


namespace TSS.ProgDec.PL.Test
{
    /// <summary>
    /// Summary description for utStudent
    /// </summary>
    [TestClass]
    public class utStudent
    {

        [TestMethod]
        public void LoadTest()
        {
            // data context
            // make var of data type of data context
            // [data type]  [data context]  = new [data type object]
            ProgDecEntities dc = new ProgDecEntities();

            var students = from s in dc.tblStudents
                           select s;
            dc = null; // clean up, because the same var name is being used elsewhere
            Assert.IsTrue(students.Count() > 0);
        }



        [TestMethod]
        public void InsertTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            // Dimension and instatiate new row 
            tblStudent newrow = new tblStudent();

            // set properties for the new record
            newrow.Id = -99;
            newrow.FirstName = "Bart";
            newrow.LastName = "Simpson";
            newrow.StudentId = "123999999";

            // Insert the row into the database
            dc.tblStudents.Add(newrow);

            // Commit the changes 
            dc.SaveChanges();

            tblStudent student = (from p in dc.tblStudents
                                  where p.Id == -99
                                  select p).FirstOrDefault();

            Assert.AreSame(newrow, student);    // one way to test if a new row was successfully added 
        }


        [TestMethod]
        public void UpdateTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            tblStudent student = (from s in dc.tblStudents
                                  where s.Id == -99
                                  select s).FirstOrDefault();

            student.FirstName = "Updated FirstName";
            student.LastName = "Updated LastName";
            student.StudentId = "123888888";
            dc.SaveChanges();

            tblStudent updatedstudent = (from s in dc.tblStudents
                                         where s.Id == -99
                                         select s).FirstOrDefault();

            Assert.AreEqual(student.FirstName, updatedstudent.FirstName);
        }


        [TestMethod]
        public void DeleteTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            tblStudent student = (from s in dc.tblStudents
                                  where s.Id == -99
                                  select s).FirstOrDefault();

            if (student != null)
            {
                dc.tblStudents.Remove(student);
                dc.SaveChanges();
            }

            tblStudent deletedstudent = (from s in dc.tblStudents
                                         where s.Id == -99
                                         select s).FirstOrDefault();

            Assert.IsNull(deletedstudent); // confirms the delete worked 
        }


    }
}
