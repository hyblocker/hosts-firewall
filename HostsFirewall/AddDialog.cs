using System;
using System.Drawing;
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

			// Localize
			Text = Localizer.GetValue("add_window.title");
			titleLabel.Text = Localizer.GetValue("add_window.title");
			activeLabel.Text = Localizer.GetValue("add_window.active");
			domainLabel.Text = Localizer.GetValue("add_window.domain");
			commentLabel.Text = Localizer.GetValue("add_window.comment");
			addButton.Text = Localizer.GetValue("add_window.add");
			cancelButton.Text = Localizer.GetValue("add_window.cancel");

			// Resize the shit
			addButton.AutoSize = false;
			addButton.AutoSize = true;
			
			cancelButton.AutoSize = false;
			cancelButton.AutoSize = true;

			titleLabel.AutoSize = false;
			titleLabel.AutoSize = true;

			// reposition shit
			addButton.Location = new Point(Size.Width - addButton.Size.Width - 29, addButton.Location.Y);
			cancelButton.Location = new Point(Size.Width - addButton.Size.Width - 37 - cancelButton.Width, addButton.Location.Y);
			activeLabel.Location = new Point(Size.Width - 90 - activeLabel.Size.Width, 17);
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
