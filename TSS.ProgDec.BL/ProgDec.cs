using System;
using System.Collections.Generic;
using System.Linq;
using TSS.ProgDec2.PL;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TSS.ProgDec.BL
{
    public class ProgDec
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProgramId { get; set; }
        [DisplayName("Change Date")]
        public DateTime ChangeDate { get; set; }

        [DisplayName("Program Name")]
        public string ProgramName { get; set; }

        [DisplayName("Student Name")]
        public string StudentName { get; set; }

        public bool Insert()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgDec progDec = new tblProgDec();

                    progDec.Id = dc.tblProgDecs.Any() ? dc.tblProgDecs.Max(p => p.Id) + 1 : 1;  // (condition) ? if{} : else{} 
                    progDec.StudentId = this.StudentId;
                    progDec.ProgramId = this.ProgramId;

                    dc.tblProgDecs.Add(progDec);
                    dc.SaveChanges();    // returns rows affected
                    return true;
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
                        tblProgDec progDec = dc.tblProgDecs.Where(p => p.Id == Id).FirstOrDefault();
                        if (progDec != null)
                        {
                            progDec.StudentId = this.StudentId;
                            progDec.ProgramId = this.ProgramId;
                            progDec.ChangeDate = DateTime.Now;

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
                    if (Id >= 0)
                    {
                        var progDec = (from pd in dc.tblProgDecs
                                       join p in dc.tblPrograms on pd.ProgramId equals p.Id
                                       join s in dc.tblStudents on pd.StudentId equals s.Id
                                       where pd.Id == this.Id

                                       select new
                                       {
                                           pd.Id,
                                           pd.ProgramId,
                                           pd.StudentId,
                                           pd.ChangeDate,
                                           p.Description,
                                           s.FirstName,
                                           s.LastName
                                       }).FirstOrDefault();

                        if (progDec != null)
                        {
                            this.Id = progDec.Id;
                            this.StudentId = progDec.StudentId;
                            this.ProgramId = progDec.ProgramId;
                            this.ChangeDate = progDec.ChangeDate;
                            this.ProgramName = progDec.Description;
                            this.StudentName = progDec.FirstName + " " + progDec.LastName;
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
                        tblProgDec progDec = dc.tblProgDecs.Where(p => p.Id == Id).FirstOrDefault();
                        if (progDec != null)
                        {
                            dc.tblProgDecs.Remove(progDec);
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



    }


    // check this code is correct 
    public class ProgDecList : List<ProgDec>
    {
        public void Load()
        {
            try
            {
                ProgDecEntities dc = new ProgDecEntities();

                var results = (from pd in dc.tblProgDecs
                               join p in dc.tblPrograms on pd.ProgramId equals p.Id
                               join s in dc.tblStudents on pd.StudentId equals s.Id
                               orderby pd.ChangeDate descending
                               select new
                               {
                                   pd.Id,
                                   pd.ProgramId,
                                   pd.StudentId,
                                   pd.ChangeDate,
                                   p.Description,
                                   s.FirstName,
                                   s.LastName
                               }).ToList();

                foreach (var p in results)
                {
                    ProgDec progDec = new ProgDec();

                    progDec.Id = p.Id;
                    progDec.StudentId = p.StudentId;
                    progDec.ProgramId = p.ProgramId;
                    progDec.ChangeDate = p.ChangeDate;
                    progDec.ProgramName = p.Description;
                    progDec.StudentName = p.FirstName + " " + p.LastName;

                    Add(progDec);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


}
