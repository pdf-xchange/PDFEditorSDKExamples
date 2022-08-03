namespace CustomPane
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
			this.pdfCtl = new AxPDFXEdit.AxPXV_Control();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pdfCtl)).BeginInit();
			this.SuspendLayout();
			// 
			// pdfCtl
			// 
			this.pdfCtl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pdfCtl.Enabled = true;
			this.pdfCtl.Location = new System.Drawing.Point(0, 0);
			this.pdfCtl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pdfCtl.Name = "pdfCtl";
			this.pdfCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfCtl.OcxState")));
			this.pdfCtl.Size = new System.Drawing.Size(741, 553);
			this.pdfCtl.TabIndex = 0;
			this.pdfCtl.OnEvent += new AxPDFXEdit._IPXV_ControlEvents_OnEventEventHandler(this.pdfCtl_OnEvent);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(741, 553);
			this.Controls.Add(this.pdfCtl);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pdfCtl)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private AxPDFXEdit.AxPXV_Control pdfCtl;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
	}
}

