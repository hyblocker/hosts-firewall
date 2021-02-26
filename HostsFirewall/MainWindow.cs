using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HostsFirewall
{
	/// <summary>
	/// The main Window, aka the amazingly performant GUI
	/// </summary>
	public partial class MainWindow : Form
	{
		private HostsFirewall firewall;
		private AddDialog addDialog;

		int lastTabIndex = 4;

		// Note to self: Consider writing your own controls if you ever touch this project again, fill rate is a bottleneck with this Material Design Library
		//               Also it's compiled for framework and i have no idea why i can load and compile it on .net core
		//               thanks unexplained black magic roslyn compiler gods for making me consider masochism again
		public MainWindow()
		{
			InitializeComponent();
			firewall = new HostsFirewall();

			// Localize
			addButton.Text = Localizer.GetValue("main_window.add");
			deleteButton.Text = Localizer.GetValue("main_window.delete");
			applyButton.Text = Localizer.GetValue("main_window.apply");

			// Resize the shit
			addButton.AutoSize = false;
			addButton.AutoSize = true;

			deleteButton.AutoSize = false;
			deleteButton.AutoSize = true;
			deleteButton.Location = new Point(addButton.Location.X + addButton.Size.Width + 8, deleteButton.Location.Y);

			applyButton.AutoSize = false;
			applyButton.AutoSize = true;
			applyButton.Location = new Point(Size.Width - applyButton.Size.Width - 29, applyButton.Location.Y);
		}

		// Called when the window is loaded
		private void MainWindow_Load(object sender, EventArgs e)
		{
			firewall.LoadHosts();
			addDialog = new AddDialog(this, firewall);
		}

		// Use shown so that everything is consistent
		// nvm shown doesn't change jack shit
		// thanks microsoft very cool 👍
		private void MainWindow_Shown(object sender, EventArgs e)
		{
			for (int i = 0; i < firewall.Length; i++)
			{
				var card = CreateCard(i);
				panel1.Controls.Add(card);
				card.Location = new Point(12, 12 + 85 * i);

				// idk theres a bug for some reason where if the bottom of the card is outside the bounds of the panel it's 17 pixels wider for some reason so we use a hack :D
				if (panel1.Height < card.Location.Y + 73)
				{
					card.Size = new Size(panel1.Width - 41, 73);
				}
				else
				{
					card.Size = new Size(panel1.Width - 24, 73);
				}
			}
			// Overflow (invisible PictureBox) so that we don't cut the shadow of the last card
			overflowPicture.Location = new Point(0, firewall.Length * 85 + 8);
		}

		/// <summary>
		/// Registers the last entry of the firewall
		/// </summary>
		public void RegisterLastEntry()
		{
			int lastIndex = firewall.Length - 1;

			var card = CreateCard(lastIndex);
			panel1.Controls.Add(card);
			card.Location = new Point(12, 12 + 85 * lastIndex);

			// idk theres a bug for some reason where if the bottom of the card is outside the bounds of the panel it's 17 pixels wider for some reason so we use a hack :D
			if (panel1.Height < card.Location.Y + 73)
			{
				card.Size = new Size(panel1.Width - 41, 73);
			}
			else
			{
				card.Size = new Size(panel1.Width - 24, 73);
			}

			// Overflow (invisible PictureBox) so that we don't cut the shadow of the last card
			overflowPicture.Location = new Point(0, firewall.Length * 85 + 8);
		}

		/// <summary>
		/// Shamelessly stolen code from Windows Forms designer :pepega:
		/// </summary>
		/// <param name="entry"></param>
		/// <param name="id">the index or id of the card, for tabs or something idk</param>
		/// <returns>The card which you are free to shove onto the form</returns>
		public MaterialCard CreateCard(int id)
		{
			MaterialCard cardRoot = new MaterialCard();
			MaterialSwitch cardToggle = new MaterialSwitch();
			Label commentLabel = new Label();
			Label domainLabel = new Label();

			// card
			cardRoot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cardRoot.BackColor = Color.FromArgb(255, 255, 255);
			cardRoot.Controls.Add(cardToggle);
			cardRoot.Controls.Add(commentLabel);
			cardRoot.Controls.Add(domainLabel);
			cardRoot.Depth = 0;
			cardRoot.ForeColor = Color.FromArgb(222, 0, 0, 0);
			cardRoot.Location = new Point(12, 12);
			cardRoot.Margin = new Padding(14);
			cardRoot.MouseState = MouseState.HOVER;
			cardRoot.Name = "cardRoot_" + id;
			cardRoot.Padding = new Padding(14);
			cardRoot.Size = new Size(481, 73);
			cardRoot.TabIndex = 0;

			// domain label
			domainLabel.AutoSize = true;
			domainLabel.Font = new Font("Roboto Light", 14F, FontStyle.Bold, GraphicsUnit.Point);
			domainLabel.Location = new Point(14, 16);
			domainLabel.Name = "domainLabel_" + id;
			domainLabel.Size = new Size(66, 23);
			domainLabel.TabIndex = 0;
			domainLabel.Text = "label1";

			// comment label
			commentLabel.AutoSize = true;
			commentLabel.Font = new Font("Roboto Light", 11F, FontStyle.Italic, GraphicsUnit.Point);
			commentLabel.Location = new Point(14, 39);
			commentLabel.Name = "commentLabel_" + id;
			commentLabel.Size = new Size(46, 18);
			commentLabel.TabIndex = 0;
			commentLabel.Text = "label2";

			// card toggle
			cardToggle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			cardToggle.AutoSize = true;
			cardToggle.Depth = 0;
			cardToggle.Location = new Point(460, 18);
			cardToggle.Margin = new Padding(0);
			cardToggle.MouseLocation = new Point(-1, -1);
			cardToggle.MouseState = MouseState.HOVER;
			cardToggle.Name = "cardToggle_" + id;
			cardToggle.Ripple = true;
			cardToggle.Size = new Size(58, 37);
			cardToggle.TabIndex = lastTabIndex + id;
			cardToggle.UseVisualStyleBackColor = true;

			// fill the shit with the data
			cardToggle.Checked = firewall[id].Enabled;
			domainLabel.Text = firewall[id].Domain;
			commentLabel.Text = firewall[id].Comment;

			// Toggle Updating
			cardToggle.CheckedChanged += (object sender, EventArgs e) =>
			{
				firewall[id] = new HostsEntry(firewall[id].RedirectIp, firewall[id].Domain, cardToggle.Checked, firewall[id].Comment);
			};

			return cardRoot;
		}

		/// <summary>
		/// Apply button. idk it sounds pretty self explanatory
		/// </summary>
		private void applyButton_Click(object sender, EventArgs e)
		{
			firewall.WriteHosts();
			firewall.FlushDNSCache();

			// Message box cuz i expect user feedback breh
			MessageBox.Show(
				Localizer.GetValue("main_window.update_success.message"),
				Localizer.GetValue("main_window.update_success.title"),
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		/// <summary>
		/// tldr: show form
		/// </summary>
		private void addButton_Click(object sender, EventArgs e)
		{
			addDialog.Reset().ShowDialog();
		}

		/// <summary>
		/// POV: how the fuck do i select cards
		/// </summary>
		private void deleteButton_Click(object sender, EventArgs e)
		{
#if DEBUG
			// OI
			// YOU`RE A JACKASS
			throw new NotImplementedException();
#else
			MessageBox.Show("too lazy to implement this atm lol, just disable the rule you dont want i guess","oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
		}
	}
}
