namespace FullDemo
{
	partial class CropPages
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ckAdjustMedia = new System.Windows.Forms.CheckBox();
			this.ckBleed = new System.Windows.Forms.CheckBox();
			this.ckArt = new System.Windows.Forms.CheckBox();
			this.CkTrim = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ckCrop = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tLeft = new System.Windows.Forms.NumericUpDown();
			this.tTop = new System.Windows.Forms.NumericUpDown();
			this.tRight = new System.Windows.Forms.NumericUpDown();
			this.tBottom = new System.Windows.Forms.NumericUpDown();
			this.cbBox = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnToZero = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cbCropMethod = new System.Windows.Forms.ComboBox();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tBottom)).BeginInit();
			this.SuspendLayout();
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
			this.groupBox2.Location = new System.Drawing.Point(7, 278);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(457, 129);
			this.groupBox2.TabIndex = 9;
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(5, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(470, 412);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Crop Pages";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.cbCropMethod);
			this.groupBox3.Location = new System.Drawing.Point(7, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(457, 253);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Crop Margins";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.ckAdjustMedia);
			this.groupBox4.Controls.Add(this.ckBleed);
			this.groupBox4.Controls.Add(this.ckArt);
			this.groupBox4.Controls.Add(this.CkTrim);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.ckCrop);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.tLeft);
			this.groupBox4.Controls.Add(this.tTop);
			this.groupBox4.Controls.Add(this.tRight);
			this.groupBox4.Controls.Add(this.tBottom);
			this.groupBox4.Controls.Add(this.cbBox);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.btnToZero);
			this.groupBox4.Location = new System.Drawing.Point(6, 46);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(445, 199);
			this.groupBox4.TabIndex = 23;
			this.groupBox4.TabStop = false;
			// 
			// ckAdjustMedia
			// 
			this.ckAdjustMedia.AutoSize = true;
			this.ckAdjustMedia.Location = new System.Drawing.Point(86, 127);
			this.ckAdjustMedia.Name = "ckAdjustMedia";
			this.ckAdjustMedia.Size = new System.Drawing.Size(303, 17);
			this.ckAdjustMedia.TabIndex = 29;
			this.ckAdjustMedia.Text = "Adjust size of the pages` Media Box to the size of Crop Box";
			this.ckAdjustMedia.UseVisualStyleBackColor = true;
			// 
			// ckBleed
			// 
			this.ckBleed.AutoSize = true;
			this.ckBleed.Location = new System.Drawing.Point(86, 173);
			this.ckBleed.Name = "ckBleed";
			this.ckBleed.Size = new System.Drawing.Size(53, 17);
			this.ckBleed.TabIndex = 28;
			this.ckBleed.Text = "Bleed";
			this.ckBleed.UseVisualStyleBackColor = true;
			// 
			// ckArt
			// 
			this.ckArt.AutoSize = true;
			this.ckArt.Location = new System.Drawing.Point(206, 173);
			this.ckArt.Name = "ckArt";
			this.ckArt.Size = new System.Drawing.Size(39, 17);
			this.ckArt.TabIndex = 27;
			this.ckArt.Text = "Art";
			this.ckArt.UseVisualStyleBackColor = true;
			// 
			// CkTrim
			// 
			this.CkTrim.AutoSize = true;
			this.CkTrim.Location = new System.Drawing.Point(206, 150);
			this.CkTrim.Name = "CkTrim";
			this.CkTrim.Size = new System.Drawing.Size(46, 17);
			this.CkTrim.TabIndex = 26;
			this.CkTrim.Text = "Trim";
			this.CkTrim.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 151);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(68, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Change Box:";
			// 
			// ckCrop
			// 
			this.ckCrop.AutoSize = true;
			this.ckCrop.Location = new System.Drawing.Point(86, 150);
			this.ckCrop.Name = "ckCrop";
			this.ckCrop.Size = new System.Drawing.Size(48, 17);
			this.ckCrop.TabIndex = 24;
			this.ckCrop.Text = "Crop";
			this.ckCrop.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Left:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(50, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Top:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(260, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Right:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(252, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Bottom:";
			// 
			// tLeft
			// 
			this.tLeft.DecimalPlaces = 1;
			this.tLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tLeft.Location = new System.Drawing.Point(87, 46);
			this.tLeft.Name = "tLeft";
			this.tLeft.Size = new System.Drawing.Size(120, 20);
			this.tLeft.TabIndex = 14;
			// 
			// tTop
			// 
			this.tTop.DecimalPlaces = 1;
			this.tTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tTop.Location = new System.Drawing.Point(87, 72);
			this.tTop.Name = "tTop";
			this.tTop.Size = new System.Drawing.Size(120, 20);
			this.tTop.TabIndex = 15;
			// 
			// tRight
			// 
			this.tRight.DecimalPlaces = 1;
			this.tRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tRight.Location = new System.Drawing.Point(305, 46);
			this.tRight.Name = "tRight";
			this.tRight.Size = new System.Drawing.Size(120, 20);
			this.tRight.TabIndex = 16;
			// 
			// tBottom
			// 
			this.tBottom.DecimalPlaces = 1;
			this.tBottom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tBottom.Location = new System.Drawing.Point(305, 72);
			this.tBottom.Name = "tBottom";
			this.tBottom.Size = new System.Drawing.Size(120, 20);
			this.tBottom.TabIndex = 17;
			// 
			// cbBox
			// 
			this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBox.FormattingEnabled = true;
			this.cbBox.Items.AddRange(new object[] {
            "Crop",
            "Bleed",
            "Trim",
            "Art"});
			this.cbBox.Location = new System.Drawing.Point(86, 19);
			this.cbBox.Name = "cbBox";
			this.cbBox.Size = new System.Drawing.Size(121, 21);
			this.cbBox.TabIndex = 19;
			this.cbBox.DropDown += new System.EventHandler(this.cbBox_DropDown);
			this.cbBox.DropDownClosed += new System.EventHandler(this.cbBox_DropDownClosed);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Apply to Box:";
			// 
			// btnToZero
			// 
			this.btnToZero.Location = new System.Drawing.Point(87, 98);
			this.btnToZero.Name = "btnToZero";
			this.btnToZero.Size = new System.Drawing.Size(120, 23);
			this.btnToZero.TabIndex = 22;
			this.btnToZero.Text = "Set to Zero";
			this.btnToZero.UseVisualStyleBackColor = true;
			this.btnToZero.Click += new System.EventHandler(this.btnToZero_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 20;
			this.label5.Text = "Crop Method:";
			// 
			// cbCropMethod
			// 
			this.cbCropMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCropMethod.FormattingEnabled = true;
			this.cbCropMethod.Items.AddRange(new object[] {
            "Manual Mergin Control",
            "Remove All White Space",
            "Remove Verticale White Space",
            "Remove Horizontale White Space"});
			this.cbCropMethod.Location = new System.Drawing.Point(92, 19);
			this.cbCropMethod.Name = "cbCropMethod";
			this.cbCropMethod.Size = new System.Drawing.Size(339, 21);
			this.cbCropMethod.TabIndex = 18;
			this.cbCropMethod.SelectedIndexChanged += new System.EventHandler(this.cbCropMethod_SelectedIndexChanged);
			// 
			// CropPages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 418);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CropPages";
			this.Text = "CropPages";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tBottom)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbPagesSubset;
		private System.Windows.Forms.Label lbNumPages;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tPages;
		private System.Windows.Forms.RadioButton rbPages;
		private System.Windows.Forms.RadioButton rbCurPage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.NumericUpDown tBottom;
		private System.Windows.Forms.NumericUpDown tRight;
		private System.Windows.Forms.NumericUpDown tTop;
		private System.Windows.Forms.NumericUpDown tLeft;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbBox;
		private System.Windows.Forms.ComboBox cbCropMethod;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnToZero;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox ckBleed;
		private System.Windows.Forms.CheckBox ckArt;
		private System.Windows.Forms.CheckBox CkTrim;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox ckCrop;
		private System.Windows.Forms.CheckBox ckAdjustMedia;
	}
}