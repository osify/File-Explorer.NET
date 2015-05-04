using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using osi_explorer_searcher.core.util;
using System.Management;

namespace osi_explorer_searcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OsifyUtilities util = new OsifyUtilities();
            this.btnMainApp_Click(sender, e);
            
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp frm = new frmHelp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMainApp_Click(object sender, EventArgs e)
        {
            frmManage frm = new frmManage();
            frm.MdiParent = this;
            frm.Show();
        }
        
    }
}
