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
    public partial class AddCourseForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Teacher slctdTeach;
        Group slctdGroup;
        Lesson slctdLesson;

        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
            UpdateComboLesson();
            UpdateComboGroup();
            UpdateComboTeacher();
            UpdateDataCourse();
        }

        public void UpdateComboLesson()
        {
            List<ComboLoader> lessons = new List<ComboLoader>();

            foreach (var item in db.Lessons.ToList())
            {
                lessons.Add(new ComboLoader
                {
                    Value = item.ID,
                    Text = item.Name
                });
            }

            cmbLessons.DataSource = lessons;
        }

        public void UpdateComboTeacher()
        {
            List<ComboLoader> teachers = new List<ComboLoader>();

            foreach (var item in db.Teachers.ToList())
            {
                teachers.Add(new ComboLoader
                {
                    Value = item.ID,
                    Text = item.Firstname+" "+item.Lastname
                });
            }

            cmbTeachers.DataSource = teachers;
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

        private void cmbLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcID = ((ComboLoader)cmbLessons.SelectedItem).Value;
            slctdLesson = db.Lessons.Find(slcID);
        }

        private void cmbTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcID = ((ComboLoader)cmbTeachers.SelectedItem).Value;
            slctdTeach = db.Teachers.Find(slcID);
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcID = ((ComboLoader)cmbGroups.SelectedItem).Value;
            slctdGroup = db.Groups.Find(slcID);
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            if(db.Courses.FirstOrDefault(c=>c.GroupID==slctdGroup.ID && c.LessonID==slctdLesson.ID &&
            c.TeacherID == slctdTeach.ID) != null)
            {
                MessageBox.Show("This course already exist.","Fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            Course newCourse = new Course
            {
                GroupID=slctdGroup.ID,
                LessonID=slctdLesson.ID,
                TeacherID=slctdTeach.ID
            };

            db.Courses.Add(newCourse);
            db.SaveChanges();
            MessageBox.Show("New course added succesfully.","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
            UpdateDataCourse();
        }

        public void UpdateDataCourse()
        {
            dgwCourse.DataSource = db.Courses.Select(c => new
            {
                c.ID,
                Group=c.Group.Name,
                Lesson=c.Lesson.Name,
                Teacher=c.Teacher.Firstname+" "+c.Teacher.Lastname
            }).ToList();

            dgwCourse.Columns[0].Visible = false;
        }
    }
}
