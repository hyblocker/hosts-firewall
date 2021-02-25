
namespace HostsFirewall
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.overflowPicture = new System.Windows.Forms.PictureBox();
			this.applyButton = new MaterialSkin.Controls.MaterialButton();
			this.addButton = new MaterialSkin.Controls.MaterialButton();
			this.deleteButton = new MaterialSkin.Controls.MaterialButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.overflowPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.overflowPicture);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(776, 397);
			this.panel1.TabIndex = 3;
			// 
			// overflowPicture
			// 
			this.overflowPicture.Location = new System.Drawing.Point(289, 208);
			this.overflowPicture.Name = "overflowPicture";
			this.overflowPicture.Size = new System.Drawing.Size(16, 16);
			this.overflowPicture.TabIndex = 0;
			this.overflowPicture.TabStop = false;
			// 
			// applyButton
			// 
			this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.applyButton.AutoSize = false;
			this.applyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.applyButton.Depth = 0;
			this.applyButton.DrawShadows = true;
			this.applyButton.HighEmphasis = true;
			this.applyButton.Icon = null;
			this.applyButton.Location = new System.Drawing.Point(702, 428);
			this.applyButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.applyButton.MouseState = MaterialSkin.MouseState.HOVER;
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(85, 36);
			this.applyButton.TabIndex = 0;
			this.applyButton.Text = "Apply";
			this.applyButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.applyButton.UseAccentColor = false;
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.addButton.AutoSize = false;
			this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addButton.Depth = 0;
			this.addButton.DrawShadows = true;
			this.addButton.HighEmphasis = true;
			this.addButton.Icon = null;
			this.addButton.Location = new System.Drawing.Point(12, 428);
			this.addButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.addButton.MinimumSize = new System.Drawing.Size(36, 36);
			this.addButton.MouseState = MaterialSkin.MouseState.HOVER;
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(69, 36);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "Add";
			this.addButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.addButton.UseAccentColor = false;
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteButton.AutoSize = false;
			this.deleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deleteButton.Depth = 0;
			this.deleteButton.DrawShadows = true;
			this.deleteButton.HighEmphasis = true;
			this.deleteButton.Icon = null;
			this.deleteButton.Location = new System.Drawing.Point(89, 428);
			this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.deleteButton.MinimumSize = new System.Drawing.Size(36, 36);
			this.deleteButton.MouseState = MaterialSkin.MouseState.HOVER;
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(81, 36);
			this.deleteButton.TabIndex = 2;
			this.deleteButton.Text = "Delete";
			this.deleteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.deleteButton.UseAccentColor = false;
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// MainWindow
			// 
			this.AcceptButton = this.applyButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 479);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.panel1);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hosts Firewall";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.Shown += new System.EventHandler(this.MainWindow_Shown);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.overflowPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private MaterialSkin.Controls.MaterialButton applyButton;
		private MaterialSkin.Controls.MaterialButton addButton;
		private MaterialSkin.Controls.MaterialButton deleteButton;
		private System.Windows.Forms.PictureBox overflowPicture;
	}
}

