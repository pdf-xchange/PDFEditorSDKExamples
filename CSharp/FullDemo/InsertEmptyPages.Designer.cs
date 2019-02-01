namespace FullDemo
{
	partial class InsertEmptyPages
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
			this.lbNumPage = new System.Windows.Forms.Label();
			this.tNumPage = new System.Windows.Forms.NumericUpDown();
			this.rbPage = new System.Windows.Forms.RadioButton();
			this.rbLast = new System.Windows.Forms.RadioButton();
			this.rbFirst = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.cbLocation = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tCountPages = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.cbOrientation = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tWidth = new System.Windows.Forms.NumericUpDown();
			this.tHeight = new System.Windows.Forms.NumericUpDown();
			this.cbPaperName = new System.Windows.Forms.ComboBox();
			this.rbCustom = new System.Windows.Forms.RadioButton();
			this.rbStandard = new System.Windows.Forms.RadioButton();
			this.rbDocument = new System.Windows.Forms.RadioButton();
			this.lbDocumentSize = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNumPage)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tCountPages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Location = new System.Drawing.Point(3, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(474, 303);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Insert Empty Pages";
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
			this.groupBox3.Location = new System.Drawing.Point(9, 179);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(455, 115);
			this.groupBox3.TabIndex = 10;
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
			this.tNumPage.ValueChanged += new System.EventHandler(this.tNumPage_ValueChanged);
			this.tNumPage.Click += new System.EventHandler(this.tNumPage_Click);
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
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.lbDocumentSize);
			this.groupBox4.Controls.Add(this.tCountPages);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.cbOrientation);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.tWidth);
			this.groupBox4.Controls.Add(this.tHeight);
			this.groupBox4.Controls.Add(this.cbPaperName);
			this.groupBox4.Controls.Add(this.rbCustom);
			this.groupBox4.Controls.Add(this.rbStandard);
			this.groupBox4.Controls.Add(this.rbDocument);
			this.groupBox4.Location = new System.Drawing.Point(9, 19);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(455, 154);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Pages";
			// 
			// tCountPages
			// 
			this.tCountPages.Location = new System.Drawing.Point(110, 121);
			this.tCountPages.Name = "tCountPages";
			this.tCountPages.Size = new System.Drawing.Size(80, 20);
			this.tCountPages.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(66, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Count:";
			// 
			// cbOrientation
			// 
			this.cbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOrientation.FormattingEnabled = true;
			this.cbOrientation.Items.AddRange(new object[] {
            "Portrait",
            "Landscape"});
			this.cbOrientation.Location = new System.Drawing.Point(110, 94);
			this.cbOrientation.Name = "cbOrientation";
			this.cbOrientation.Size = new System.Drawing.Size(184, 21);
			this.cbOrientation.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(43, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Orientation:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "x";
			// 
			// tWidth
			// 
			this.tWidth.DecimalPlaces = 1;
			this.tWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tWidth.Location = new System.Drawing.Point(110, 68);
			this.tWidth.Maximum = new decimal(new int[] {
            14400,
            0,
            0,
            0});
			this.tWidth.Name = "tWidth";
			this.tWidth.Size = new System.Drawing.Size(80, 20);
			this.tWidth.TabIndex = 5;
			this.tWidth.Value = new decimal(new int[] {
            792,
            0,
            0,
            0});
			this.tWidth.ValueChanged += new System.EventHandler(this.tWidth_ValueChanged);
			this.tWidth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tWidth_MouseClick);
			// 
			// tHeight
			// 
			this.tHeight.DecimalPlaces = 1;
			this.tHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tHeight.Location = new System.Drawing.Point(214, 68);
			this.tHeight.Maximum = new decimal(new int[] {
            14400,
            0,
            0,
            0});
			this.tHeight.Name = "tHeight";
			this.tHeight.Size = new System.Drawing.Size(80, 20);
			this.tHeight.TabIndex = 4;
			this.tHeight.Value = new decimal(new int[] {
            612,
            0,
            0,
            0});
			this.tHeight.ValueChanged += new System.EventHandler(this.tHeight_ValueChanged);
			this.tHeight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tHeight_MouseClick);
			// 
			// cbPaperName
			// 
			this.cbPaperName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPaperName.FormattingEnabled = true;
			this.cbPaperName.Location = new System.Drawing.Point(110, 41);
			this.cbPaperName.Name = "cbPaperName";
			this.cbPaperName.Size = new System.Drawing.Size(184, 21);
			this.cbPaperName.TabIndex = 3;
			this.cbPaperName.DropDown += new System.EventHandler(this.cbPaperName_DropDown);
			this.cbPaperName.SelectedIndexChanged += new System.EventHandler(this.cbPaperName_SelectedIndexChanged);
			// 
			// rbCustom
			// 
			this.rbCustom.AutoSize = true;
			this.rbCustom.Location = new System.Drawing.Point(24, 68);
			this.rbCustom.Name = "rbCustom";
			this.rbCustom.Size = new System.Drawing.Size(63, 17);
			this.rbCustom.TabIndex = 2;
			this.rbCustom.Text = "Custom:";
			this.rbCustom.UseVisualStyleBackColor = true;
			// 
			// rbStandard
			// 
			this.rbStandard.AutoSize = true;
			this.rbStandard.Location = new System.Drawing.Point(24, 42);
			this.rbStandard.Name = "rbStandard";
			this.rbStandard.Size = new System.Drawing.Size(71, 17);
			this.rbStandard.TabIndex = 1;
			this.rbStandard.Text = "Standard:";
			this.rbStandard.UseVisualStyleBackColor = true;
			// 
			// rbDocument
			// 
			this.rbDocument.AutoSize = true;
			this.rbDocument.Checked = true;
			this.rbDocument.Location = new System.Drawing.Point(24, 19);
			this.rbDocument.Name = "rbDocument";
			this.rbDocument.Size = new System.Drawing.Size(77, 17);
			this.rbDocument.TabIndex = 0;
			this.rbDocument.TabStop = true;
			this.rbDocument.Text = "Document:";
			this.rbDocument.UseVisualStyleBackColor = true;
			this.rbDocument.Click += new System.EventHandler(this.rbDocument_Click);
			// 
			// lbDocumentSize
			// 
			this.lbDocumentSize.AutoSize = true;
			this.lbDocumentSize.Enabled = false;
			this.lbDocumentSize.Location = new System.Drawing.Point(107, 21);
			this.lbDocumentSize.Name = "lbDocumentSize";
			this.lbDocumentSize.Size = new System.Drawing.Size(60, 13);
			this.lbDocumentSize.TabIndex = 11;
			this.lbDocumentSize.Text = "(612 x 792)";
			// 
			// InsertEmptyPages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 312);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "InsertEmptyPages";
			this.Text = "InsertEmptyPages";
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNumPage)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tCountPages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tHeight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.NumericUpDown tCountPages;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbOrientation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown tWidth;
		private System.Windows.Forms.NumericUpDown tHeight;
		private System.Windows.Forms.ComboBox cbPaperName;
		private System.Windows.Forms.RadioButton rbCustom;
		private System.Windows.Forms.RadioButton rbStandard;
		private System.Windows.Forms.RadioButton rbDocument;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lbNumPage;
		private System.Windows.Forms.NumericUpDown tNumPage;
		private System.Windows.Forms.RadioButton rbPage;
		private System.Windows.Forms.RadioButton rbLast;
		private System.Windows.Forms.RadioButton rbFirst;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbLocation;
		private System.Windows.Forms.Label lbDocumentSize;
	}
}