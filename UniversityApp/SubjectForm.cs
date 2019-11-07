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
    public partial class SubjectForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Lesson slctdLesson;

        public SubjectForm()
        {
            InitializeComponent();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            UpdateDataSubjects();
        }

        public void UpdateDataSubjects()
        {
            dgwSubjects.DataSource = db.Lessons.Select(g => new
            {
                g.ID,
                g.Name
            }).ToList();
            dgwSubjects.Columns[0].Visible = false;
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            string sname = txtSname.Text;

            if (string.IsNullOrEmpty(sname))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            if (db.Lessons.FirstOrDefault(g => g.Name.ToLower() == sname.ToLower()) != null)
            {
                MessageBox.Show("This lesson name already exist.");
                return;
            }

            Lesson newLess = new Lesson
            {
                Name = sname
            };

            db.Lessons.Add(newLess);
            db.SaveChanges();
            UpdateDataSubjects();
            MessageBox.Show($"New subject {sname} created succesfully.");
            txtSname.Text = "";
            slctdLesson = null;
        }

        private void btnEditSubject_Click(object sender, EventArgs e)
        {
            string sname = txtSname.Text;

            if (string.IsNullOrEmpty(sname))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            slctdLesson.Name = sname;
            db.SaveChanges();
            UpdateDataSubjects();
            MessageBox.Show("All changes saved succesfully.");
            txtSname.Text = "";
            slctdLesson = null;
        }

        private void dgwSubjects_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int slctdID = (int)dgwSubjects.Rows[e.RowIndex].Cells["ID"].Value;

            slctdLesson = db.Lessons.Find(slctdID);

            txtSname.Text = slctdLesson.Name;
        }
    }
}
