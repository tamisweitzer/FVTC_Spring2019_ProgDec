using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.WFUI
{
    public partial class MaintainPrograms : System.Web.UI.Page
    {

        ProgramList programs;
        DegreeTypeList degreeTypes; // TODO err because this is not in BL yet
        Program program;


        protected void Page_Load(object sender, EventArgs e)
        {
            // If not a post back, get info from database  
            if (!IsPostBack)
            {
                programs = new ProgramList();
                programs.Load();

                degreeTypes = new DegreeTypeList();
                degreeTypes.Load();
                Rebind();

                // put objects into session
                Session["programs"] = programs;
                Session["degreetypes"] = degreeTypes;   // review to see if i typed this right 

            }
            else
            {
                // Get the objects from session
                programs = (ProgramList)Session["programs"];
                degreeTypes = (DegreeTypeList)Session["degreeTypes"];
            }
        }

        private void Rebind()
        {
            // bind to the screen 
            ddlPrograms.DataSource = programs;
            ddlDegreeTypes.DataSource = degreeTypes;

            // Designate the property that is shown to the user
            ddlPrograms.DataTextField = "Description";  //  shows the description of the of the program type being selected of class prop // Designate the property to use as the unique identifier
            ddlDegreeTypes.DataTextField = "Description";

            ddlPrograms.DataValueField = "Id";
            ddlDegreeTypes.DataValueField = "Id";

            ddlPrograms.DataBind();
            ddlDegreeTypes.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the program we want to delete from the combo box
                program = programs[ddlPrograms.SelectedIndex];
                if (program != null)
                {
                    // Delete from the database
                    program.Delete();

                    //Remove from the list in the UI
                    programs.Remove(program);

                    // Update Session to this new list
                    Session["programs"] = programs;

                    Rebind();
                }
                else
                {
                    throw new Exception("Please pick a program to delete");
                }
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex.Message);
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the program we want to update from the combo box
                program = programs[ddlPrograms.SelectedIndex];

                if (program != null)
                {
                    // Update from database
                    program.Description = txtDescription.Text;
                    program.DegreeTypeId[ddlDegreeTypes.SelectedIndex].Id;

                    program.Update();

                    // Put the updated one in the list
                    programs[ddlPrograms.SelectedIndex] = program;

                    // Update Session to this new list
                    Session["programs"] = programs;

                    Rebind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                program = new Program();

                program.Description = txtDescription.Text;
                program.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                program.Insert();
                programs.Add(program);
                Session["programs"] = programs;
                Rebind();

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void ddlPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the program that i want to work on 
            program = programs[ddlPrograms.SelectedIndex];

            // put the description on the screen 
            txtDescription.Text = program.Description;

            // select the correct degree type in the other dropdown 
            ddlDegreeTypes.SelectedValue = program.DegreeTypeId.ToString();
        }
    }
}