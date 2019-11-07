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
    public partial class TeacherDashboardForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();

        Teacher currentTeacher { get; set; }

        Group slctdGroup;
        Lesson slctdLesson;
        Student slctdStu;

        public TeacherDashboardForm(Teacher teach)
        {
            InitializeComponent();
            currentTeacher = teach;
        }

        private void TeacherDashboardForm_Load(object sender, EventArgs e)
        {
            this.Text = currentTeacher.Firstname + " " + currentTeacher.Lastname;
            UpdateComboGroup();
            UpdateDataGrades();
        }

        public void UpdateComboStudents()
        {
            List<ComboLoader> students = new List<ComboLoader>();

            foreach (var item in db.Students.Where(s=>s.GroupID==slctdGroup.ID).ToList())
            {
                students.Add(new ComboLoader
                {
                    Value = item.ID,
                    Text = item.Firstname+" "+item.Lastname
                });
            }

            cmbStudents.DataSource = students;
        }

        public void UpdateComboGroup()
        {
            List<ComboLoader> groups = new List<ComboLoader>();

            foreach (var item in db.Courses.Where(c=>c.TeacherID==currentTeacher.ID).Select(c => c.Group).Distinct().ToList())
            {
                groups.Add(new ComboLoader
                {
                    Value=item.ID,
                    Text=item.Name
                });
            }

            cmbGroups.DataSource = groups;
        }

        public void UpdateComboLessons()
        {
            List<ComboLoader> lessons = new List<ComboLoader>();

            foreach (var item in db.Courses.Where(c => c.TeacherID == currentTeacher.ID && c.GroupID==slctdGroup.ID).Select(c => c.Lesson).Distinct().ToList())
            {
                lessons.Add(new ComboLoader
                {
                    Value = item.ID,
                    Text = item.Name
                });
            }

            cmbLessons.DataSource = lessons;
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcID = ((ComboLoader)cmbGroups.SelectedItem).Value;
            slctdGroup = db.Groups.Find(slcID);

            UpdateComboStudents();
            UpdateComboLessons();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            Grade newGrade = new Grade
            {
                StudentID = slctdStu.ID,
                TeacherID=currentTeacher.ID,
                LessonID = slctdLesson.ID,
                Point = (int)nmGrade.Value
            };

            db.Grades.Add(newGrade);
            db.SaveChanges();
            UpdateDataGrades();
            nmGrade.Value = 0;
        }

        private void cmbLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcID = ((ComboLoader)cmbLessons.SelectedItem).Value;
            slctdLesson = db.Lessons.Find(slcID);
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcID = ((ComboLoader)cmbStudents.SelectedItem).Value;
            slctdStu = db.Students.Find(slcID);
        }

        public void UpdateDataGrades()
        {
            dgwStudentsGrades.DataSource = db.Grades.Where(g=>g.TeacherID==currentTeacher.ID).Select(g => new
            {
                g.Lesson.Name,
                Student = g.Student.Firstname + " " + g.Student.Lastname,
                g.Point
            }).ToList();
        }
    }
}
