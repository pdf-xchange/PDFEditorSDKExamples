namespace FullDemo
{
	partial class RotatePagesForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbDirection = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbOrientation = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.rbAllPages = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cbDirection);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(708, 360);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Rotate Pages";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(44, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 20);
			this.label1.TabIndex = 10;
			this.label1.Text = "Direction:";
			// 
			// cbDirection
			// 
			this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDirection.FormattingEnabled = true;
			this.cbDirection.Items.AddRange(new object[] {
            "Clockwise 90 degrees",
            "180 degrees",
            "Counterclockwise 90 degrees"});
			this.cbDirection.Location = new System.Drawing.Point(130, 29);
			this.cbDirection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbDirection.Name = "cbDirection";
			this.cbDirection.Size = new System.Drawing.Size(229, 28);
			this.cbDirection.TabIndex = 9;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbOrientation);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.cbPagesSubset);
			this.groupBox2.Controls.Add(this.lbNumPages);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.tPages);
			this.groupBox2.Controls.Add(this.rbPages);
			this.groupBox2.Controls.Add(this.rbCurPage);
			this.groupBox2.Controls.Add(this.rbAllPages);
			this.groupBox2.Location = new System.Drawing.Point(10, 71);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Size = new System.Drawing.Size(688, 275);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pages Range";
			// 
			// cbOrientation
			// 
			this.cbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOrientation.FormattingEnabled = true;
			this.cbOrientation.Items.AddRange(new object[] {
            "Pages of Any Orientations",
            "Portrait Pages",
            "Landscape Pages"});
			this.cbOrientation.Location = new System.Drawing.Point(120, 225);
			this.cbOrientation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbOrientation.Name = "cbOrientation";
			this.cbOrientation.Size = new System.Drawing.Size(229, 28);
			this.cbOrientation.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(48, 188);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 20);
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
			this.cbPagesSubset.Location = new System.Drawing.Point(120, 183);
			this.cbPagesSubset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbPagesSubset.Name = "cbPagesSubset";
			this.cbPagesSubset.Size = new System.Drawing.Size(229, 28);
			this.cbPagesSubset.TabIndex = 7;
			// 
			// lbNumPages
			// 
			this.lbNumPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNumPages.Location = new System.Drawing.Point(351, 102);
			this.lbNumPages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbNumPages.Name = "lbNumPages";
			this.lbNumPages.Size = new System.Drawing.Size(230, 22);
			this.lbNumPages.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(120, 132);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(513, 46);
			this.label11.TabIndex = 5;
			this.label11.Text = "Type page numbers and/or page ranges separated by commas counting from the start " +
    "of the document. For example, type 1, 3, 5-12";
			// 
			// tPages
			// 
			this.tPages.Location = new System.Drawing.Point(120, 97);
			this.tPages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tPages.Name = "tPages";
			this.tPages.Size = new System.Drawing.Size(229, 26);
			this.tPages.TabIndex = 3;
			// 
			// rbPages
			// 
			this.rbPages.AutoSize = true;
			this.rbPages.Location = new System.Drawing.Point(26, 98);
			this.rbPages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rbPages.Name = "rbPages";
			this.rbPages.Size = new System.Drawing.Size(83, 24);
			this.rbPages.TabIndex = 2;
			this.rbPages.Text = "Pages:";
			this.rbPages.UseVisualStyleBackColor = true;
			this.rbPages.CheckedChanged += new System.EventHandler(this.rbPages_CheckedChanged);
			// 
			// rbCurPage
			// 
			this.rbCurPage.AutoSize = true;
			this.rbCurPage.Location = new System.Drawing.Point(26, 65);
			this.rbCurPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rbCurPage.Name = "rbCurPage";
			this.rbCurPage.Size = new System.Drawing.Size(127, 24);
			this.rbCurPage.TabIndex = 1;
			this.rbCurPage.Text = "Current page";
			this.rbCurPage.UseVisualStyleBackColor = true;
			// 
			// rbAllPages
			// 
			this.rbAllPages.AutoSize = true;
			this.rbAllPages.Checked = true;
			this.rbAllPages.Location = new System.Drawing.Point(26, 29);
			this.rbAllPages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rbAllPages.Name = "rbAllPages";
			this.rbAllPages.Size = new System.Drawing.Size(99, 24);
			this.rbAllPages.TabIndex = 0;
			this.rbAllPages.TabStop = true;
			this.rbAllPages.Text = "All pages";
			this.rbAllPages.UseVisualStyleBackColor = true;
			// 
			// RotatePagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(718, 365);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "RotatePagesForm";
			this.Text = "RotatePagesForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbPagesSubset;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.RadioButton rbPages;
		private System.Windows.Forms.RadioButton rbCurPage;
		private System.Windows.Forms.RadioButton rbAllPages;
		private System.Windows.Forms.ComboBox cbDirection;
		private System.Windows.Forms.ComboBox cbOrientation;
		private System.Windows.Forms.Label label1;
	}
}