using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StudentForm().ShowDialog();
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GroupForm().ShowDialog();
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TeacherForm().ShowDialog();
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SubjectForm().ShowDialog();
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddCourseForm().ShowDialog();
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddQuestionForm().ShowDialog();
        }
    }
}
