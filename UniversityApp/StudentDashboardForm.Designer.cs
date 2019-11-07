namespace UniversityApp
{
    partial class StudentDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbLessons = new System.Windows.Forms.ComboBox();
            this.dgwStudentGrades = new System.Windows.Forms.DataGridView();
            this.lblAvgText = new System.Windows.Forms.Label();
            this.btnGoToExam = new System.Windows.Forms.Button();
            this.lblFinalResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudentGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLessons
            // 
            this.cmbLessons.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLessons.FormattingEnabled = true;
            this.cmbLessons.Location = new System.Drawing.Point(30, 49);
            this.cmbLessons.Name = "cmbLessons";
            this.cmbLessons.Size = new System.Drawing.Size(220, 32);
            this.cmbLessons.TabIndex = 53;
            this.cmbLessons.SelectedIndexChanged += new System.EventHandler(this.cmbLessons_SelectedIndexChanged);
            // 
            // dgwStudentGrades
            // 
            this.dgwStudentGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwStudentGrades.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgwStudentGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStudentGrades.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgwStudentGrades.Location = new System.Drawing.Point(0, 247);
            this.dgwStudentGrades.Name = "dgwStudentGrades";
            this.dgwStudentGrades.Size = new System.Drawing.Size(806, 203);
            this.dgwStudentGrades.TabIndex = 58;
            // 
            // lblAvgText
            // 
            this.lblAvgText.AutoSize = true;
            this.lblAvgText.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgText.Location = new System.Drawing.Point(12, 148);
            this.lblAvgText.Name = "lblAvgText";
            this.lblAvgText.Size = new System.Drawing.Size(97, 34);
            this.lblAvgText.TabIndex = 60;
            this.lblAvgText.Text = "label1";
            // 
            // btnGoToExam
            // 
            this.btnGoToExam.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToExam.Location = new System.Drawing.Point(363, 49);
            this.btnGoToExam.Name = "btnGoToExam";
            this.btnGoToExam.Size = new System.Drawing.Size(103, 32);
            this.btnGoToExam.TabIndex = 61;
            this.btnGoToExam.Text = "Exam";
            this.btnGoToExam.UseVisualStyleBackColor = true;
            this.btnGoToExam.Click += new System.EventHandler(this.btnGoToExam_Click);
            // 
            // lblFinalResult
            // 
            this.lblFinalResult.AutoSize = true;
            this.lblFinalResult.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalResult.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFinalResult.Location = new System.Drawing.Point(12, 199);
            this.lblFinalResult.Name = "lblFinalResult";
            this.lblFinalResult.Size = new System.Drawing.Size(97, 34);
            this.lblFinalResult.TabIndex = 62;
            this.lblFinalResult.Text = "label1";
            // 
            // StudentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 450);
            this.Controls.Add(this.lblFinalResult);
            this.Controls.Add(this.btnGoToExam);
            this.Controls.Add(this.lblAvgText);
            this.Controls.Add(this.dgwStudentGrades);
            this.Controls.Add(this.cmbLessons);
            this.Name = "StudentDashboardForm";
            this.Text = "StudentDashboardForm";
            this.Load += new System.EventHandler(this.StudentDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudentGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLessons;
        private System.Windows.Forms.DataGridView dgwStudentGrades;
        private System.Windows.Forms.Label lblAvgText;
        private System.Windows.Forms.Button btnGoToExam;
        private System.Windows.Forms.Label lblFinalResult;
    }
}