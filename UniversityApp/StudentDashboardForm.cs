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
    public partial class StudentDashboardForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Lesson slctdLesson;

        Student currentStu { get; set; }

        public StudentDashboardForm(Student stu)
        {
            InitializeComponent();
            currentStu = stu;
        }

        private void StudentDashboardForm_Load(object sender, EventArgs e)
        {
            this.Text = currentStu.Firstname + " " + currentStu.Lastname;
            UpdateComboLesson();
            UpdateDataStuGrades();
            ShowUserFinalResult();
        }

        public void UpdateComboLesson()
        {
            List<ComboLoader> lessons = new List<ComboLoader>();

            foreach (var item in db.Courses.Where(c => c.GroupID == currentStu.GroupID).Select(c => c.Lesson).Distinct().ToList())
            {
                lessons.Add(new ComboLoader
                {
                    Value = item.ID,
                    Text = item.Name
                });
            }

            cmbLessons.DataSource = lessons;
        }

        public void UpdateDataStuGrades()
        {
            dgwStudentGrades.DataSource = db.Grades.Where(s => s.StudentID == currentStu.ID).Select(s => new
            {
                s.ID,
                Student=s.Student.Firstname+" "+s.Student.Lastname,
                Lesson=s.Lesson.Name,
                s.Point
            }).ToList();

            dgwStudentGrades.Columns[0].Visible = false;
        }

        private void cmbLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slctdID = ((ComboLoader)cmbLessons.SelectedItem).Value;
            slctdLesson = db.Lessons.Find(slctdID);
            ShowUserFinalResult();

            if (db.Grades.FirstOrDefault(g=>g.StudentID==currentStu.ID && g.LessonID == slctdLesson.ID) == null)
            {
                lblAvgText.Text = $"You are not graduated in {slctdLesson.Name} yet.";
                btnGoToExam.Visible = false;
                return;
            }

            btnGoToExam.Visible = true;
            double? avg = db.Grades.Where(g => g.StudentID == currentStu.ID && g.LessonID == slctdLesson.ID).Select(g=>g.Point).Average();
            
            lblAvgText.Text = $"Your current average in {slctdLesson.Name} is: {(int)(avg * 5)} point.";

        }

        private void btnGoToExam_Click(object sender, EventArgs e)
        {
            ExamForm exform = new ExamForm(currentStu,slctdLesson);
            exform.ShowDialog();
        }

        public void ShowUserFinalResult()
        {
            Evalution currentUserEval = db.Evalutions.FirstOrDefault(e => e.StudentID == currentStu.ID && e.LessonID == slctdLesson.ID);

            if (currentUserEval == null)
            {
                btnGoToExam.Enabled = true;
                lblFinalResult.Text=$"You not finish the exam from {slctdLesson.Name} yet.";
            }
            else
            {
                btnGoToExam.Enabled = false;
                if (currentUserEval.AfeterExamPoint < 17 || currentUserEval.AfeterExamPoint+currentUserEval.BeforeExamPoint<51)
                {
                    lblFinalResult.Text = $"Your current final result is {currentUserEval.BeforeExamPoint} + {currentUserEval.AfeterExamPoint} = {currentUserEval.BeforeExamPoint + currentUserEval.AfeterExamPoint}.(Fail)";
                }
                else
                {
                    lblFinalResult.Text = $"Your current final result is {currentUserEval.BeforeExamPoint} + {currentUserEval.AfeterExamPoint} = {currentUserEval.BeforeExamPoint + currentUserEval.AfeterExamPoint}.(Pass)";
                }
            }
        }
    }
}
