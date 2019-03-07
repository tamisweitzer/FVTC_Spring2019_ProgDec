using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec2.PL;




namespace TSS.ProgDec.BL
{
    public class DegreeType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public bool Insert()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblDegreeType degreeType = new tblDegreeType();

                    degreeType.Id = dc.tblDegreeTypes.Any() ? dc.tblDegreeTypes.Max(p => p.Id) + 1 : 1;  // (condition) ? if{} : else{} 
                    degreeType.Description = this.Description;

                    dc.tblDegreeTypes.Add(degreeType);
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
                        tblDegreeType degreeType = dc.tblDegreeTypes.Where(p => p.Id == Id).FirstOrDefault();
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



        public void LoadById()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    if (Id >= 0)
                    {
                        tblDegreeType degreeType = dc.tblDegreeTypes.Where(p => p.Id == Id).FirstOrDefault();
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



        public int Delete()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    if (Id >= 0)
                    {
                        tblDegreeType degreeType = dc.tblDegreeTypes.Where(p => p.Id == Id).FirstOrDefault();
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

    }



    public class DegreeTypeList : List<DegreeType>
    {
        //public void Sort()
        //{
        //    List<DegreeType> degreeTypes = this.OrderBy(p => p.Description).ToList();
        //    this.Clear();
        //    this.AddRange(degreeTypes);
        //}
        public void Load()
        {
            try
            {
                ProgDecEntities dc = new ProgDecEntities();

                foreach (tblDegreeType p in dc.tblDegreeTypes)
                {
                    // Make a DegreeType object 
                    DegreeType degreetype = new DegreeType();

                    // Fill the degreetype object properties
                    // from values in the table
                    degreetype.Id = p.Id;
                    degreetype.Description = p.Description;

                    // Add it to the DegreeTypeList (myself)
                    Add(degreetype);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

