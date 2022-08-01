using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqLabs.作業;

namespace MyHomeWork
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Frm作業_1 f = new Frm作業_1();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            Frm作業_2 f = new Frm作業_2();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            Frm作業_3 f = new Frm作業_3();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void 水平排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 關閉目前視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();

        }

        private void 關閉所有視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            //login l = new login();
            //l.ShowDialog();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            Frm作業_4 f = new Frm作業_4();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
