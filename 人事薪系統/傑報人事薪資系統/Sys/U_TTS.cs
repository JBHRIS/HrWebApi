using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
	public partial class U_TTS : JBControls.JBForm
	{
		public U_TTS()
		{
			InitializeComponent();
		}

		private void U_TTS_Load(object sender, EventArgs e)
		{
			fullDataCtrl1.bnAddEnable = false;
			fullDataCtrl1.bnEditEnable = false;
			fullDataCtrl1.bnDelEnable = false;
			fullDataCtrl1.bnExportEnable = false;

			fullDataCtrl1.DataAdapter = u_TTSTableAdapter;

			fullDataCtrl1.Init_Ctrls();
		}
	}
}