using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vanara;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;
using MessageBox = System.Windows.Forms.MessageBox;

#pragma warning disable IDE1006 // Naming Styles

namespace Coffee_FF
{
	public partial class MainForm : Form
	{
		private const string DownloadReason = "Download";
		private const string ProcessReason = "Process";
		private const string UploadReason = "Upload";

#pragma warning disable CA1416 // Validate platform compatibility
		private static readonly Lazy<bool> IsAdmin = new(() => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator));
#pragma warning restore CA1416 // Validate platform compatibility

		private readonly CancellationTokenSource cts = new();
		private readonly List<NetworkInterface> Interfaces = new();
		private readonly Lazy<string> MilkPath = new(() => Path.Combine(Properties.Settings.Default.RelativeMilkPath, "Milk.exe"));
		private readonly SortedSet<uint> ListDeniedAccessFiles = new();
		private readonly Lazy<string> SugarPath = new(() => Path.Combine(Properties.Settings.Default.RelativeSugarPath, "Sugar.exe"));

		private DateTime ClearStopDelay = DateTime.Now;
		private DateTime ClearStopDelay2 = DateTime.Now;
		private DateTime compareDate = DateTime.Now;
		private SafePowerRequestObject DownloadPowerRequest, ProcessPowerRequest, UploadPowerRequest;
		private bool DownloadPrevented;
		private bool firsttick = true;
		private long lastBtyesReceived;
		private long lastBytesSend;
		private bool menuexit;
		private bool ProcessPrevented;
		private bool ProcTabVisited = false;
		private bool UploadPrevented;

		public MainForm()
		{
			InitializeComponent();

			// Make default menu item bold
			showToolStripMenuItem.Font = new System.Drawing.Font(showToolStripMenuItem.Font, System.Drawing.FontStyle.Bold);

			if (!IsAdmin.Value)
			{
				sleepBlockBtn.SetElevationRequiredState(true); //Important
				runWithWinBtn.SetElevationRequiredState(true);
			}
		}

		public void SaveState()
		{
			try
			{
				Properties.Settings.Default.NetworkAdaptor = nicComboBox.SelectedItem.ToString();
				Properties.Settings.Default.DownloadThreshold = (int)downloadUpDn.Value;
				Properties.Settings.Default.UploadThreshold = (int)uploadUpDn.Value;
				Properties.Settings.Default.DelayRemoveSleep = (int)removeDelayUpDn.Value;
				Properties.Settings.Default.PressKeyInMinutes = (int)keypressIntervalUpDn.Value;  // Send virtual key press every X minutes
				Properties.Settings.Default.EnDisKeyPress = keypressEnableCheckBox.Checked;
				Properties.Settings.Default.DisDisplayStandby = preventDisplayStandbyCheck.Checked;
			}
			catch { }
			finally
			{
				Properties.Settings.Default.Save();
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (!menuexit && e.CloseReason != CloseReason.WindowsShutDown) // If system shuting down will close and save
			{
				Hide();
				WindowState = FormWindowState.Minimized;

				trayIcon.Visible = true;  //dont actualy exit the program
				trayIcon.BalloonTipIcon = ToolTipIcon.Info;
				trayIcon.BalloonTipTitle = "Attention";
				trayIcon.BalloonTipText = $"Coffee_FF minimized to system tray.{Environment.NewLine}Right-click on the icon for more options.";
				trayIcon.ShowBalloonTip(5000);

				e.Cancel = true;
			}
			else
			{
				try
				{
					cts.Cancel();
					refreshTimer.Enabled = false;
					SaveState();
				}
				catch { }
			}
			base.OnFormClosing(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
				e.Handled = true;
			base.OnKeyPress(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			Interfaces.AddRange(EnumNICs());
			if (Interfaces.Count == 0)
			{
				refreshTimer.Enabled = false;
				MessageBox.Show("No active network connections detected, the program will now close");
				menuexit = true;
				Close();
			}
			else
			{
				nicComboBox.Items.AddRange(Interfaces.Select(i => i.Description).ToArray());
				nicComboBox.SelectedIndex = 0;

				var result = Properties.Settings.Default.NetworkAdaptor;

				if (!string.IsNullOrEmpty(result))
					nicComboBox.SelectedIndex = nicComboBox.Items.IndexOf(result);

				if (nicComboBox.SelectedIndex < 0)
				{
					nicComboBox.SelectedIndex = 0;
					MessageBox.Show($"Error: {result} not found.");
				}

				downloadUpDn.Value = Properties.Settings.Default.DownloadThreshold;
				uploadUpDn.Value = Properties.Settings.Default.UploadThreshold;
				removeDelayUpDn.Value = Properties.Settings.Default.DelayRemoveSleep;
				keypressIntervalUpDn.Value = Properties.Settings.Default.PressKeyInMinutes;
				keypressEnableCheckBox.Checked = Properties.Settings.Default.EnDisKeyPress;
				preventDisplayStandbyCheck.Checked = Properties.Settings.Default.DisDisplayStandby;
				refreshTimer.Enabled = true;
			}
			base.OnLoad(e);
		}

		private static IEnumerable<NetworkInterface> EnumNICs() => NetworkInterface.GetAllNetworkInterfaces().
				Where(nic => (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
				!nic.Description.StartsWith("Software") && !nic.Description.StartsWith("Teredo") && !nic.Description.Contains("Virtual"));

		private static Process StartProcess(string fullPath, bool elevated = false) => elevated ? Process.Start(new ProcessStartInfo(fullPath) { Verb = "runas" }) : Process.Start(fullPath);

		private void blockSleepBtnClick(object sender, EventArgs e)
		{
			SystemRequired(ProcessReason);
			ClearStopDelay2 = DateTime.Now.AddMinutes((int)blockDurationUpDn.Value);
		}

		private void closeBtnClick(object sender, EventArgs e) => Close();

		private void donateBtnClick(object sender, EventArgs e) => StartProcess(@"http://sourceforge.net/project/project_donations.php?group_id=540532");

		private async IAsyncEnumerable<ListItem<uint>> EnumValidProcesses([EnumeratorCancellation] CancellationToken cancellationToken = default)
		{
			var procIds = await Task.Run(() => EnumProcesses(), cancellationToken);
			foreach (var processId in procIds)
			{
				if (cancellationToken.IsCancellationRequested)
					break;

				// If Idle or System skip so it will not be added to the list
				var FileDenied = ListDeniedAccessFiles.Contains(processId);

				// *** Additional catch if new Denied process found Check and generate a list of denied processes
				if (!FileDenied)
				{
					using var hProc = OpenProcess((uint)(ProcessAccess.PROCESS_QUERY_INFORMATION | ProcessAccess.PROCESS_VM_READ), false, processId);
					if (!hProc.IsInvalid)
					{
						var hMod = new HINSTANCE[1];
						if (EnumProcessModules(hProc, hMod, (uint)IntPtr.Size, out _))
						{
							var sb = new StringBuilder(2048);
							if (GetModuleFileNameEx(hProc, hMod[0], sb, (uint)sb.Capacity) > 0)
							{
								var desc = Path.GetFileName(sb.ToString());
								FileVersionInfo ver = FileVersionInfo.GetVersionInfo(sb.ToString());
								if (!string.IsNullOrEmpty(ver.FileDescription))
									desc = $"{desc} ({ver.FileDescription})";
								yield return new ListItem<uint>(desc, processId);
							}
						}
					}
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			menuexit = true;
			Close();
		}

		private void gotoWebBtnClick(object sender, EventArgs e) => StartProcess(@"http://coffeeff.sourceforge.net/");

		private void keypressEnableCheckedChanged(object sender, EventArgs e)
		{
			DownloadPrevented = true;
			UploadPrevented = true;
			ProcessPrevented = true;
			SystemNotRequired(DownloadReason);
			SystemNotRequired(UploadReason);
			SystemNotRequired(ProcessReason);
			ClearStopDelay = DateTime.Now;
			ClearStopDelay2 = DateTime.Now;
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			Show();
			trayIcon.Visible = false;
		}

		private void numericUpDown1_Leave(object sender, EventArgs e)
		{
			if (downloadUpDn.Text.Length == 0)
			{
				downloadUpDn.Text = 10.ToString();
				downloadUpDn.Value = 10;
			}
		}

		private void preventDisplayStandbyCheckCheckedChanged(object sender, EventArgs e)
		{
			// When checked/unchecked clear Downoad, Upload and Process...
			DownloadPrevented = true;
			UploadPrevented = true;
			ProcessPrevented = true;
			SystemNotRequired(DownloadReason);
			SystemNotRequired(UploadReason);
			SystemNotRequired(ProcessReason);
			ClearStopDelay = DateTime.Now;
			ClearStopDelay2 = DateTime.Now;
		}

		private void programsPage_Enter(object sender, EventArgs e)
		{
			if (!ProcTabVisited)
			{
				refreshProgBtnClick(this, e);
				ProcTabVisited = true;
			}
		}

		private async void refreshProgBtnClick(object sender, EventArgs e)
		{
			// Update process list
			XXPrograms.Text = "Loading...";

			// Make a list of checked processes
			var ListCheckedBoxes = new SortedSet<uint>();
			foreach (var chk in clbProcess.CheckedItems.Cast<ListItem<uint>>())
				ListCheckedBoxes.Add(chk.Value);

			// Populate listbox
			clbProcess.Items.Clear();
			clbProcess.BeginUpdate();
			await foreach (var item in EnumValidProcesses(cts.Token))
			{
				clbProcess.Items.Add(item, ListCheckedBoxes.Contains(item.Value));
			}
			clbProcess.EndUpdate();

			XXPrograms.Text = $"{clbProcess.Items.Count} processes";
		}

		private void runWithWinBtnClick(object sender, EventArgs e) => StartProcess(SugarPath.Value, !IsAdmin.Value);

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Show();
			trayIcon.Visible = false;
		}

		private void sleepBlockBtnClick(object sender, EventArgs e) => StartProcess(MilkPath.Value, !IsAdmin.Value);

		private void SystemNotRequired(string Reason)
		{
			if (!DownloadPrevented) //this stops it running when it is already cleared
				return;

			switch (Reason)
			{
				case DownloadReason:
					PowerClearRequest(DownloadPowerRequest, POWER_REQUEST_TYPE.PowerRequestSystemRequired);
					PowerClearRequest(DownloadPowerRequest, POWER_REQUEST_TYPE.PowerRequestDisplayRequired);
					DownloadPrevented = false;
					break;

				case UploadReason:
					PowerClearRequest(UploadPowerRequest, POWER_REQUEST_TYPE.PowerRequestSystemRequired);
					PowerClearRequest(UploadPowerRequest, POWER_REQUEST_TYPE.PowerRequestDisplayRequired);
					UploadPrevented = false;
					break;

				case ProcessReason:
					PowerClearRequest(ProcessPowerRequest, POWER_REQUEST_TYPE.PowerRequestSystemRequired);
					PowerClearRequest(ProcessPowerRequest, POWER_REQUEST_TYPE.PowerRequestDisplayRequired);
					ProcessPrevented = false;
					break;
			}
		}

		private void SystemRequired(string Reason)
		{
			switch (Reason)
			{
				case DownloadReason:
					if (DownloadPowerRequest is null)  //first time setup the power request
					{
						// Set up the diagnostic string
						var DownloadPowerRequestContext = new REASON_CONTEXT(Reason + " trafic above threshold.");

						// Create the request, get a handle
						DownloadPowerRequest = PowerCreateRequest(DownloadPowerRequestContext);
					}

					if (DownloadPrevented == false)  //this stops it running when it is aready done
					{
						// Set a system request to prevent automatic sleep
						PowerSetRequest(DownloadPowerRequest, POWER_REQUEST_TYPE.PowerRequestSystemRequired);
						if (preventDisplayStandbyCheck.Checked)
							PowerSetRequest(DownloadPowerRequest, POWER_REQUEST_TYPE.PowerRequestDisplayRequired);
						DownloadPrevented = true;
						// Download the file...
					}

					break;

				case UploadReason:
					if (UploadPowerRequest is null)  //first time setup the power request
					{
						// Set up the diagnostic string
						var UploadPowerRequestContext = new REASON_CONTEXT(Reason + " trafic above threshold.");

						// Create the request, get a handle
						UploadPowerRequest = PowerCreateRequest(UploadPowerRequestContext);
					}

					if (UploadPrevented == false)  //this stops it running when it is aready done
					{
						// Set a system request to prevent automatic sleep
						PowerSetRequest(UploadPowerRequest, POWER_REQUEST_TYPE.PowerRequestSystemRequired);
						if (preventDisplayStandbyCheck.Checked)
							PowerSetRequest(UploadPowerRequest, POWER_REQUEST_TYPE.PowerRequestDisplayRequired);
						UploadPrevented = true;
						// Download the file...
					}

					break;

				case ProcessReason:
					if (ProcessPowerRequest is null)  //first time setup the power request
					{
						// Set up the diagnostic string
						var ProcessPowerRequestContext = new REASON_CONTEXT(Reason + " an application that is ticked in coffee is open.");

						// Create the request, get a handle
						ProcessPowerRequest = PowerCreateRequest(ProcessPowerRequestContext);
					}

					if (ProcessPrevented == false)  //this stops it running when it is aready done
					{
						// Set a system request to prevent automatic sleep
						PowerSetRequest(ProcessPowerRequest, POWER_REQUEST_TYPE.PowerRequestSystemRequired);
						if (preventDisplayStandbyCheck.Checked)
							PowerSetRequest(ProcessPowerRequest, POWER_REQUEST_TYPE.PowerRequestDisplayRequired);
						ProcessPrevented = true;
						// Download the file...
					}
					break;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (firsttick)
			{
				// hides the window if run with /hide command
				if (Environment.GetCommandLineArgs().Contains("/hide)"))  //dirty but it works
					Close();

				firsttick = false;
			}

			// Display NIC status
			if (nicComboBox.SelectedIndex != -1)
				lblOP.Text = "Adapter Operational status: " + Interfaces[nicComboBox.SelectedIndex]?.OperationalStatus;

			// Display when Delay will be removed
			if (DateTime.Now > ClearStopDelay && DateTime.Now > ClearStopDelay2)
			{
				Delay.Text = "Delay removed \n";
			}
			else
			{
				Delay.Text = "Delay will be removed \n on: " + (ClearStopDelay > ClearStopDelay2 ? ClearStopDelay : ClearStopDelay2);
			}

			// Display download/upload stats
			IPv4InterfaceStatistics interfaceStatistic = Interfaces[nicComboBox.SelectedIndex].GetIPv4Statistics();
			lblUpload.Text = ((FormattableString)$"Upload: {interfaceStatistic.BytesSent - lastBytesSend:B}/s").ToString(ByteSizeFormatter.Instance);
			lblDownload.Text = ((FormattableString)$"Download: {interfaceStatistic.BytesReceived - lastBtyesReceived:B}/s").ToString(ByteSizeFormatter.Instance);

			// Handle download trigger
			if (interfaceStatistic.BytesReceived - lastBtyesReceived > downloadUpDn.Value)
			{
				if (downloadUpDn.Value != 0)
				{
					SystemRequired(DownloadReason);
					ClearStopDelay = DateTime.Now.AddMinutes((int)removeDelayUpDn.Value); // Reset Delay every time Download detected

					if (DateTime.Now > compareDate && keypressEnableCheckBox.Checked)
					{
						compareDate = DateTime.Now.AddMinutes((int)keypressIntervalUpDn.Value);
						DelayMaker.Delay();
					}
				}
			}
			else
			{
				if (DateTime.Now > ClearStopDelay) //Delay for X minutes before clear sleep block
				{
					SystemNotRequired(DownloadReason);
				}
				else
				{
					if (DateTime.Now > compareDate && keypressEnableCheckBox.Checked)
					{
						compareDate = DateTime.Now.AddMinutes((int)keypressIntervalUpDn.Value);
						DelayMaker.Delay();
					}
				}
			}

			// Handle upload trigger
			if (interfaceStatistic.BytesSent - lastBytesSend > uploadUpDn.Value)
			{
				if (uploadUpDn.Value != 0)
				{
					SystemRequired(UploadReason);
					ClearStopDelay = DateTime.Now.AddMinutes((int)removeDelayUpDn.Value); // Reset Delay every time Upload detected

					if (DateTime.Now > compareDate && keypressEnableCheckBox.Checked)
					{
						compareDate = DateTime.Now.AddMinutes((int)keypressIntervalUpDn.Value);
						DelayMaker.Delay();
					}
				}
			}
			else
			{
				if (DateTime.Now > ClearStopDelay) //Delay for X minutes before clear sleep block
				{
					SystemNotRequired(UploadReason);
				}
				else
				{
					if (DateTime.Now > compareDate && keypressEnableCheckBox.Checked)
					{
						compareDate = DateTime.Now.AddMinutes((int)keypressIntervalUpDn.Value);
						DelayMaker.Delay();
					}
				}
			}

			// Save current stats
			lastBytesSend = interfaceStatistic.BytesSent;
			lastBtyesReceived = interfaceStatistic.BytesReceived;

			// Handle process trigger
			if (clbProcess.CheckedIndices.Count > 0)
			{
				SystemRequired(ProcessReason);
				ClearStopDelay = DateTime.Now.AddMinutes((int)removeDelayUpDn.Value); // Reset Delay every time Process detected

				if (DateTime.Now > compareDate && keypressEnableCheckBox.Checked)
				{
					compareDate = DateTime.Now.AddMinutes((int)keypressIntervalUpDn.Value);
					DelayMaker.Delay();
				}
			}
			else
			{
				if (DateTime.Now > ClearStopDelay && DateTime.Now > ClearStopDelay2)
				{
					SystemNotRequired(ProcessReason);
				}
				else
				{
					if (DateTime.Now > compareDate && keypressEnableCheckBox.Checked)
					{
						compareDate = DateTime.Now.AddMinutes((int)keypressIntervalUpDn.Value);
						DelayMaker.Delay();
					}
				}
			}
		}
	}

	//here's the heart of it (Delay IDLE timer by simulating key press)
	internal static class DelayMaker
	{
		private const int VK_CONTROL = 0x11;

		//we're actually triggering a keyboard event.
		public static void Delay() => keybd_event(VK_CONTROL, 0, KEYEVENTF.KEYEVENTF_KEYUP, default);

		//you can access the timer used to monitor input events.  This timer gets reset when an event is triggered and delays things like locking of the screen.
		public static int GetLastInputTime()
		{
			var lastInputInfo = new LASTINPUTINFO { cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO)) };
			return GetLastInputInfo(ref lastInputInfo) ? (Environment.TickCount - (int)lastInputInfo.dwTime) / 1000 : 0;
		}
	}

	internal class ListItem<T>
	{
		public ListItem(string text, T value)
		{
			Text = text;
			Value = value;
		}

		public string Text { get; }
		public T Value { get; }

		public override bool Equals(object obj) => obj is ListItem<T> i ? Equals(i.Value, Value) : base.Equals(obj);
		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Text;
	}
}