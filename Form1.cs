using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;

namespace YARP
{
    public partial class Form1 : Form
    {
        private TextBox urlBar;
        private WebView2 webView;

        public Form1()
        {
            InitializeComponent();

            this.Text = "YARP";
            this.Width = 1000;
            this.Height = 700;

            urlBar = new TextBox();
            urlBar.Dock = DockStyle.Top;
            urlBar.KeyDown += UrlBar_KeyDown;
            this.Controls.Add(urlBar);

            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);

            webView.Source = new Uri("https://www.google.com");
        }

        private void UrlBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = urlBar.Text.Trim();
                if (!url.StartsWith("http"))
                    url = "https://" + url;

                webView.Source = new Uri(url);
            }
        }
    }
}