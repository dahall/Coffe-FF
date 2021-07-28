using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Milk
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void DoPowerCfg()
		{
			var powercfg = Process.Start(new ProcessStartInfo
			{
				CreateNoWindow = true,
				FileName = "powercfg.exe",
				Arguments = "-requests",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				// WindowStyle = ProcessWindowStyle.Hidden
			});
			powercfg.WaitForExit();

			var error = powercfg.StandardError.ReadToEnd();
			if (error.Length == 0)
			{
				textBox1.Text = powercfg.StandardOutput.ReadToEnd();
				textBox1.Select(textBox1.Text.Length, textBox1.Text.Length);
				toolStripStatusLabel1.Text = $"Last Updated: {DateTime.Now:T} - F5 to Refresh";
			}
			else
			{
				// has to be a messagebox or the user wont see it
				MessageBox.Show(error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Top = Screen.PrimaryScreen.Bounds.Height / 2 - 135;
			Left = Screen.PrimaryScreen.Bounds.Width / 2 + 180;

			DoPowerCfg();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5 && e.Modifiers == Keys.None)
			{
				DoPowerCfg();
			}
		}
	}
}