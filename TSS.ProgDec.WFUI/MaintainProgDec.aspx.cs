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
        BL.ProgDec progDec;
        ProgramList programs;
        StudentList students;


        protected void Page_Load(object sender, EventArgs e)
        {
            // If not a post back, get info from database  
            if (!IsPostBack)
            {
                programs  = new ProgramList();          ///////////// start checking here for mistakes
                programs.Load();

                students = new StudentList();
                students.Load();

                Rebind();

                Session["programs"] = programs;
                Session["students"] = students;
            }
            else
            {
                // Get the objects from session
                programs = (ProgramList)Session["programs"];
                students = (StudentsList)Session["students"];
            }
        }

        private void Rebind()
        {
            ddlPrograms.DataSource = programs;
            ddlPrograms.DataTextField = "Description";
            ddlPrograms.DataValueField = "Id";
            ddlPrograms.DataBind();

            ddlStudents.DataSource = students;
            ddlStudents.DataTextField = "FullName";
            ddlStudents.DataValueField = "Id";
            ddlStudents.DataBind();

        }

        

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                progDec = new BL.ProgDec();

                progdec.ProgramId = programs[ddlPrograms.SelectedIndex].Id;
                progdec.StudentId = students[ddlStudents.SelectedIndex].Id;

                progdec.Insert();

                Rebind();

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void ddlProgDecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the progDec that i want to work on 
            progDec = progdecs[ddlProgDecs.SelectedIndex];

            // put the description on the screen 
            txtDescription.Text = progDec.Description;
        }
    }
}