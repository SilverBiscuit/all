﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using helper;

namespace 主程序
{
    public partial class 淘宝阿里商品 : Form
    {
        public 淘宝阿里商品()
        {
            InitializeComponent();
        }
        public static string COOKIE = "";
        #region 淘宝
        public void taobao(string url)
        {

            try
            {

                string html = method.GetUrlWithCookie(url, COOKIE, "gbk");
                Match company = Regex.Match(html, @"请进入([\s\S]*?)的([\s\S]*?)实力");
                Match name = Regex.Match(html, @"<title>([\s\S]*?)-");

                MatchCollection main = Regex.Matches(html, @"<dl class=""J_Prop([\s\S]*?)</dl>");
                ArrayList xxs = new ArrayList();
 
                if (main.Count > 1)
                {
                    string zhu = main[0].Groups[1].Value;
                    string zhu1 = main[1].Groups[1].Value;

                    MatchCollection xuanxiangs1 = Regex.Matches(zhu, @"<span>([\s\S]*?)</span>");
                    MatchCollection xuanxiangs2 = Regex.Matches(zhu1, @"<span>([\s\S]*?)</span>");
                    foreach (Match match1 in xuanxiangs1)
                    {
                        foreach (Match match2 in xuanxiangs2)
                        {
                            xxs.Add(match1.Groups[1].Value+","+ match2.Groups[1].Value);
                        }
                    }

                }


                




                MatchCollection prices = Regex.Matches(html, @"\{""price"":""([\s\S]*?)""");

                MatchCollection skus = Regex.Matches(html, @"""skuId"":""([\s\S]*?)""");



                for (int i = 0; i < skus.Count; i++)
                {
                    try
                    {


                        string[] text = xxs[i].ToString().Split(new string[] { "," }, StringSplitOptions.None);

                        ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count + 1).ToString()); //使用Listview展示数据   
                        lv1.SubItems.Add(Regex.Replace(company.Groups[2].Value, "<[^>]+>", "").Trim());
                        lv1.SubItems.Add(name.Groups[1].Value);
                        lv1.SubItems.Add(skus[i].Groups[1].Value);
                     
                        lv1.SubItems.Add(text[0]);
                        lv1.SubItems.Add(text[1]);

                        lv1.SubItems.Add(prices[i].Groups[1].Value);
                    }
                    catch
                    {

                        continue;
                    }
                }





            }


            catch (System.Exception ex)
            {

              MessageBox.Show( ex.ToString());
            }

        }

        #endregion

        #region 天猫
        public void tmall(string url)
        {

            try
            {

                string html = method.GetUrlWithCookie(url, COOKIE,"gbk");
                Match company = Regex.Match(html, @"<strong>([\s\S]*?)</strong>");
                Match name = Regex.Match(html, @"<title>([\s\S]*?)-");

                Match main = Regex.Match(html, @"skuList([\s\S]*?)salesProp");
                string zhu = main.Groups[1].Value;


                MatchCollection xuanxiangs = Regex.Matches(zhu, @"""names"":""([\s\S]*?)""");
                MatchCollection prices = Regex.Matches(zhu, @"""price"":""([\s\S]*?)""");

                MatchCollection skus = Regex.Matches(zhu, @"""skuId"":""([\s\S]*?)""");



                for (int i = 0; i < xuanxiangs.Count; i++)
                {
                    try
                    {
                        string[] text = xuanxiangs[i].Groups[1].Value.Split(new string[] { " " }, StringSplitOptions.None);



                    ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count + 1).ToString()); //使用Listview展示数据   
                        lv1.SubItems.Add(company.Groups[1].Value);
                        lv1.SubItems.Add(name.Groups[1].Value);
                    lv1.SubItems.Add(skus[i].Groups[1].Value);
                    lv1.SubItems.Add(text[0]);
                    lv1.SubItems.Add(text[1]);
                    
                    lv1.SubItems.Add(prices[i].Groups[1].Value);
                    }
                    catch
                    {

                        continue;
                    }
                }





            }


            catch (System.Exception ex)
            {

                ex.ToString();
            }

        }

        #endregion

        #region 阿里巴巴
        public void alibab(string url)
        {

            try
            {

                string html = method.gethtml(url, COOKIE);
                Match company = Regex.Match(html, @"company-name"">([\s\S]*?)<");
                Match name = Regex.Match(html, @"<h1 class=""d-title"">([\s\S]*?)</h1>");

                Match  main = Regex.Match(html, @"skuMap([\s\S]*?)\{([\s\S]*?)end");
                string zhu = "}," + main.Groups[2].Value;
              
              
                MatchCollection xuanxiangs = Regex.Matches(zhu, @"\},""([\s\S]*?)""");
                MatchCollection prices = Regex.Matches(zhu,@"""price"":""([\s\S]*?)""");
                
                MatchCollection skus = Regex.Matches(zhu, @"""skuId"":([\s\S]*?)\}");
              

              
                for (int i = 0; i < xuanxiangs.Count; i++)
                {
                    try
                    {

                        string[] text = xuanxiangs[i].Groups[1].Value.Split(new string[] { "&gt;" }, StringSplitOptions.None);



                        ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count + 1).ToString()); //使用Listview展示数据   
                        lv1.SubItems.Add(company.Groups[1].Value);
                        lv1.SubItems.Add(name.Groups[1].Value);
                        lv1.SubItems.Add(skus[i].Groups[1].Value);
                        lv1.SubItems.Add(text[0]);
                        lv1.SubItems.Add(text[1]);
                        
                        lv1.SubItems.Add(prices[i].Groups[1].Value);
                       
                    }
                    catch
                    {

                        continue;
                    }

                }





            }


            catch (System.Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        #endregion
        private void 淘宝阿里商品_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            #region 通用检测

            string html = method.GetUrl("http://www.acaiji.com/index/index/vip.html", "utf-8");

            if (html.Contains(@"\u6dd8\u5b9d\u963f\u91ccSKU"))
            {
                COOKIE = helper.Form1.cookie;
                if (radioButton1.Checked == true)
                {
                    tmall(textBox1.Text);
                }
                else if (radioButton2.Checked == true)
                {
                    alibab(textBox2.Text);

                }
                else if (radioButton3.Checked == true)
                {
                    taobao(textBox3.Text);

                }

            }

            else
            {
                MessageBox.Show("验证失败");
                return;
            }


            #endregion
          
           
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            method.DataTableToExcel(method.listViewToDataTable(this.listView1), "Sheet1", true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            listView1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helper.Form1 fm1 = new helper.Form1();
            fm1.Show();
        }
    }
}
