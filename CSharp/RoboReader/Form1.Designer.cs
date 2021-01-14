namespace RoboReader
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.ckSolid = new System.Windows.Forms.CheckBox();
			this.ckUseDocHighlighter = new System.Windows.Forms.CheckBox();
			this.ckSmooth = new System.Windows.Forms.CheckBox();
			this.ckBlue = new System.Windows.Forms.CheckBox();
			this.pdfCtl = new AxPDFXEdit.AxPXV_Control();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pdfCtl)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(12, 12);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(145, 37);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnStart
			// 
			this.btnStart.Enabled = false;
			this.btnStart.Location = new System.Drawing.Point(180, 12);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(145, 37);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ckSolid
			// 
			this.ckSolid.AutoSize = true;
			this.ckSolid.Checked = true;
			this.ckSolid.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckSolid.Enabled = false;
			this.ckSolid.Location = new System.Drawing.Point(593, 19);
			this.ckSolid.Name = "ckSolid";
			this.ckSolid.Size = new System.Drawing.Size(70, 24);
			this.ckSolid.TabIndex = 3;
			this.ckSolid.Text = "Solid";
			this.ckSolid.UseVisualStyleBackColor = true;
			// 
			// ckUseDocHighlighter
			// 
			this.ckUseDocHighlighter.AutoSize = true;
			this.ckUseDocHighlighter.Checked = true;
			this.ckUseDocHighlighter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckUseDocHighlighter.Enabled = false;
			this.ckUseDocHighlighter.Location = new System.Drawing.Point(371, 19);
			this.ckUseDocHighlighter.Name = "ckUseDocHighlighter";
			this.ckUseDocHighlighter.Size = new System.Drawing.Size(173, 24);
			this.ckUseDocHighlighter.TabIndex = 4;
			this.ckUseDocHighlighter.Text = "Use DocHighlighter";
			this.ckUseDocHighlighter.UseVisualStyleBackColor = true;
			// 
			// ckSmooth
			// 
			this.ckSmooth.AutoSize = true;
			this.ckSmooth.Enabled = false;
			this.ckSmooth.Location = new System.Drawing.Point(712, 19);
			this.ckSmooth.Name = "ckSmooth";
			this.ckSmooth.Size = new System.Drawing.Size(91, 24);
			this.ckSmooth.TabIndex = 5;
			this.ckSmooth.Text = "Smooth";
			this.ckSmooth.UseVisualStyleBackColor = true;
			// 
			// ckBlue
			// 
			this.ckBlue.AutoSize = true;
			this.ckBlue.Enabled = false;
			this.ckBlue.Location = new System.Drawing.Point(852, 19);
			this.ckBlue.Name = "ckBlue";
			this.ckBlue.Size = new System.Drawing.Size(67, 24);
			this.ckBlue.TabIndex = 6;
			this.ckBlue.Text = "Blue";
			this.ckBlue.UseVisualStyleBackColor = true;
			// 
			// pdfCtl
			// 
			this.pdfCtl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pdfCtl.Enabled = true;
			this.pdfCtl.Location = new System.Drawing.Point(0, 0);
			this.pdfCtl.Name = "pdfCtl";
			this.pdfCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfCtl.OcxState")));
			this.pdfCtl.Size = new System.Drawing.Size(1283, 821);
			this.pdfCtl.TabIndex = 7;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.pdfCtl);
			this.panel1.Location = new System.Drawing.Point(12, 55);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1283, 821);
			this.panel1.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1307, 888);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.ckBlue);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.ckUseDocHighlighter);
			this.Controls.Add(this.ckSmooth);
			this.Controls.Add(this.ckSolid);
			this.Name = "Form1";
			this.Text = "RoboReader";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pdfCtl)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.CheckBox ckSolid;
		private System.Windows.Forms.CheckBox ckUseDocHighlighter;
		private System.Windows.Forms.CheckBox ckSmooth;
		private System.Windows.Forms.CheckBox ckBlue;
		private AxPDFXEdit.AxPXV_Control pdfCtl;
		private System.Windows.Forms.Panel panel1;
	}
}

