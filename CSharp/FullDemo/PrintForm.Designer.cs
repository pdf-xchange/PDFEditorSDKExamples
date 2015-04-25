namespace FullDemo
{
	partial class PrintForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.ckSheetsRevOrder = new System.Windows.Forms.CheckBox();
			this.tSheets = new System.Windows.Forms.TextBox();
			this.rbSheets = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.rbAllSheets = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.cbClrOver = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbPrintDocFilter = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ckAsImage = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbPagesScale = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbDuplex = new System.Windows.Forms.ComboBox();
			this.ckCollate = new System.Windows.Forms.CheckBox();
			this.tCopies = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.ckPagesRevOrder = new System.Windows.Forms.CheckBox();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.rbAllPages = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cbPrinter = new System.Windows.Forms.ComboBox();
			this.gboxOpts = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.gboxOpts.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(77, 427);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(342, 30);
			this.label1.TabIndex = 21;
			this.label1.Text = "Type sheet numbers and/or page ranges separated by commas counting from the start" +
    " of the document. For example, type 1, 3, 5-12";
			// 
			// ckSheetsRevOrder
			// 
			this.ckSheetsRevOrder.AutoSize = true;
			this.ckSheetsRevOrder.Location = new System.Drawing.Point(243, 407);
			this.ckSheetsRevOrder.Name = "ckSheetsRevOrder";
			this.ckSheetsRevOrder.Size = new System.Drawing.Size(101, 17);
			this.ckSheetsRevOrder.TabIndex = 20;
			this.ckSheetsRevOrder.Text = "Reversed Order";
			this.ckSheetsRevOrder.UseVisualStyleBackColor = true;
			// 
			// tSheets
			// 
			this.tSheets.Location = new System.Drawing.Point(81, 404);
			this.tSheets.Name = "tSheets";
			this.tSheets.Size = new System.Drawing.Size(154, 20);
			this.tSheets.TabIndex = 19;
			this.tSheets.TextChanged += new System.EventHandler(this.tSheets_TextChanged);
			// 
			// rbSheets
			// 
			this.rbSheets.AutoSize = true;
			this.rbSheets.Location = new System.Drawing.Point(17, 406);
			this.rbSheets.Name = "rbSheets";
			this.rbSheets.Size = new System.Drawing.Size(61, 17);
			this.rbSheets.TabIndex = 18;
			this.rbSheets.Text = "Sheets:";
			this.rbSheets.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 357);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Sheets Output:";
			// 
			// rbAllSheets
			// 
			this.rbAllSheets.AutoSize = true;
			this.rbAllSheets.Checked = true;
			this.rbAllSheets.Location = new System.Drawing.Point(17, 383);
			this.rbAllSheets.Name = "rbAllSheets";
			this.rbAllSheets.Size = new System.Drawing.Size(70, 17);
			this.rbAllSheets.TabIndex = 17;
			this.rbAllSheets.TabStop = true;
			this.rbAllSheets.Text = "All sheets";
			this.rbAllSheets.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(94, 364);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(365, 2);
			this.label3.TabIndex = 16;
			// 
			// cbClrOver
			// 
			this.cbClrOver.FormattingEnabled = true;
			this.cbClrOver.Items.AddRange(new object[] {
            "Auto",
            "Grayscale",
            "Monochrome"});
			this.cbClrOver.Location = new System.Drawing.Point(104, 305);
			this.cbClrOver.Name = "cbClrOver";
			this.cbClrOver.Size = new System.Drawing.Size(164, 21);
			this.cbClrOver.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 308);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Colors Override:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbPrintDocFilter
			// 
			this.cbPrintDocFilter.FormattingEnabled = true;
			this.cbPrintDocFilter.Location = new System.Drawing.Point(104, 278);
			this.cbPrintDocFilter.Name = "cbPrintDocFilter";
			this.cbPrintDocFilter.Size = new System.Drawing.Size(219, 21);
			this.cbPrintDocFilter.Sorted = true;
			this.cbPrintDocFilter.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(72, 281);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Print:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ckAsImage
			// 
			this.ckAsImage.AutoSize = true;
			this.ckAsImage.Location = new System.Drawing.Point(104, 332);
			this.ckAsImage.Name = "ckAsImage";
			this.ckAsImage.Size = new System.Drawing.Size(97, 17);
			this.ckAsImage.TabIndex = 14;
			this.ckAsImage.Text = "Print as images";
			this.ckAsImage.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 254);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Pages  scaling:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbPagesScale
			// 
			this.cbPagesScale.FormattingEnabled = true;
			this.cbPagesScale.Location = new System.Drawing.Point(104, 251);
			this.cbPagesScale.Name = "cbPagesScale";
			this.cbPagesScale.Size = new System.Drawing.Size(219, 21);
			this.cbPagesScale.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(235, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Duplex:";
			// 
			// cbDuplex
			// 
			this.cbDuplex.FormattingEnabled = true;
			this.cbDuplex.Items.AddRange(new object[] {
            "Auto",
            "None",
            "Long Edge",
            "Short Edge"});
			this.cbDuplex.Location = new System.Drawing.Point(282, 44);
			this.cbDuplex.Name = "cbDuplex";
			this.cbDuplex.Size = new System.Drawing.Size(100, 21);
			this.cbDuplex.TabIndex = 6;
			// 
			// ckCollate
			// 
			this.ckCollate.AutoSize = true;
			this.ckCollate.Location = new System.Drawing.Point(126, 46);
			this.ckCollate.Name = "ckCollate";
			this.ckCollate.Size = new System.Drawing.Size(58, 17);
			this.ckCollate.TabIndex = 4;
			this.ckCollate.Text = "Collate";
			this.ckCollate.UseVisualStyleBackColor = true;
			// 
			// tCopies
			// 
			this.tCopies.Location = new System.Drawing.Point(65, 44);
			this.tCopies.Name = "tCopies";
			this.tCopies.Size = new System.Drawing.Size(55, 20);
			this.tCopies.TabIndex = 3;
			this.tCopies.Text = "1";
			this.tCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(20, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Copies:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ckPagesRevOrder
			// 
			this.ckPagesRevOrder.AutoSize = true;
			this.ckPagesRevOrder.Location = new System.Drawing.Point(276, 125);
			this.ckPagesRevOrder.Name = "ckPagesRevOrder";
			this.ckPagesRevOrder.Size = new System.Drawing.Size(101, 17);
			this.ckPagesRevOrder.TabIndex = 8;
			this.ckPagesRevOrder.Text = "Reversed Order";
			this.ckPagesRevOrder.UseVisualStyleBackColor = true;
			// 
			// cbPagesSubset
			// 
			this.cbPagesSubset.FormattingEnabled = true;
			this.cbPagesSubset.Items.AddRange(new object[] {
            "All",
            "Odd",
            "Even"});
			this.cbPagesSubset.Location = new System.Drawing.Point(80, 123);
			this.cbPagesSubset.Name = "cbPagesSubset";
			this.cbPagesSubset.Size = new System.Drawing.Size(154, 21);
			this.cbPagesSubset.TabIndex = 7;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(32, 127);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Subset:";
			// 
			// lbNumPages
			// 
			this.lbNumPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNumPages.Location = new System.Drawing.Point(236, 66);
			this.lbNumPages.Name = "lbNumPages";
			this.lbNumPages.Size = new System.Drawing.Size(142, 14);
			this.lbNumPages.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(80, 86);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(342, 30);
			this.label11.TabIndex = 5;
			this.label11.Text = "Type page numbers and/or page ranges separated by commas counting from the start " +
    "of the document. For example, type 1, 3, 5-12";
			// 
			// tPages
			// 
			this.tPages.Location = new System.Drawing.Point(80, 63);
			this.tPages.Name = "tPages";
			this.tPages.Size = new System.Drawing.Size(154, 20);
			this.tPages.TabIndex = 3;
			this.tPages.TextChanged += new System.EventHandler(this.tPages_TextChanged);
			// 
			// rbPages
			// 
			this.rbPages.AutoSize = true;
			this.rbPages.Location = new System.Drawing.Point(17, 65);
			this.rbPages.Name = "rbPages";
			this.rbPages.Size = new System.Drawing.Size(58, 17);
			this.rbPages.TabIndex = 2;
			this.rbPages.Text = "Pages:";
			this.rbPages.UseVisualStyleBackColor = true;
			// 
			// rbCurPage
			// 
			this.rbCurPage.AutoSize = true;
			this.rbCurPage.Location = new System.Drawing.Point(17, 43);
			this.rbCurPage.Name = "rbCurPage";
			this.rbCurPage.Size = new System.Drawing.Size(86, 17);
			this.rbCurPage.TabIndex = 1;
			this.rbCurPage.Text = "Current page";
			this.rbCurPage.UseVisualStyleBackColor = true;
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
			this.groupBox1.Controls.Add(this.ckPagesRevOrder);
			this.groupBox1.Controls.Add(this.cbPagesSubset);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.lbNumPages);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tPages);
			this.groupBox1.Controls.Add(this.rbPages);
			this.groupBox1.Controls.Add(this.rbCurPage);
			this.groupBox1.Controls.Add(this.rbAllPages);
			this.groupBox1.Location = new System.Drawing.Point(6, 73);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 151);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pages Range";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(22, 21);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(40, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Printer:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbPrinter
			// 
			this.cbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPrinter.FormattingEnabled = true;
			this.cbPrinter.Location = new System.Drawing.Point(65, 18);
			this.cbPrinter.Name = "cbPrinter";
			this.cbPrinter.Size = new System.Drawing.Size(318, 21);
			this.cbPrinter.TabIndex = 1;
			// 
			// gboxOpts
			// 
			this.gboxOpts.BackColor = System.Drawing.Color.Transparent;
			this.gboxOpts.Controls.Add(this.label1);
			this.gboxOpts.Controls.Add(this.ckSheetsRevOrder);
			this.gboxOpts.Controls.Add(this.tSheets);
			this.gboxOpts.Controls.Add(this.rbSheets);
			this.gboxOpts.Controls.Add(this.label2);
			this.gboxOpts.Controls.Add(this.rbAllSheets);
			this.gboxOpts.Controls.Add(this.label3);
			this.gboxOpts.Controls.Add(this.cbClrOver);
			this.gboxOpts.Controls.Add(this.label4);
			this.gboxOpts.Controls.Add(this.cbPrintDocFilter);
			this.gboxOpts.Controls.Add(this.label5);
			this.gboxOpts.Controls.Add(this.ckAsImage);
			this.gboxOpts.Controls.Add(this.label6);
			this.gboxOpts.Controls.Add(this.cbPagesScale);
			this.gboxOpts.Controls.Add(this.label7);
			this.gboxOpts.Controls.Add(this.cbDuplex);
			this.gboxOpts.Controls.Add(this.ckCollate);
			this.gboxOpts.Controls.Add(this.tCopies);
			this.gboxOpts.Controls.Add(this.label8);
			this.gboxOpts.Controls.Add(this.groupBox1);
			this.gboxOpts.Controls.Add(this.label12);
			this.gboxOpts.Controls.Add(this.cbPrinter);
			this.gboxOpts.Location = new System.Drawing.Point(2, 2);
			this.gboxOpts.Name = "gboxOpts";
			this.gboxOpts.Size = new System.Drawing.Size(476, 460);
			this.gboxOpts.TabIndex = 0;
			this.gboxOpts.TabStop = false;
			this.gboxOpts.Text = "Print Options";
			// 
			// PrintForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(480, 463);
			this.Controls.Add(this.gboxOpts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "PrintForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxOpts.ResumeLayout(false);
			this.gboxOpts.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox ckSheetsRevOrder;
		private System.Windows.Forms.TextBox tSheets;
		private System.Windows.Forms.RadioButton rbSheets;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbAllSheets;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbClrOver;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbPrintDocFilter;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox ckAsImage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbPagesScale;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbDuplex;
		private System.Windows.Forms.CheckBox ckCollate;
		private System.Windows.Forms.TextBox tCopies;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox ckPagesRevOrder;
		private System.Windows.Forms.ComboBox cbPagesSubset;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.RadioButton rbPages;
		private System.Windows.Forms.RadioButton rbCurPage;
		private System.Windows.Forms.RadioButton rbAllPages;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cbPrinter;
		private System.Windows.Forms.GroupBox gboxOpts;
	}
}