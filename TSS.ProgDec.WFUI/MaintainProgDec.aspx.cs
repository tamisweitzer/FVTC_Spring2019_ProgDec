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
                programs  = new ProgDecList();          ///////////// start checking here for mistakes
                progdecs.Load();
                Rebind();

                Session["progdecs"] = progdecs;
            }
            else
            {
                // Get the objects from session
                progdecs = (ProgDecList)Session["progdecs"];
            }
        }

        private void Rebind()
        {
            ddlProgDecs.DataSource = progdecs;
            ddlProgDecs.DataTextField = "Id";
            ddlProgDecs.DataValueField = "StudentId";
            ddlProgDecs.DataValueField = "ProgramId";
            ddlProgDecs.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {  
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                progDec = new B.ProgDec();

                progDec.Description = txtDescription.Text;

                progDec.Insert();
                progdecs.Add(progDec);
                Session["progdecs"] = progdecs;
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