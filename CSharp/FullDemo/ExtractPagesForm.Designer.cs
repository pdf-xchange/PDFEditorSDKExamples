namespace FullDemo
{
	partial class ExtractPagesForm
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
			this.label11 = new System.Windows.Forms.Label();
			this.gboxOpts = new System.Windows.Forms.GroupBox();
			this.cbExportMode = new System.Windows.Forms.ComboBox();
			this.tPages = new System.Windows.Forms.TextBox();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.ckOpenFolder = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.gboxOpts.SuspendLayout();
			this.SuspendLayout();
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(19, 71);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(342, 30);
			this.label11.TabIndex = 5;
			this.label11.Text = "Type page numbers and/or page ranges separated by commas counting from the start " +
    "of the document. For example, type 1, 3, 5-12";
			// 
			// gboxOpts
			// 
			this.gboxOpts.BackColor = System.Drawing.Color.Transparent;
			this.gboxOpts.Controls.Add(this.cbExportMode);
			this.gboxOpts.Controls.Add(this.tPages);
			this.gboxOpts.Controls.Add(this.lbNumPages);
			this.gboxOpts.Controls.Add(this.ckOpenFolder);
			this.gboxOpts.Controls.Add(this.label11);
			this.gboxOpts.Controls.Add(this.label19);
			this.gboxOpts.Location = new System.Drawing.Point(2, 2);
			this.gboxOpts.Name = "gboxOpts";
			this.gboxOpts.Size = new System.Drawing.Size(476, 183);
			this.gboxOpts.TabIndex = 0;
			this.gboxOpts.TabStop = false;
			this.gboxOpts.Text = "Extract Pages Options";
			// 
			// cbExportMode
			// 
			this.cbExportMode.FormattingEnabled = true;
			this.cbExportMode.Items.AddRange(new object[] {
            "All pages into one file",
            "Each page into separate file",
            "Each pages range into separate file"});
			this.cbExportMode.Location = new System.Drawing.Point(22, 112);
			this.cbExportMode.Name = "cbExportMode";
			this.cbExportMode.Size = new System.Drawing.Size(214, 21);
			this.cbExportMode.TabIndex = 23;
			// 
			// tPages
			// 
			this.tPages.Location = new System.Drawing.Point(22, 47);
			this.tPages.Name = "tPages";
			this.tPages.Size = new System.Drawing.Size(214, 20);
			this.tPages.TabIndex = 22;
			this.tPages.TextChanged += new System.EventHandler(this.tPages_TextChanged);
			// 
			// lbNumPages
			// 
			this.lbNumPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNumPages.Location = new System.Drawing.Point(241, 50);
			this.lbNumPages.Name = "lbNumPages";
			this.lbNumPages.Size = new System.Drawing.Size(142, 14);
			this.lbNumPages.TabIndex = 21;
			// 
			// ckOpenFolder
			// 
			this.ckOpenFolder.AutoSize = true;
			this.ckOpenFolder.Checked = true;
			this.ckOpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckOpenFolder.Location = new System.Drawing.Point(22, 148);
			this.ckOpenFolder.Name = "ckOpenFolder";
			this.ckOpenFolder.Size = new System.Drawing.Size(152, 17);
			this.ckOpenFolder.TabIndex = 20;
			this.ckOpenFolder.Text = "Open folder with result files";
			this.ckOpenFolder.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(19, 28);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(124, 13);
			this.label19.TabIndex = 17;
			this.label19.Text = "Specify pages to extract:";
			// 
			// ExtractPagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 186);
			this.Controls.Add(this.gboxOpts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ExtractPagesForm";
			this.gboxOpts.ResumeLayout(false);
			this.gboxOpts.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.GroupBox gboxOpts;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox ckOpenFolder;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.ComboBox cbExportMode;
	}
}