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
			this.label9 = new System.Windows.Forms.Label();
			this.cbPagesSubset = new System.Windows.Forms.ComboBox();
			this.gboxOpts = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.ckAsBackground = new System.Windows.Forms.CheckBox();
			this.cbVOffsetFrom = new System.Windows.Forms.ComboBox();
			this.cbHOffsetFrom = new System.Windows.Forms.ComboBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.tVOffset = new System.Windows.Forms.NumericUpDown();
			this.tHOffset = new System.Windows.Forms.NumericUpDown();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnFontName = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.cbAlign = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tStrokeWidth = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.btnStrokeClr = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFillClr = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.lbNumPgs = new System.Windows.Forms.Label();
			this.tNumPage = new System.Windows.Forms.NumericUpDown();
			this.tPath = new System.Windows.Forms.TextBox();
			this.btnOpnFolder = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.ckScaleRelative = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tScale = new System.Windows.Forms.NumericUpDown();
			this.tRotation = new System.Windows.Forms.NumericUpDown();
			this.tOpacity = new System.Windows.Forms.NumericUpDown();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.gboxOpts.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tVOffset)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tHOffset)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tStrokeWidth)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNumPage)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tRotation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tOpacity)).BeginInit();
			this.SuspendLayout();
			// 
			// tText
			// 
			this.tText.Location = new System.Drawing.Point(53, 17);
			this.tText.Multiline = true;
			this.tText.Name = "tText";
			this.tText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tText.Size = new System.Drawing.Size(378, 36);
			this.tText.TabIndex = 3;
			this.tText.Text = "Watermark Sample";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 22);
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
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.cbPagesSubset);
			this.groupBox1.Controls.Add(this.lbNumPages);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tPages);
			this.groupBox1.Controls.Add(this.rbPages);
			this.groupBox1.Controls.Add(this.rbCurPage);
			this.groupBox1.Controls.Add(this.rbAllPages);
			this.groupBox1.Location = new System.Drawing.Point(6, 371);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 158);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pages Range";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(32, 122);
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
			this.cbPagesSubset.Location = new System.Drawing.Point(80, 119);
			this.cbPagesSubset.Name = "cbPagesSubset";
			this.cbPagesSubset.Size = new System.Drawing.Size(154, 21);
			this.cbPagesSubset.TabIndex = 7;
			// 
			// gboxOpts
			// 
			this.gboxOpts.BackColor = System.Drawing.Color.Transparent;
			this.gboxOpts.Controls.Add(this.groupBox6);
			this.gboxOpts.Controls.Add(this.groupBox3);
			this.gboxOpts.Controls.Add(this.groupBox2);
			this.gboxOpts.Controls.Add(this.groupBox1);
			this.gboxOpts.Location = new System.Drawing.Point(2, 2);
			this.gboxOpts.Name = "gboxOpts";
			this.gboxOpts.Size = new System.Drawing.Size(476, 538);
			this.gboxOpts.TabIndex = 0;
			this.gboxOpts.TabStop = false;
			this.gboxOpts.Text = "Watermark Adding Options";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.ckAsBackground);
			this.groupBox6.Controls.Add(this.cbVOffsetFrom);
			this.groupBox6.Controls.Add(this.cbHOffsetFrom);
			this.groupBox6.Controls.Add(this.label22);
			this.groupBox6.Controls.Add(this.label21);
			this.groupBox6.Controls.Add(this.tVOffset);
			this.groupBox6.Controls.Add(this.tHOffset);
			this.groupBox6.Controls.Add(this.label20);
			this.groupBox6.Controls.Add(this.label19);
			this.groupBox6.Location = new System.Drawing.Point(6, 274);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(459, 91);
			this.groupBox6.TabIndex = 13;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Placement Options";
			// 
			// ckAsBackground
			// 
			this.ckAsBackground.AutoSize = true;
			this.ckAsBackground.Location = new System.Drawing.Point(33, 71);
			this.ckAsBackground.Name = "ckAsBackground";
			this.ckAsBackground.Size = new System.Drawing.Size(99, 17);
			this.ckAsBackground.TabIndex = 8;
			this.ckAsBackground.Text = "As Background";
			this.ckAsBackground.UseVisualStyleBackColor = true;
			// 
			// cbVOffsetFrom
			// 
			this.cbVOffsetFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVOffsetFrom.FormattingEnabled = true;
			this.cbVOffsetFrom.Location = new System.Drawing.Point(316, 45);
			this.cbVOffsetFrom.Name = "cbVOffsetFrom";
			this.cbVOffsetFrom.Size = new System.Drawing.Size(121, 21);
			this.cbVOffsetFrom.TabIndex = 7;
			// 
			// cbHOffsetFrom
			// 
			this.cbHOffsetFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHOffsetFrom.FormattingEnabled = true;
			this.cbHOffsetFrom.Location = new System.Drawing.Point(316, 18);
			this.cbHOffsetFrom.Name = "cbHOffsetFrom";
			this.cbHOffsetFrom.Size = new System.Drawing.Size(121, 21);
			this.cbHOffsetFrom.TabIndex = 6;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(280, 48);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(30, 13);
			this.label22.TabIndex = 5;
			this.label22.Text = "from:";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(280, 21);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(30, 13);
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
			this.tVOffset.Location = new System.Drawing.Point(132, 45);
			this.tVOffset.Name = "tVOffset";
			this.tVOffset.Size = new System.Drawing.Size(64, 20);
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
			this.tHOffset.Location = new System.Drawing.Point(132, 19);
			this.tHOffset.Name = "tHOffset";
			this.tHOffset.Size = new System.Drawing.Size(64, 20);
			this.tHOffset.TabIndex = 2;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(42, 47);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(76, 13);
			this.label20.TabIndex = 1;
			this.label20.Text = "Vertical Offset:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(30, 21);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(88, 13);
			this.label19.TabIndex = 0;
			this.label19.Text = "Horizontal Offset:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.cbType);
			this.groupBox3.Location = new System.Drawing.Point(6, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(459, 168);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Source";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnFontName);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.cbAlign);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.tStrokeWidth);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.btnStrokeClr);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.btnFillClr);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.tText);
			this.groupBox4.Location = new System.Drawing.Point(6, 40);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(439, 121);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			// 
			// btnFontName
			// 
			this.btnFontName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFontName.Location = new System.Drawing.Point(53, 58);
			this.btnFontName.Name = "btnFontName";
			this.btnFontName.Size = new System.Drawing.Size(137, 25);
			this.btnFontName.TabIndex = 15;
			this.btnFontName.Text = "Arial";
			this.btnFontName.UseVisualStyleBackColor = true;
			this.btnFontName.Click += new System.EventHandler(this.btnFontName_Click);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(251, 63);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(33, 13);
			this.label16.TabIndex = 16;
			this.label16.Text = "Align:";
			// 
			// cbAlign
			// 
			this.cbAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAlign.FormattingEnabled = true;
			this.cbAlign.Location = new System.Drawing.Point(310, 59);
			this.cbAlign.Name = "cbAlign";
			this.cbAlign.Size = new System.Drawing.Size(121, 21);
			this.cbAlign.TabIndex = 17;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(16, 63);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(31, 13);
			this.label15.TabIndex = 14;
			this.label15.Text = "Font:";
			// 
			// tStrokeWidth
			// 
			this.tStrokeWidth.DecimalPlaces = 1;
			this.tStrokeWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tStrokeWidth.Location = new System.Drawing.Point(310, 86);
			this.tStrokeWidth.Name = "tStrokeWidth";
			this.tStrokeWidth.Size = new System.Drawing.Size(121, 20);
			this.tStrokeWidth.TabIndex = 13;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(212, 91);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 13);
			this.label14.TabIndex = 12;
			this.label14.Text = "Stroke Width:";
			// 
			// btnStrokeClr
			// 
			this.btnStrokeClr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btnStrokeClr.Location = new System.Drawing.Point(150, 86);
			this.btnStrokeClr.Name = "btnStrokeClr";
			this.btnStrokeClr.Size = new System.Drawing.Size(40, 20);
			this.btnStrokeClr.TabIndex = 11;
			this.btnStrokeClr.UseVisualStyleBackColor = false;
			this.btnStrokeClr.Click += new System.EventHandler(this.btnStrokeClr_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(103, 88);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(41, 13);
			this.label13.TabIndex = 10;
			this.label13.Text = "Stroke:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Fill:";
			// 
			// btnFillClr
			// 
			this.btnFillClr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btnFillClr.Location = new System.Drawing.Point(53, 86);
			this.btnFillClr.Name = "btnFillClr";
			this.btnFillClr.Size = new System.Drawing.Size(40, 20);
			this.btnFillClr.TabIndex = 8;
			this.btnFillClr.UseVisualStyleBackColor = false;
			this.btnFillClr.Click += new System.EventHandler(this.btnTextClr_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label18);
			this.groupBox5.Controls.Add(this.label17);
			this.groupBox5.Controls.Add(this.lbNumPgs);
			this.groupBox5.Controls.Add(this.tNumPage);
			this.groupBox5.Controls.Add(this.tPath);
			this.groupBox5.Controls.Add(this.btnOpnFolder);
			this.groupBox5.Location = new System.Drawing.Point(6, 40);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(439, 121);
			this.groupBox5.TabIndex = 10;
			this.groupBox5.TabStop = false;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(12, 75);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(35, 13);
			this.label18.TabIndex = 5;
			this.label18.Text = "Page:";
			this.label18.Visible = false;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(9, 35);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(38, 13);
			this.label17.TabIndex = 4;
			this.label17.Text = "Name:";
			// 
			// lbNumPgs
			// 
			this.lbNumPgs.Location = new System.Drawing.Point(179, 75);
			this.lbNumPgs.Name = "lbNumPgs";
			this.lbNumPgs.Size = new System.Drawing.Size(153, 14);
			this.lbNumPgs.TabIndex = 3;
			this.lbNumPgs.Visible = false;
			// 
			// tNumPage
			// 
			this.tNumPage.Location = new System.Drawing.Point(53, 73);
			this.tNumPage.Name = "tNumPage";
			this.tNumPage.Size = new System.Drawing.Size(120, 20);
			this.tNumPage.TabIndex = 2;
			this.tNumPage.Visible = false;
			// 
			// tPath
			// 
			this.tPath.Location = new System.Drawing.Point(53, 32);
			this.tPath.Name = "tPath";
			this.tPath.Size = new System.Drawing.Size(325, 20);
			this.tPath.TabIndex = 1;
			// 
			// btnOpnFolder
			// 
			this.btnOpnFolder.Location = new System.Drawing.Point(383, 30);
			this.btnOpnFolder.Name = "btnOpnFolder";
			this.btnOpnFolder.Size = new System.Drawing.Size(50, 23);
			this.btnOpnFolder.TabIndex = 0;
			this.btnOpnFolder.Text = "Open";
			this.btnOpnFolder.UseVisualStyleBackColor = true;
			this.btnOpnFolder.Click += new System.EventHandler(this.button1_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(19, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Type:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbType
			// 
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(59, 19);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(386, 21);
			this.cbType.TabIndex = 11;
			this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.ckScaleRelative);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.tScale);
			this.groupBox2.Controls.Add(this.tRotation);
			this.groupBox2.Controls.Add(this.tOpacity);
			this.groupBox2.Location = new System.Drawing.Point(6, 190);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(459, 78);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Appearance";
			// 
			// label12
			// 
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label12.Location = new System.Drawing.Point(39, 41);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(365, 2);
			this.label12.TabIndex = 21;
			// 
			// ckScaleRelative
			// 
			this.ckScaleRelative.AutoSize = true;
			this.ckScaleRelative.Location = new System.Drawing.Point(250, 51);
			this.ckScaleRelative.Name = "ckScaleRelative";
			this.ckScaleRelative.Size = new System.Drawing.Size(159, 17);
			this.ckScaleRelative.TabIndex = 20;
			this.ckScaleRelative.Text = "Scale relative to target page";
			this.ckScaleRelative.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(142, 52);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(15, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "%";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(43, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Scale:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(247, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Opacity:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(142, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "°";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(389, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(15, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "%";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Rotation:";
			// 
			// tScale
			// 
			this.tScale.Location = new System.Drawing.Point(81, 50);
			this.tScale.Name = "tScale";
			this.tScale.Size = new System.Drawing.Size(55, 20);
			this.tScale.TabIndex = 18;
			this.tScale.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// tRotation
			// 
			this.tRotation.Location = new System.Drawing.Point(81, 14);
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
			this.tOpacity.Location = new System.Drawing.Point(319, 14);
			this.tOpacity.Name = "tOpacity";
			this.tOpacity.Size = new System.Drawing.Size(64, 20);
			this.tOpacity.TabIndex = 13;
			this.tOpacity.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// colorDialog1
			// 
			this.colorDialog1.SolidColorOnly = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// AddWatermarkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(479, 547);
			this.Controls.Add(this.gboxOpts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AddWatermarkForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxOpts.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tVOffset)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tHOffset)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tStrokeWidth)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNumPage)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tScale)).EndInit();
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
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown tRotation;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox ckScaleRelative;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown tScale;
		private System.Windows.Forms.ComboBox cbPagesSubset;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cbAlign;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btnFontName;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown tStrokeWidth;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnStrokeClr;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFillClr;
		private System.Windows.Forms.Button btnOpnFolder;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox tPath;
		private System.Windows.Forms.Label lbNumPgs;
		private System.Windows.Forms.NumericUpDown tNumPage;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckBox ckAsBackground;
		private System.Windows.Forms.ComboBox cbVOffsetFrom;
		private System.Windows.Forms.ComboBox cbHOffsetFrom;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.NumericUpDown tVOffset;
		private System.Windows.Forms.NumericUpDown tHOffset;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
	}
}