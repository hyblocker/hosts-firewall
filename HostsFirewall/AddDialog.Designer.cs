
namespace HostsFirewall
{
	partial class AddDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.domainTextbox = new MaterialSkin.Controls.MaterialTextBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.commentTextbox = new MaterialSkin.Controls.MaterialTextBox();
			this.addButton = new MaterialSkin.Controls.MaterialButton();
			this.cancelButton = new MaterialSkin.Controls.MaterialButton();
			this.commentLabel = new System.Windows.Forms.Label();
			this.domainLabel = new System.Windows.Forms.Label();
			this.activeToggle = new MaterialSkin.Controls.MaterialSwitch();
			this.activeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// domainTextbox
			// 
			this.domainTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.domainTextbox.Depth = 0;
			this.domainTextbox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.domainTextbox.Location = new System.Drawing.Point(12, 80);
			this.domainTextbox.MaxLength = 50;
			this.domainTextbox.MouseState = MaterialSkin.MouseState.OUT;
			this.domainTextbox.Multiline = false;
			this.domainTextbox.Name = "domainTextbox";
			this.domainTextbox.Size = new System.Drawing.Size(577, 36);
			this.domainTextbox.TabIndex = 0;
			this.domainTextbox.Text = "example.com";
			this.domainTextbox.UseTallSize = false;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Roboto Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.titleLabel.Location = new System.Drawing.Point(12, 13);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(155, 23);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "Add HOSTS Rule";
			// 
			// commentTextbox
			// 
			this.commentTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.commentTextbox.Depth = 0;
			this.commentTextbox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.commentTextbox.Location = new System.Drawing.Point(12, 166);
			this.commentTextbox.MaxLength = 50;
			this.commentTextbox.MouseState = MaterialSkin.MouseState.OUT;
			this.commentTextbox.Multiline = false;
			this.commentTextbox.Name = "commentTextbox";
			this.commentTextbox.Size = new System.Drawing.Size(577, 36);
			this.commentTextbox.TabIndex = 2;
			this.commentTextbox.Text = "";
			this.commentTextbox.UseTallSize = false;
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addButton.Depth = 0;
			this.addButton.DrawShadows = true;
			this.addButton.HighEmphasis = true;
			this.addButton.Icon = null;
			this.addButton.Location = new System.Drawing.Point(539, 230);
			this.addButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.addButton.MouseState = MaterialSkin.MouseState.HOVER;
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(50, 36);
			this.addButton.TabIndex = 3;
			this.addButton.Text = "Add";
			this.addButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.addButton.UseAccentColor = false;
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.Depth = 0;
			this.cancelButton.DrawShadows = true;
			this.cancelButton.HighEmphasis = true;
			this.cancelButton.Icon = null;
			this.cancelButton.Location = new System.Drawing.Point(454, 230);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(77, 36);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.cancelButton.UseAccentColor = false;
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// commentLabel
			// 
			this.commentLabel.AutoSize = true;
			this.commentLabel.Font = new System.Drawing.Font("Roboto Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.commentLabel.Location = new System.Drawing.Point(12, 134);
			this.commentLabel.Name = "commentLabel";
			this.commentLabel.Size = new System.Drawing.Size(73, 18);
			this.commentLabel.TabIndex = 5;
			this.commentLabel.Text = "Comment";
			// 
			// domainLabel
			// 
			this.domainLabel.AutoSize = true;
			this.domainLabel.Font = new System.Drawing.Font("Roboto Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.domainLabel.Location = new System.Drawing.Point(12, 46);
			this.domainLabel.Name = "domainLabel";
			this.domainLabel.Size = new System.Drawing.Size(58, 18);
			this.domainLabel.TabIndex = 6;
			this.domainLabel.Text = "Domain";
			// 
			// activeToggle
			// 
			this.activeToggle.AutoSize = true;
			this.activeToggle.Checked = true;
			this.activeToggle.CheckState = System.Windows.Forms.CheckState.Checked;
			this.activeToggle.Depth = 0;
			this.activeToggle.Location = new System.Drawing.Point(531, 9);
			this.activeToggle.Margin = new System.Windows.Forms.Padding(0);
			this.activeToggle.MouseLocation = new System.Drawing.Point(-1, -1);
			this.activeToggle.MouseState = MaterialSkin.MouseState.HOVER;
			this.activeToggle.Name = "activeToggle";
			this.activeToggle.Ripple = true;
			this.activeToggle.Size = new System.Drawing.Size(58, 37);
			this.activeToggle.TabIndex = 7;
			this.activeToggle.UseVisualStyleBackColor = true;
			// 
			// activeLabel
			// 
			this.activeLabel.AutoSize = true;
			this.activeLabel.Font = new System.Drawing.Font("Roboto Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.activeLabel.Location = new System.Drawing.Point(483, 17);
			this.activeLabel.Name = "activeLabel";
			this.activeLabel.Size = new System.Drawing.Size(48, 18);
			this.activeLabel.TabIndex = 8;
			this.activeLabel.Text = "Active";
			// 
			// AddDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(605, 281);
			this.Controls.Add(this.activeLabel);
			this.Controls.Add(this.activeToggle);
			this.Controls.Add(this.domainLabel);
			this.Controls.Add(this.commentLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.commentTextbox);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.domainTextbox);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(621, 320);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(621, 320);
			this.Name = "AddDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add HOSTS Rule";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialTextBox domainTextbox;
		private System.Windows.Forms.Label titleLabel;
		private MaterialSkin.Controls.MaterialTextBox aaa;
		private MaterialSkin.Controls.MaterialButton addButton;
		private MaterialSkin.Controls.MaterialButton cancelButton;
		private System.Windows.Forms.Label commentLabel;
		private System.Windows.Forms.Label domainLabel;
		private MaterialSkin.Controls.MaterialSwitch activeToggle;
		private System.Windows.Forms.Label activeLabel;
		private MaterialSkin.Controls.MaterialTextBox commentTextbox;
	}
}