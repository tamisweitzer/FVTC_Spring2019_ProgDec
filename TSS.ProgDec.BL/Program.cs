using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Degree Type Name")]
        public string DegreeTypeName { get; set; }
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }   // 

        public int Insert()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram program = new tblProgram();

                    program.Id = dc.tblPrograms.Any() ? dc.tblPrograms.Max(s => s.Id) + 1 : 1;  // (if condition) ? thenthis : else 
                    program.Description = this.Description;
                    program.DegreeTypeId = this.DegreeTypeId;
                    program.ImagePath = this.ImagePath;

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
                            program.ImagePath = this.ImagePath;


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
                        // missing an if() here?? error on line 135, '}' expected
                        var results = (from p in dc.tblPrograms
                                       join dt in dc.tblDegreeTypes on p.DegreeTypeId equals dt.Id
                                       where p.Id == this.Id
                                       select new
                                       {
                                           p.Id,
                                           p.DegreeTypeId,
                                           p.Description,
                                           DegreeTypeName = dt.Description,
                                           p.ImagePath
                                       }).FirstOrDefault();

                        // does the if() go here? if (!null) 
                        if (results != null)
                        {
                            this.Id = results.Id;
                            this.Description = results.Description;
                            this.DegreeTypeId = results.DegreeTypeId;
                            this.DegreeTypeName = results.DegreeTypeName;
                            this.ImagePath = results.ImagePath;
                        }
                            

                       // check if i am missing a bracket in this area? 
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
                    // insert two  table join and combine them so the output can show degree type name instead of just id 
                    var results = (from p in dc.tblPrograms
                                   join dt in dc.tblDegreeTypes on p.DegreeTypeId equals dt.Id
                                   orderby p.Description
                                   select new
                                   {
                                       p.Id,
                                       p.DegreeTypeId,
                                       p.Description,
                                       DegreeTypeName = dt.Description,
                                       p.ImagePath
                                   }).ToList();



                    foreach (var p in results)
                    {
                        Program program = new Program();
                        program.Id = p.Id;
                        program.Description = p.Description;
                        program.DegreeTypeId = p.DegreeTypeId;
                        program.DegreeTypeName = p.DegreeTypeName;
                        program.ImagePath = p.ImagePath;
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
