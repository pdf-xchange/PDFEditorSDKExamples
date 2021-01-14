namespace FullDemo
{
	partial class OCRPagesForm
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ckAutoDeskew = new System.Windows.Forms.CheckBox();
			this.cbQuality = new System.Windows.Forms.ComboBox();
			this.cbOutputType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(473, 280);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "OCR Pages";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ckAutoDeskew);
			this.groupBox3.Controls.Add(this.cbQuality);
			this.groupBox3.Controls.Add(this.cbOutputType);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(6, 177);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(458, 96);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Output";
			// 
			// ckAutoDeskew
			// 
			this.ckAutoDeskew.AutoSize = true;
			this.ckAutoDeskew.Location = new System.Drawing.Point(80, 73);
			this.ckAutoDeskew.Name = "ckAutoDeskew";
			this.ckAutoDeskew.Size = new System.Drawing.Size(90, 17);
			this.ckAutoDeskew.TabIndex = 4;
			this.ckAutoDeskew.Text = "Auto Deskew";
			this.ckAutoDeskew.UseVisualStyleBackColor = true;
			// 
			// cbQuality
			// 
			this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbQuality.FormattingEnabled = true;
			this.cbQuality.Items.AddRange(new object[] {
            "Auto",
            "600",
            "400",
            "300",
            "250",
            "200",
            "150",
            "100",
            "96",
            "72"});
			this.cbQuality.Location = new System.Drawing.Point(80, 46);
			this.cbQuality.Name = "cbQuality";
			this.cbQuality.Size = new System.Drawing.Size(154, 21);
			this.cbQuality.TabIndex = 3;
			// 
			// cbOutputType
			// 
			this.cbOutputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOutputType.FormattingEnabled = true;
			this.cbOutputType.Items.AddRange(new object[] {
            "Create New Searchable PDF",
            "Preserve Original Content and Add Text Layer"});
			this.cbOutputType.Location = new System.Drawing.Point(80, 19);
			this.cbOutputType.Name = "cbOutputType";
			this.cbOutputType.Size = new System.Drawing.Size(342, 21);
			this.cbOutputType.TabIndex = 2;
			this.cbOutputType.SelectedIndexChanged += new System.EventHandler(this.cbOutputType_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Quality:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Output Type:";
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
			// rbPages
			// 
			this.rbPages.AutoSize = true;
			this.rbPages.Location = new System.Drawing.Point(17, 42);
			this.rbPages.Name = "rbPages";
			this.rbPages.Size = new System.Drawing.Size(58, 17);
			this.rbPages.TabIndex = 2;
			this.rbPages.Text = "Pages:";
			this.rbPages.UseVisualStyleBackColor = true;
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
			// OCRPagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 289);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "OCRPagesForm";
			this.Text = "OCRPagesForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox ckAutoDeskew;
		private System.Windows.Forms.ComboBox cbQuality;
		private System.Windows.Forms.ComboBox cbOutputType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}