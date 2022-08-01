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
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_101", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_101", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_101", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
                                            new Student{ Name = "ggg", Class = "CS_101", Chi = 70, Eng = 90, Math = 75, Gender = "Female" },
                                            new Student{ Name = "hhh", Class = "CS_101", Chi = 80, Eng = 60, Math = 90, Gender = "Female" },
                                          };
        }

        private void button33_Click(object sender, EventArgs e)
        {
            var q = from p in students_scores
                   select  p.Math;
            var q1 = from n in q
                    group n by TheMath(n) into g
                    select new { TheMath = g.Key, MyCount = g.Count(), MyAvg = g.Average() };
            this.dataGridView1.DataSource = q1.ToList();
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
        }
        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }
       
    
    private void button36_Click(object sender, EventArgs e)
        {


            var q = from p in students_scores
                    select p;
            this.dataGridView1.DataSource = q.ToList();
            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].XValueMember = "Name";
            this.chart1.Series[0].YValueMembers = "Chi";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chart1.Series[1].XValueMember = "Name";
            this.chart1.Series[1].YValueMembers = "Eng";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chart1.Series[2].XValueMember = "Name";
            this.chart1.Series[2].YValueMembers = "Math";
            this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }
        string TheMath(int n)
        {
            string i;
            if (n <= 100 && n >= 90)            
                i = "優良";            
            else if (n < 90 && n >= 70)
             i = "佳"; 
            else                         
                    i = "待加強";
            
            return i;

        }

        private void Frm作業_3_Load(object sender, EventArgs e)
        {
           
        }

        private void button37_Click(object sender, EventArgs e)
        {
                                 
        }
    }
}
