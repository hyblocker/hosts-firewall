using System;
using System.Windows.Forms;

namespace HostsFirewall
{
	public partial class AddDialog : Form
	{
		private MainWindow Window;
		private HostsFirewall Firewall;

		public AddDialog(MainWindow window, HostsFirewall firewall)
		{
			InitializeComponent();
			Window = window;
			Firewall = firewall;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			// Validate
			if (Utils.IsValidDomain(domainTextbox.Text))
			{
				Firewall.Add(domainTextbox.Text,
					commentTextbox.Text.Replace("\r", string.Empty).Replace("\n", string.Empty), // Kiss multiline exploits goodbye (unless there's some other line ending) :DDDD
					activeToggle.Checked);

				Window.RegisterLastEntry();

				// what, you'd expect it to close if it adds it, would you not???
				Close();
			}
			else
			{
				MessageBox.Show("Please insert a valid domain...", // and not whatever bullshit you inserted
					"Invalid Domain",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// how else am i supposed to cancel? 
		/// nvm theres the close button
		/// </summary>
		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Returns an add dialog for chaining cuz i cant be bothered to write another line
		/// </summary>
		public AddDialog Reset()
		{
			activeToggle.Checked = true;
			domainTextbox.Text = "example.com";
			commentTextbox.Text = string.Empty;

			return this;
		}
	}
}
