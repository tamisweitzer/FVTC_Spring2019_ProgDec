using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec2.PL;

namespace TSS.ProgDec.BL
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set;  }
        public string FullName { get { return FirstName + " " + LastName; } }


        public int Insert()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblStudent student = new tblStudent();

                    student.Id = dc.tblStudents.Any() ? dc.tblStudents.Max(s => s.Id) + 1 : 1;  // (condition) ? if{} : else{} 
                    student.FirstName = this.FirstName;
                    student.LastName = this.LastName;
                    student.StudentId = this.StudentId;
                    this.Id = student.Id; 

                    dc.tblStudents.Add(student);
                    return dc.SaveChanges();    // returns rows affected
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    if (Id >= 0)
                    {
                        tblStudent student = dc.tblStudents.Where(s => s.Id == Id).FirstOrDefault();
                        if (student != null)
                        {
                            student.FirstName = this.FirstName;
                            student.LastName = this.LastName;
                            student.StudentId = this.StudentId;

                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
                    }
                    else
                    {
                        throw new Exception("ID is not set");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public int Delete()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    if (Id >= 0)
                    {
                        tblStudent student = dc.tblStudents.Where(s => s.Id == Id).FirstOrDefault();
                        if (student != null)
                        {
                            dc.tblStudents.Remove(student);
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
                    }
                    else
                    {
                        throw new Exception("ID is not set");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void LoadById()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    if (Id >= 0 )
                    {
                        tblStudent student = dc.tblStudents.Where(s => s.Id == Id).FirstOrDefault();
                        if (student != null)
                        {
                            this.Id = student.Id;
                            this.FirstName = student.FirstName;
                            this.LastName = student.LastName;
                            this.StudentId = student.StudentId;
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Id was not set");
                    }
                }
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
    }



    public class StudentList : List<Student> 
    {
        public void Load()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    foreach(tblStudent s in dc.tblStudents)
                    {
                        Student student = new Student();
                        student.Id = s.Id;
                        student.FirstName = s.FirstName;
                        student.LastName = s.LastName;
                        student.StudentId = s.StudentId;

                        Add(student);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
    }
}
