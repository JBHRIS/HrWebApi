using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Sys
{
    public partial class FRMVersion : JBControls.JBForm
    {
        public FRMVersion()
        {
            InitializeComponent();
        }

        private void FRMVersion_Load(object sender, EventArgs e)
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                versionLabel.Text = "ver " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

            string txtPath = Environment.CurrentDirectory + @"\Version.txt";

            if (!File.Exists(txtPath))
                throw new FileNotFoundException("ReadTxtContent()：txtPath 參數，檔案不存在");

            using (FileStream fs = new FileStream(txtPath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
            {
                string LineContent = string.Empty;
                string Data = string.Empty;
                
                while ((LineContent = reader.ReadLine()) != null)
                {
                    string[] ColData = LineContent.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
                    txtContent.Text += LineContent + Environment.NewLine;
                }
            }

        }
    }
}
