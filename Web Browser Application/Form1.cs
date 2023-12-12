using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Web_Browser_Application;
using EO.WebBrowser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Web_Browser_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webView2 = new WebView();

            //webView1.JSInitCode = string.Format("window.setTimeout(function() {{ {0} }}, 5);", Properties.Resources.jquery);

            // Load a URL
            webView2.LoadUrl("https://example.com");

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;
            if (!string.IsNullOrEmpty(url))
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                webView2.LoadUrl((url));
            }
        }
    }
}
