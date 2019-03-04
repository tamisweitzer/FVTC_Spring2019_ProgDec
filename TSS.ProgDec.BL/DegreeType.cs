using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec2.PL;


namespace TSS.ProgDec.BL
{
    // remember to declare the class as public
    public class DegreeType
    {
        public int Id { get; set; }
        public string Description { get; set; }


        public int Insert()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblDegreeType degreeType = new tblDegreeType();

                    degreeType.Id = dc.tblDegreeTypes.Any() ? dc.tblDegreeTypes.Max(s => s.Id) + 1 : 1;  // (condition) ? if{} : else{} 
                    degreeType.Description = this.Description;
                    

                    this.Id = degreeType.Id;

                    dc.tblDegreeTypes.Add(degreeType);
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
                        tblDegreeType degreeType = dc.tblDegreeTypes.Where(s => s.Id == Id).FirstOrDefault();
                        if (degreeType != null)
                        {
                            degreeType.Description = this.Description;
                            
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
                        tblDegreeType degreeType = dc.tblDegreeTypes.Where(s => s.Id == Id).FirstOrDefault();
                        if (degreeType != null)
                        {
                            dc.tblDegreeTypes.Remove(degreeType);
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
                        tblDegreeType degreeType = dc.tblDegreeTypes.Where(s => s.Id == Id).FirstOrDefault();
                        if (degreeType != null)
                        {
                            this.Id = degreeType.Id;
                            this.Description = degreeType.Description;
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
}

