using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityApp.Model;
using UniversityApp.Extension;

namespace UniversityApp
{
    public partial class TeacherForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Teacher slctdTeach;

        public TeacherForm()
        {
            InitializeComponent();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            UpdateDataTeachers();
        }

        public void UpdateDataTeachers()
        {
            dgwTeachers.DataSource = db.Teachers.Select(s => new
            {
                s.ID,
                s.Firstname,
                s.Lastname,
                s.Username,
                s.Birthdate
            }).ToList();

            dgwTeachers.Columns[0].Visible = false;
        }

        public void ClearForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            string fname = txtFname.Text;
            string lname = txtLname.Text;
            string password = txtPassword.Text;
            string username = txtUname.Text;
            DateTime birthdate = dtBirthdate.Value;

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname)
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            if (db.Teachers.FirstOrDefault(t => t.Username == username) != null)
            {
                MessageBox.Show("Username like this name already exist.");
                return;
            }

            string mainPass = Extensions.HashPassword(password);

            Teacher newTeach = new Teacher
            {
                Firstname = fname,
                Lastname = lname,
                Username = username,
                Birthdate = birthdate,
                Password = mainPass
            };

            db.Teachers.Add(newTeach);
            db.SaveChanges();
            UpdateDataTeachers();
            MessageBox.Show($"New teacher {fname} {lname} created succesfully.");
            ClearForm();
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            string fname = txtFname.Text;
            string lname = txtLname.Text;
            string password = txtPassword.Text;
            string username = txtUname.Text;
            DateTime birthdate = dtBirthdate.Value;

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname)
                || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            if (slctdTeach.Username != username && db.Teachers.FirstOrDefault(t => t.Username == username) != null)
            {
                MessageBox.Show("Username like this name already exist.");
                return;
            }

            slctdTeach.Firstname = fname;
            slctdTeach.Lastname = lname;
            slctdTeach.Username = username;
            slctdTeach.Birthdate = birthdate;

            db.SaveChanges();
            UpdateDataTeachers();
            ClearForm();
            MessageBox.Show("All changes saved succesfully.");
            txtPassword.Enabled = true;
        }

        private void dgwTeachers_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int slctdID = (int)dgwTeachers.Rows[e.RowIndex].Cells["ID"].Value;
            slctdTeach = db.Teachers.Find(slctdID);

            txtFname.Text = slctdTeach.Firstname;
            txtLname.Text = slctdTeach.Lastname;
            txtUname.Text = slctdTeach.Username;
            dtBirthdate.Value = (DateTime)slctdTeach.Birthdate;
            txtPassword.Enabled = false;
        }
    }
}
