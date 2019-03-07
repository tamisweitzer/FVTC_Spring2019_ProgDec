using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec2.PL;

namespace TSS.ProgDec.BL
{
    public class Program
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DegreeTypeId { get; set; }


        public int Insert()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram program = new tblProgram();

                    program.Id = dc.tblPrograms.Any() ? dc.tblPrograms.Max(s => s.Id) + 1 : 1;  // (condition) ? if{} : else{} 
                    program.Description = this.Description;
                    program.DegreeTypeId = this.DegreeTypeId;
                   
                    this.Id = program.Id;

                    dc.tblPrograms.Add(program);
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
                        tblProgram program = dc.tblPrograms.Where(s => s.Id == Id).FirstOrDefault();
                        if (program != null)
                        {
                            program.Description = this.Description;
                            program.DegreeTypeId = this.DegreeTypeId;
                            

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
                        tblProgram program = dc.tblPrograms.Where(s => s.Id == Id).FirstOrDefault();
                        if (program != null)
                        {
                            dc.tblPrograms.Remove(program);
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
                        tblProgram program = dc.tblPrograms.Where(s => s.Id == Id).FirstOrDefault();
                        if (program != null)
                        {
                            this.Id = program.Id;
                            this.Description = program.Description;
                            this.DegreeTypeId = program.DegreeTypeId;
                            
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
    }



    public class ProgramList : List<Program>
    {
        public void Load()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    foreach (tblProgram p in dc.tblPrograms)
                    {
                        Program program = new Program();
                        program.Id = p.Id;
                        program.Description = p.Description;
                        program.DegreeTypeId = p.DegreeTypeId;
                       

                        Add(program);
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
