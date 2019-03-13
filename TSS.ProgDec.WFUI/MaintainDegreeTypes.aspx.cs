using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.WFUI
{
    public partial class MaintainDegreeTypes : System.Web.UI.Page
    {

        DegreeTypeList degreeTypes;
        DegreeType degreeType;


        protected void Page_Load(object sender, EventArgs e)
        {
            // If not a post back, get info from database  
            if (!IsPostBack)
            {
                degreeTypes = new DegreeTypeList();
                degreeTypes.Load();
                Rebind();

                Session["degreetypes"] = degreeTypes;
            }
            else
            {
                // Get the objects from session
                degreeTypes = (DegreeTypeList)Session["degreeTypes"];
            }
        }

        private void Rebind()
        {
            ddlDegreeTypes.DataSource = degreeTypes; 
            ddlDegreeTypes.DataTextField = "Description";
            ddlDegreeTypes.DataValueField = "Id";
            ddlDegreeTypes.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the degreeType we want to delete from the combo box
                degreeType = degreeTypes[ddlDegreeTypes.SelectedIndex];
                if (degreeType != null)
                {
                    // Delete from the database
                    degreeType.Delete();

                    //Remove from the list in the UI
                    degreeTypes.Remove(degreeType);

                    // Update Session to this new list
                    Session["degreeTypes"] = degreeTypes;

                    Rebind();
                }
                else
                {
                    throw new Exception("Please pick a Degree Type to delete");
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
                // Get the degreeType we want to update from the combo box
                degreeType = degreeTypes[ddlDegreeTypes.SelectedIndex];

                if (degreeType != null)
                {
                    // Update from database
                    degreeType.Description = txtDescription.Text;
                  
                    degreeType.Update();

                    // Put the updated one in the list
                    degreeTypes[ddlDegreeTypes.SelectedIndex] = degreeType;

                    // Update Session to this new list
                    Session["degreeTypes"] = degreeTypes;

                    Rebind();
                }
                else
                {
                    throw new Exception("Please pick a Degree Type to update");
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
                degreeType = new DegreeType();

                degreeType.Description = txtDescription.Text;
               
                degreeType.Insert();
                degreeTypes.Add(degreeType);
                Session["degreeTypes"] = degreeTypes;
                Rebind();

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void ddlDegreeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the degreeType that i want to work on 
            degreeType = degreeTypes[ddlDegreeTypes.SelectedIndex];

            // put the description on the screen 
            txtDescription.Text = degreeType.Description;
        }
    }
}