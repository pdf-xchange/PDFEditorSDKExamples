namespace FullDemo
{
	partial class InsertPagesForm
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
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbAllPages = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gboxOpts = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tDestPos = new System.Windows.Forms.NumericUpDown();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.btnBrowseForOpen = new System.Windows.Forms.Button();
			this.tSrcToOpen = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.gboxOpts.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tDestPos)).BeginInit();
			this.SuspendLayout();
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(80, 65);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(342, 30);
			this.label11.TabIndex = 5;
			this.label11.Text = "Type page numbers and/or page ranges separated by commas counting from the start " +
    "of the document. For example, type 1, 3, 5-12";
			// 
			// tPages
			// 
			this.tPages.Location = new System.Drawing.Point(80, 42);
			this.tPages.Name = "tPages";
			this.tPages.Size = new System.Drawing.Size(154, 20);
			this.tPages.TabIndex = 3;
			this.tPages.TextChanged += new System.EventHandler(this.tPages_TextChanged);
			// 
			// rbPages
			// 
			this.rbPages.AutoSize = true;
			this.rbPages.Location = new System.Drawing.Point(17, 44);
			this.rbPages.Name = "rbPages";
			this.rbPages.Size = new System.Drawing.Size(58, 17);
			this.rbPages.TabIndex = 2;
			this.rbPages.Text = "Pages:";
			this.rbPages.UseVisualStyleBackColor = true;
			// 
			// rbAllPages
			// 
			this.rbAllPages.AutoSize = true;
			this.rbAllPages.Checked = true;
			this.rbAllPages.Location = new System.Drawing.Point(17, 20);
			this.rbAllPages.Name = "rbAllPages";
			this.rbAllPages.Size = new System.Drawing.Size(68, 17);
			this.rbAllPages.TabIndex = 0;
			this.rbAllPages.TabStop = true;
			this.rbAllPages.Text = "All pages";
			this.rbAllPages.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tPages);
			this.groupBox1.Controls.Add(this.rbPages);
			this.groupBox1.Controls.Add(this.rbAllPages);
			this.groupBox1.Location = new System.Drawing.Point(6, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 103);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Source Pages Range";
			// 
			// gboxOpts
			// 
			this.gboxOpts.BackColor = System.Drawing.Color.Transparent;
			this.gboxOpts.Controls.Add(this.groupBox2);
			this.gboxOpts.Controls.Add(this.label19);
			this.gboxOpts.Controls.Add(this.btnBrowseForOpen);
			this.gboxOpts.Controls.Add(this.tSrcToOpen);
			this.gboxOpts.Controls.Add(this.groupBox1);
			this.gboxOpts.Location = new System.Drawing.Point(2, 2);
			this.gboxOpts.Name = "gboxOpts";
			this.gboxOpts.Size = new System.Drawing.Size(476, 244);
			this.gboxOpts.TabIndex = 0;
			this.gboxOpts.TabStop = false;
			this.gboxOpts.Text = "Insert Pages Options";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tDestPos);
			this.groupBox2.Controls.Add(this.lbNumPages);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(6, 181);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(464, 57);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Destination Options";
			// 
			// tDestPos
			// 
			this.tDestPos.Location = new System.Drawing.Point(103, 25);
			this.tDestPos.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
			this.tDestPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tDestPos.Name = "tDestPos";
			this.tDestPos.Size = new System.Drawing.Size(80, 20);
			this.tDestPos.TabIndex = 24;
			this.tDestPos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lbNumPages
			// 
			this.lbNumPages.Location = new System.Drawing.Point(223, 27);
			this.lbNumPages.Name = "lbNumPages";
			this.lbNumPages.Size = new System.Drawing.Size(106, 17);
			this.lbNumPages.TabIndex = 23;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(189, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "page";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Insert before:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(19, 28);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(190, 13);
			this.label19.TabIndex = 17;
			this.label19.Text = "Specify document to insert pages from:";
			// 
			// btnBrowseForOpen
			// 
			this.btnBrowseForOpen.Location = new System.Drawing.Point(373, 44);
			this.btnBrowseForOpen.Name = "btnBrowseForOpen";
			this.btnBrowseForOpen.Size = new System.Drawing.Size(73, 22);
			this.btnBrowseForOpen.TabIndex = 19;
			this.btnBrowseForOpen.Text = "Browse...";
			this.btnBrowseForOpen.UseVisualStyleBackColor = true;
			this.btnBrowseForOpen.Click += new System.EventHandler(this.btnBrowseForOpen_Click);
			// 
			// tSrcToOpen
			// 
			this.tSrcToOpen.Location = new System.Drawing.Point(22, 45);
			this.tSrcToOpen.Name = "tSrcToOpen";
			this.tSrcToOpen.ReadOnly = true;
			this.tSrcToOpen.Size = new System.Drawing.Size(345, 20);
			this.tSrcToOpen.TabIndex = 18;
			// 
			// InsertPagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(480, 247);
			this.Controls.Add(this.gboxOpts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "InsertPagesForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxOpts.ResumeLayout(false);
			this.gboxOpts.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tDestPos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.RadioButton rbPages;
		private System.Windows.Forms.RadioButton rbAllPages;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox gboxOpts;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btnBrowseForOpen;
		private System.Windows.Forms.TextBox tSrcToOpen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.NumericUpDown tDestPos;
	}
}