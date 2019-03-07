using System;
using System.Collections.Generic;
using System.Linq;
using TSS.ProgDec2.PL;
using System.Text;
using System.Threading.Tasks;


namespace TSS.ProgDec.BL
{
    public class ProgDec
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProgramId { get; set; }
        public DateTime ChangeDate { get; set; }

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
                        tblProgDec progDec = dc.tblProgDecs.Where(p => p.Id == Id).FirstOrDefault();
                        if (progDec != null)
                        {
                            this.Id = progDec.Id;
                            this.StudentId = progDec.StudentId;
                            this.ProgramId = progDec.ProgramId;
                            this.ChangeDate = progDec.ChangeDate;
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



    public class ProgDecList : List<ProgDec>
    {
        public void Load()
        {
            try
            {
                ProgDecEntities dc = new ProgDecEntities();
                {
                    foreach (tblProgDec p in dc.tblProgDecs)
                    {
                        ProgDec progDec = new ProgDec();
                        progDec.Id = p.Id;
                        progDec.StudentId = p.StudentId;
                        progDec.ProgramId = p.ProgramId;
                        progDec.ChangeDate = p.ChangeDate;

                        Add(progDec);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


}
