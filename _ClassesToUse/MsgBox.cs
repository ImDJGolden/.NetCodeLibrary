using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMsgBoxClass
{
	internal class MsgBox
	{
		public static void Success(string msg) 
		{
			MessageBox.Show(msg, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static void Info(string msg) 
		{
			MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void Question(string msg, string title) 
		{
			MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public static void Error(string msg) 
		{
			MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void Warning(string msg) 
		{
			MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
