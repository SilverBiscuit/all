﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using helper;

namespace 专利查询
{
    public partial class 专利查询 : Form
    {
        public 专利查询()
        {
            InitializeComponent();
        }
        public static string COOKIE = "";
        bool zanting = true;
        #region 主程序
        public void run()
        {

            try
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("请导入文件查询");
                    return;
                }


                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "")
                        continue;
                    string html = method.gethtml("https://tsdr.uspto.gov/statusview/sn" + dataGridView1.Rows[i].Cells[0].Value, COOKIE);
                    label2.Text = "正在查询" + dataGridView1.Rows[i].Cells[0].Value + "......";
                    Match a1 = Regex.Match(html, @"Generated on:</div>([\s\S]*?)</div>");
                    Match a2 = Regex.Match(html, @"Mark:</div>([\s\S]*?)</div>");
                    Match a3 = Regex.Match(html, @"US Serial Number:</div>([\s\S]*?)</div>");
                    Match a4 = Regex.Match(html, @"Application Filing Date:</div>([\s\S]*?)</div>");
                    Match a5 = Regex.Match(html, @"Filed as TEAS Plus:</div>([\s\S]*?)</div>");
                    Match a6 = Regex.Match(html, @"Currently TEAS Plus:</div>([\s\S]*?)</div>");
                    Match a7 = Regex.Match(html, @"Register:</div>([\s\S]*?)</div>");
                    Match a8 = Regex.Match(html, @"Mark Type:</div>([\s\S]*?)</div>");
                    Match a9 = Regex.Match(html, @"TM5 Common Status Descriptor:</div>([\s\S]*?)</div>");
                    Match a10 = Regex.Match(html, @"Status:</div>([\s\S]*?)</div>");
                    Match a11 = Regex.Match(html, @"Status Date:</div>([\s\S]*?)</div>");
                    Match a12 = Regex.Match(html, @"Mark Literal Elements:</div>([\s\S]*?)</div>");
                    Match a13 = Regex.Match(html, @"Standard Character Claim:</div>([\s\S]*?)</div>");
                    Match a14 = Regex.Match(html, @"Mark Drawing Type:</div>([\s\S]*?)</div>");
                    Match a15 = Regex.Match(html, @"Description of Mark:</div>([\s\S]*?)</div>");
                    Match a16 = Regex.Match(html, @"Note:</strong>([\s\S]*?)</div>");
                    Match a17 = Regex.Match(html, @"For:</div>([\s\S]*?)</div>");
                    Match a18 = Regex.Match(html, @"International Class\(es\):</div>([\s\S]*?)</div>");
                    Match a19 = Regex.Match(html, @"U.S Class\(es\):</div>([\s\S]*?)</div>");
                    Match a20 = Regex.Match(html, @"Class Status:</div>([\s\S]*?)</div>");
                    Match a21 = Regex.Match(html, @"Basis:</div>([\s\S]*?)</div>");
                    Match a22 = Regex.Match(html, @"First Use:</div>([\s\S]*?)</div>");
                    Match a23 = Regex.Match(html, @"Use in Commerce:</div>([\s\S]*?)</div>");
                    Match a24 = Regex.Match(html, @"Filed Use:</div>([\s\S]*?)</div>");
                    Match a25 = Regex.Match(html, @"Currently Use:</div>([\s\S]*?)</div>");
                    Match a26 = Regex.Match(html, @"Filed ITU:</div>([\s\S]*?)</div>");
                    Match a27 = Regex.Match(html, @"Currently ITU:</div>([\s\S]*?)</div>");
                    Match a28 = Regex.Match(html, @"Filed 44D:</div>([\s\S]*?)</div>");
                    Match a29 = Regex.Match(html, @"Currently 44E:</div>([\s\S]*?)</div>");
                    Match a291 = Regex.Match(html, @"Filed 44E:</div>([\s\S]*?)</div>");
                    Match a30 = Regex.Match(html, @"Currently 66A:</div>([\s\S]*?)</div>");
                    Match a31 = Regex.Match(html, @"Filed 66A:</div>([\s\S]*?)</div>");
                    Match a32 = Regex.Match(html, @"Currently No Basis:</div>([\s\S]*?)</div>");
                    Match a33 = Regex.Match(html, @"Filed No Basis:</div>([\s\S]*?)</div>");
                    Match a34 = Regex.Match(html, @"Owner Name:</div>([\s\S]*?)</div>");
                    Match a35 = Regex.Match(html, @"Owner Address:</div>([\s\S]*?)</div>");
                    Match a36 = Regex.Match(html, @"Legal Entity Type:</div>([\s\S]*?)</div>");
                    Match a37 = Regex.Match(html, @"State or Country Where Organized:</div>([\s\S]*?)</div>");
                    Match a38 = Regex.Match(html, @"Correspondent Name/Address:</div>([\s\S]*?)</div>");
                    Match a39 = Regex.Match(html, @"Phone:</div>([\s\S]*?)</div>");
                    MatchCollection a40 = Regex.Matches(html, @"<td valign=""top"">([\s\S]*?)</td>");
                    Match a41 = Regex.Match(html, @"Current Location:</div>([\s\S]*?)</div>");
                    Match a42 = Regex.Match(html, @"Date in Location:</div>([\s\S]*?)</div>");








                    if(a40.Count>2)
                    {




                        ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count + 1).ToString()); //使用Listview展示数据    
                        lv1.SubItems.Add(Regex.Replace(a1.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a2.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a3.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a4.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a5.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a6.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a7.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a8.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a9.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a10.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a11.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a12.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a13.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a14.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a15.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a16.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a17.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a18.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a19.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a20.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a21.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a22.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a23.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a24.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a25.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a26.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a27.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a28.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a29.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a291.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a30.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a31.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a32.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a33.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a34.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a35.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a36.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a37.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a38.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a39.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a40[0].Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a40[1].Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a40[2].Groups[1].Value, "<[^>]+>", "").Trim());

                        lv1.SubItems.Add(Regex.Replace(a41.Groups[1].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(Regex.Replace(a42.Groups[1].Value, "<[^>]+>", "").Trim());


                        while (this.zanting == false)
                        {
                            Application.DoEvents();//如果loader是false表明正在加载,,则Application.DoEvents()意思就是处理其他消息。阻止当前的队列继续执行。
                        }


                        if (listView1.Items.Count > 2)
                        {
                            listView1.EnsureVisible(listView1.Items.Count - 1);  //滚动到指定位置
                        }
                        Thread.Sleep(500);




                    }


                }
                label2.Text = "查询结束"+ "......";
            }



            catch (System.Exception ex)
            {

              MessageBox.Show( ex.ToString());
            }

        }

        #endregion
        private void 专利查询_Load(object sender, EventArgs e)
        {

        }

        OpenFileDialog Ofile = new OpenFileDialog();


        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            this.ds.Tables.Clear();
            this.Ofile.FileName = "";
            this.dataGridView1.DataSource = "";
            this.Ofile.ShowDialog();
            string fileName = this.Ofile.FileName;
            if (fileName != null && fileName != "")
            {
                string connectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + "; Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
                oleDbConnection.Open();
                DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]
                {
                    null,
                    null,
                    null,
                    "TABLE"
                });
                string str = oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
                string selectCommandText = "select * from [" + str + "]";
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, oleDbConnection);
                oleDbDataAdapter.Fill(this.ds, "temp");
                oleDbConnection.Close();
                this.dataGridView1.DataSource = this.ds.Tables[0];

                textBox1.Text = this.Ofile.FileName;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            method.DataTableToExcel(method.listViewToDataTable(this.listView1), "Sheet1", true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zanting = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zanting = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region 通用验证

            bool value = false;
            string html = method.GetUrl("http://acaiji.com/success/ip.php", "utf-8");
            string localip = method.GetIP();
            MatchCollection ips = Regex.Matches(html, @"<td style='color:red;'>([\s\S]*?)</td>", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            foreach (Match ip in ips)
            {
                if (ip.Groups[1].Value.Trim() == "8.8.8.8")
                {
                    value = true;
                    break;
                }

            }
            if (value == true)
            {
                Thread thread = new Thread(new ThreadStart(run));
                Control.CheckForIllegalCrossThreadCalls = false;
                thread.Start();


            }
            else
            {
                MessageBox.Show("IP不符");

            }
            #endregion
           
        }
    }
}
