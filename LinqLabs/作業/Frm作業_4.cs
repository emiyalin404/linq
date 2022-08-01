using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_4 : Form
    {


        public Frm作業_4()
        {
            InitializeComponent();
        }
        public void Theclear()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView2.Columns.Clear();
            this.treeView1.Nodes.Clear();


        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
            Theclear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from p in files
                    group p by p.Length <= 100000 ? "大" : "小";
            this.dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {

                TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString());
                foreach (var item in group)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Theclear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = (from p in files
                     group p by p.CreationTime.Year into g
                     select new { Year = g.Key, MyCount = g.Count(), Info = g }).OrderByDescending(p => p.Year);
            List<int> list = new List<int>();

            this.dataGridView1.DataSource = q.ToList();
            treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                string s = $"{group.Year}({group.MyCount})";
                TreeNode x = this.treeView1.Nodes.Add(group.Year.ToString());
                foreach (var item in group.Info)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
            //foreach(var group in q)
            //{
            //    string s = $"{group.}"
            //}


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Theclear();
            this.productsTableAdapter1.Fill(nwDataSet1.Products);
            dataGridView1.DataSource = nwDataSet1.Products;

            //var q = from p in nwDataSet1.Products
            //        group p by p.UnitPrice ? "大" : "小";
            //this.dataGridView1.DataSource = q.ToList();
            //foreach (var group in q)
            //{

            //    TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString());
            //    foreach (var item in group)
            //    {
            //        x.Nodes.Add(item.ToString());
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var q = dbcontext.Order_Details.Select(n => n.UnitPrice * n.Quantity * (1 - (int)n.Discount)).Sum();


            var q = from n in dbcontext.Order_Details
                    group n by n.Order.EmployeeID into g
                    select new { g.Key, safd = g.Select(n => n.UnitPrice * n.Quantity * (1 - (int)n.Discount)).Sum() };
            this.dataGridView1.DataSource = q.OrderBy(n => n.safd).Take(5).ToList();
        }

        NorthwindEntities1 dbcontext = new NorthwindEntities1();
        private void button2_Click(object sender, EventArgs e)
        {


            var q = dbcontext.Order_Details.Select(n => n.UnitPrice * n.Quantity * (1 - (int)n.Discount)).Sum();
            MessageBox.Show($"{q:C2}");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = from p in dbcontext.Products
                    orderby p.UnitPrice descending
                    select new { p.ProductName, p.UnitPrice, p.CategoryID };
            this.dataGridView1.DataSource = q.Take(5).ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from p in dbcontext.Order_Details
                    where p.UnitPrice > 250
                    select p;
            this.dataGridView1.DataSource = q.ToList();


        }
    }
}
