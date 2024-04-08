using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class RegisterCourse : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentListFromSession();
                FillStudentDropdown();
                fillListCourses();
            }
        }

        private void FillStudentDropdown()
        {
            List<Student> students = GetStudentListFromSession();                      
            List<string> studentDisplayNames = new List<string>();

            // verify the students list
            if (students != null && students.Count > 0)
            {
                // Add the students name to the list
                studentDisplayNames.AddRange(students.Select(student => student.ToString()).ToList());
                // Add "SELECT ..." as 1st element
                studentDisplayNames.Insert(0, "Select ...");
            }
            else
            {
                // if the list it's empty
                studentDisplayNames.Add("No students available");
            }

            // Clean the dropdown and place the data
            StudentDropdown.Items.Clear();
            StudentDropdown.DataSource = studentDisplayNames;
            StudentDropdown.DataBind();
        }

        private void fillListCourses()
        {
            // get courses from helper
            List<Course> courses = Helper.GetAvailableCourses();

            // Adding each course to the checkbox list
            foreach (Course course in courses)
            {
                string itemText = $"{course.Code} {course.Title} - {course.WeeklyHours} hours/week";
                chkCourses.Items.Add(new ListItem(itemText, course.Code));
            }


        }


        private List<Student> GetStudentListFromSession()
        {
            return Session["StudentList"] as List<Student> ?? new List<Student>();
        }


        protected void Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorDiv.Visible = false;
            if (StudentDropdown.SelectedIndex == 0)
            {
                studentRegisteredCoursesDiv.Visible = true;
                HtmlGenericControl listCourses = new HtmlGenericControl("div");
                listCourses.InnerHtml = "Must select one!";
                listCourses.Attributes["class"] = "alert alert-danger mt-3";
                studentRegisteredCoursesDiv.Controls.Add(listCourses);
                chkCourses.Items.Cast<ListItem>().ToList().ForEach(item => item.Selected = false);
            }
            else
            {
                string selectedStudentId = StudentDropdown.SelectedValue;
                int idSelectedStudent = int.Parse(selectedStudentId.Split('-')[0].Trim());
                studentRegisteredCoursesDiv.Visible = true;
                HtmlGenericControl listCourses = new HtmlGenericControl("div");
                listCourses.InnerHtml = getStudentCourses(idSelectedStudent);
                listCourses.Attributes["class"] = "alert alert-primary mt-3";
                studentRegisteredCoursesDiv.Controls.Add(listCourses);
            }
        }

        protected string getStudentCourses(int studentId)
        {
            List<Student> students = GetStudentListFromSession();
            Student student = students.FirstOrDefault(s => s.Id == studentId);            
            int numberOfCourses = 0;

            if (student != null)
            {
                //get the registered courses
                List<Course> registeredCourses = student.RegisteredCourses;
                //deselect all items first
                chkCourses.Items.Cast<ListItem>().ToList().ForEach(item => item.Selected = false);

                if (registeredCourses.Count > 0)
                {
                    foreach (var course in registeredCourses)
                    {
                        numberOfCourses++;
                        foreach (ListItem item in chkCourses.Items)
                        {
                            if (item.Value == course.Code)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
                return ($"Selected student has registered {numberOfCourses} courses, {student.TotalWeeklyHours()} hours weekly");
            }
            return "not found!";            
        }

        protected void save_Click(object sender, EventArgs e)
        {
            errorDiv.Visible = false;
            List<Student> students = GetStudentListFromSession();

            // get the selection
            string selectedStudentId = StudentDropdown.SelectedValue;

            if(StudentDropdown.SelectedIndex == 0) {
                HtmlGenericControl errormsg = new HtmlGenericControl("div");
                studentRegisteredCoursesDiv.Visible = true;
                errormsg.InnerHtml = "Must select one!";
                errormsg.Attributes["class"] = "alert alert-danger mt-3";
                studentRegisteredCoursesDiv.Controls.Add(errormsg);
                return;
            }

            // get the student ID from the list
            int idSelectedStudent = int.Parse(selectedStudentId.Split('-')[0].Trim());                   

            // Retrieve the student by ID
            Student selectedStudent = students.FirstOrDefault(student => student.Id == idSelectedStudent);

            //pass the data to the methods
            checkboxesCoursesSelected(selectedStudent);
            studentRegisteredCoursesDiv.Visible = true;
            HtmlGenericControl listCourses = new HtmlGenericControl("div");
            listCourses.InnerHtml = getStudentCourses(selectedStudent.Id);
            listCourses.Attributes["class"] = "alert alert-primary mt-3";
            studentRegisteredCoursesDiv.Controls.Add(listCourses);
        }


        private void checkboxesCoursesSelected(Student selectedStudent)
        {
            bool selected = false;

            // verify if at least one checkbox is selected
            foreach (ListItem item in chkCourses.Items)
            {
                if (item.Selected)
                {
                    selected = true;
                    break;
                }
            }
            //if the verification is successfull, add the selection to the student
            if (selected)
            {
                List<Course> coursesToAdd = new List<Course>();
                foreach (ListItem item in chkCourses.Items)
                {
                    if (item.Selected)
                    {
                        Course course = Helper.GetCourseByCode(item.Value);
                        coursesToAdd.Add(course);
                    }
                }
                try
                {
                    selectedStudent.RegisterCourses(coursesToAdd);
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                    errorDiv.Visible = true;
                    return;
                }

            }
            else
            {
                lblErrorMessage.Text = "You need at least one course";
                errorDiv.Visible = true;
                return;
            }

        }
        
    }
}