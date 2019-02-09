namespace FullDemo
{
	partial class PrintAdvancedOptions
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
			this.tOpacity = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.ckNotePop_Up = new System.Windows.Forms.CheckBox();
			this.ckNotes = new System.Windows.Forms.CheckBox();
			this.ckMarksAnnot = new System.Windows.Forms.CheckBox();
			this.ckMediaAnnot = new System.Windows.Forms.CheckBox();
			this.ckDataOnly = new System.Windows.Forms.CheckBox();
			this.ckFormFields = new System.Windows.Forms.CheckBox();
			this.ckStamps = new System.Windows.Forms.CheckBox();
			this.ckMarkups = new System.Windows.Forms.CheckBox();
			this.ckPageContent = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbGradientDPI = new System.Windows.Forms.ComboBox();
			this.cbBitmapDPI = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ckIgnoreCropClip = new System.Windows.Forms.CheckBox();
			this.ckIgnoreDocClrOverrides = new System.Windows.Forms.CheckBox();
			this.cbLineMode = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbTextMode = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbClrOver = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tOpacity)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tOpacity);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ckNotePop_Up);
			this.groupBox1.Controls.Add(this.ckNotes);
			this.groupBox1.Controls.Add(this.ckMarksAnnot);
			this.groupBox1.Controls.Add(this.ckMediaAnnot);
			this.groupBox1.Controls.Add(this.ckDataOnly);
			this.groupBox1.Controls.Add(this.ckFormFields);
			this.groupBox1.Controls.Add(this.ckStamps);
			this.groupBox1.Controls.Add(this.ckMarkups);
			this.groupBox1.Controls.Add(this.ckPageContent);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 258);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Print Content Options";
			// 
			// tOpacity
			// 
			this.tOpacity.Enabled = false;
			this.tOpacity.Location = new System.Drawing.Point(95, 226);
			this.tOpacity.Name = "tOpacity";
			this.tOpacity.Size = new System.Drawing.Size(67, 20);
			this.tOpacity.TabIndex = 10;
			this.tOpacity.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 228);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Opacity:";
			// 
			// ckNotePop_Up
			// 
			this.ckNotePop_Up.AutoSize = true;
			this.ckNotePop_Up.Enabled = false;
			this.ckNotePop_Up.Location = new System.Drawing.Point(46, 203);
			this.ckNotePop_Up.Name = "ckNotePop_Up";
			this.ckNotePop_Up.Size = new System.Drawing.Size(126, 17);
			this.ckNotePop_Up.TabIndex = 8;
			this.ckNotePop_Up.Text = "Print Note Pop-Up(s):";
			this.ckNotePop_Up.UseVisualStyleBackColor = true;
			this.ckNotePop_Up.CheckedChanged += new System.EventHandler(this.ckNotePop_Up_CheckedChanged);
			// 
			// ckNotes
			// 
			this.ckNotes.AutoSize = true;
			this.ckNotes.Location = new System.Drawing.Point(26, 180);
			this.ckNotes.Name = "ckNotes";
			this.ckNotes.Size = new System.Drawing.Size(78, 17);
			this.ckNotes.TabIndex = 7;
			this.ckNotes.Text = "Print Notes";
			this.ckNotes.UseVisualStyleBackColor = true;
			this.ckNotes.CheckedChanged += new System.EventHandler(this.ckNotes_CheckedChanged);
			// 
			// ckMarksAnnot
			// 
			this.ckMarksAnnot.AutoSize = true;
			this.ckMarksAnnot.Location = new System.Drawing.Point(26, 157);
			this.ckMarksAnnot.Name = "ckMarksAnnot";
			this.ckMarksAnnot.Size = new System.Drawing.Size(168, 17);
			this.ckMarksAnnot.TabIndex = 6;
			this.ckMarksAnnot.Text = "Show Print-Marks Annotations";
			this.ckMarksAnnot.UseVisualStyleBackColor = true;
			// 
			// ckMediaAnnot
			// 
			this.ckMediaAnnot.AutoSize = true;
			this.ckMediaAnnot.Location = new System.Drawing.Point(26, 134);
			this.ckMediaAnnot.Name = "ckMediaAnnot";
			this.ckMediaAnnot.Size = new System.Drawing.Size(254, 17);
			this.ckMediaAnnot.TabIndex = 5;
			this.ckMediaAnnot.Text = "Print Media-Annotations (movie, sound, 3D, etc.)";
			this.ckMediaAnnot.UseVisualStyleBackColor = true;
			// 
			// ckDataOnly
			// 
			this.ckDataOnly.AutoSize = true;
			this.ckDataOnly.Enabled = false;
			this.ckDataOnly.Location = new System.Drawing.Point(46, 111);
			this.ckDataOnly.Name = "ckDataOnly";
			this.ckDataOnly.Size = new System.Drawing.Size(267, 17);
			this.ckDataOnly.TabIndex = 4;
			this.ckDataOnly.Text = "Print Data Only (field with no border or background)";
			this.ckDataOnly.UseVisualStyleBackColor = true;
			// 
			// ckFormFields
			// 
			this.ckFormFields.AutoSize = true;
			this.ckFormFields.Location = new System.Drawing.Point(26, 88);
			this.ckFormFields.Name = "ckFormFields";
			this.ckFormFields.Size = new System.Drawing.Size(103, 17);
			this.ckFormFields.TabIndex = 3;
			this.ckFormFields.Text = "Print Form Fields";
			this.ckFormFields.UseVisualStyleBackColor = true;
			this.ckFormFields.CheckedChanged += new System.EventHandler(this.ckFormFields_CheckedChanged);
			// 
			// ckStamps
			// 
			this.ckStamps.AutoSize = true;
			this.ckStamps.Location = new System.Drawing.Point(26, 65);
			this.ckStamps.Name = "ckStamps";
			this.ckStamps.Size = new System.Drawing.Size(85, 17);
			this.ckStamps.TabIndex = 2;
			this.ckStamps.Text = "Print Stamps";
			this.ckStamps.UseVisualStyleBackColor = true;
			// 
			// ckMarkups
			// 
			this.ckMarkups.AutoSize = true;
			this.ckMarkups.Location = new System.Drawing.Point(26, 42);
			this.ckMarkups.Name = "ckMarkups";
			this.ckMarkups.Size = new System.Drawing.Size(332, 17);
			this.ckMarkups.TabIndex = 1;
			this.ckMarkups.Text = "Print Markups (anorations such as rectange, circle, polygon, etc.)";
			this.ckMarkups.UseVisualStyleBackColor = true;
			// 
			// ckPageContent
			// 
			this.ckPageContent.AutoSize = true;
			this.ckPageContent.Location = new System.Drawing.Point(26, 19);
			this.ckPageContent.Name = "ckPageContent";
			this.ckPageContent.Size = new System.Drawing.Size(115, 17);
			this.ckPageContent.TabIndex = 0;
			this.ckPageContent.Text = "Print Page Content";
			this.ckPageContent.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbGradientDPI);
			this.groupBox2.Controls.Add(this.cbBitmapDPI);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.ckIgnoreCropClip);
			this.groupBox2.Controls.Add(this.ckIgnoreDocClrOverrides);
			this.groupBox2.Controls.Add(this.cbLineMode);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbTextMode);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cbClrOver);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(12, 276);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(440, 188);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rendering Options";
			// 
			// cbGradientDPI
			// 
			this.cbGradientDPI.FormattingEnabled = true;
			this.cbGradientDPI.Location = new System.Drawing.Point(254, 72);
			this.cbGradientDPI.Name = "cbGradientDPI";
			this.cbGradientDPI.Size = new System.Drawing.Size(121, 21);
			this.cbGradientDPI.TabIndex = 25;
			// 
			// cbBitmapDPI
			// 
			this.cbBitmapDPI.FormattingEnabled = true;
			this.cbBitmapDPI.Location = new System.Drawing.Point(254, 32);
			this.cbBitmapDPI.Name = "cbBitmapDPI";
			this.cbBitmapDPI.Size = new System.Drawing.Size(121, 21);
			this.cbBitmapDPI.TabIndex = 24;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(251, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(141, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Resolution for Gradiend Fills:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(251, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(159, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Maximum Resolution for Images:";
			// 
			// ckIgnoreCropClip
			// 
			this.ckIgnoreCropClip.AutoSize = true;
			this.ckIgnoreCropClip.Location = new System.Drawing.Point(41, 162);
			this.ckIgnoreCropClip.Name = "ckIgnoreCropClip";
			this.ckIgnoreCropClip.Size = new System.Drawing.Size(129, 17);
			this.ckIgnoreCropClip.TabIndex = 21;
			this.ckIgnoreCropClip.Text = "Ignore Page Crop-Clip";
			this.ckIgnoreCropClip.UseVisualStyleBackColor = true;
			// 
			// ckIgnoreDocClrOverrides
			// 
			this.ckIgnoreDocClrOverrides.AutoSize = true;
			this.ckIgnoreDocClrOverrides.Location = new System.Drawing.Point(41, 139);
			this.ckIgnoreDocClrOverrides.Name = "ckIgnoreDocClrOverrides";
			this.ckIgnoreDocClrOverrides.Size = new System.Drawing.Size(191, 17);
			this.ckIgnoreDocClrOverrides.TabIndex = 20;
			this.ckIgnoreDocClrOverrides.Text = "Ignore Accessibility Color Overrides";
			this.ckIgnoreDocClrOverrides.UseVisualStyleBackColor = true;
			// 
			// cbLineMode
			// 
			this.cbLineMode.FormattingEnabled = true;
			this.cbLineMode.Items.AddRange(new object[] {
            "Auto",
            "Logical Units",
            "Device Units"});
			this.cbLineMode.Location = new System.Drawing.Point(41, 112);
			this.cbLineMode.Name = "cbLineMode";
			this.cbLineMode.Size = new System.Drawing.Size(164, 21);
			this.cbLineMode.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(43, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Line Width Mode:";
			// 
			// cbTextMode
			// 
			this.cbTextMode.FormattingEnabled = true;
			this.cbTextMode.Location = new System.Drawing.Point(41, 72);
			this.cbTextMode.Name = "cbTextMode";
			this.cbTextMode.Size = new System.Drawing.Size(164, 21);
			this.cbTextMode.TabIndex = 17;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Text Rendering Mode:";
			// 
			// cbClrOver
			// 
			this.cbClrOver.FormattingEnabled = true;
			this.cbClrOver.Location = new System.Drawing.Point(41, 32);
			this.cbClrOver.Name = "cbClrOver";
			this.cbClrOver.Size = new System.Drawing.Size(164, 21);
			this.cbClrOver.TabIndex = 15;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(43, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Colors Override:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(352, 470);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(246, 470);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(100, 30);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// PrintAdvancedOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 508);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "PrintAdvancedOptions";
			this.Text = "Print Advanced Options";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tOpacity)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox ckNotePop_Up;
		private System.Windows.Forms.CheckBox ckNotes;
		private System.Windows.Forms.CheckBox ckMarksAnnot;
		private System.Windows.Forms.CheckBox ckMediaAnnot;
		private System.Windows.Forms.CheckBox ckDataOnly;
		private System.Windows.Forms.CheckBox ckFormFields;
		private System.Windows.Forms.CheckBox ckStamps;
		private System.Windows.Forms.CheckBox ckMarkups;
		private System.Windows.Forms.CheckBox ckPageContent;
		private System.Windows.Forms.NumericUpDown tOpacity;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbClrOver;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbGradientDPI;
		private System.Windows.Forms.ComboBox cbBitmapDPI;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox ckIgnoreCropClip;
		private System.Windows.Forms.CheckBox ckIgnoreDocClrOverrides;
		private System.Windows.Forms.ComboBox cbLineMode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbTextMode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
	}
}