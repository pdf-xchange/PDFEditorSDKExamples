namespace FullDemo
{
	partial class AddWatermarkForm
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
			this.tText = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.rbAllPages = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gboxOpts = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tRotation = new System.Windows.Forms.NumericUpDown();
			this.tOpacity = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTextClr = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.groupBox1.SuspendLayout();
			this.gboxOpts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tRotation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tOpacity)).BeginInit();
			this.SuspendLayout();
			// 
			// tText
			// 
			this.tText.Location = new System.Drawing.Point(65, 29);
			this.tText.Multiline = true;
			this.tText.Name = "tText";
			this.tText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tText.Size = new System.Drawing.Size(394, 38);
			this.tText.TabIndex = 3;
			this.tText.Text = "Watermark Sample";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(32, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Text:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbNumPages
			// 
			this.lbNumPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNumPages.Location = new System.Drawing.Point(234, 66);
			this.lbNumPages.Name = "lbNumPages";
			this.lbNumPages.Size = new System.Drawing.Size(153, 14);
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
			this.groupBox1.Controls.Add(this.lbNumPages);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tPages);
			this.groupBox1.Controls.Add(this.rbPages);
			this.groupBox1.Controls.Add(this.rbCurPage);
			this.groupBox1.Controls.Add(this.rbAllPages);
			this.groupBox1.Location = new System.Drawing.Point(6, 105);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 127);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pages Range";
			// 
			// gboxOpts
			// 
			this.gboxOpts.BackColor = System.Drawing.Color.Transparent;
			this.gboxOpts.Controls.Add(this.label5);
			this.gboxOpts.Controls.Add(this.label4);
			this.gboxOpts.Controls.Add(this.tRotation);
			this.gboxOpts.Controls.Add(this.tOpacity);
			this.gboxOpts.Controls.Add(this.label3);
			this.gboxOpts.Controls.Add(this.label2);
			this.gboxOpts.Controls.Add(this.label1);
			this.gboxOpts.Controls.Add(this.btnTextClr);
			this.gboxOpts.Controls.Add(this.tText);
			this.gboxOpts.Controls.Add(this.label8);
			this.gboxOpts.Controls.Add(this.groupBox1);
			this.gboxOpts.Location = new System.Drawing.Point(2, 2);
			this.gboxOpts.Name = "gboxOpts";
			this.gboxOpts.Size = new System.Drawing.Size(476, 238);
			this.gboxOpts.TabIndex = 0;
			this.gboxOpts.TabStop = false;
			this.gboxOpts.Text = "Watermark Adding Options";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(381, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "°";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(270, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Rotation:";
			// 
			// tRotation
			// 
			this.tRotation.Location = new System.Drawing.Point(323, 74);
			this.tRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.tRotation.Name = "tRotation";
			this.tRotation.Size = new System.Drawing.Size(55, 20);
			this.tRotation.TabIndex = 14;
			this.tRotation.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
			// 
			// tOpacity
			// 
			this.tOpacity.Location = new System.Drawing.Point(163, 74);
			this.tOpacity.Name = "tOpacity";
			this.tOpacity.Size = new System.Drawing.Size(64, 20);
			this.tOpacity.TabIndex = 13;
			this.tOpacity.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(227, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(15, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "%";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(114, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Opacity:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Text Color:";
			// 
			// btnTextClr
			// 
			this.btnTextClr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btnTextClr.Location = new System.Drawing.Point(65, 73);
			this.btnTextClr.Name = "btnTextClr";
			this.btnTextClr.Size = new System.Drawing.Size(36, 23);
			this.btnTextClr.TabIndex = 8;
			this.btnTextClr.UseVisualStyleBackColor = false;
			this.btnTextClr.Click += new System.EventHandler(this.btnTextClr_Click);
			// 
			// colorDialog1
			// 
			this.colorDialog1.SolidColorOnly = true;
			// 
			// AddWatermarkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 240);
			this.Controls.Add(this.gboxOpts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AddWatermarkForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxOpts.ResumeLayout(false);
			this.gboxOpts.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tRotation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tOpacity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tText;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.RadioButton rbPages;
		private System.Windows.Forms.RadioButton rbCurPage;
		private System.Windows.Forms.RadioButton rbAllPages;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox gboxOpts;
		private System.Windows.Forms.NumericUpDown tOpacity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnTextClr;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown tRotation;
	}
}