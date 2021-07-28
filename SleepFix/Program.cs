using System;
using System.Threading;
using System.Windows.Forms;

namespace Coffee_FF
{
	internal static class Program
	{
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		private static void Main()
		{
			using var mutex = new Mutex(true, "Coffee_SC", out var createdNew);
			if (createdNew)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			else
			{
				MessageBox.Show("Coffee is already running, check the notification area.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}