using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.WFUI
{
    public partial class MaintainStudents : System.Web.UI.Page
    {
        StudentList students;
        Student student;

        protected void Page_Load(object sender, EventArgs e)
        {
            // If not a post back, get info from database  
            if (!IsPostBack)
            {
                students = new StudentList();
                students.Load();

                Rebind();

                // put objects into session
                Session["students"] = students;
            }
            else
            {
                // Get the objects from session
                students = (StudentList)Session["students"];
            }
        }

        private void Rebind()
        {
            ddlStudents.DataSource = students;  // bind to the screen 
            ddlStudents.DataTextField = "FullName";
            ddlStudents.DataValueField = "Id";
            ddlStudents.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the student we want to delete from the combo box
                student = students[ddlStudents.SelectedIndex];
                if (student != null)
                {
                    // Delete from the database
                    student.Delete();

                    //Remove from the list in the UI
                    students.Remove(student);

                    // Update Session to this new list
                    Session["students"] = students;

                    Rebind();
                }
                else
                {
                    throw new Exception("Please pick a student to delete");
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
                // Get the student we want to update from the combo box
                student = students[ddlStudents.SelectedIndex];

                if (student != null)
                {
                    // Update from database
                    student.FirstName = txtFirstName.Text;
                    student.LastName = txtLastName.Text;
                    student.StudentId = txtStudentId.Text;

                    student.Update();

                    // Put the updated one in the list
                    students[ddlStudents.SelectedIndex] = student;

                    // Update Session to this new list
                    Session["students"] = students;

                    Rebind();
                }
                else
                {
                    throw new Exception("Please pick a student to udpate");
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
                student = new Student();

                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.StudentId = txtStudentId.Text;

                student.Insert();
                students.Add(student);
                Session["students"] = students;
                Rebind();

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the student that i want to work on 
            student = students[ddlStudents.SelectedIndex];

            // put the description on the screen 
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtStudentId.Text = student.StudentId;
        }
    }
}