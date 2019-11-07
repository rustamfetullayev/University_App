using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityApp.Extension;
using UniversityApp.Model;

namespace UniversityApp
{
    public partial class Login : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();

        Admin admin;
        Student student;
        Teacher teacher;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (rbAdmin.Checked)
            {
                admin = db.Admins.FirstOrDefault(a => a.Username == username);

                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please fill emtpy areas correctly.");
                    return;
                }

                if (admin == null)
                {
                    MessageBox.Show($"Username or password is wrong.");
                    return;
                }

                if (!Extensions.CheckPassword(password, admin.Password))
                {
                    MessageBox.Show($"Username or password is wrong.");
                    return;
                }

                new AdminForm().ShowDialog();
            }

            else if (rbStudent.Checked)
            {
                student = db.Students.FirstOrDefault(a => a.Username == username);

                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please fill emtpy areas correctly.");
                    return;
                }

                if (student == null)
                {
                    MessageBox.Show($"Username or password is wrong.");
                    return;
                }

                if (!Extensions.CheckPassword(password, student.Password))
                {
                    MessageBox.Show($"Username or password is wrong.");
                    return;
                }

                StudentDashboardForm sform = new StudentDashboardForm(student);

                sform.ShowDialog();
            }

            else if(rbTeacher.Checked)
            {
                teacher = db.Teachers.FirstOrDefault(a => a.Username == username);

                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please fill emtpy areas correctly.");
                    return;
                }

                if (teacher == null)
                {
                    MessageBox.Show($"Username or password is wrong.");
                    return;
                }

                if (!Extensions.CheckPassword(password, teacher.Password))
                {
                    MessageBox.Show($"Username or password is wrong.");
                    return;
                }

                TeacherDashboardForm tform = new TeacherDashboardForm(teacher);

                tform.ShowDialog();
            }
        }
    }
}
