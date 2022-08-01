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
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
        }
        public void Theclear()
        {
            this.dataGridView1.Columns.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Theclear();
            this.productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);


            var q = from p in awDataSet1.ProductPhoto
                        //where p.ModifiedDate.Subtract(dateTimePicker2()-dateTimePicker1())
                    where p.ModifiedDate >= dateTimePicker1.Value && p.ModifiedDate <= dateTimePicker2.Value
                    select p;
            dataGridView1.DataSource = q.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Theclear();
            this.productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
            dataGridView1.DataSource = (awDataSet1.ProductPhoto);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Theclear();
            this.productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);

            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year.ToString() == comboBox3.Text
                    select p;
            dataGridView1.DataSource = q.ToList();
        }
        void season(int M1, int M2)
        {

            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year/*.ToString()*/ == Convert.ToInt32(comboBox3.Text)
                    && p.ModifiedDate.Month >= M1 && p.ModifiedDate.Month <= M2
                    select p;

            dataGridView1.DataSource = q.ToList();
            label1.Text = "有" + q.ToList().Count() + "筆";
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            { season(1, 3); }
            if (comboBox2.SelectedIndex == 1)
            { season(4, 6); }
            if (comboBox2.SelectedIndex == 2)
            { season(7, 9); }
            if (comboBox2.SelectedIndex == 3)
            { season(10, 12); }
        }

        private void Frm作業_2_Load(object sender, EventArgs e)
        {
            Theclear();
            this.productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
            var q = from p in awDataSet1.ProductPhoto
                    orderby p.ModifiedDate.Year
                    select p.ModifiedDate.Year;

            List<int> list = new List<int>();
            foreach (var item in q.Distinct())

                comboBox3.Items.Add(item);
        }
    }
}
