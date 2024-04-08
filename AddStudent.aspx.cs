using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StudentList"] == null)
                {
                    Session["StudentList"] = new List<Student>();
                }

                BindStudentList();
            }
            else
            {
                BindStudentList();
            }
        }

        protected void StudentName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StudentName.Text))
            {
                RequiredFieldValidator1.IsValid = false;
                RequiredFieldValidator1.ErrorMessage = "Student name is required.";
            }
            else
            {
                RequiredFieldValidator1.IsValid = true;
                RequiredFieldValidator1.ErrorMessage = "";
            }
        }


        protected void AddStudentButn_Click(object sender, EventArgs e)
        {
            string name = StudentName.Text.Trim(); // Eliminar espacios en blanco al inicio y al final

            // Verificar si el nombre está vacío
            if (string.IsNullOrWhiteSpace(name))
            {
                BindStudentList();
                return;
            }
            
            string type = StudentType.SelectedValue;

            Student student = null;
            switch (type)
            {
                case "FullTime":
                    student = new FulltimeStudent(name, type);
                    break;
                case "PartTime":
                    student = new ParttimeStudent(name, type);
                    break;
                case "Coop":
                    student = new CoopStudent(name, type);
                    break;
            }

            StudentName.Text = "";
            StudentType.SelectedIndex = 0;
            AddStudentToList(student);
            BindStudentList();
        }


        public void AddStudentToList(Student student)
        {
            List<Student> studentList = Session["StudentList"] as List<Student>;
            studentList.Add(student);
        }

        private void BindStudentList()
        {
            studentList.Controls.Clear();
            List<Student> studentListData = Session["StudentList"] as List<Student>;

            if (studentListData == null || studentListData.Count == 0)
            {
                // La lista de estudiantes está vacía, mostrar mensaje
                HtmlGenericControl emptyMessageDiv = new HtmlGenericControl("div")
                {
                    InnerText = "No students added yet."
                };
                studentList.Controls.Add(emptyMessageDiv);
            }
            else
            {
                // La lista de estudiantes no está vacía, crear elementos HTML para cada estudiante
                foreach (var student in studentListData)
                {
                    // Crear un div de clase 'row' para envolver los datos del estudiante
                    HtmlGenericControl rowDiv = new HtmlGenericControl("div");
                    rowDiv.Attributes.Add("class", "datarow d-flex align-items-center");

                    // Crear un div para el ID del estudiante
                    HtmlGenericControl idDiv = new HtmlGenericControl("div");
                    idDiv.Attributes.Add("class", "student-list1");
                    idDiv.InnerText = $"{student.Id}";

                    // Crear un div para el nombre del estudiante
                    HtmlGenericControl nameDiv = new HtmlGenericControl("div");
                    nameDiv.Attributes.Add("class", "student-list");
                    nameDiv.InnerText = $"{student.Name}";

                    // Agregar los divs al div de clase 'row'
                    rowDiv.Controls.Add(idDiv);
                    rowDiv.Controls.Add(nameDiv);

                    // Agregar el div de clase 'row' al contenedor principal
                    studentList.Controls.Add(rowDiv);
                }


            }
        }


    }
}