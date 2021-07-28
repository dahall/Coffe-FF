using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Sugar
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
#pragma warning disable CA1416 // Validate platform compatibility
			// The path to the key where Windows looks for startup applications
			using RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			// Add the value in the registry so that the application runs at startup
			// Check to see the current state (running at startup or not)
			if (rkApp.GetValue("Coffee") is null)
			{
				// The value doesn't exist, the application is not set to run at startup
				rkApp.SetValue("Coffee", Application.StartupPath + @"\Coffee_FF.exe /hide");
				label1.Text = "Coffee WILL start with windows";
			}
			else
			{
				// The value exists, the application is set to run at startup
				rkApp.DeleteValue("Coffee");
				label1.Text = "Coffee will NOT start with windows";
			}
#pragma warning restore CA1416 // Validate platform compatibility
		}
	}
}