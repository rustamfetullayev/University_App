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
    public partial class GroupForm : Form
    {
        UniversityDataEntities db = new UniversityDataEntities();
        Group slctdGroup;

        public GroupForm()
        {
            InitializeComponent();
        }

        private void btnEditStu_Click(object sender, EventArgs e)
        {
            string gname = txtGname.Text;

            if (string.IsNullOrEmpty(gname))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            slctdGroup.Name = gname;
            db.SaveChanges();
            UpdateDataGroups();
            txtGname.Text = "";
            slctdGroup = null;
        }

        private void btnAddStu_Click(object sender, EventArgs e)
        {
            string gname = txtGname.Text;

            if (string.IsNullOrEmpty(gname))
            {
                MessageBox.Show("Please fill empty areas correctly.");
                return;
            }

            if (db.Groups.FirstOrDefault(g => g.Name.ToLower() == gname.ToLower()) != null)
            {
                MessageBox.Show("This group name already exist.");
                return;
            }

            Group newGroup = new Group
            {
                Name = gname
            };

            db.Groups.Add(newGroup);
            db.SaveChanges();
            UpdateDataGroups();
            MessageBox.Show($"New group {gname} created succesfully.");
            txtGname.Text = "";
            slctdGroup = null;
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            UpdateDataGroups();
        }

        public void UpdateDataGroups()
        {
            dgwGroups.DataSource = db.Groups.Select(g => new
            {
                g.ID,
                g.Name
            }).ToList();
            dgwGroups.Columns[0].Visible = false;
        }

        private void dgwGroups_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int slctdID = (int)dgwGroups.Rows[e.RowIndex].Cells["ID"].Value;

            slctdGroup = db.Groups.Find(slctdID);

            txtGname.Text = slctdGroup.Name;
        }
    }
}
