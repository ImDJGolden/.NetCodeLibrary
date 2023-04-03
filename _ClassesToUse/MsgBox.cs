using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMsgBoxClass
{
	internal class MsgBox
	{
		#region Functions
		public static void Empty(string msg, string title, MessageBoxButtons btn, MessageBoxIcon icon)
		{
			MessageBox.Show(msg, title, btn, icon);
		}


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

		public static void Question(string msg, string title, MessageBoxButtons btn)
		{
			MessageBox.Show(msg, title, btn, MessageBoxIcon.Question);
		}


		public static void Error(string msg) 
		{
			MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void Error(string msg, MessageBoxButtons btn)
		{
			MessageBox.Show(msg, "Error!", btn, MessageBoxIcon.Error);
		}


		public static void Warning(string msg) 
		{
			MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public static void Warning(string msg, MessageBoxButtons btn)
		{
			MessageBox.Show(msg, "Warning!", btn, MessageBoxIcon.Warning);
		}
		#endregion
	}
}
