using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBModule.Message.UI
{
    public partial class HtmlViewer : Form
    {
        public HtmlViewer()
        {
            InitializeComponent();
        }
        public string Content = "";
        private void HtmlViewer_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = Content;
        }
    }
}
