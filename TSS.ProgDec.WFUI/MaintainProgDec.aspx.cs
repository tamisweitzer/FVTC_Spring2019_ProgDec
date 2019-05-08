using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.WFUI
{
    public partial class MaintainProgDecs : System.Web.UI.Page
    {
        
        ProgramList programs;
        StudentList students;
        BL.ProgDec progDec;


        protected void Page_Load(object sender, EventArgs e)
        {
            // If not a post back, get info from database  
            if (!IsPostBack)
            {
                programs  = new ProgramList();
                programs.Load();

                students = new StudentList();
                students.Load();

                //Rebind();

                Session["programs"] = programs;
                Session["students"] = students;
            }
            else
            {
                // Get the objects from session
                programs = (ProgramList)Session["programs"];
                students = (StudentList)Session["students"];
            }
        }


        // commenting this out because it is broken and i can't fix it
        //private void Rebind()
        //{
        //    ddlPrograms.DataSource = programs;
        //    ddlPrograms.DataTextField = "Description";
        //    ddlPrograms.DataValueField = "Id";
        //    ddlPrograms.DataBind();

        //    ddlStudents.DataSource = students;
        //    ddlStudents.DataTextField = "FullName";
        //    ddlStudents.DataValueField = "Id";
        //    ddlStudents.DataBind();

        //}

        

        //protected void btnInsert_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        progdec = new BL.ProgDec();

        //        progdec.ProgramId = programs[ddlPrograms.SelectedIndex].Id;
        //        progdec.StudentId = students[ddlStudents.SelectedIndex].Id;

        //        progdec.Insert();

        //        Rebind();

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Error: " + ex.Message);
        //    }
        //}

        
    }
}