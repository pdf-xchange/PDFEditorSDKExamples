namespace FullDemo
{
	partial class MovePages
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
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lbNumPage = new System.Windows.Forms.Label();
			this.tNumPage = new System.Windows.Forms.NumericUpDown();
			this.rbPage = new System.Windows.Forms.RadioButton();
			this.rbLast = new System.Windows.Forms.RadioButton();
			this.rbFirst = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.cbLocation = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNumPage)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// rbPages
			// 
			this.rbPages.AutoSize = true;
			this.rbPages.Location = new System.Drawing.Point(17, 42);
			this.rbPages.Name = "rbPages";
			this.rbPages.Size = new System.Drawing.Size(58, 17);
			this.rbPages.TabIndex = 2;
			this.rbPages.Text = "Pages:";
			this.rbPages.UseVisualStyleBackColor = true;
			this.rbPages.CheckedChanged += new System.EventHandler(this.rbPages_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(473, 280);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Move Pages";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lbNumPage);
			this.groupBox3.Controls.Add(this.tNumPage);
			this.groupBox3.Controls.Add(this.rbPage);
			this.groupBox3.Controls.Add(this.rbLast);
			this.groupBox3.Controls.Add(this.rbFirst);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cbLocation);
			this.groupBox3.Location = new System.Drawing.Point(9, 154);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(455, 115);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Destination";
			// 
			// lbNumPage
			// 
			this.lbNumPage.AutoSize = true;
			this.lbNumPage.Location = new System.Drawing.Point(165, 85);
			this.lbNumPage.Name = "lbNumPage";
			this.lbNumPage.Size = new System.Drawing.Size(0, 13);
			this.lbNumPage.TabIndex = 6;
			// 
			// tNumPage
			// 
			this.tNumPage.Location = new System.Drawing.Point(77, 83);
			this.tNumPage.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.tNumPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tNumPage.Name = "tNumPage";
			this.tNumPage.Size = new System.Drawing.Size(82, 20);
			this.tNumPage.TabIndex = 5;
			this.tNumPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// rbPage
			// 
			this.rbPage.AutoSize = true;
			this.rbPage.Location = new System.Drawing.Point(24, 83);
			this.rbPage.Name = "rbPage";
			this.rbPage.Size = new System.Drawing.Size(53, 17);
			this.rbPage.TabIndex = 4;
			this.rbPage.Text = "Page:";
			this.rbPage.UseVisualStyleBackColor = true;
			this.rbPage.CheckedChanged += new System.EventHandler(this.rbPage_CheckedChanged);
			// 
			// rbLast
			// 
			this.rbLast.AutoSize = true;
			this.rbLast.Location = new System.Drawing.Point(24, 60);
			this.rbLast.Name = "rbLast";
			this.rbLast.Size = new System.Drawing.Size(45, 17);
			this.rbLast.TabIndex = 3;
			this.rbLast.Text = "Last";
			this.rbLast.UseVisualStyleBackColor = true;
			this.rbLast.Click += new System.EventHandler(this.rbLast_Click);
			// 
			// rbFirst
			// 
			this.rbFirst.AutoSize = true;
			this.rbFirst.Checked = true;
			this.rbFirst.Location = new System.Drawing.Point(24, 37);
			this.rbFirst.Name = "rbFirst";
			this.rbFirst.Size = new System.Drawing.Size(44, 17);
			this.rbFirst.TabIndex = 2;
			this.rbFirst.TabStop = true;
			this.rbFirst.Text = "First";
			this.rbFirst.UseVisualStyleBackColor = true;
			this.rbFirst.Click += new System.EventHandler(this.rbFirst_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Location:";
			// 
			// cbLocation
			// 
			this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLocation.FormattingEnabled = true;
			this.cbLocation.Items.AddRange(new object[] {
            "Before",
            "After"});
			this.cbLocation.Location = new System.Drawing.Point(77, 14);
			this.cbLocation.Name = "cbLocation";
			this.cbLocation.Size = new System.Drawing.Size(154, 21);
			this.cbLocation.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.cbPagesSubset);
			this.groupBox2.Controls.Add(this.lbNumPages);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.tPages);
			this.groupBox2.Controls.Add(this.rbPages);
			this.groupBox2.Controls.Add(this.rbCurPage);
			this.groupBox2.Location = new System.Drawing.Point(6, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(458, 129);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pages Range";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(32, 100);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Subset:";
			// 
			// cbPagesSubset
			// 
			this.cbPagesSubset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPagesSubset.FormattingEnabled = true;
			this.cbPagesSubset.Items.AddRange(new object[] {
            "All",
            "Odd",
            "Even"});
			this.cbPagesSubset.Location = new System.Drawing.Point(80, 97);
			this.cbPagesSubset.Name = "cbPagesSubset";
			this.cbPagesSubset.Size = new System.Drawing.Size(154, 21);
			this.cbPagesSubset.TabIndex = 7;
			// 
			// lbNumPages
			// 
			this.lbNumPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNumPages.Location = new System.Drawing.Point(234, 99);
			this.lbNumPages.Name = "lbNumPages";
			this.lbNumPages.Size = new System.Drawing.Size(153, 14);
			this.lbNumPages.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(80, 64);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(342, 30);
			this.label11.TabIndex = 5;
			this.label11.Text = "Type page numbers and/or page ranges separated by commas counting from the start " +
    "of the document. For example, type 1, 3, 5-12";
			// 
			// tPages
			// 
			this.tPages.Location = new System.Drawing.Point(80, 41);
			this.tPages.Name = "tPages";
			this.tPages.Size = new System.Drawing.Size(154, 20);
			this.tPages.TabIndex = 3;
			// 
			// rbCurPage
			// 
			this.rbCurPage.AutoSize = true;
			this.rbCurPage.Checked = true;
			this.rbCurPage.Location = new System.Drawing.Point(17, 19);
			this.rbCurPage.Name = "rbCurPage";
			this.rbCurPage.Size = new System.Drawing.Size(86, 17);
			this.rbCurPage.TabIndex = 1;
			this.rbCurPage.TabStop = true;
			this.rbCurPage.Text = "Current page";
			this.rbCurPage.UseVisualStyleBackColor = true;
			// 
			// MovePages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 289);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MovePages";
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNumPage)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rbPages;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbPagesSubset;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.RadioButton rbCurPage;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbPage;
		private System.Windows.Forms.RadioButton rbLast;
		private System.Windows.Forms.RadioButton rbFirst;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbLocation;
		private System.Windows.Forms.Label lbNumPage;
		private System.Windows.Forms.NumericUpDown tNumPage;
	}
}