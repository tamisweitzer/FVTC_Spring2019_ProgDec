using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec2.PL;

namespace TSS.ProgDec.BL
{
    public class Advisor
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Advisor() { }

        public Advisor(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


    public class AdvisorList: List<Advisor>
    {
        public void Load()
        {
            ProgDecEntities dc = new ProgDecEntities();

            foreach(tblAdvisor advisor in dc.tblAdvisors)
            {
                Advisor a = new Advisor(advisor.Id, advisor.Name);
                Add(a);
            }
        }


        public void LoadByProgDecId(int progDecId)
        {
            try
            {
                ProgDecEntities dc = new ProgDecEntities();

                var advisors = from pda in dc.tblProgDecAdvisors
                               join a in dc.tblAdvisors on pda.AdvisorId equals a.Id
                               where pda.ProgDecId == progDecId
                               select new
                               {
                                   a.Id,
                                   a.Name
                               };

                foreach (var advisor in advisors)
                {
                    Advisor a = new Advisor(advisor.Id, advisor.Name);
                    this.Add(a);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


    public static class ProgDecAdvisor
    {
        public static void Delete(int progDecId, int advisorId)
        {
            ProgDecEntities dc = new ProgDecEntities();
            tblProgDecAdvisor pda = dc.tblProgDecAdvisors.FirstOrDefault(p => p.ProgDecId == progDecId
                                    && p.AdvisorId == advisorId);

            if (pda != null)
            {
                dc.tblProgDecAdvisors.Remove(pda);
                dc.SaveChanges();
            }
            dc = null;
        }

        public static void Add(int progDecId, int advisorId)
        {
            ProgDecEntities dc = new ProgDecEntities();
            tblProgDecAdvisor pda = new tblProgDecAdvisor();

            pda.Id = dc.tblProgDecAdvisors.Any() ? dc.tblProgDecAdvisors.Max(p => p.Id) + 1 : 1; 
            pda.ProgDecId = progDecId;
            pda.AdvisorId = advisorId;

            dc.tblProgDecAdvisors.Add(pda);
            dc.SaveChanges();
            dc = null;
        }

    }
}
