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
    public partial class StudentForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Student slctdStu;
        Group slctdGroup;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            UpdateComboGroup();
            UpdateDataStudents();
        }

        public void UpdateComboGroup()
        {
            List<ComboLoader> groups = new List<ComboLoader>();

            foreach (var item in db.Groups.ToList())
            {
                groups.Add(new ComboLoader
                {
                    Value = item.ID,
                    Text = item.Name
                });
            }

            cmbGroups.DataSource = groups;
        }

        public void UpdateDataStudents()
        {
            dgwStudents.DataSource = db.Students.Select(s => new
            {
                s.ID,
                s.Firstname,
                s.Lastname,
                s.Username,
                s.Birthdate,
                Group = s.Group.Name
            }).ToList();

            dgwStudents.Columns[0].Visible = false;
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

        private void btnAddStu_Click(object sender, EventArgs e)
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

            if (db.Students.FirstOrDefault(s => s.Username == username) != null)
            {
                MessageBox.Show("Username like this name already exist.");
                return;
            }

            string mainPass = Extensions.HashPassword(password);

            Student newStu = new Student
            {
                Firstname = fname,
                Lastname = lname,
                Username = username,
                Birthdate = birthdate,
                Password = mainPass,
                GroupID = slctdGroup.ID
            };

            db.Students.Add(newStu);
            db.SaveChanges();
            UpdateDataStudents();
            MessageBox.Show($"New student {fname} {lname} created succesfully.");
            ClearForm();
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slctdID = ((ComboLoader)cmbGroups.SelectedItem).Value;
            slctdGroup = db.Groups.Find(slctdID);
        }

        private void dgwStudents_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int slctdID = (int)dgwStudents.Rows[e.RowIndex].Cells["ID"].Value;
            slctdStu = db.Students.Find(slctdID);

            txtFname.Text = slctdStu.Firstname;
            txtLname.Text = slctdStu.Lastname;
            txtUname.Text = slctdStu.Username;
            dtBirthdate.Value = (DateTime)slctdStu.Birthdate;
            cmbGroups.Text = slctdStu.Group.Name;
            txtPassword.Enabled = false;
        }

        private void btnEditStu_Click(object sender, EventArgs e)
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

            if (slctdStu.Username != username && db.Students.FirstOrDefault(s => s.Username == username) != null)
            {
                MessageBox.Show("Username like this name already exist.");
                return;
            }

            slctdStu.Firstname = fname;
            slctdStu.Lastname = lname;
            slctdStu.Username = username;
            slctdStu.Birthdate = birthdate;
            slctdStu.GroupID = slctdGroup.ID;

            db.SaveChanges();
            UpdateDataStudents();
            ClearForm();
            MessageBox.Show("All changes saved succesfully.");
            txtPassword.Enabled = true;
        }
    }
}
