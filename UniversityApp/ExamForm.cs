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
    public partial class ExamForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Student currentStu { get; set; }
        Lesson currentLesson { get; set; }

        public ExamForm(Student loggedStu,Lesson enteredLesson)
        {
            InitializeComponent();
            currentStu = loggedStu;
            currentLesson = enteredLesson;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            LoadExamForm();
        }

        public void LoadExamForm()
        {
            int y = -98;
            int pnlNum = 0;
            foreach (var ques in db.Questions.Where(q=>q.LessonID==currentLesson.ID).ToList())
            {
                y += 110;
                pnlNum++;

                Panel newPanel = new Panel();
                newPanel.Location = new Point(12, y);
                newPanel.Name = $"panel{pnlNum}";
                newPanel.Size = new Size(784, 103);
                newPanel.TabIndex = 0;
                newPanel.BorderStyle = BorderStyle.FixedSingle;

                this.Controls.Add(newPanel);

                Label newLabel = new Label();
                newLabel.Text = ques.MainQuestion;
                newLabel.Size = new Size(784, 40);
                newLabel.Location = new Point(10, 10);
                newLabel.Font = new Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newPanel.Controls.Add(newLabel);
                //
                //radioButtonA
                //
                RadioButton rb_A = new RadioButton();
                rb_A.AutoSize = true;
                rb_A.Location = new System.Drawing.Point(28, 65);
                rb_A.Name = "radioButton1";
                rb_A.Size = new System.Drawing.Size(85, 17);
                rb_A.TabIndex = 1;
                rb_A.TabStop = true;
                rb_A.Text = ques.Answer_A;
                rb_A.UseVisualStyleBackColor = true;
                rb_A.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newPanel.Controls.Add(rb_A);
                // 
                // radioButtonB
                // 
                RadioButton rb_B = new RadioButton();
                rb_B.AutoSize = true;
                rb_B.Location = new System.Drawing.Point(214, 65);
                rb_B.Name = "radioButton2";
                rb_B.Size = new System.Drawing.Size(85, 17);
                rb_B.TabIndex = 2;
                rb_B.TabStop = true;
                rb_B.Text = ques.Answer_B;
                rb_B.UseVisualStyleBackColor = true;
                rb_B.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newPanel.Controls.Add(rb_B);
                // 
                // radioButtonC
                // 
                RadioButton rb_C = new RadioButton();
                rb_C.AutoSize = true;
                rb_C.Location = new System.Drawing.Point(384, 65);
                rb_C.Name = "radioButton3";
                rb_C.Size = new System.Drawing.Size(85, 17);
                rb_C.TabIndex = 3;
                rb_C.TabStop = true;
                rb_C.Text = ques.Answer_C;
                rb_C.UseVisualStyleBackColor = true;
                rb_C.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newPanel.Controls.Add(rb_C);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int sumPoint = 0;
            foreach (Control cPnl in this.Controls)
            {
                if(cPnl is Panel)
                {
                    foreach (Control cLbl in ((Panel)cPnl).Controls)
                    {
                        if(cLbl is Label)
                        {
                            Question ques = db.Questions.FirstOrDefault(q => q.MainQuestion == ((Label)cLbl).Text);
                            foreach (Control CRb in ((Panel)cPnl).Controls)
                            {
                                if(CRb is RadioButton)
                                {
                                    if (((RadioButton)CRb).Checked && ques.CorrrectAnswer == CRb.Text)
                                    {
                                        sumPoint += 10;
                                    }
                                    else
                                    {
                                        sumPoint += 0;
                                    }
                                }
                            }
                        }
                    }
                }
                
            }

            double? avg = db.Grades.Where(g => g.StudentID == currentStu.ID && g.LessonID == currentLesson.ID).Select(g => g.Point).Average();


            Evalution newEval = new Evalution
            {
                StudentID = currentStu.ID,
                LessonID = currentLesson.ID,
                AfeterExamPoint = sumPoint,
                BeforeExamPoint = (int)(avg * 5)
            };

            db.Evalutions.Add(newEval);
            db.SaveChanges();
            MessageBox.Show($"Your final exam point is {sumPoint}");
            this.Close();
        }
    }
}
