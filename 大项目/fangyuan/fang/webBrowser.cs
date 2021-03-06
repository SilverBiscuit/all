﻿using fang._2019;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fang
{
    public partial class webBrowser : Form
    {
        public static string cookie { get; set; }
        public string url;

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);



        public webBrowser(string URL)
        {
            InitializeComponent();
            this.url = URL;   //构造函数传参到成员变量
        }

        private void webBrowser_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;

            webBrowser1.Url = new Uri(this.url);
            
            timer1.Start();

          
        }


        #region 非常重要获取当前存在浏览器的cookie，可以登陆wbbbrowser更新cookie。
        /// <summary>
        /// 非常重要获取当前存在浏览器的cookie，可以登陆wbbbrowser更新cookie。
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetCookies(string url)
        {
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;


                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }
        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = GetCookies(this.url);
            cookie = textBox1.Text;
            //textBox1.Text = webBrowser1.Document.Cookie;
            //cookie = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement element2 = webBrowser1.Document.CreateElement("script"); //新建个script标签
            element2.SetAttribute("type", "text/javascript");
            element2.SetAttribute("text", textBox1.Text); //脚本内容
            webBrowser1.Document.Body.AppendChild(element2); //插入到webbrowser当前网页中
            webBrowser1.Document.InvokeScript("doFuck");//执行新插入script标签中的doFuck函数

            //this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  webBrowser1.Refresh();
        }
    }
}
