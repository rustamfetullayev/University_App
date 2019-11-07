namespace UniversityApp
{
    partial class TeacherDashboardForm
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
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.btnAddGrade = new System.Windows.Forms.Button();
            this.cmbLessons = new System.Windows.Forms.ComboBox();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgwStudentsGrades = new System.Windows.Forms.DataGridView();
            this.nmGrade = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudentsGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGroups
            // 
            this.cmbGroups.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(28, 58);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(220, 32);
            this.cmbGroups.TabIndex = 5;
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // btnAddGrade
            // 
            this.btnAddGrade.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGrade.Location = new System.Drawing.Point(28, 149);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new System.Drawing.Size(373, 69);
            this.btnAddGrade.TabIndex = 51;
            this.btnAddGrade.Text = "Add Grade";
            this.btnAddGrade.UseVisualStyleBackColor = true;
            this.btnAddGrade.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // cmbLessons
            // 
            this.cmbLessons.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLessons.FormattingEnabled = true;
            this.cmbLessons.Location = new System.Drawing.Point(295, 58);
            this.cmbLessons.Name = "cmbLessons";
            this.cmbLessons.Size = new System.Drawing.Size(220, 32);
            this.cmbLessons.TabIndex = 52;
            this.cmbLessons.SelectedIndexChanged += new System.EventHandler(this.cmbLessons_SelectedIndexChanged);
            // 
            // cmbStudents
            // 
            this.cmbStudents.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(562, 58);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(220, 32);
            this.cmbStudents.TabIndex = 53;
            this.cmbStudents.SelectedIndexChanged += new System.EventHandler(this.cmbStudents_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 54;
            this.label6.Text = "Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 55;
            this.label1.Text = "Lesson";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(558, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 56;
            this.label2.Text = "Student";
            // 
            // dgwStudentsGrades
            // 
            this.dgwStudentsGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwStudentsGrades.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgwStudentsGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStudentsGrades.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgwStudentsGrades.Location = new System.Drawing.Point(0, 270);
            this.dgwStudentsGrades.Name = "dgwStudentsGrades";
            this.dgwStudentsGrades.Size = new System.Drawing.Size(794, 236);
            this.dgwStudentsGrades.TabIndex = 57;
            // 
            // nmGrade
            // 
            this.nmGrade.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmGrade.Location = new System.Drawing.Point(562, 174);
            this.nmGrade.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmGrade.Name = "nmGrade";
            this.nmGrade.Size = new System.Drawing.Size(220, 44);
            this.nmGrade.TabIndex = 58;
            // 
            // TeacherDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 506);
            this.Controls.Add(this.nmGrade);
            this.Controls.Add(this.dgwStudentsGrades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.cmbLessons);
            this.Controls.Add(this.btnAddGrade);
            this.Controls.Add(this.cmbGroups);
            this.Name = "TeacherDashboardForm";
            this.Text = "TeacherDashboardForm";
            this.Load += new System.EventHandler(this.TeacherDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudentsGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.Button btnAddGrade;
        private System.Windows.Forms.ComboBox cmbLessons;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgwStudentsGrades;
        private System.Windows.Forms.NumericUpDown nmGrade;
    }
}