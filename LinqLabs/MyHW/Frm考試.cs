﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs
{
    public partial class Frm考試 : Form
    {
        public Frm考試()
        {
            InitializeComponent();

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get;  set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get;  set; }
            public string Gender { get; set; }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績
           
            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |				
            // 數學不及格 ... 是誰 
            #endregion

        }
  
        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg

            //各科 sum, min, max, avg
        }
        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            // print 每一群是哪幾個 ? (每一群 sort by 分數 descending)
        }

        private void button35_Click(object sender, EventArgs e)
        {
            // 統計 :　所有隨機分數出現的次數/比率; sort ascending or descending
            // 63     7.00%
            // 100    6.00%
            // 78     6.00%
            // 89     5.00%
            // 83     5.00%
            // 61     4.00%
            // 64     4.00%
            // 91     4.00%
            // 79     4.00%
            // 84     3.00%
            // 62     3.00%
            // 73     3.00%
            // 74     3.00%
            // 75     3.00%
        }
        NorthwindEntities dbContext = new NorthwindEntities();
        private void button34_Click(object sender, EventArgs e)
        {
            var q = dbContext.Order_Details.AsEnumerable().Select(o => new { year = o.Order.OrderDate.Value.Year, total=o.UnitPrice*o.Quantity })
              .GroupBy(o => o.year).Select(o => new { year = o.Key, total=$"{o.Sum(s=>s.total):c2}"}).OrderBy(o=>o.total);
            listBox1.Items.Add("年度最低為: " + q.First().total);
            listBox1.Items.Add("年度最高為: " + q.Last().total);
            listBox1.Items.Add("=============================================");
            listBox1.Items.Add("哪一年銷售最好: " + q.First().year);
            listBox1.Items.Add("哪一年銷售最不好: " + q.Last().year);
            listBox1.Items.Add("=============================================");
            var q1 = dbContext.Order_Details.AsEnumerable().
                Select(o => new { month = o.Order.OrderDate.Value.Year + "年" + o.Order.OrderDate.Value.Month + "月", total = o.UnitPrice * o.Quantity })
                .GroupBy(o => o.month).Select(o => new { month = o.Key, total = $"{o.Sum(s => s.total):c2}" }).OrderBy(o => o.total);
            listBox1.Items.Add("那一個月最高: " + q1.First().month);
            listBox1.Items.Add("那一個月最低: " + q1.Last().month);
            //===========================================
            chart1.DataSource = null;
            chart1.DataSource = q.ToList();
            chart1.Series[0].XValueMember = "year";
            chart1.Series[0].YValueMembers = "total";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //===============================================================
            chart2.DataSource = null;
            chart2.DataSource = q1.ToList();
            chart2.Series[0].XValueMember = "month";
            chart2.Series[0].YValueMembers = "total";
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            // 年度最高銷售金額 年度最低銷售金額
            // 那一年總銷售最好 ? 那一年總銷售最不好 ?
            // 那一個月總銷售最好 ? 那一個月總銷售最不好 ?
            // 每年 總銷售分析 圖
            // 每月 總銷售分析 圖
        }
    }
}
