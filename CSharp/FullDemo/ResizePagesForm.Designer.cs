namespace FullDemo
{
	partial class ResizePagesForm
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbOrientation = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tWidth = new System.Windows.Forms.NumericUpDown();
			this.tHeight = new System.Windows.Forms.NumericUpDown();
			this.cbPaperName = new System.Windows.Forms.ComboBox();
			this.rbCustom = new System.Windows.Forms.RadioButton();
			this.rbStandard = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cbVOffsetFrom = new System.Windows.Forms.ComboBox();
			this.cbHOffsetFrom = new System.Windows.Forms.ComboBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.tVOffset = new System.Windows.Forms.NumericUpDown();
			this.tHOffset = new System.Windows.Forms.NumericUpDown();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ckScaleText = new System.Windows.Forms.CheckBox();
			this.ckScaleAnnotations = new System.Windows.Forms.CheckBox();
			this.ckConstraintProportions = new System.Windows.Forms.CheckBox();
			this.ckScalePage = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.lbNumPages = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tPages = new System.Windows.Forms.TextBox();
			this.rbPages = new System.Windows.Forms.RadioButton();
			this.rbCurPage = new System.Windows.Forms.RadioButton();
			this.rbAllPages = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tHeight)).BeginInit();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tVOffset)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tHOffset)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(708, 708);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Resize Pages";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbOrientation);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.tWidth);
			this.groupBox4.Controls.Add(this.tHeight);
			this.groupBox4.Controls.Add(this.cbPaperName);
			this.groupBox4.Controls.Add(this.rbCustom);
			this.groupBox4.Controls.Add(this.rbStandard);
			this.groupBox4.Location = new System.Drawing.Point(10, 29);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox4.Size = new System.Drawing.Size(682, 117);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Pages";
			// 
			// cbOrientation
			// 
			this.cbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOrientation.FormattingEnabled = true;
			this.cbOrientation.Items.AddRange(new object[] {
            "Portrait",
            "Landscape"});
			this.cbOrientation.Location = new System.Drawing.Point(474, 29);
			this.cbOrientation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbOrientation.Name = "cbOrientation";
			this.cbOrientation.Size = new System.Drawing.Size(180, 28);
			this.cbOrientation.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(294, 74);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 20);
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
			this.tWidth.Location = new System.Drawing.Point(165, 71);
			this.tWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tWidth.Maximum = new decimal(new int[] {
            14400,
            0,
            0,
            0});
			this.tWidth.Name = "tWidth";
			this.tWidth.Size = new System.Drawing.Size(120, 26);
			this.tWidth.TabIndex = 5;
			this.tWidth.Value = new decimal(new int[] {
            792,
            0,
            0,
            0});
			this.tWidth.ValueChanged += new System.EventHandler(this.tWidth_ValueChanged);
			this.tWidth.Click += new System.EventHandler(this.tWidth_Click);
			// 
			// tHeight
			// 
			this.tHeight.DecimalPlaces = 1;
			this.tHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tHeight.Location = new System.Drawing.Point(321, 71);
			this.tHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tHeight.Maximum = new decimal(new int[] {
            14400,
            0,
            0,
            0});
			this.tHeight.Name = "tHeight";
			this.tHeight.Size = new System.Drawing.Size(120, 26);
			this.tHeight.TabIndex = 4;
			this.tHeight.Value = new decimal(new int[] {
            612,
            0,
            0,
            0});
			this.tHeight.ValueChanged += new System.EventHandler(this.tHeight_ValueChanged);
			this.tHeight.Click += new System.EventHandler(this.tHeight_Click);
			// 
			// cbPaperName
			// 
			this.cbPaperName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPaperName.FormattingEnabled = true;
			this.cbPaperName.Location = new System.Drawing.Point(165, 29);
			this.cbPaperName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbPaperName.Name = "cbPaperName";
			this.cbPaperName.Size = new System.Drawing.Size(274, 28);
			this.cbPaperName.TabIndex = 3;
			this.cbPaperName.SelectedIndexChanged += new System.EventHandler(this.cbPaperName_SelectedIndexChanged);
			// 
			// rbCustom
			// 
			this.rbCustom.AutoSize = true;
			this.rbCustom.Location = new System.Drawing.Point(36, 71);
			this.rbCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rbCustom.Name = "rbCustom";
			this.rbCustom.Size = new System.Drawing.Size(93, 24);
			this.rbCustom.TabIndex = 2;
			this.rbCustom.Text = "Custom:";
			this.rbCustom.UseVisualStyleBackColor = true;
			this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
			// 
			// rbStandard
			// 
			this.rbStandard.AutoSize = true;
			this.rbStandard.Location = new System.Drawing.Point(36, 31);
			this.rbStandard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rbStandard.Name = "rbStandard";
			this.rbStandard.Size = new System.Drawing.Size(104, 24);
			this.rbStandard.TabIndex = 1;
			this.rbStandard.Text = "Standard:";
			this.rbStandard.UseVisualStyleBackColor = true;
			this.rbStandard.CheckedChanged += new System.EventHandler(this.rbStandard_CheckedChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cbVOffsetFrom);
			this.groupBox6.Controls.Add(this.cbHOffsetFrom);
			this.groupBox6.Controls.Add(this.label22);
			this.groupBox6.Controls.Add(this.label21);
			this.groupBox6.Controls.Add(this.tVOffset);
			this.groupBox6.Controls.Add(this.tHOffset);
			this.groupBox6.Controls.Add(this.label20);
			this.groupBox6.Controls.Add(this.label19);
			this.groupBox6.Location = new System.Drawing.Point(10, 155);
			this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox6.Size = new System.Drawing.Size(688, 118);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Placement Options";
			// 
			// cbVOffsetFrom
			// 
			this.cbVOffsetFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVOffsetFrom.FormattingEnabled = true;
			this.cbVOffsetFrom.Location = new System.Drawing.Point(474, 69);
			this.cbVOffsetFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbVOffsetFrom.Name = "cbVOffsetFrom";
			this.cbVOffsetFrom.Size = new System.Drawing.Size(180, 28);
			this.cbVOffsetFrom.TabIndex = 7;
			// 
			// cbHOffsetFrom
			// 
			this.cbHOffsetFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHOffsetFrom.FormattingEnabled = true;
			this.cbHOffsetFrom.Location = new System.Drawing.Point(474, 28);
			this.cbHOffsetFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbHOffsetFrom.Name = "cbHOffsetFrom";
			this.cbHOffsetFrom.Size = new System.Drawing.Size(180, 28);
			this.cbHOffsetFrom.TabIndex = 6;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(420, 74);
			this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(45, 20);
			this.label22.TabIndex = 5;
			this.label22.Text = "from:";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(420, 32);
			this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(45, 20);
			this.label21.TabIndex = 4;
			this.label21.Text = "from:";
			// 
			// tVOffset
			// 
			this.tVOffset.DecimalPlaces = 1;
			this.tVOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tVOffset.Location = new System.Drawing.Point(186, 69);
			this.tVOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tVOffset.Name = "tVOffset";
			this.tVOffset.Size = new System.Drawing.Size(96, 26);
			this.tVOffset.TabIndex = 3;
			// 
			// tHOffset
			// 
			this.tHOffset.DecimalPlaces = 1;
			this.tHOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tHOffset.Location = new System.Drawing.Point(186, 29);
			this.tHOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tHOffset.Name = "tHOffset";
			this.tHOffset.Size = new System.Drawing.Size(96, 26);
			this.tHOffset.TabIndex = 2;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(63, 72);
			this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(114, 20);
			this.label20.TabIndex = 1;
			this.label20.Text = "Vertical Offset:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(45, 32);
			this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(133, 20);
			this.label19.TabIndex = 0;
			this.label19.Text = "Horizontal Offset:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ckScaleText);
			this.groupBox3.Controls.Add(this.ckScaleAnnotations);
			this.groupBox3.Controls.Add(this.ckConstraintProportions);
			this.groupBox3.Controls.Add(this.ckScalePage);
			this.groupBox3.Location = new System.Drawing.Point(10, 523);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox3.Size = new System.Drawing.Size(688, 172);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Content Scale Options";
			// 
			// ckScaleText
			// 
			this.ckScaleText.AutoSize = true;
			this.ckScaleText.Checked = true;
			this.ckScaleText.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckScaleText.Enabled = false;
			this.ckScaleText.Location = new System.Drawing.Point(80, 135);
			this.ckScaleText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ckScaleText.Name = "ckScaleText";
			this.ckScaleText.Size = new System.Drawing.Size(307, 24);
			this.ckScaleText.TabIndex = 3;
			this.ckScaleText.Text = "Scale text in comments and form fields";
			this.ckScaleText.UseVisualStyleBackColor = true;
			// 
			// ckScaleAnnotations
			// 
			this.ckScaleAnnotations.AutoSize = true;
			this.ckScaleAnnotations.Checked = true;
			this.ckScaleAnnotations.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckScaleAnnotations.Enabled = false;
			this.ckScaleAnnotations.Location = new System.Drawing.Point(52, 100);
			this.ckScaleAnnotations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ckScaleAnnotations.Name = "ckScaleAnnotations";
			this.ckScaleAnnotations.Size = new System.Drawing.Size(261, 24);
			this.ckScaleAnnotations.TabIndex = 2;
			this.ckScaleAnnotations.Text = "Scale comments and form fields";
			this.ckScaleAnnotations.UseVisualStyleBackColor = true;
			this.ckScaleAnnotations.CheckedChanged += new System.EventHandler(this.ckScaleAnnotations_CheckedChanged);
			// 
			// ckConstraintProportions
			// 
			this.ckConstraintProportions.AutoSize = true;
			this.ckConstraintProportions.Checked = true;
			this.ckConstraintProportions.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckConstraintProportions.Enabled = false;
			this.ckConstraintProportions.Location = new System.Drawing.Point(52, 65);
			this.ckConstraintProportions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ckConstraintProportions.Name = "ckConstraintProportions";
			this.ckConstraintProportions.Size = new System.Drawing.Size(217, 24);
			this.ckConstraintProportions.TabIndex = 1;
			this.ckConstraintProportions.Text = "Keep content aspect ratio";
			this.ckConstraintProportions.UseVisualStyleBackColor = true;
			// 
			// ckScalePage
			// 
			this.ckScalePage.AutoSize = true;
			this.ckScalePage.Location = new System.Drawing.Point(26, 29);
			this.ckScalePage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ckScalePage.Name = "ckScalePage";
			this.ckScalePage.Size = new System.Drawing.Size(351, 24);
			this.ckScalePage.TabIndex = 0;
			this.ckScalePage.Text = "Scale page content according new page size";
			this.ckScalePage.UseVisualStyleBackColor = true;
			this.ckScalePage.CheckedChanged += new System.EventHandler(this.ckScalePage_CheckedChanged);
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
			this.groupBox2.Controls.Add(this.rbAllPages);
			this.groupBox2.Location = new System.Drawing.Point(10, 283);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Size = new System.Drawing.Size(688, 231);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pages Range";
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
			// ResizePagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(718, 711);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "ResizePagesForm";
			this.Text = "ResizePagesForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tHeight)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tVOffset)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tHOffset)).EndInit();
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
		private System.Windows.Forms.RadioButton rbAllPages;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox ckScaleText;
		private System.Windows.Forms.CheckBox ckScaleAnnotations;
		private System.Windows.Forms.CheckBox ckConstraintProportions;
		private System.Windows.Forms.CheckBox ckScalePage;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.ComboBox cbVOffsetFrom;
		private System.Windows.Forms.ComboBox cbHOffsetFrom;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.NumericUpDown tVOffset;
		private System.Windows.Forms.NumericUpDown tHOffset;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbOrientation;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown tWidth;
		private System.Windows.Forms.NumericUpDown tHeight;
		private System.Windows.Forms.ComboBox cbPaperName;
		private System.Windows.Forms.RadioButton rbCustom;
		private System.Windows.Forms.RadioButton rbStandard;
	}
}