namespace PreviewCtrl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.previewCtrl1 = new PDFXEditCtrl.PreviewCtrl();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolOpenFile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolCurPage = new System.Windows.Forms.ToolStripTextBox();
			this.toolPageCount = new System.Windows.Forms.ToolStripLabel();
			this.toolPagePrev = new System.Windows.Forms.ToolStripButton();
			this.toolPageNext = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolZoomWidth = new System.Windows.Forms.ToolStripButton();
			this.toolZoomFit = new System.Windows.Forms.ToolStripButton();
			this.toolZoomOut = new System.Windows.Forms.ToolStripButton();
			this.toolZoomIn = new System.Windows.Forms.ToolStripButton();
			this.nextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.prevPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.zoomFitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomFitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			//
			// menuStrip1
			//
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
			this.menuStrip1.Size = new System.Drawing.Size(1148, 35);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			//
			// fileToolStripMenuItem
			//
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
			this.fileToolStripMenuItem.Text = "File";
			//
			// fileToolStripMenuItem1
			//
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(210, 30);
			this.fileToolStripMenuItem1.Text = "File";
			this.fileToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolOpenFile.Image")));
			this.fileToolStripMenuItem1.Click += new System.EventHandler(this.fileToolOpenFile_Click);
			//
			// viewToolStripMenuItem
			//
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextPageToolStripMenuItem,
            this.prevPageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.zoomFitWidthToolStripMenuItem,
            this.zoomFitPageToolStripMenuItem,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
			this.viewToolStripMenuItem.Text = "View";
			//
			// openFileDialog1
			//
			this.openFileDialog1.DefaultExt = "pdf";
			this.openFileDialog1.Filter = "PDF Documents (*.pdf)|*.pdf|All Files (*.*)|*.*";
			//
			// tabPage1
			//
			this.tabPage1.Controls.Add(this.previewCtrl1);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1140, 527);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Page none";
			this.tabPage1.UseVisualStyleBackColor = true;
			//
			// previewCtrl1
			//
			this.previewCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.previewCtrl1.Location = new System.Drawing.Point(3, 3);
			this.previewCtrl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.previewCtrl1.Name = "previewCtrl1";
			this.previewCtrl1.Size = new System.Drawing.Size(1134, 521);
			this.previewCtrl1.TabIndex = 1;
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 66);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1148, 560);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			//
			// toolStrip1
			//
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenFile,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolCurPage,
            this.toolPageCount,
            this.toolPagePrev,
            this.toolPageNext,
            this.toolStripSeparator2,
            this.toolZoomWidth,
            this.toolZoomFit,
            this.toolZoomOut,
            this.toolZoomIn});
			this.toolStrip1.Location = new System.Drawing.Point(0, 35);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1148, 31);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			//
			// toolOpenFile
			//
			this.toolOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolOpenFile.Image")));
			this.toolOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOpenFile.Name = "toolOpenFile";
			this.toolOpenFile.Size = new System.Drawing.Size(28, 28);
			this.toolOpenFile.Text = "Open File";
			this.toolOpenFile.Click += new System.EventHandler(this.fileToolOpenFile_Click);
			//
			// toolStripSeparator1
			//
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			//
			// toolStripLabel1
			//
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(50, 28);
			this.toolStripLabel1.Text = "Page";
			//
			// toolCurPage
			//
			this.toolCurPage.Name = "toolCurPage";
			this.toolCurPage.Size = new System.Drawing.Size(100, 31);
			//
			// toolPageCount
			//
			this.toolPageCount.Name = "toolPageCount";
			this.toolPageCount.Size = new System.Drawing.Size(34, 28);
			this.toolPageCount.Text = "/ n";
			//
			// toolPagePrev
			//
			this.toolPagePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolPagePrev.Image = ((System.Drawing.Image)(resources.GetObject("toolPagePrev.Image")));
			this.toolPagePrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolPagePrev.Name = "toolPagePrev";
			this.toolPagePrev.Size = new System.Drawing.Size(28, 28);
			this.toolPagePrev.Text = "Prev Page";
			this.toolPagePrev.Click += new System.EventHandler(this.toolPagePrev_Click);
			//
			// toolPageNext
			//
			this.toolPageNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolPageNext.Image = ((System.Drawing.Image)(resources.GetObject("toolPageNext.Image")));
			this.toolPageNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolPageNext.Name = "toolPageNext";
			this.toolPageNext.Size = new System.Drawing.Size(28, 28);
			this.toolPageNext.Text = "Next Page";
			this.toolPageNext.Click += new System.EventHandler(this.toolPageNext_Click);
			//
			// toolStripSeparator2
			//
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			//
			// toolZoomWidth
			//
			this.toolZoomWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolZoomWidth.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomWidth.Image")));
			this.toolZoomWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolZoomWidth.Name = "toolZoomWidth";
			this.toolZoomWidth.Size = new System.Drawing.Size(28, 28);
			this.toolZoomWidth.Text = "Zoom Fit Width";
			this.toolZoomWidth.Click += new System.EventHandler(this.toolZoomWidth_Click);
			//
			// toolZoomFit
			//
			this.toolZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolZoomFit.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomFit.Image")));
			this.toolZoomFit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolZoomFit.Name = "toolZoomFit";
			this.toolZoomFit.Size = new System.Drawing.Size(28, 28);
			this.toolZoomFit.Text = "Zoom Fit";
			this.toolZoomFit.Click += new System.EventHandler(this.toolZoomFit_Click);
			//
			// toolZoomOut
			//
			this.toolZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomOut.Image")));
			this.toolZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolZoomOut.Name = "toolZoomOut";
			this.toolZoomOut.Size = new System.Drawing.Size(28, 28);
			this.toolZoomOut.Text = "Zoom Out";
			this.toolZoomOut.Click += new System.EventHandler(this.toolZoomOut_Click);
			//
			// toolZoomIn
			//
			this.toolZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomIn.Image")));
			this.toolZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolZoomIn.Name = "toolZoomIn";
			this.toolZoomIn.Size = new System.Drawing.Size(28, 28);
			this.toolZoomIn.Text = "Zoom In";
			this.toolZoomIn.Click += new System.EventHandler(this.toolZoomIn_Click);
			//
			// nextPageToolStripMenuItem
			//
			this.nextPageToolStripMenuItem.Name = "nextPageToolStripMenuItem";
			this.nextPageToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
			this.nextPageToolStripMenuItem.Text = "Next Page";
			this.nextPageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolPageNext.Image")));
			this.nextPageToolStripMenuItem.Click += new System.EventHandler(this.toolPageNext_Click);
			//
			// prevPageToolStripMenuItem
			//
			this.prevPageToolStripMenuItem.Name = "prevPageToolStripMenuItem";
			this.prevPageToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
			this.prevPageToolStripMenuItem.Text = "Prev Page";
			this.prevPageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolPagePrev.Image")));
			this.prevPageToolStripMenuItem.Click += new System.EventHandler(this.toolPagePrev_Click);
			//
			// toolStripMenuItem1
			//
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(218, 6);
			//
			// zoomFitWidthToolStripMenuItem
			//
			this.zoomFitWidthToolStripMenuItem.Name = "zoomFitWidthToolStripMenuItem";
			this.zoomFitWidthToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
			this.zoomFitWidthToolStripMenuItem.Text = "Zoom Fit Width";
			this.zoomFitWidthToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomWidth.Image")));
			this.zoomFitWidthToolStripMenuItem.Click += new System.EventHandler(this.toolZoomWidth_Click);
			//
			// zoomFitPageToolStripMenuItem
			//
			this.zoomFitPageToolStripMenuItem.Name = "zoomFitPageToolStripMenuItem";
			this.zoomFitPageToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
			this.zoomFitPageToolStripMenuItem.Text = "Zoom Fit Page";
			this.zoomFitPageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomFit.Image")));
			this.zoomFitPageToolStripMenuItem.Click += new System.EventHandler(this.toolZoomFit_Click);
			//
			// zoomInToolStripMenuItem
			//
			this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
			this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
			this.zoomInToolStripMenuItem.Text = "Zoom In";
			this.zoomInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomIn.Image")));
			this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.toolZoomIn_Click);
			//
			// zoomOutToolStripMenuItem
			//
			this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
			this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
			this.zoomOutToolStripMenuItem.Text = "Zoom Out";
			this.zoomOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolZoomOut.Image")));
			this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.toolZoomOut_Click);
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1148, 626);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TabPage tabPage1;
		private PDFXEditCtrl.PreviewCtrl previewCtrl1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolOpenFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox toolCurPage;
		private System.Windows.Forms.ToolStripLabel toolPageCount;
		private System.Windows.Forms.ToolStripButton toolPagePrev;
		private System.Windows.Forms.ToolStripButton toolPageNext;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolZoomFit;
		private System.Windows.Forms.ToolStripButton toolZoomWidth;
		private System.Windows.Forms.ToolStripButton toolZoomIn;
		private System.Windows.Forms.ToolStripButton toolZoomOut;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nextPageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem prevPageToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem zoomFitWidthToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoomFitPageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
	}
}

