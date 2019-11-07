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
    public partial class AddQuestionForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Lesson slctdLesson;
        Question slctdQuestion;

        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void AddQuestionForm_Load(object sender, EventArgs e)
        {
            UpdateComboLesson();
            UpdateDataQuestions();
        }

        public void UpdateDataQuestions()
        {
            dgwQuestions.DataSource = db.Questions.Select(q => new
            {
                q.ID,
                Question=q.MainQuestion,
                Variant_A=q.Answer_A,
                Variant_B=q.Answer_B,
                Variant_C=q.Answer_C,
                Correct_variant=q.CorrrectAnswer,
                Lesson=q.Lesson.Name
            }).ToList();

            dgwQuestions.Columns[0].Visible = false;
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

        private void cmbLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slcId = ((ComboLoader)cmbLessons.SelectedItem).Value;
            slctdLesson = db.Lessons.Find(slcId);
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;
            string varA = txtA.Text;
            string varB = txtB.Text;
            string varC = txtC.Text;
            string corrVar = txtCorrectVar.Text;

            if(string.IsNullOrEmpty(question)|| string.IsNullOrEmpty(varA)||
                string.IsNullOrEmpty(varB)|| string.IsNullOrEmpty(varC)||
                string.IsNullOrEmpty(corrVar))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            if (db.Questions.FirstOrDefault(q => q.MainQuestion == question) != null)
            {
                MessageBox.Show("This question already exist.");
                return;
            }

            Question newQuestion = new Question
            {
                MainQuestion = question,
                Answer_A = varA,
                Answer_B = varB,
                Answer_C = varC,
                CorrrectAnswer = corrVar,
                LessonID = slctdLesson.ID
            };

            db.Questions.Add(newQuestion);
            db.SaveChanges();
            UpdateDataQuestions();
            MessageBox.Show("New question added succesfully.");
            ClearForm();
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

        private void dgwQuestions_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int slctdID = (int)dgwQuestions.Rows[e.RowIndex].Cells["ID"].Value;
            slctdQuestion = db.Questions.Find(slctdID);

            txtQuestion.Text = slctdQuestion.MainQuestion;
            txtA.Text = slctdQuestion.Answer_A;
            txtB.Text = slctdQuestion.Answer_B;
            txtC.Text = slctdQuestion.Answer_C;
            txtCorrectVar.Text = slctdQuestion.CorrrectAnswer;

            cmbLessons.Text = slctdQuestion.Lesson.Name;
        }

        private void btnDelQuestion_Click(object sender, EventArgs e)
        {
            if (slctdQuestion == null)
            {
                MessageBox.Show("Please select a question first.");
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to delete this question?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                db.Questions.Remove(slctdQuestion);
                db.SaveChanges();
                UpdateDataQuestions();
                MessageBox.Show("Question deleted succesfully.");
                ClearForm();
                slctdQuestion = null;
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (slctdQuestion == null)
            {
                MessageBox.Show("Please select a question first.");
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to edit this question?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtQuestion.Text) || string.IsNullOrEmpty(txtA.Text) ||
                string.IsNullOrEmpty(txtB.Text) || string.IsNullOrEmpty(txtC.Text) ||
                string.IsNullOrEmpty(txtCorrectVar.Text))
                {
                    MessageBox.Show("Please fill empty areas correctly.");
                    return;
                }

                slctdQuestion.MainQuestion = txtQuestion.Text;
                slctdQuestion.Answer_A = txtA.Text;
                slctdQuestion.Answer_B = txtB.Text;
                slctdQuestion.Answer_C = txtC.Text;
                slctdQuestion.CorrrectAnswer = txtCorrectVar.Text;
                slctdQuestion.LessonID = slctdLesson.ID;

                db.SaveChanges();
                UpdateDataQuestions();
                MessageBox.Show("Question edited succesfully.");
                ClearForm();
                slctdQuestion = null;
            }
        }
    }
}
