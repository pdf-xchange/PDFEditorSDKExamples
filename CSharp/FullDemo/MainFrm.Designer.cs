using System;
using System.Windows.Forms;

namespace FullDemo
{
	public class MyTreeView : TreeView
	{
		protected override void WndProc(ref Message m)
		{
			// Suppress WM_LBUTTONDBLCLK
			if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
			else base.WndProc(ref m);
		}
	}
		partial class MainFrm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
			this.tabJS = new System.Windows.Forms.TabPage();
			this.label29 = new System.Windows.Forms.Label();
			this.btnRunJS = new System.Windows.Forms.Button();
			this.tOutputJS = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.tInputJS = new System.Windows.Forms.TextBox();
			this.tabCmds = new System.Windows.Forms.TabPage();
			this.btnCmdShowHide = new System.Windows.Forms.Button();
			this.lvCmds = new System.Windows.Forms.ListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colOffline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colAdobeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label23 = new System.Windows.Forms.Label();
			this.btnCmdOnOff = new System.Windows.Forms.Button();
			this.btnCmdExec = new System.Windows.Forms.Button();
			this.ckAllowShortcuts = new System.Windows.Forms.CheckBox();
			this.tabView = new System.Windows.Forms.TabPage();
			this.cmdBarsTree = new FullDemo.MyTreeView();
			this.ckRibbonUI = new System.Windows.Forms.CheckBox();
			this.ckShowFormViewBar = new System.Windows.Forms.CheckBox();
			this.label44 = new System.Windows.Forms.Label();
			this.ckShowRotateViewBar = new System.Windows.Forms.CheckBox();
			this.ckShowDocOptsBar = new System.Windows.Forms.CheckBox();
			this.ckShowDocLaunchBar = new System.Windows.Forms.CheckBox();
			this.ckLockCmdPanes = new System.Windows.Forms.CheckBox();
			this.ckShowPagesLayoutBar = new System.Windows.Forms.CheckBox();
			this.ckShowPagesNavBar = new System.Windows.Forms.CheckBox();
			this.ckShowPageZoomBar = new System.Windows.Forms.CheckBox();
			this.ckShowMeasureBar = new System.Windows.Forms.CheckBox();
			this.ckShowContentEdtBar = new System.Windows.Forms.CheckBox();
			this.ckShowCommentBar = new System.Windows.Forms.CheckBox();
			this.ckShowPropBar = new System.Windows.Forms.CheckBox();
			this.ckShowStdBar = new System.Windows.Forms.CheckBox();
			this.ckShowMenu = new System.Windows.Forms.CheckBox();
			this.ckShowFileBar = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.ckShowPanZoom = new System.Windows.Forms.CheckBox();
			this.ckShowStampsPalette = new System.Windows.Forms.CheckBox();
			this.ckShowCommentStyles = new System.Windows.Forms.CheckBox();
			this.ckShowSearchPane = new System.Windows.Forms.CheckBox();
			this.label17 = new System.Windows.Forms.Label();
			this.ckSyncDocPanesLayout = new System.Windows.Forms.CheckBox();
			this.ckShowAttachments = new System.Windows.Forms.CheckBox();
			this.ckShowSignatures = new System.Windows.Forms.CheckBox();
			this.ckShowLayers = new System.Windows.Forms.CheckBox();
			this.ckShowComments = new System.Windows.Forms.CheckBox();
			this.ckShowBookm = new System.Windows.Forms.CheckBox();
			this.ckShowThumbs = new System.Windows.Forms.CheckBox();
			this.ckHideSb = new System.Windows.Forms.CheckBox();
			this.ckShowCmdPanes = new System.Windows.Forms.CheckBox();
			this.ckUnlockCmdBars = new System.Windows.Forms.CheckBox();
			this.tabDoc = new System.Windows.Forms.TabPage();
			this.gboxPages = new System.Windows.Forms.GroupBox();
			this.btnZoomOut = new System.Windows.Forms.Button();
			this.btnZoomIn = new System.Windows.Forms.Button();
			this.tCurPage = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cbPagesLayout = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cbPagesZoom = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.lbPageRotation = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lbPageSize = new System.Windows.Forms.Label();
			this.ckAllowAskForSave = new System.Windows.Forms.CheckBox();
			this.btnCloseDoc = new System.Windows.Forms.Button();
			this.gboxSave = new System.Windows.Forms.GroupBox();
			this.ckSwitchToDest = new System.Windows.Forms.CheckBox();
			this.btnSimpleSave = new System.Windows.Forms.Button();
			this.ckIStreamDestDemo = new System.Windows.Forms.CheckBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.btnShowSaveAsDlg = new System.Windows.Forms.Button();
			this.btnBrowseForSaveAs = new System.Windows.Forms.Button();
			this.btnSaveToCustDest = new System.Windows.Forms.Button();
			this.tDestToSave = new System.Windows.Forms.TextBox();
			this.gboxOpen = new System.Windows.Forms.GroupBox();
			this.ckHideSingleTab = new System.Windows.Forms.CheckBox();
			this.ckMultDocs = new System.Windows.Forms.CheckBox();
			this.ckIStreamSrcDemo = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.btnShowOpenDlg = new System.Windows.Forms.Button();
			this.btnBrowseForOpen = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.tSrcToOpen = new System.Windows.Forms.TextBox();
			this.gboxInfo = new System.Windows.Forms.GroupBox();
			this.lbModDate = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.lbCreatDate = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.lbPDFA = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.lbPDFForm = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.lbPDFSpecVer = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lbSrc = new System.Windows.Forms.Label();
			this.lbPagesCnt = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tCreator = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tProducer = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tKeyw = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tSubj = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tAuthor = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tTitle = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ckModified = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabCtl = new System.Windows.Forms.TabControl();
			this.tabUILang = new System.Windows.Forms.TabPage();
			this.btnSetUILang = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.cbUILangs = new System.Windows.Forms.ComboBox();
			this.tabOpers = new System.Windows.Forms.TabPage();
			this.lbDocReq = new System.Windows.Forms.Label();
			this.picDocReq = new System.Windows.Forms.PictureBox();
			this.btnRunOp = new System.Windows.Forms.Button();
			this.ckShowOpDlg = new System.Windows.Forms.CheckBox();
			this.cbOpers = new System.Windows.Forms.ComboBox();
			this.label30 = new System.Windows.Forms.Label();
			this.pnOpOpts = new System.Windows.Forms.Panel();
			this.tabSettingsIO = new System.Windows.Forms.TabPage();
			this.gboxImpExp = new System.Windows.Forms.GroupBox();
			this.ckSettIncHist = new System.Windows.Forms.CheckBox();
			this.btnSettSave = new System.Windows.Forms.Button();
			this.btnSettLoad = new System.Windows.Forms.Button();
			this.label35 = new System.Windows.Forms.Label();
			this.btnBrowseForSettFile = new System.Windows.Forms.Button();
			this.tSettFile = new System.Windows.Forms.TextBox();
			this.gboxProgramOpts = new System.Windows.Forms.GroupBox();
			this.btnBrowseForHistDir = new System.Windows.Forms.Button();
			this.tHistDir = new System.Windows.Forms.TextBox();
			this.ckKeepHist = new System.Windows.Forms.CheckBox();
			this.btnBrowseForPrefsFile = new System.Windows.Forms.Button();
			this.tPrefs_file = new System.Windows.Forms.TextBox();
			this.rbPrefs_file = new System.Windows.Forms.RadioButton();
			this.tPrefs_reg = new System.Windows.Forms.TextBox();
			this.rbPrefs_reg = new System.Windows.Forms.RadioButton();
			this.ckKeepPrefs = new System.Windows.Forms.CheckBox();
			this.tabCustomUI = new System.Windows.Forms.TabPage();
			this.btnResetUI = new System.Windows.Forms.Button();
			this.gboxCustFonts = new System.Windows.Forms.GroupBox();
			this.label42 = new System.Windows.Forms.Label();
			this.btnDefaultFnt = new System.Windows.Forms.Button();
			this.lbDefaultFnt = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.btnMenuFnt = new System.Windows.Forms.Button();
			this.lbMenuFnt = new System.Windows.Forms.Label();
			this.gboxCustColors = new System.Windows.Forms.GroupBox();
			this.btnSelClr = new System.Windows.Forms.Button();
			this.label40 = new System.Windows.Forms.Label();
			this.btnTextClr = new System.Windows.Forms.Button();
			this.label39 = new System.Windows.Forms.Label();
			this.btnWndClr = new System.Windows.Forms.Button();
			this.label38 = new System.Windows.Forms.Label();
			this.btnFaceClr = new System.Windows.Forms.Button();
			this.label37 = new System.Windows.Forms.Label();
			this.tabHelp = new System.Windows.Forms.TabPage();
			this.label43 = new System.Windows.Forms.Label();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.label33 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pdfCtl = new AxPDFXEdit.AxPXV_Control();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label45 = new System.Windows.Forms.Label();
			this.tabJS.SuspendLayout();
			this.tabCmds.SuspendLayout();
			this.tabView.SuspendLayout();
			this.tabDoc.SuspendLayout();
			this.gboxPages.SuspendLayout();
			this.gboxSave.SuspendLayout();
			this.gboxOpen.SuspendLayout();
			this.gboxInfo.SuspendLayout();
			this.tabCtl.SuspendLayout();
			this.tabUILang.SuspendLayout();
			this.tabOpers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picDocReq)).BeginInit();
			this.tabSettingsIO.SuspendLayout();
			this.gboxImpExp.SuspendLayout();
			this.gboxProgramOpts.SuspendLayout();
			this.tabCustomUI.SuspendLayout();
			this.gboxCustFonts.SuspendLayout();
			this.gboxCustColors.SuspendLayout();
			this.tabHelp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pdfCtl)).BeginInit();
			this.SuspendLayout();
			// 
			// tabJS
			// 
			this.tabJS.Controls.Add(this.label29);
			this.tabJS.Controls.Add(this.btnRunJS);
			this.tabJS.Controls.Add(this.tOutputJS);
			this.tabJS.Controls.Add(this.label28);
			this.tabJS.Controls.Add(this.tInputJS);
			this.tabJS.Location = new System.Drawing.Point(4, 29);
			this.tabJS.Margin = new System.Windows.Forms.Padding(4);
			this.tabJS.Name = "tabJS";
			this.tabJS.Padding = new System.Windows.Forms.Padding(4);
			this.tabJS.Size = new System.Drawing.Size(728, 987);
			this.tabJS.TabIndex = 4;
			this.tabJS.Text = "Java Script";
			this.tabJS.UseVisualStyleBackColor = true;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(4, 566);
			this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(231, 20);
			this.label29.TabIndex = 4;
			this.label29.Text = "Result of executing Java Script:";
			// 
			// btnRunJS
			// 
			this.btnRunJS.Location = new System.Drawing.Point(576, 536);
			this.btnRunJS.Margin = new System.Windows.Forms.Padding(4);
			this.btnRunJS.Name = "btnRunJS";
			this.btnRunJS.Size = new System.Drawing.Size(140, 32);
			this.btnRunJS.TabIndex = 3;
			this.btnRunJS.Text = "Run";
			this.btnRunJS.UseVisualStyleBackColor = true;
			this.btnRunJS.Click += new System.EventHandler(this.btnRunJS_Click);
			// 
			// tOutputJS
			// 
			this.tOutputJS.BackColor = System.Drawing.SystemColors.Control;
			this.tOutputJS.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tOutputJS.Location = new System.Drawing.Point(8, 590);
			this.tOutputJS.Margin = new System.Windows.Forms.Padding(4);
			this.tOutputJS.Multiline = true;
			this.tOutputJS.Name = "tOutputJS";
			this.tOutputJS.ReadOnly = true;
			this.tOutputJS.Size = new System.Drawing.Size(706, 361);
			this.tOutputJS.TabIndex = 2;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(5, 11);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(209, 20);
			this.label28.TabIndex = 1;
			this.label28.Text = "Enter Java Script code here:";
			// 
			// tInputJS
			// 
			this.tInputJS.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tInputJS.Location = new System.Drawing.Point(8, 40);
			this.tInputJS.Margin = new System.Windows.Forms.Padding(4);
			this.tInputJS.Multiline = true;
			this.tInputJS.Name = "tInputJS";
			this.tInputJS.Size = new System.Drawing.Size(706, 484);
			this.tInputJS.TabIndex = 0;
			// 
			// tabCmds
			// 
			this.tabCmds.Controls.Add(this.btnCmdShowHide);
			this.tabCmds.Controls.Add(this.lvCmds);
			this.tabCmds.Controls.Add(this.label23);
			this.tabCmds.Controls.Add(this.btnCmdOnOff);
			this.tabCmds.Controls.Add(this.btnCmdExec);
			this.tabCmds.Controls.Add(this.ckAllowShortcuts);
			this.tabCmds.Location = new System.Drawing.Point(4, 29);
			this.tabCmds.Margin = new System.Windows.Forms.Padding(4);
			this.tabCmds.Name = "tabCmds";
			this.tabCmds.Padding = new System.Windows.Forms.Padding(4);
			this.tabCmds.Size = new System.Drawing.Size(728, 987);
			this.tabCmds.TabIndex = 2;
			this.tabCmds.Text = "Commands";
			this.tabCmds.UseVisualStyleBackColor = true;
			// 
			// btnCmdShowHide
			// 
			this.btnCmdShowHide.Location = new System.Drawing.Point(585, 921);
			this.btnCmdShowHide.Margin = new System.Windows.Forms.Padding(4);
			this.btnCmdShowHide.Name = "btnCmdShowHide";
			this.btnCmdShowHide.Size = new System.Drawing.Size(130, 32);
			this.btnCmdShowHide.TabIndex = 6;
			this.btnCmdShowHide.Text = "Show/Hide";
			this.btnCmdShowHide.UseVisualStyleBackColor = true;
			this.btnCmdShowHide.Click += new System.EventHandler(this.btnCmdShowHide_Click);
			// 
			// lvCmds
			// 
			this.lvCmds.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.lvCmds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.colName,
			this.colTitle,
			this.colOffline,
			this.colHidden,
			this.colAdobeName,
			this.colTip});
			this.lvCmds.FullRowSelect = true;
			this.lvCmds.GridLines = true;
			this.lvCmds.HideSelection = false;
			this.lvCmds.Location = new System.Drawing.Point(18, 88);
			this.lvCmds.Margin = new System.Windows.Forms.Padding(4);
			this.lvCmds.MultiSelect = false;
			this.lvCmds.Name = "lvCmds";
			this.lvCmds.Size = new System.Drawing.Size(696, 822);
			this.lvCmds.TabIndex = 5;
			this.lvCmds.UseCompatibleStateImageBehavior = false;
			this.lvCmds.View = System.Windows.Forms.View.Details;
			this.lvCmds.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvCmds_ItemSelectionChanged);
			this.lvCmds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCmds_MouseDoubleClick);
			// 
			// colName
			// 
			this.colName.Text = "Identification Name";
			this.colName.Width = 200;
			// 
			// colTitle
			// 
			this.colTitle.Text = "Title";
			this.colTitle.Width = 300;
			// 
			// colOffline
			// 
			this.colOffline.Text = "Offline";
			this.colOffline.Width = 90;
			// 
			// colHidden
			// 
			this.colHidden.Text = "Hidden";
			// 
			// colAdobeName
			// 
			this.colAdobeName.Text = "Adobe\'s Name";
			this.colAdobeName.Width = 140;
			// 
			// colTip
			// 
			this.colTip.Text = "Tooltip";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(14, 64);
			this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(193, 20);
			this.label23.TabIndex = 4;
			this.label23.Text = "Supported commands list:";
			// 
			// btnCmdOnOff
			// 
			this.btnCmdOnOff.Location = new System.Drawing.Point(446, 921);
			this.btnCmdOnOff.Margin = new System.Windows.Forms.Padding(4);
			this.btnCmdOnOff.Name = "btnCmdOnOff";
			this.btnCmdOnOff.Size = new System.Drawing.Size(130, 32);
			this.btnCmdOnOff.TabIndex = 3;
			this.btnCmdOnOff.Text = "Turn On/Off";
			this.btnCmdOnOff.UseVisualStyleBackColor = true;
			this.btnCmdOnOff.Click += new System.EventHandler(this.btnCmdOnOff_Click);
			// 
			// btnCmdExec
			// 
			this.btnCmdExec.Location = new System.Drawing.Point(18, 921);
			this.btnCmdExec.Margin = new System.Windows.Forms.Padding(4);
			this.btnCmdExec.Name = "btnCmdExec";
			this.btnCmdExec.Size = new System.Drawing.Size(130, 32);
			this.btnCmdExec.TabIndex = 2;
			this.btnCmdExec.Text = "Execute";
			this.btnCmdExec.UseVisualStyleBackColor = true;
			this.btnCmdExec.Click += new System.EventHandler(this.btnCmdExec_Click);
			// 
			// ckAllowShortcuts
			// 
			this.ckAllowShortcuts.AutoSize = true;
			this.ckAllowShortcuts.Location = new System.Drawing.Point(18, 22);
			this.ckAllowShortcuts.Margin = new System.Windows.Forms.Padding(4);
			this.ckAllowShortcuts.Name = "ckAllowShortcuts";
			this.ckAllowShortcuts.Size = new System.Drawing.Size(253, 24);
			this.ckAllowShortcuts.TabIndex = 0;
			this.ckAllowShortcuts.Text = "Allow Shortcuts for Commands";
			this.ckAllowShortcuts.UseVisualStyleBackColor = true;
			this.ckAllowShortcuts.CheckedChanged += new System.EventHandler(this.ckAllowShortcuts_CheckedChanged);
			// 
			// tabView
			// 
			this.tabView.Controls.Add(this.label45);
			this.tabView.Controls.Add(this.cmdBarsTree);
			this.tabView.Controls.Add(this.ckRibbonUI);
			this.tabView.Controls.Add(this.ckShowFormViewBar);
			this.tabView.Controls.Add(this.label44);
			this.tabView.Controls.Add(this.ckShowRotateViewBar);
			this.tabView.Controls.Add(this.ckShowDocOptsBar);
			this.tabView.Controls.Add(this.ckShowDocLaunchBar);
			this.tabView.Controls.Add(this.ckLockCmdPanes);
			this.tabView.Controls.Add(this.ckShowPagesLayoutBar);
			this.tabView.Controls.Add(this.ckShowPagesNavBar);
			this.tabView.Controls.Add(this.ckShowPageZoomBar);
			this.tabView.Controls.Add(this.ckShowMeasureBar);
			this.tabView.Controls.Add(this.ckShowContentEdtBar);
			this.tabView.Controls.Add(this.ckShowCommentBar);
			this.tabView.Controls.Add(this.ckShowPropBar);
			this.tabView.Controls.Add(this.ckShowStdBar);
			this.tabView.Controls.Add(this.ckShowMenu);
			this.tabView.Controls.Add(this.ckShowFileBar);
			this.tabView.Controls.Add(this.label15);
			this.tabView.Controls.Add(this.label27);
			this.tabView.Controls.Add(this.label26);
			this.tabView.Controls.Add(this.label25);
			this.tabView.Controls.Add(this.label24);
			this.tabView.Controls.Add(this.ckShowPanZoom);
			this.tabView.Controls.Add(this.ckShowStampsPalette);
			this.tabView.Controls.Add(this.ckShowCommentStyles);
			this.tabView.Controls.Add(this.ckShowSearchPane);
			this.tabView.Controls.Add(this.label17);
			this.tabView.Controls.Add(this.ckSyncDocPanesLayout);
			this.tabView.Controls.Add(this.ckShowAttachments);
			this.tabView.Controls.Add(this.ckShowSignatures);
			this.tabView.Controls.Add(this.ckShowLayers);
			this.tabView.Controls.Add(this.ckShowComments);
			this.tabView.Controls.Add(this.ckShowBookm);
			this.tabView.Controls.Add(this.ckShowThumbs);
			this.tabView.Controls.Add(this.ckHideSb);
			this.tabView.Controls.Add(this.ckShowCmdPanes);
			this.tabView.Controls.Add(this.ckUnlockCmdBars);
			this.tabView.Location = new System.Drawing.Point(4, 29);
			this.tabView.Margin = new System.Windows.Forms.Padding(4);
			this.tabView.Name = "tabView";
			this.tabView.Padding = new System.Windows.Forms.Padding(4);
			this.tabView.Size = new System.Drawing.Size(728, 1134);
			this.tabView.TabIndex = 1;
			this.tabView.Text = "View";
			this.tabView.UseVisualStyleBackColor = true;
			this.tabView.Click += new System.EventHandler(this.tabView_Click);
			// 
			// cmdBarsTree
			// 
			this.cmdBarsTree.CheckBoxes = true;
			this.cmdBarsTree.Location = new System.Drawing.Point(327, 209);
			this.cmdBarsTree.Name = "cmdBarsTree";
			this.cmdBarsTree.Size = new System.Drawing.Size(381, 457);
			this.cmdBarsTree.TabIndex = 60;
			this.cmdBarsTree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.cmdBarsTree_DrawNode);
			// 
			// ckRibbonUI
			// 
			this.ckRibbonUI.AutoSize = true;
			this.ckRibbonUI.Location = new System.Drawing.Point(30, 157);
			this.ckRibbonUI.Name = "ckRibbonUI";
			this.ckRibbonUI.Size = new System.Drawing.Size(140, 24);
			this.ckRibbonUI.TabIndex = 59;
			this.ckRibbonUI.Text = "Use Ribbon UI";
			this.ckRibbonUI.UseVisualStyleBackColor = true;
			this.ckRibbonUI.CheckedChanged += new System.EventHandler(this.ckRibbonUI_CheckedChanged);
			// 
			// ckShowFormViewBar
			// 
			this.ckShowFormViewBar.AutoSize = true;
			this.ckShowFormViewBar.Location = new System.Drawing.Point(30, 482);
			this.ckShowFormViewBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowFormViewBar.Name = "ckShowFormViewBar";
			this.ckShowFormViewBar.Size = new System.Drawing.Size(181, 24);
			this.ckShowFormViewBar.TabIndex = 59;
			this.ckShowFormViewBar.Text = "Show Form View bar";
			this.ckShowFormViewBar.UseVisualStyleBackColor = true;
			this.ckShowFormViewBar.CheckedChanged += new System.EventHandler(this.cbShowFormViewbar_CheckedChanged);
			// 
			// label44
			// 
			this.label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label44.Location = new System.Drawing.Point(12, 670);
			this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(575, 1);
			this.label44.TabIndex = 58;
			// 
			// ckShowRotateViewBar
			// 
			this.ckShowRotateViewBar.AutoSize = true;
			this.ckShowRotateViewBar.Location = new System.Drawing.Point(30, 440);
			this.ckShowRotateViewBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowRotateViewBar.Name = "ckShowRotateViewBar";
			this.ckShowRotateViewBar.Size = new System.Drawing.Size(193, 24);
			this.ckShowRotateViewBar.TabIndex = 57;
			this.ckShowRotateViewBar.Text = "Show Rotate View bar";
			this.ckShowRotateViewBar.UseVisualStyleBackColor = true;
			this.ckShowRotateViewBar.CheckedChanged += new System.EventHandler(this.ckShowRotateViewBar_CheckedChanged);
			// 
			// ckShowDocOptsBar
			// 
			this.ckShowDocOptsBar.AutoSize = true;
			this.ckShowDocOptsBar.Location = new System.Drawing.Point(30, 610);
			this.ckShowDocOptsBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowDocOptsBar.Name = "ckShowDocOptsBar";
			this.ckShowDocOptsBar.Size = new System.Drawing.Size(239, 24);
			this.ckShowDocOptsBar.TabIndex = 56;
			this.ckShowDocOptsBar.Text = "Show Document Options bar";
			this.ckShowDocOptsBar.UseVisualStyleBackColor = true;
			this.ckShowDocOptsBar.CheckedChanged += new System.EventHandler(this.ckShowDocOptsBar_CheckedChanged);
			// 
			// ckShowDocLaunchBar
			// 
			this.ckShowDocLaunchBar.AutoSize = true;
			this.ckShowDocLaunchBar.Location = new System.Drawing.Point(30, 579);
			this.ckShowDocLaunchBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowDocLaunchBar.Name = "ckShowDocLaunchBar";
			this.ckShowDocLaunchBar.Size = new System.Drawing.Size(237, 24);
			this.ckShowDocLaunchBar.TabIndex = 55;
			this.ckShowDocLaunchBar.Text = "Show Launch Document bar";
			this.ckShowDocLaunchBar.UseVisualStyleBackColor = true;
			this.ckShowDocLaunchBar.CheckedChanged += new System.EventHandler(this.ckShowDocLaunchBar_CheckedChanged);
			// 
			// ckLockCmdPanes
			// 
			this.ckLockCmdPanes.AutoSize = true;
			this.ckLockCmdPanes.Location = new System.Drawing.Point(30, 94);
			this.ckLockCmdPanes.Margin = new System.Windows.Forms.Padding(4);
			this.ckLockCmdPanes.Name = "ckLockCmdPanes";
			this.ckLockCmdPanes.Size = new System.Drawing.Size(582, 24);
			this.ckLockCmdPanes.TabIndex = 2;
			this.ckLockCmdPanes.Text = "Lock Command Panes (i.e. prevent minimize/restore command panes by user)";
			this.ckLockCmdPanes.UseVisualStyleBackColor = true;
			this.ckLockCmdPanes.CheckedChanged += new System.EventHandler(this.ckLockCmdPanes_CheckedChanged);
			// 
			// ckShowPagesLayoutBar
			// 
			this.ckShowPagesLayoutBar.AutoSize = true;
			this.ckShowPagesLayoutBar.Location = new System.Drawing.Point(30, 545);
			this.ckShowPagesLayoutBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowPagesLayoutBar.Name = "ckShowPagesLayoutBar";
			this.ckShowPagesLayoutBar.Size = new System.Drawing.Size(203, 24);
			this.ckShowPagesLayoutBar.TabIndex = 53;
			this.ckShowPagesLayoutBar.Text = "Show Pages Layout bar";
			this.ckShowPagesLayoutBar.UseVisualStyleBackColor = true;
			this.ckShowPagesLayoutBar.CheckedChanged += new System.EventHandler(this.ckShowPagesLayoutBar_CheckedChanged);
			// 
			// ckShowPagesNavBar
			// 
			this.ckShowPagesNavBar.AutoSize = true;
			this.ckShowPagesNavBar.Location = new System.Drawing.Point(30, 514);
			this.ckShowPagesNavBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowPagesNavBar.Name = "ckShowPagesNavBar";
			this.ckShowPagesNavBar.Size = new System.Drawing.Size(229, 24);
			this.ckShowPagesNavBar.TabIndex = 52;
			this.ckShowPagesNavBar.Text = "Show Pages Navigation bar";
			this.ckShowPagesNavBar.UseVisualStyleBackColor = true;
			this.ckShowPagesNavBar.CheckedChanged += new System.EventHandler(this.ckShowPagesNavBar_CheckedChanged);
			// 
			// ckShowPageZoomBar
			// 
			this.ckShowPageZoomBar.AutoSize = true;
			this.ckShowPageZoomBar.Location = new System.Drawing.Point(30, 642);
			this.ckShowPageZoomBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowPageZoomBar.Name = "ckShowPageZoomBar";
			this.ckShowPageZoomBar.Size = new System.Drawing.Size(147, 24);
			this.ckShowPageZoomBar.TabIndex = 51;
			this.ckShowPageZoomBar.Text = "Show Zoom bar";
			this.ckShowPageZoomBar.UseVisualStyleBackColor = true;
			this.ckShowPageZoomBar.CheckedChanged += new System.EventHandler(this.ckShowZoomBar_CheckedChanged);
			// 
			// ckShowMeasureBar
			// 
			this.ckShowMeasureBar.AutoSize = true;
			this.ckShowMeasureBar.Location = new System.Drawing.Point(30, 406);
			this.ckShowMeasureBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowMeasureBar.Name = "ckShowMeasureBar";
			this.ckShowMeasureBar.Size = new System.Drawing.Size(204, 24);
			this.ckShowMeasureBar.TabIndex = 50;
			this.ckShowMeasureBar.Text = "Show Measurement bar";
			this.ckShowMeasureBar.UseVisualStyleBackColor = true;
			this.ckShowMeasureBar.CheckedChanged += new System.EventHandler(this.ckShowMeasureBar_CheckedChanged);
			// 
			// ckShowContentEdtBar
			// 
			this.ckShowContentEdtBar.AutoSize = true;
			this.ckShowContentEdtBar.Location = new System.Drawing.Point(30, 375);
			this.ckShowContentEdtBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowContentEdtBar.Name = "ckShowContentEdtBar";
			this.ckShowContentEdtBar.Size = new System.Drawing.Size(216, 24);
			this.ckShowContentEdtBar.TabIndex = 49;
			this.ckShowContentEdtBar.Text = "Show Content Editing bar";
			this.ckShowContentEdtBar.UseVisualStyleBackColor = true;
			this.ckShowContentEdtBar.CheckedChanged += new System.EventHandler(this.ckShowContentEdtBar_CheckedChanged);
			// 
			// ckShowCommentBar
			// 
			this.ckShowCommentBar.AutoSize = true;
			this.ckShowCommentBar.Location = new System.Drawing.Point(30, 344);
			this.ckShowCommentBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowCommentBar.Name = "ckShowCommentBar";
			this.ckShowCommentBar.Size = new System.Drawing.Size(196, 24);
			this.ckShowCommentBar.TabIndex = 48;
			this.ckShowCommentBar.Text = "Show Commenting bar";
			this.ckShowCommentBar.UseVisualStyleBackColor = true;
			this.ckShowCommentBar.CheckedChanged += new System.EventHandler(this.ckShowCommentBar_CheckedChanged);
			// 
			// ckShowPropBar
			// 
			this.ckShowPropBar.AutoSize = true;
			this.ckShowPropBar.Location = new System.Drawing.Point(30, 312);
			this.ckShowPropBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowPropBar.Name = "ckShowPropBar";
			this.ckShowPropBar.Size = new System.Drawing.Size(178, 24);
			this.ckShowPropBar.TabIndex = 47;
			this.ckShowPropBar.Text = "Show Properties bar";
			this.ckShowPropBar.UseVisualStyleBackColor = true;
			this.ckShowPropBar.CheckedChanged += new System.EventHandler(this.ckShowPropBar_CheckedChanged);
			// 
			// ckShowStdBar
			// 
			this.ckShowStdBar.AutoSize = true;
			this.ckShowStdBar.Location = new System.Drawing.Point(30, 281);
			this.ckShowStdBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowStdBar.Name = "ckShowStdBar";
			this.ckShowStdBar.Size = new System.Drawing.Size(172, 24);
			this.ckShowStdBar.TabIndex = 46;
			this.ckShowStdBar.Text = "Show Standard bar";
			this.ckShowStdBar.UseVisualStyleBackColor = true;
			this.ckShowStdBar.CheckedChanged += new System.EventHandler(this.ckShowStdBar_CheckedChanged);
			// 
			// ckShowMenu
			// 
			this.ckShowMenu.AutoSize = true;
			this.ckShowMenu.Location = new System.Drawing.Point(30, 216);
			this.ckShowMenu.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowMenu.Name = "ckShowMenu";
			this.ckShowMenu.Size = new System.Drawing.Size(146, 24);
			this.ckShowMenu.TabIndex = 45;
			this.ckShowMenu.Text = "Show Menu bar";
			this.ckShowMenu.UseVisualStyleBackColor = true;
			this.ckShowMenu.CheckedChanged += new System.EventHandler(this.ckShowMenu_CheckedChanged);
			// 
			// ckShowFileBar
			// 
			this.ckShowFileBar.AutoSize = true;
			this.ckShowFileBar.Location = new System.Drawing.Point(30, 247);
			this.ckShowFileBar.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowFileBar.Name = "ckShowFileBar";
			this.ckShowFileBar.Size = new System.Drawing.Size(131, 24);
			this.ckShowFileBar.TabIndex = 44;
			this.ckShowFileBar.Text = "Show File bar";
			this.ckShowFileBar.UseVisualStyleBackColor = true;
			this.ckShowFileBar.CheckedChanged += new System.EventHandler(this.ckShowFileBar_CheckedChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(8, 192);
			this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(121, 20);
			this.label15.TabIndex = 43;
			this.label15.Text = "Command bars:";
			// 
			// label27
			// 
			this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label27.Location = new System.Drawing.Point(137, 203);
			this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(450, 3);
			this.label27.TabIndex = 42;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(0, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(100, 23);
			this.label26.TabIndex = 61;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(0, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 23);
			this.label25.TabIndex = 62;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(0, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 63;
			// 
			// ckShowPanZoom
			// 
			this.ckShowPanZoom.AutoSize = true;
			this.ckShowPanZoom.Location = new System.Drawing.Point(23, 820);
			this.ckShowPanZoom.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowPanZoom.Name = "ckShowPanZoom";
			this.ckShowPanZoom.Size = new System.Drawing.Size(227, 24);
			this.ckShowPanZoom.TabIndex = 38;
			this.ckShowPanZoom.Text = "Show Pan and Zoom pane ";
			this.ckShowPanZoom.UseVisualStyleBackColor = true;
			this.ckShowPanZoom.CheckedChanged += new System.EventHandler(this.ckShowPanZoom_CheckedChanged);
			// 
			// ckShowStampsPalette
			// 
			this.ckShowStampsPalette.AutoSize = true;
			this.ckShowStampsPalette.Location = new System.Drawing.Point(23, 788);
			this.ckShowStampsPalette.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowStampsPalette.Name = "ckShowStampsPalette";
			this.ckShowStampsPalette.Size = new System.Drawing.Size(188, 24);
			this.ckShowStampsPalette.TabIndex = 37;
			this.ckShowStampsPalette.Text = "Show Stamps Palette";
			this.ckShowStampsPalette.UseVisualStyleBackColor = true;
			this.ckShowStampsPalette.CheckedChanged += new System.EventHandler(this.ckShowStampsPalette_CheckedChanged);
			// 
			// ckShowCommentStyles
			// 
			this.ckShowCommentStyles.AutoSize = true;
			this.ckShowCommentStyles.Location = new System.Drawing.Point(23, 724);
			this.ckShowCommentStyles.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowCommentStyles.Name = "ckShowCommentStyles";
			this.ckShowCommentStyles.Size = new System.Drawing.Size(249, 24);
			this.ckShowCommentStyles.TabIndex = 36;
			this.ckShowCommentStyles.Text = "Show Comment Styles Palette";
			this.ckShowCommentStyles.UseVisualStyleBackColor = true;
			this.ckShowCommentStyles.CheckedChanged += new System.EventHandler(this.ckShowCommentStyles_CheckedChanged);
			// 
			// ckShowSearchPane
			// 
			this.ckShowSearchPane.AutoSize = true;
			this.ckShowSearchPane.Location = new System.Drawing.Point(23, 756);
			this.ckShowSearchPane.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowSearchPane.Name = "ckShowSearchPane";
			this.ckShowSearchPane.Size = new System.Drawing.Size(170, 24);
			this.ckShowSearchPane.TabIndex = 35;
			this.ckShowSearchPane.Text = "Show Search pane";
			this.ckShowSearchPane.UseVisualStyleBackColor = true;
			this.ckShowSearchPane.CheckedChanged += new System.EventHandler(this.ckShowSearchPane_CheckedChanged);
			// 
			// label17
			// 
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label17.Location = new System.Drawing.Point(152, 873);
			this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(436, 2);
			this.label17.TabIndex = 34;
			// 
			// ckSyncDocPanesLayout
			// 
			this.ckSyncDocPanesLayout.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ckSyncDocPanesLayout.Location = new System.Drawing.Point(327, 878);
			this.ckSyncDocPanesLayout.Margin = new System.Windows.Forms.Padding(4);
			this.ckSyncDocPanesLayout.Name = "ckSyncDocPanesLayout";
			this.ckSyncDocPanesLayout.Size = new System.Drawing.Size(212, 81);
			this.ckSyncDocPanesLayout.TabIndex = 10;
			this.ckSyncDocPanesLayout.Text = "Auto-syncronize document panes layout";
			this.ckSyncDocPanesLayout.UseVisualStyleBackColor = true;
			this.ckSyncDocPanesLayout.CheckedChanged += new System.EventHandler(this.ckSyncDocPanesLayout_CheckedChanged);
			// 
			// ckShowAttachments
			// 
			this.ckShowAttachments.AutoSize = true;
			this.ckShowAttachments.Location = new System.Drawing.Point(23, 1059);
			this.ckShowAttachments.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowAttachments.Name = "ckShowAttachments";
			this.ckShowAttachments.Size = new System.Drawing.Size(202, 24);
			this.ckShowAttachments.TabIndex = 9;
			this.ckShowAttachments.Text = "Show Attachment pane";
			this.ckShowAttachments.UseVisualStyleBackColor = true;
			this.ckShowAttachments.CheckedChanged += new System.EventHandler(this.ckShowAttachments_CheckedChanged);
			// 
			// ckShowSignatures
			// 
			this.ckShowSignatures.AutoSize = true;
			this.ckShowSignatures.Location = new System.Drawing.Point(23, 1028);
			this.ckShowSignatures.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowSignatures.Name = "ckShowSignatures";
			this.ckShowSignatures.Size = new System.Drawing.Size(196, 24);
			this.ckShowSignatures.TabIndex = 8;
			this.ckShowSignatures.Text = "Show Signatures pane";
			this.ckShowSignatures.UseVisualStyleBackColor = true;
			this.ckShowSignatures.CheckedChanged += new System.EventHandler(this.ckShowSignatures_CheckedChanged);
			// 
			// ckShowLayers
			// 
			this.ckShowLayers.AutoSize = true;
			this.ckShowLayers.Location = new System.Drawing.Point(23, 994);
			this.ckShowLayers.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowLayers.Name = "ckShowLayers";
			this.ckShowLayers.Size = new System.Drawing.Size(166, 24);
			this.ckShowLayers.TabIndex = 7;
			this.ckShowLayers.Text = "Show Layers pane";
			this.ckShowLayers.UseVisualStyleBackColor = true;
			this.ckShowLayers.CheckedChanged += new System.EventHandler(this.ckShowLayers_CheckedChanged);
			// 
			// ckShowComments
			// 
			this.ckShowComments.AutoSize = true;
			this.ckShowComments.Location = new System.Drawing.Point(23, 963);
			this.ckShowComments.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowComments.Name = "ckShowComments";
			this.ckShowComments.Size = new System.Drawing.Size(196, 24);
			this.ckShowComments.TabIndex = 6;
			this.ckShowComments.Text = "Show Comments pane";
			this.ckShowComments.UseVisualStyleBackColor = true;
			this.ckShowComments.CheckedChanged += new System.EventHandler(this.ckShowComments_CheckedChanged);
			// 
			// ckShowBookm
			// 
			this.ckShowBookm.AutoSize = true;
			this.ckShowBookm.Location = new System.Drawing.Point(23, 932);
			this.ckShowBookm.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowBookm.Name = "ckShowBookm";
			this.ckShowBookm.Size = new System.Drawing.Size(199, 24);
			this.ckShowBookm.TabIndex = 5;
			this.ckShowBookm.Text = "Show Bookmarks pane";
			this.ckShowBookm.UseVisualStyleBackColor = true;
			this.ckShowBookm.CheckedChanged += new System.EventHandler(this.ckShowBookm_CheckedChanged);
			// 
			// ckShowThumbs
			// 
			this.ckShowThumbs.AutoSize = true;
			this.ckShowThumbs.Location = new System.Drawing.Point(23, 898);
			this.ckShowThumbs.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowThumbs.Name = "ckShowThumbs";
			this.ckShowThumbs.Size = new System.Drawing.Size(200, 24);
			this.ckShowThumbs.TabIndex = 4;
			this.ckShowThumbs.Text = "Show Thumbnails pane";
			this.ckShowThumbs.UseVisualStyleBackColor = true;
			this.ckShowThumbs.CheckedChanged += new System.EventHandler(this.ckShowThumbs_CheckedChanged);
			// 
			// ckHideSb
			// 
			this.ckHideSb.AutoSize = true;
			this.ckHideSb.Location = new System.Drawing.Point(30, 126);
			this.ckHideSb.Margin = new System.Windows.Forms.Padding(4);
			this.ckHideSb.Name = "ckHideSb";
			this.ckHideSb.Size = new System.Drawing.Size(142, 24);
			this.ckHideSb.TabIndex = 3;
			this.ckHideSb.Text = "Hide Scrollbars";
			this.ckHideSb.UseVisualStyleBackColor = true;
			this.ckHideSb.CheckedChanged += new System.EventHandler(this.ckHideSb_CheckedChanged);
			// 
			// ckShowCmdPanes
			// 
			this.ckShowCmdPanes.AutoSize = true;
			this.ckShowCmdPanes.Location = new System.Drawing.Point(30, 30);
			this.ckShowCmdPanes.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowCmdPanes.Name = "ckShowCmdPanes";
			this.ckShowCmdPanes.Size = new System.Drawing.Size(201, 24);
			this.ckShowCmdPanes.TabIndex = 0;
			this.ckShowCmdPanes.Text = "Show Command Panes";
			this.ckShowCmdPanes.UseVisualStyleBackColor = true;
			this.ckShowCmdPanes.CheckedChanged += new System.EventHandler(this.ckShowCmdPanes_CheckedChanged);
			// 
			// ckUnlockCmdBars
			// 
			this.ckUnlockCmdBars.AutoSize = true;
			this.ckUnlockCmdBars.Location = new System.Drawing.Point(30, 62);
			this.ckUnlockCmdBars.Margin = new System.Windows.Forms.Padding(4);
			this.ckUnlockCmdBars.Name = "ckUnlockCmdBars";
			this.ckUnlockCmdBars.Size = new System.Drawing.Size(511, 24);
			this.ckUnlockCmdBars.TabIndex = 1;
			this.ckUnlockCmdBars.Text = "Unlock Command Bars (i.e. allow toggle/customize toolbars by user)";
			this.ckUnlockCmdBars.UseVisualStyleBackColor = true;
			this.ckUnlockCmdBars.CheckedChanged += new System.EventHandler(this.ckUnlockCmdBars_CheckedChanged);
			// 
			// tabDoc
			// 
			this.tabDoc.Controls.Add(this.gboxPages);
			this.tabDoc.Controls.Add(this.ckAllowAskForSave);
			this.tabDoc.Controls.Add(this.btnCloseDoc);
			this.tabDoc.Controls.Add(this.gboxSave);
			this.tabDoc.Controls.Add(this.gboxOpen);
			this.tabDoc.Controls.Add(this.gboxInfo);
			this.tabDoc.Location = new System.Drawing.Point(4, 29);
			this.tabDoc.Margin = new System.Windows.Forms.Padding(4);
			this.tabDoc.Name = "tabDoc";
			this.tabDoc.Padding = new System.Windows.Forms.Padding(4);
			this.tabDoc.Size = new System.Drawing.Size(728, 1134);
			this.tabDoc.TabIndex = 0;
			this.tabDoc.Text = "Document";
			this.tabDoc.UseVisualStyleBackColor = true;
			// 
			// gboxPages
			// 
			this.gboxPages.Controls.Add(this.btnZoomOut);
			this.gboxPages.Controls.Add(this.btnZoomIn);
			this.gboxPages.Controls.Add(this.tCurPage);
			this.gboxPages.Controls.Add(this.label12);
			this.gboxPages.Controls.Add(this.cbPagesLayout);
			this.gboxPages.Controls.Add(this.label13);
			this.gboxPages.Controls.Add(this.cbPagesZoom);
			this.gboxPages.Controls.Add(this.label14);
			this.gboxPages.Controls.Add(this.lbPageRotation);
			this.gboxPages.Controls.Add(this.label16);
			this.gboxPages.Controls.Add(this.label18);
			this.gboxPages.Controls.Add(this.lbPageSize);
			this.gboxPages.Location = new System.Drawing.Point(9, 507);
			this.gboxPages.Margin = new System.Windows.Forms.Padding(4);
			this.gboxPages.Name = "gboxPages";
			this.gboxPages.Padding = new System.Windows.Forms.Padding(4);
			this.gboxPages.Size = new System.Drawing.Size(711, 160);
			this.gboxPages.TabIndex = 2;
			this.gboxPages.TabStop = false;
			this.gboxPages.Text = "Pages View";
			// 
			// btnZoomOut
			// 
			this.btnZoomOut.Location = new System.Drawing.Point(336, 102);
			this.btnZoomOut.Margin = new System.Windows.Forms.Padding(4);
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new System.Drawing.Size(33, 33);
			this.btnZoomOut.TabIndex = 11;
			this.btnZoomOut.Text = "-";
			this.btnZoomOut.UseVisualStyleBackColor = true;
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// btnZoomIn
			// 
			this.btnZoomIn.Location = new System.Drawing.Point(302, 102);
			this.btnZoomIn.Margin = new System.Windows.Forms.Padding(4);
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new System.Drawing.Size(33, 33);
			this.btnZoomIn.TabIndex = 10;
			this.btnZoomIn.Text = "+";
			this.btnZoomIn.UseVisualStyleBackColor = true;
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// tCurPage
			// 
			this.tCurPage.AcceptsReturn = true;
			this.tCurPage.Location = new System.Drawing.Point(144, 34);
			this.tCurPage.Margin = new System.Windows.Forms.Padding(4);
			this.tCurPage.Name = "tCurPage";
			this.tCurPage.Size = new System.Drawing.Size(223, 26);
			this.tCurPage.TabIndex = 1;
			this.tCurPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tCurPage_KeyDown);
			this.tCurPage.Leave += new System.EventHandler(this.tCurPage_Leave);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(28, 40);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(114, 20);
			this.label12.TabIndex = 0;
			this.label12.Text = "Current Page:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbPagesLayout
			// 
			this.cbPagesLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPagesLayout.FormattingEnabled = true;
			this.cbPagesLayout.Location = new System.Drawing.Point(144, 68);
			this.cbPagesLayout.Margin = new System.Windows.Forms.Padding(4);
			this.cbPagesLayout.Name = "cbPagesLayout";
			this.cbPagesLayout.Size = new System.Drawing.Size(223, 28);
			this.cbPagesLayout.TabIndex = 3;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(28, 74);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(114, 20);
			this.label13.TabIndex = 2;
			this.label13.Text = "Pages Layout:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbPagesZoom
			// 
			this.cbPagesZoom.FormattingEnabled = true;
			this.cbPagesZoom.Location = new System.Drawing.Point(144, 104);
			this.cbPagesZoom.Margin = new System.Windows.Forms.Padding(4);
			this.cbPagesZoom.Name = "cbPagesZoom";
			this.cbPagesZoom.Size = new System.Drawing.Size(151, 28);
			this.cbPagesZoom.TabIndex = 5;
			this.cbPagesZoom.SelectedIndexChanged += new System.EventHandler(this.cbPagesZoom_SelectedIndexChanged);
			this.cbPagesZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPagesZoom_KeyDown);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(28, 110);
			this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(114, 20);
			this.label14.TabIndex = 4;
			this.label14.Text = "Pages Zoom:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbPageRotation
			// 
			this.lbPageRotation.Location = new System.Drawing.Point(503, 70);
			this.lbPageRotation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPageRotation.Name = "lbPageRotation";
			this.lbPageRotation.Size = new System.Drawing.Size(200, 20);
			this.lbPageRotation.TabIndex = 9;
			this.lbPageRotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(375, 38);
			this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(127, 20);
			this.label16.TabIndex = 6;
			this.label16.Text = "Page Size:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(371, 70);
			this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(131, 20);
			this.label18.TabIndex = 8;
			this.label18.Text = "Page Rotation:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbPageSize
			// 
			this.lbPageSize.Location = new System.Drawing.Point(503, 38);
			this.lbPageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPageSize.Name = "lbPageSize";
			this.lbPageSize.Size = new System.Drawing.Size(200, 20);
			this.lbPageSize.TabIndex = 7;
			this.lbPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ckAllowAskForSave
			// 
			this.ckAllowAskForSave.AutoSize = true;
			this.ckAllowAskForSave.Location = new System.Drawing.Point(286, 910);
			this.ckAllowAskForSave.Margin = new System.Windows.Forms.Padding(4);
			this.ckAllowAskForSave.Name = "ckAllowAskForSave";
			this.ckAllowAskForSave.Size = new System.Drawing.Size(261, 24);
			this.ckAllowAskForSave.TabIndex = 5;
			this.ckAllowAskForSave.Text = "Allow ask for save user changes";
			this.ckAllowAskForSave.UseVisualStyleBackColor = true;
			// 
			// btnCloseDoc
			// 
			this.btnCloseDoc.Location = new System.Drawing.Point(42, 903);
			this.btnCloseDoc.Margin = new System.Windows.Forms.Padding(4);
			this.btnCloseDoc.Name = "btnCloseDoc";
			this.btnCloseDoc.Size = new System.Drawing.Size(228, 38);
			this.btnCloseDoc.TabIndex = 4;
			this.btnCloseDoc.Text = "Close Document";
			this.btnCloseDoc.UseVisualStyleBackColor = true;
			this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
			// 
			// gboxSave
			// 
			this.gboxSave.Controls.Add(this.ckSwitchToDest);
			this.gboxSave.Controls.Add(this.btnSimpleSave);
			this.gboxSave.Controls.Add(this.ckIStreamDestDemo);
			this.gboxSave.Controls.Add(this.label20);
			this.gboxSave.Controls.Add(this.label21);
			this.gboxSave.Controls.Add(this.btnShowSaveAsDlg);
			this.gboxSave.Controls.Add(this.btnBrowseForSaveAs);
			this.gboxSave.Controls.Add(this.btnSaveToCustDest);
			this.gboxSave.Controls.Add(this.tDestToSave);
			this.gboxSave.Location = new System.Drawing.Point(9, 675);
			this.gboxSave.Margin = new System.Windows.Forms.Padding(4);
			this.gboxSave.Name = "gboxSave";
			this.gboxSave.Padding = new System.Windows.Forms.Padding(4);
			this.gboxSave.Size = new System.Drawing.Size(711, 212);
			this.gboxSave.TabIndex = 3;
			this.gboxSave.TabStop = false;
			this.gboxSave.Text = "Save";
			// 
			// ckSwitchToDest
			// 
			this.ckSwitchToDest.AutoSize = true;
			this.ckSwitchToDest.Location = new System.Drawing.Point(292, 176);
			this.ckSwitchToDest.Margin = new System.Windows.Forms.Padding(4);
			this.ckSwitchToDest.Name = "ckSwitchToDest";
			this.ckSwitchToDest.Size = new System.Drawing.Size(215, 24);
			this.ckSwitchToDest.TabIndex = 7;
			this.ckSwitchToDest.Text = "Switch to new destination";
			this.ckSwitchToDest.UseVisualStyleBackColor = true;
			// 
			// btnSimpleSave
			// 
			this.btnSimpleSave.Location = new System.Drawing.Point(442, 34);
			this.btnSimpleSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSimpleSave.Name = "btnSimpleSave";
			this.btnSimpleSave.Size = new System.Drawing.Size(228, 38);
			this.btnSimpleSave.TabIndex = 2;
			this.btnSimpleSave.Text = "Save to Source";
			this.btnSimpleSave.UseVisualStyleBackColor = true;
			this.btnSimpleSave.Click += new System.EventHandler(this.btnSimpleSave_Click);
			// 
			// ckIStreamDestDemo
			// 
			this.ckIStreamDestDemo.AutoSize = true;
			this.ckIStreamDestDemo.Location = new System.Drawing.Point(36, 176);
			this.ckIStreamDestDemo.Margin = new System.Windows.Forms.Padding(4);
			this.ckIStreamDestDemo.Name = "ckIStreamDestDemo";
			this.ckIStreamDestDemo.Size = new System.Drawing.Size(225, 24);
			this.ckIStreamDestDemo.TabIndex = 6;
			this.ckIStreamDestDemo.Text = "IStream-Destination Demo";
			this.ckIStreamDestDemo.UseVisualStyleBackColor = true;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(32, 116);
			this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(402, 20);
			this.label20.TabIndex = 4;
			this.label20.Text = "or specify custom destination path to save document to:";
			// 
			// label21
			// 
			this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label21.Location = new System.Drawing.Point(36, 102);
			this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(663, 3);
			this.label21.TabIndex = 3;
			// 
			// btnShowSaveAsDlg
			// 
			this.btnShowSaveAsDlg.Location = new System.Drawing.Point(36, 34);
			this.btnShowSaveAsDlg.Margin = new System.Windows.Forms.Padding(4);
			this.btnShowSaveAsDlg.Name = "btnShowSaveAsDlg";
			this.btnShowSaveAsDlg.Size = new System.Drawing.Size(342, 38);
			this.btnShowSaveAsDlg.TabIndex = 1;
			this.btnShowSaveAsDlg.Text = "Click to Show SaveAs Dialog...";
			this.btnShowSaveAsDlg.UseVisualStyleBackColor = true;
			this.btnShowSaveAsDlg.Click += new System.EventHandler(this.btnShowSaveAsDlg_Click);
			// 
			// btnBrowseForSaveAs
			// 
			this.btnBrowseForSaveAs.Location = new System.Drawing.Point(442, 138);
			this.btnBrowseForSaveAs.Margin = new System.Windows.Forms.Padding(4);
			this.btnBrowseForSaveAs.Name = "btnBrowseForSaveAs";
			this.btnBrowseForSaveAs.Size = new System.Drawing.Size(110, 33);
			this.btnBrowseForSaveAs.TabIndex = 8;
			this.btnBrowseForSaveAs.Text = "Browse...";
			this.btnBrowseForSaveAs.UseVisualStyleBackColor = true;
			this.btnBrowseForSaveAs.Click += new System.EventHandler(this.btnBrowseForSaveAs_Click);
			// 
			// btnSaveToCustDest
			// 
			this.btnSaveToCustDest.Location = new System.Drawing.Point(560, 138);
			this.btnSaveToCustDest.Margin = new System.Windows.Forms.Padding(4);
			this.btnSaveToCustDest.Name = "btnSaveToCustDest";
			this.btnSaveToCustDest.Size = new System.Drawing.Size(136, 33);
			this.btnSaveToCustDest.TabIndex = 0;
			this.btnSaveToCustDest.Text = "Save";
			this.btnSaveToCustDest.UseVisualStyleBackColor = true;
			this.btnSaveToCustDest.Click += new System.EventHandler(this.btnSaveToCustDest_Click);
			// 
			// tDestToSave
			// 
			this.tDestToSave.Location = new System.Drawing.Point(36, 140);
			this.tDestToSave.Margin = new System.Windows.Forms.Padding(4);
			this.tDestToSave.Name = "tDestToSave";
			this.tDestToSave.Size = new System.Drawing.Size(398, 26);
			this.tDestToSave.TabIndex = 5;
			// 
			// gboxOpen
			// 
			this.gboxOpen.Controls.Add(this.ckHideSingleTab);
			this.gboxOpen.Controls.Add(this.ckMultDocs);
			this.gboxOpen.Controls.Add(this.ckIStreamSrcDemo);
			this.gboxOpen.Controls.Add(this.label19);
			this.gboxOpen.Controls.Add(this.label11);
			this.gboxOpen.Controls.Add(this.btnShowOpenDlg);
			this.gboxOpen.Controls.Add(this.btnBrowseForOpen);
			this.gboxOpen.Controls.Add(this.btnOpen);
			this.gboxOpen.Controls.Add(this.tSrcToOpen);
			this.gboxOpen.Location = new System.Drawing.Point(9, 9);
			this.gboxOpen.Margin = new System.Windows.Forms.Padding(4);
			this.gboxOpen.Name = "gboxOpen";
			this.gboxOpen.Padding = new System.Windows.Forms.Padding(4);
			this.gboxOpen.Size = new System.Drawing.Size(711, 201);
			this.gboxOpen.TabIndex = 0;
			this.gboxOpen.TabStop = false;
			this.gboxOpen.Text = "Open";
			// 
			// ckHideSingleTab
			// 
			this.ckHideSingleTab.AutoSize = true;
			this.ckHideSingleTab.Location = new System.Drawing.Point(437, 58);
			this.ckHideSingleTab.Name = "ckHideSingleTab";
			this.ckHideSingleTab.Size = new System.Drawing.Size(140, 24);
			this.ckHideSingleTab.TabIndex = 8;
			this.ckHideSingleTab.Text = "Hide single tab";
			this.ckHideSingleTab.UseVisualStyleBackColor = true;
			this.ckHideSingleTab.CheckedChanged += new System.EventHandler(this.ckHideSingleTab_CheckedChanged);
			// 
			// ckMultDocs
			// 
			this.ckMultDocs.AutoSize = true;
			this.ckMultDocs.Location = new System.Drawing.Point(437, 28);
			this.ckMultDocs.Name = "ckMultDocs";
			this.ckMultDocs.Size = new System.Drawing.Size(220, 24);
			this.ckMultDocs.TabIndex = 7;
			this.ckMultDocs.Text = "Multiple documents  mode";
			this.ckMultDocs.UseVisualStyleBackColor = true;
			this.ckMultDocs.CheckedChanged += new System.EventHandler(this.ckMultDocs_CheckedChanged);
			// 
			// ckIStreamSrcDemo
			// 
			this.ckIStreamSrcDemo.AutoSize = true;
			this.ckIStreamSrcDemo.Location = new System.Drawing.Point(36, 166);
			this.ckIStreamSrcDemo.Margin = new System.Windows.Forms.Padding(4);
			this.ckIStreamSrcDemo.Name = "ckIStreamSrcDemo";
			this.ckIStreamSrcDemo.Size = new System.Drawing.Size(195, 24);
			this.ckIStreamSrcDemo.TabIndex = 4;
			this.ckIStreamSrcDemo.Text = "IStream-Source Demo";
			this.ckIStreamSrcDemo.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(32, 108);
			this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(393, 20);
			this.label19.TabIndex = 2;
			this.label19.Text = "or specify custom source path to open document from:";
			// 
			// label11
			// 
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label11.Location = new System.Drawing.Point(36, 96);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(663, 2);
			this.label11.TabIndex = 1;
			// 
			// btnShowOpenDlg
			// 
			this.btnShowOpenDlg.Location = new System.Drawing.Point(36, 42);
			this.btnShowOpenDlg.Margin = new System.Windows.Forms.Padding(4);
			this.btnShowOpenDlg.Name = "btnShowOpenDlg";
			this.btnShowOpenDlg.Size = new System.Drawing.Size(342, 38);
			this.btnShowOpenDlg.TabIndex = 0;
			this.btnShowOpenDlg.Text = "Click to Show Open Dialog...";
			this.btnShowOpenDlg.UseVisualStyleBackColor = true;
			this.btnShowOpenDlg.Click += new System.EventHandler(this.btnShowOpenDlg_Click);
			// 
			// btnBrowseForOpen
			// 
			this.btnBrowseForOpen.Location = new System.Drawing.Point(442, 130);
			this.btnBrowseForOpen.Margin = new System.Windows.Forms.Padding(4);
			this.btnBrowseForOpen.Name = "btnBrowseForOpen";
			this.btnBrowseForOpen.Size = new System.Drawing.Size(110, 33);
			this.btnBrowseForOpen.TabIndex = 5;
			this.btnBrowseForOpen.Text = "Browse...";
			this.btnBrowseForOpen.UseVisualStyleBackColor = true;
			this.btnBrowseForOpen.Click += new System.EventHandler(this.btnBrowseForOpen_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(560, 130);
			this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(136, 33);
			this.btnOpen.TabIndex = 6;
			this.btnOpen.Text = "Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// tSrcToOpen
			// 
			this.tSrcToOpen.Location = new System.Drawing.Point(36, 132);
			this.tSrcToOpen.Margin = new System.Windows.Forms.Padding(4);
			this.tSrcToOpen.Name = "tSrcToOpen";
			this.tSrcToOpen.Size = new System.Drawing.Size(398, 26);
			this.tSrcToOpen.TabIndex = 3;
			// 
			// gboxInfo
			// 
			this.gboxInfo.Controls.Add(this.lbModDate);
			this.gboxInfo.Controls.Add(this.label36);
			this.gboxInfo.Controls.Add(this.lbCreatDate);
			this.gboxInfo.Controls.Add(this.label34);
			this.gboxInfo.Controls.Add(this.lbPDFA);
			this.gboxInfo.Controls.Add(this.label32);
			this.gboxInfo.Controls.Add(this.lbPDFForm);
			this.gboxInfo.Controls.Add(this.label31);
			this.gboxInfo.Controls.Add(this.lbPDFSpecVer);
			this.gboxInfo.Controls.Add(this.label22);
			this.gboxInfo.Controls.Add(this.lbSrc);
			this.gboxInfo.Controls.Add(this.lbPagesCnt);
			this.gboxInfo.Controls.Add(this.label10);
			this.gboxInfo.Controls.Add(this.tCreator);
			this.gboxInfo.Controls.Add(this.label8);
			this.gboxInfo.Controls.Add(this.tProducer);
			this.gboxInfo.Controls.Add(this.label7);
			this.gboxInfo.Controls.Add(this.tKeyw);
			this.gboxInfo.Controls.Add(this.label6);
			this.gboxInfo.Controls.Add(this.tSubj);
			this.gboxInfo.Controls.Add(this.label5);
			this.gboxInfo.Controls.Add(this.tAuthor);
			this.gboxInfo.Controls.Add(this.label4);
			this.gboxInfo.Controls.Add(this.tTitle);
			this.gboxInfo.Controls.Add(this.label3);
			this.gboxInfo.Controls.Add(this.label2);
			this.gboxInfo.Controls.Add(this.ckModified);
			this.gboxInfo.Controls.Add(this.label1);
			this.gboxInfo.Location = new System.Drawing.Point(9, 218);
			this.gboxInfo.Margin = new System.Windows.Forms.Padding(4);
			this.gboxInfo.Name = "gboxInfo";
			this.gboxInfo.Padding = new System.Windows.Forms.Padding(4);
			this.gboxInfo.Size = new System.Drawing.Size(711, 280);
			this.gboxInfo.TabIndex = 1;
			this.gboxInfo.TabStop = false;
			this.gboxInfo.Text = "Info";
			// 
			// lbModDate
			// 
			this.lbModDate.Location = new System.Drawing.Point(450, 117);
			this.lbModDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbModDate.Name = "lbModDate";
			this.lbModDate.Size = new System.Drawing.Size(250, 20);
			this.lbModDate.TabIndex = 13;
			this.lbModDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(321, 117);
			this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(129, 20);
			this.label36.TabIndex = 12;
			this.label36.Text = "Modified:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbCreatDate
			// 
			this.lbCreatDate.Location = new System.Drawing.Point(450, 98);
			this.lbCreatDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbCreatDate.Name = "lbCreatDate";
			this.lbCreatDate.Size = new System.Drawing.Size(250, 20);
			this.lbCreatDate.TabIndex = 11;
			this.lbCreatDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(321, 98);
			this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(129, 20);
			this.label34.TabIndex = 10;
			this.label34.Text = "Created:";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbPDFA
			// 
			this.lbPDFA.Location = new System.Drawing.Point(196, 98);
			this.lbPDFA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPDFA.Name = "lbPDFA";
			this.lbPDFA.Size = new System.Drawing.Size(177, 20);
			this.lbPDFA.TabIndex = 7;
			this.lbPDFA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(18, 98);
			this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(177, 20);
			this.label32.TabIndex = 6;
			this.label32.Text = "PDF/A:";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbPDFForm
			// 
			this.lbPDFForm.Location = new System.Drawing.Point(196, 76);
			this.lbPDFForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPDFForm.Name = "lbPDFForm";
			this.lbPDFForm.Size = new System.Drawing.Size(270, 20);
			this.lbPDFForm.TabIndex = 5;
			this.lbPDFForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(18, 76);
			this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(177, 20);
			this.label31.TabIndex = 4;
			this.label31.Text = "PDF-Form:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbPDFSpecVer
			// 
			this.lbPDFSpecVer.Location = new System.Drawing.Point(196, 57);
			this.lbPDFSpecVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPDFSpecVer.Name = "lbPDFSpecVer";
			this.lbPDFSpecVer.Size = new System.Drawing.Size(270, 20);
			this.lbPDFSpecVer.TabIndex = 3;
			this.lbPDFSpecVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(18, 57);
			this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(177, 20);
			this.label22.TabIndex = 2;
			this.label22.Text = "PDF-Specification:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbSrc
			// 
			this.lbSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbSrc.Location = new System.Drawing.Point(196, 24);
			this.lbSrc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbSrc.Name = "lbSrc";
			this.lbSrc.Size = new System.Drawing.Size(442, 20);
			this.lbSrc.TabIndex = 1;
			this.lbSrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbPagesCnt
			// 
			this.lbPagesCnt.Location = new System.Drawing.Point(196, 117);
			this.lbPagesCnt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPagesCnt.Name = "lbPagesCnt";
			this.lbPagesCnt.Size = new System.Drawing.Size(177, 20);
			this.lbPagesCnt.TabIndex = 9;
			this.lbPagesCnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(18, 117);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(177, 20);
			this.label10.TabIndex = 8;
			this.label10.Text = "Pages Count:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tCreator
			// 
			this.tCreator.Location = new System.Drawing.Point(471, 236);
			this.tCreator.Margin = new System.Windows.Forms.Padding(4);
			this.tCreator.Name = "tCreator";
			this.tCreator.ReadOnly = true;
			this.tCreator.Size = new System.Drawing.Size(223, 26);
			this.tCreator.TabIndex = 27;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(381, 238);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 20);
			this.label8.TabIndex = 26;
			this.label8.Text = "Creator:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tProducer
			// 
			this.tProducer.Location = new System.Drawing.Point(471, 201);
			this.tProducer.Margin = new System.Windows.Forms.Padding(4);
			this.tProducer.Name = "tProducer";
			this.tProducer.ReadOnly = true;
			this.tProducer.Size = new System.Drawing.Size(223, 26);
			this.tProducer.TabIndex = 25;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(381, 204);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 20);
			this.label7.TabIndex = 24;
			this.label7.Text = "Producer:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tKeyw
			// 
			this.tKeyw.Location = new System.Drawing.Point(471, 166);
			this.tKeyw.Margin = new System.Windows.Forms.Padding(4);
			this.tKeyw.Name = "tKeyw";
			this.tKeyw.ReadOnly = true;
			this.tKeyw.Size = new System.Drawing.Size(223, 26);
			this.tKeyw.TabIndex = 23;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(381, 170);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 20);
			this.label6.TabIndex = 22;
			this.label6.Text = "Keywords:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tSubj
			// 
			this.tSubj.Location = new System.Drawing.Point(144, 236);
			this.tSubj.Margin = new System.Windows.Forms.Padding(4);
			this.tSubj.Name = "tSubj";
			this.tSubj.ReadOnly = true;
			this.tSubj.Size = new System.Drawing.Size(223, 26);
			this.tSubj.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(62, 238);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 20);
			this.label5.TabIndex = 20;
			this.label5.Text = "Subject:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tAuthor
			// 
			this.tAuthor.Location = new System.Drawing.Point(144, 201);
			this.tAuthor.Margin = new System.Windows.Forms.Padding(4);
			this.tAuthor.Name = "tAuthor";
			this.tAuthor.ReadOnly = true;
			this.tAuthor.Size = new System.Drawing.Size(223, 26);
			this.tAuthor.TabIndex = 19;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(62, 204);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 20);
			this.label4.TabIndex = 18;
			this.label4.Text = "Author:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tTitle
			// 
			this.tTitle.Location = new System.Drawing.Point(144, 166);
			this.tTitle.Margin = new System.Windows.Forms.Padding(4);
			this.tTitle.Name = "tTitle";
			this.tTitle.ReadOnly = true;
			this.tTitle.Size = new System.Drawing.Size(223, 26);
			this.tTitle.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(62, 170);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 20);
			this.label3.TabIndex = 16;
			this.label3.Text = "Title:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(36, 148);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(663, 2);
			this.label2.TabIndex = 15;
			// 
			// ckModified
			// 
			this.ckModified.AutoSize = true;
			this.ckModified.Location = new System.Drawing.Point(546, 56);
			this.ckModified.Margin = new System.Windows.Forms.Padding(4);
			this.ckModified.Name = "ckModified";
			this.ckModified.Size = new System.Drawing.Size(112, 24);
			this.ckModified.TabIndex = 14;
			this.ckModified.Text = "Is Modified";
			this.ckModified.UseVisualStyleBackColor = true;
			this.ckModified.CheckedChanged += new System.EventHandler(this.ckModified_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 24);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Source:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabCtl
			// 
			this.tabCtl.Controls.Add(this.tabDoc);
			this.tabCtl.Controls.Add(this.tabView);
			this.tabCtl.Controls.Add(this.tabCmds);
			this.tabCtl.Controls.Add(this.tabJS);
			this.tabCtl.Controls.Add(this.tabUILang);
			this.tabCtl.Controls.Add(this.tabOpers);
			this.tabCtl.Controls.Add(this.tabSettingsIO);
			this.tabCtl.Controls.Add(this.tabCustomUI);
			this.tabCtl.Controls.Add(this.tabHelp);
			this.tabCtl.Dock = System.Windows.Forms.DockStyle.Left;
			this.tabCtl.Location = new System.Drawing.Point(0, 0);
			this.tabCtl.Margin = new System.Windows.Forms.Padding(4);
			this.tabCtl.Name = "tabCtl";
			this.tabCtl.SelectedIndex = 0;
			this.tabCtl.Size = new System.Drawing.Size(736, 1167);
			this.tabCtl.TabIndex = 0;
			this.tabCtl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCtl_Selected);
			// 
			// tabUILang
			// 
			this.tabUILang.Controls.Add(this.btnSetUILang);
			this.tabUILang.Controls.Add(this.label9);
			this.tabUILang.Controls.Add(this.cbUILangs);
			this.tabUILang.Location = new System.Drawing.Point(4, 29);
			this.tabUILang.Margin = new System.Windows.Forms.Padding(4);
			this.tabUILang.Name = "tabUILang";
			this.tabUILang.Padding = new System.Windows.Forms.Padding(4);
			this.tabUILang.Size = new System.Drawing.Size(728, 987);
			this.tabUILang.TabIndex = 5;
			this.tabUILang.Text = "UI-Language";
			this.tabUILang.UseVisualStyleBackColor = true;
			// 
			// btnSetUILang
			// 
			this.btnSetUILang.Location = new System.Drawing.Point(434, 45);
			this.btnSetUILang.Margin = new System.Windows.Forms.Padding(4);
			this.btnSetUILang.Name = "btnSetUILang";
			this.btnSetUILang.Size = new System.Drawing.Size(142, 34);
			this.btnSetUILang.TabIndex = 2;
			this.btnSetUILang.Text = "Apply";
			this.btnSetUILang.UseVisualStyleBackColor = true;
			this.btnSetUILang.Click += new System.EventHandler(this.btnSetUILang_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(21, 21);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(239, 20);
			this.label9.TabIndex = 1;
			this.label9.Text = "Choose language for Editor\'s UI:";
			// 
			// cbUILangs
			// 
			this.cbUILangs.FormattingEnabled = true;
			this.cbUILangs.Location = new System.Drawing.Point(26, 46);
			this.cbUILangs.Margin = new System.Windows.Forms.Padding(4);
			this.cbUILangs.Name = "cbUILangs";
			this.cbUILangs.Size = new System.Drawing.Size(400, 28);
			this.cbUILangs.TabIndex = 0;
			// 
			// tabOpers
			// 
			this.tabOpers.Controls.Add(this.lbDocReq);
			this.tabOpers.Controls.Add(this.picDocReq);
			this.tabOpers.Controls.Add(this.btnRunOp);
			this.tabOpers.Controls.Add(this.ckShowOpDlg);
			this.tabOpers.Controls.Add(this.cbOpers);
			this.tabOpers.Controls.Add(this.label30);
			this.tabOpers.Controls.Add(this.pnOpOpts);
			this.tabOpers.Location = new System.Drawing.Point(4, 29);
			this.tabOpers.Margin = new System.Windows.Forms.Padding(4);
			this.tabOpers.Name = "tabOpers";
			this.tabOpers.Padding = new System.Windows.Forms.Padding(4);
			this.tabOpers.Size = new System.Drawing.Size(728, 987);
			this.tabOpers.TabIndex = 6;
			this.tabOpers.Text = "Operations";
			this.tabOpers.UseVisualStyleBackColor = true;
			// 
			// lbDocReq
			// 
			this.lbDocReq.Location = new System.Drawing.Point(54, 926);
			this.lbDocReq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbDocReq.Name = "lbDocReq";
			this.lbDocReq.Size = new System.Drawing.Size(248, 50);
			this.lbDocReq.TabIndex = 9;
			this.lbDocReq.Text = "The opened document is required for this operation";
			// 
			// picDocReq
			// 
			this.picDocReq.Image = global::FullDemo.Properties.Resources.ico_msg_warning_24;
			this.picDocReq.InitialImage = null;
			this.picDocReq.Location = new System.Drawing.Point(9, 926);
			this.picDocReq.Margin = new System.Windows.Forms.Padding(4);
			this.picDocReq.Name = "picDocReq";
			this.picDocReq.Size = new System.Drawing.Size(46, 45);
			this.picDocReq.TabIndex = 8;
			this.picDocReq.TabStop = false;
			// 
			// btnRunOp
			// 
			this.btnRunOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnRunOp.ForeColor = System.Drawing.Color.MediumBlue;
			this.btnRunOp.Location = new System.Drawing.Point(510, 921);
			this.btnRunOp.Margin = new System.Windows.Forms.Padding(4);
			this.btnRunOp.Name = "btnRunOp";
			this.btnRunOp.Size = new System.Drawing.Size(206, 39);
			this.btnRunOp.TabIndex = 7;
			this.btnRunOp.Text = "Run Operation...";
			this.btnRunOp.UseVisualStyleBackColor = true;
			this.btnRunOp.Click += new System.EventHandler(this.btnRunOp_Click);
			// 
			// ckShowOpDlg
			// 
			this.ckShowOpDlg.Checked = true;
			this.ckShowOpDlg.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckShowOpDlg.Location = new System.Drawing.Point(314, 921);
			this.ckShowOpDlg.Margin = new System.Windows.Forms.Padding(4);
			this.ckShowOpDlg.Name = "ckShowOpDlg";
			this.ckShowOpDlg.Size = new System.Drawing.Size(201, 39);
			this.ckShowOpDlg.TabIndex = 6;
			this.ckShowOpDlg.Text = "Show operation\'s UI ";
			this.ckShowOpDlg.UseVisualStyleBackColor = true;
			// 
			// cbOpers
			// 
			this.cbOpers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOpers.FormattingEnabled = true;
			this.cbOpers.Location = new System.Drawing.Point(206, 16);
			this.cbOpers.Margin = new System.Windows.Forms.Padding(4);
			this.cbOpers.Name = "cbOpers";
			this.cbOpers.Size = new System.Drawing.Size(346, 28);
			this.cbOpers.Sorted = true;
			this.cbOpers.TabIndex = 5;
			this.cbOpers.SelectedIndexChanged += new System.EventHandler(this.cbOpers_SelectedIndexChanged);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(20, 22);
			this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(183, 20);
			this.label30.TabIndex = 4;
			this.label30.Text = "Choose operation demo:";
			// 
			// pnOpOpts
			// 
			this.pnOpOpts.Location = new System.Drawing.Point(0, 63);
			this.pnOpOpts.Margin = new System.Windows.Forms.Padding(4);
			this.pnOpOpts.Name = "pnOpOpts";
			this.pnOpOpts.Size = new System.Drawing.Size(723, 849);
			this.pnOpOpts.TabIndex = 3;
			// 
			// tabSettingsIO
			// 
			this.tabSettingsIO.Controls.Add(this.gboxImpExp);
			this.tabSettingsIO.Controls.Add(this.gboxProgramOpts);
			this.tabSettingsIO.Location = new System.Drawing.Point(4, 29);
			this.tabSettingsIO.Name = "tabSettingsIO";
			this.tabSettingsIO.Padding = new System.Windows.Forms.Padding(3);
			this.tabSettingsIO.Size = new System.Drawing.Size(728, 987);
			this.tabSettingsIO.TabIndex = 8;
			this.tabSettingsIO.Text = "Settings I/O";
			this.tabSettingsIO.UseVisualStyleBackColor = true;
			// 
			// gboxImpExp
			// 
			this.gboxImpExp.Controls.Add(this.ckSettIncHist);
			this.gboxImpExp.Controls.Add(this.btnSettSave);
			this.gboxImpExp.Controls.Add(this.btnSettLoad);
			this.gboxImpExp.Controls.Add(this.label35);
			this.gboxImpExp.Controls.Add(this.btnBrowseForSettFile);
			this.gboxImpExp.Controls.Add(this.tSettFile);
			this.gboxImpExp.Location = new System.Drawing.Point(6, 290);
			this.gboxImpExp.Name = "gboxImpExp";
			this.gboxImpExp.Size = new System.Drawing.Size(716, 164);
			this.gboxImpExp.TabIndex = 2;
			this.gboxImpExp.TabStop = false;
			this.gboxImpExp.Text = "Import/Export Settings";
			// 
			// ckSettIncHist
			// 
			this.ckSettIncHist.AutoSize = true;
			this.ckSettIncHist.Location = new System.Drawing.Point(284, 115);
			this.ckSettIncHist.Name = "ckSettIncHist";
			this.ckSettIncHist.Size = new System.Drawing.Size(368, 24);
			this.ckSettIncHist.TabIndex = 15;
			this.ckSettIncHist.Text = "Include history of documens opening (Recents)";
			this.ckSettIncHist.UseVisualStyleBackColor = true;
			// 
			// btnSettSave
			// 
			this.btnSettSave.Location = new System.Drawing.Point(148, 110);
			this.btnSettSave.Name = "btnSettSave";
			this.btnSettSave.Size = new System.Drawing.Size(110, 33);
			this.btnSettSave.TabIndex = 14;
			this.btnSettSave.Text = "Save";
			this.btnSettSave.UseVisualStyleBackColor = true;
			this.btnSettSave.Click += new System.EventHandler(this.btnSettSave_Click);
			// 
			// btnSettLoad
			// 
			this.btnSettLoad.Location = new System.Drawing.Point(23, 110);
			this.btnSettLoad.Name = "btnSettLoad";
			this.btnSettLoad.Size = new System.Drawing.Size(110, 33);
			this.btnSettLoad.TabIndex = 13;
			this.btnSettLoad.Text = "Load";
			this.btnSettLoad.UseVisualStyleBackColor = true;
			this.btnSettLoad.Click += new System.EventHandler(this.btnSettLoad_Click);
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(20, 41);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(150, 20);
			this.label35.TabIndex = 12;
			this.label35.Text = "Editor\'s settings file:";
			// 
			// btnBrowseForSettFile
			// 
			this.btnBrowseForSettFile.Location = new System.Drawing.Point(542, 64);
			this.btnBrowseForSettFile.Margin = new System.Windows.Forms.Padding(4);
			this.btnBrowseForSettFile.Name = "btnBrowseForSettFile";
			this.btnBrowseForSettFile.Size = new System.Drawing.Size(110, 33);
			this.btnBrowseForSettFile.TabIndex = 11;
			this.btnBrowseForSettFile.Text = "Browse...";
			this.btnBrowseForSettFile.UseVisualStyleBackColor = true;
			this.btnBrowseForSettFile.Click += new System.EventHandler(this.btnBrowseForSettFile_Click);
			// 
			// tSettFile
			// 
			this.tSettFile.Location = new System.Drawing.Point(24, 67);
			this.tSettFile.Name = "tSettFile";
			this.tSettFile.ReadOnly = true;
			this.tSettFile.Size = new System.Drawing.Size(511, 26);
			this.tSettFile.TabIndex = 10;
			this.tSettFile.Text = "C:\\MyApp\\PDFXEditPrefs.dat";
			// 
			// gboxProgramOpts
			// 
			this.gboxProgramOpts.Controls.Add(this.btnBrowseForHistDir);
			this.gboxProgramOpts.Controls.Add(this.tHistDir);
			this.gboxProgramOpts.Controls.Add(this.ckKeepHist);
			this.gboxProgramOpts.Controls.Add(this.btnBrowseForPrefsFile);
			this.gboxProgramOpts.Controls.Add(this.tPrefs_file);
			this.gboxProgramOpts.Controls.Add(this.rbPrefs_file);
			this.gboxProgramOpts.Controls.Add(this.tPrefs_reg);
			this.gboxProgramOpts.Controls.Add(this.rbPrefs_reg);
			this.gboxProgramOpts.Controls.Add(this.ckKeepPrefs);
			this.gboxProgramOpts.Location = new System.Drawing.Point(6, 6);
			this.gboxProgramOpts.Name = "gboxProgramOpts";
			this.gboxProgramOpts.Size = new System.Drawing.Size(716, 278);
			this.gboxProgramOpts.TabIndex = 1;
			this.gboxProgramOpts.TabStop = false;
			this.gboxProgramOpts.Text = "Program Preferences/History";
			// 
			// btnBrowseForHistDir
			// 
			this.btnBrowseForHistDir.Location = new System.Drawing.Point(521, 228);
			this.btnBrowseForHistDir.Margin = new System.Windows.Forms.Padding(4);
			this.btnBrowseForHistDir.Name = "btnBrowseForHistDir";
			this.btnBrowseForHistDir.Size = new System.Drawing.Size(110, 33);
			this.btnBrowseForHistDir.TabIndex = 9;
			this.btnBrowseForHistDir.Text = "Browse...";
			this.btnBrowseForHistDir.UseVisualStyleBackColor = true;
			this.btnBrowseForHistDir.Click += new System.EventHandler(this.btnBrowseForHistDir_Click);
			// 
			// tHistDir
			// 
			this.tHistDir.Location = new System.Drawing.Point(46, 231);
			this.tHistDir.Name = "tHistDir";
			this.tHistDir.ReadOnly = true;
			this.tHistDir.Size = new System.Drawing.Size(468, 26);
			this.tHistDir.TabIndex = 8;
			this.tHistDir.Text = "C:\\MyApp";
			// 
			// ckKeepHist
			// 
			this.ckKeepHist.AutoSize = true;
			this.ckKeepHist.Location = new System.Drawing.Point(24, 202);
			this.ckKeepHist.Name = "ckKeepHist";
			this.ckKeepHist.Size = new System.Drawing.Size(457, 24);
			this.ckKeepHist.TabIndex = 7;
			this.ckKeepHist.Text = "Keep/restore history of documents opening (select location):";
			this.ckKeepHist.UseVisualStyleBackColor = true;
			this.ckKeepHist.CheckedChanged += new System.EventHandler(this.ckKeepHist_CheckedChanged);
			// 
			// btnBrowseForPrefsFile
			// 
			this.btnBrowseForPrefsFile.Location = new System.Drawing.Point(541, 159);
			this.btnBrowseForPrefsFile.Margin = new System.Windows.Forms.Padding(4);
			this.btnBrowseForPrefsFile.Name = "btnBrowseForPrefsFile";
			this.btnBrowseForPrefsFile.Size = new System.Drawing.Size(111, 33);
			this.btnBrowseForPrefsFile.TabIndex = 6;
			this.btnBrowseForPrefsFile.Text = "Browse...";
			this.btnBrowseForPrefsFile.UseVisualStyleBackColor = true;
			this.btnBrowseForPrefsFile.Click += new System.EventHandler(this.btnBrowseForPrefsFile_Click);
			// 
			// tPrefs_file
			// 
			this.tPrefs_file.Location = new System.Drawing.Point(68, 162);
			this.tPrefs_file.Name = "tPrefs_file";
			this.tPrefs_file.ReadOnly = true;
			this.tPrefs_file.Size = new System.Drawing.Size(466, 26);
			this.tPrefs_file.TabIndex = 4;
			this.tPrefs_file.Text = "C:\\MyApp\\PDFXEditPrefs.dat";
			// 
			// rbPrefs_file
			// 
			this.rbPrefs_file.AutoSize = true;
			this.rbPrefs_file.Location = new System.Drawing.Point(46, 133);
			this.rbPrefs_file.Name = "rbPrefs_file";
			this.rbPrefs_file.Size = new System.Drawing.Size(127, 24);
			this.rbPrefs_file.TabIndex = 3;
			this.rbPrefs_file.Text = "Use local file:";
			this.rbPrefs_file.UseVisualStyleBackColor = true;
			this.rbPrefs_file.CheckedChanged += new System.EventHandler(this.rbPrefs_file_CheckedChanged);
			// 
			// tPrefs_reg
			// 
			this.tPrefs_reg.Location = new System.Drawing.Point(68, 100);
			this.tPrefs_reg.Name = "tPrefs_reg";
			this.tPrefs_reg.Size = new System.Drawing.Size(584, 26);
			this.tPrefs_reg.TabIndex = 2;
			this.tPrefs_reg.Text = "HKCU\\Software\\MyApp\\PDFXEdit";
			// 
			// rbPrefs_reg
			// 
			this.rbPrefs_reg.AutoSize = true;
			this.rbPrefs_reg.Location = new System.Drawing.Point(46, 71);
			this.rbPrefs_reg.Name = "rbPrefs_reg";
			this.rbPrefs_reg.Size = new System.Drawing.Size(187, 24);
			this.rbPrefs_reg.TabIndex = 1;
			this.rbPrefs_reg.Text = "Use system\'s registry:";
			this.rbPrefs_reg.UseVisualStyleBackColor = true;
			this.rbPrefs_reg.CheckedChanged += new System.EventHandler(this.rbPrefs_reg_CheckedChanged);
			// 
			// ckKeepPrefs
			// 
			this.ckKeepPrefs.AutoSize = true;
			this.ckKeepPrefs.Location = new System.Drawing.Point(24, 37);
			this.ckKeepPrefs.Name = "ckKeepPrefs";
			this.ckKeepPrefs.Size = new System.Drawing.Size(485, 24);
			this.ckKeepPrefs.TabIndex = 0;
			this.ckKeepPrefs.Text = "Keep user preferences on exit and restore it on application start:";
			this.ckKeepPrefs.UseVisualStyleBackColor = true;
			this.ckKeepPrefs.CheckedChanged += new System.EventHandler(this.ckKeepPrefs_CheckedChanged);
			// 
			// tabCustomUI
			// 
			this.tabCustomUI.Controls.Add(this.btnResetUI);
			this.tabCustomUI.Controls.Add(this.gboxCustFonts);
			this.tabCustomUI.Controls.Add(this.gboxCustColors);
			this.tabCustomUI.Location = new System.Drawing.Point(4, 29);
			this.tabCustomUI.Name = "tabCustomUI";
			this.tabCustomUI.Padding = new System.Windows.Forms.Padding(3);
			this.tabCustomUI.Size = new System.Drawing.Size(728, 987);
			this.tabCustomUI.TabIndex = 9;
			this.tabCustomUI.Text = "Customize UI";
			this.tabCustomUI.UseVisualStyleBackColor = true;
			// 
			// btnResetUI
			// 
			this.btnResetUI.Location = new System.Drawing.Point(6, 332);
			this.btnResetUI.Name = "btnResetUI";
			this.btnResetUI.Size = new System.Drawing.Size(171, 33);
			this.btnResetUI.TabIndex = 13;
			this.btnResetUI.Text = "Reset to Defaults";
			this.btnResetUI.UseVisualStyleBackColor = true;
			this.btnResetUI.Click += new System.EventHandler(this.btnResetUI_Click);
			// 
			// gboxCustFonts
			// 
			this.gboxCustFonts.Controls.Add(this.label42);
			this.gboxCustFonts.Controls.Add(this.btnDefaultFnt);
			this.gboxCustFonts.Controls.Add(this.lbDefaultFnt);
			this.gboxCustFonts.Controls.Add(this.label41);
			this.gboxCustFonts.Controls.Add(this.btnMenuFnt);
			this.gboxCustFonts.Controls.Add(this.lbMenuFnt);
			this.gboxCustFonts.Location = new System.Drawing.Point(6, 149);
			this.gboxCustFonts.Name = "gboxCustFonts";
			this.gboxCustFonts.Size = new System.Drawing.Size(716, 171);
			this.gboxCustFonts.TabIndex = 12;
			this.gboxCustFonts.TabStop = false;
			this.gboxCustFonts.Text = "Fonts";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(21, 97);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(109, 20);
			this.label42.TabIndex = 5;
			this.label42.Text = "Common font:";
			// 
			// btnDefaultFnt
			// 
			this.btnDefaultFnt.Location = new System.Drawing.Point(306, 117);
			this.btnDefaultFnt.Name = "btnDefaultFnt";
			this.btnDefaultFnt.Size = new System.Drawing.Size(108, 33);
			this.btnDefaultFnt.TabIndex = 4;
			this.btnDefaultFnt.Text = "Change...";
			this.btnDefaultFnt.UseVisualStyleBackColor = true;
			this.btnDefaultFnt.Click += new System.EventHandler(this.btnDefaultFnt_Click);
			// 
			// lbDefaultFnt
			// 
			this.lbDefaultFnt.Location = new System.Drawing.Point(41, 121);
			this.lbDefaultFnt.Name = "lbDefaultFnt";
			this.lbDefaultFnt.Size = new System.Drawing.Size(258, 24);
			this.lbDefaultFnt.TabIndex = 3;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(21, 40);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(85, 20);
			this.label41.TabIndex = 2;
			this.label41.Text = "Menu font:";
			// 
			// btnMenuFnt
			// 
			this.btnMenuFnt.Location = new System.Drawing.Point(306, 60);
			this.btnMenuFnt.Name = "btnMenuFnt";
			this.btnMenuFnt.Size = new System.Drawing.Size(108, 33);
			this.btnMenuFnt.TabIndex = 1;
			this.btnMenuFnt.Text = "Change...";
			this.btnMenuFnt.UseVisualStyleBackColor = true;
			this.btnMenuFnt.Click += new System.EventHandler(this.btnMenuFnt_Click);
			// 
			// lbMenuFnt
			// 
			this.lbMenuFnt.Location = new System.Drawing.Point(41, 64);
			this.lbMenuFnt.Name = "lbMenuFnt";
			this.lbMenuFnt.Size = new System.Drawing.Size(258, 24);
			this.lbMenuFnt.TabIndex = 0;
			// 
			// gboxCustColors
			// 
			this.gboxCustColors.Controls.Add(this.btnSelClr);
			this.gboxCustColors.Controls.Add(this.label40);
			this.gboxCustColors.Controls.Add(this.btnTextClr);
			this.gboxCustColors.Controls.Add(this.label39);
			this.gboxCustColors.Controls.Add(this.btnWndClr);
			this.gboxCustColors.Controls.Add(this.label38);
			this.gboxCustColors.Controls.Add(this.btnFaceClr);
			this.gboxCustColors.Controls.Add(this.label37);
			this.gboxCustColors.Location = new System.Drawing.Point(6, 6);
			this.gboxCustColors.Name = "gboxCustColors";
			this.gboxCustColors.Size = new System.Drawing.Size(716, 137);
			this.gboxCustColors.TabIndex = 11;
			this.gboxCustColors.TabStop = false;
			this.gboxCustColors.Text = "Colors";
			// 
			// btnSelClr
			// 
			this.btnSelClr.BackColor = System.Drawing.Color.White;
			this.btnSelClr.Location = new System.Drawing.Point(306, 83);
			this.btnSelClr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSelClr.Name = "btnSelClr";
			this.btnSelClr.Size = new System.Drawing.Size(108, 35);
			this.btnSelClr.TabIndex = 17;
			this.btnSelClr.UseVisualStyleBackColor = false;
			this.btnSelClr.Click += new System.EventHandler(this.btnSelClr_Click);
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(220, 90);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(79, 20);
			this.label40.TabIndex = 16;
			this.label40.Text = "Selection:";
			// 
			// btnTextClr
			// 
			this.btnTextClr.BackColor = System.Drawing.Color.White;
			this.btnTextClr.Location = new System.Drawing.Point(88, 83);
			this.btnTextClr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnTextClr.Name = "btnTextClr";
			this.btnTextClr.Size = new System.Drawing.Size(108, 35);
			this.btnTextClr.TabIndex = 13;
			this.btnTextClr.UseVisualStyleBackColor = false;
			this.btnTextClr.Click += new System.EventHandler(this.btnTextClr_Click);
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(38, 90);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(43, 20);
			this.label39.TabIndex = 14;
			this.label39.Text = "Text:";
			// 
			// btnWndClr
			// 
			this.btnWndClr.BackColor = System.Drawing.Color.White;
			this.btnWndClr.Location = new System.Drawing.Point(306, 38);
			this.btnWndClr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnWndClr.Name = "btnWndClr";
			this.btnWndClr.Size = new System.Drawing.Size(108, 35);
			this.btnWndClr.TabIndex = 11;
			this.btnWndClr.UseVisualStyleBackColor = false;
			this.btnWndClr.Click += new System.EventHandler(this.btnWndClr_Click);
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(230, 45);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(69, 20);
			this.label38.TabIndex = 12;
			this.label38.Text = "Window:";
			// 
			// btnFaceClr
			// 
			this.btnFaceClr.BackColor = System.Drawing.Color.White;
			this.btnFaceClr.Location = new System.Drawing.Point(88, 38);
			this.btnFaceClr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnFaceClr.Name = "btnFaceClr";
			this.btnFaceClr.Size = new System.Drawing.Size(108, 35);
			this.btnFaceClr.TabIndex = 9;
			this.btnFaceClr.UseVisualStyleBackColor = false;
			this.btnFaceClr.Click += new System.EventHandler(this.btnFaceClr_Click);
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(32, 45);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(49, 20);
			this.label37.TabIndex = 10;
			this.label37.Text = "Face:";
			// 
			// tabHelp
			// 
			this.tabHelp.Controls.Add(this.label43);
			this.tabHelp.Controls.Add(this.linkLabel2);
			this.tabHelp.Controls.Add(this.label33);
			this.tabHelp.Controls.Add(this.linkLabel1);
			this.tabHelp.Location = new System.Drawing.Point(4, 29);
			this.tabHelp.Margin = new System.Windows.Forms.Padding(4);
			this.tabHelp.Name = "tabHelp";
			this.tabHelp.Padding = new System.Windows.Forms.Padding(4);
			this.tabHelp.Size = new System.Drawing.Size(728, 987);
			this.tabHelp.TabIndex = 7;
			this.tabHelp.Text = "Help";
			this.tabHelp.UseVisualStyleBackColor = true;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(8, 83);
			this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(305, 20);
			this.label43.TabIndex = 3;
			this.label43.Text = "Also the actual source is available";
			this.label43.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(310, 83);
			this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(41, 20);
			this.linkLabel2.TabIndex = 2;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "here";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(29, 45);
			this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(49, 20);
			this.label33.TabIndex = 1;
			this.label33.Text = "Go to";
			this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(80, 45);
			this.linkLabel1.Margin=new System.Windows.Forms.Padding(4,0,4,0);			
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(233, 20);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "PDF-XChange Editor SDK Help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(758, 6);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pdfCtl);
			this.splitContainer1.Panel2Collapsed = true;
			this.splitContainer1.Size = new System.Drawing.Size(993, 1157);
			this.splitContainer1.SplitterDistance = 414;
			this.splitContainer1.SplitterWidth = 6;
			this.splitContainer1.TabIndex = 3;
			// 
			// pdfCtl
			// 
			this.pdfCtl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pdfCtl.Enabled = true;
			this.pdfCtl.Location = new System.Drawing.Point(0, 0);
			this.pdfCtl.Margin = new System.Windows.Forms.Padding(4);
			this.pdfCtl.Name = "pdfCtl";
			this.pdfCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfCtl.OcxState")));
			this.pdfCtl.Size = new System.Drawing.Size(993, 1157);
			this.pdfCtl.TabIndex = 0;
			this.pdfCtl.OnEvent += new AxPDFXEdit._IPXV_ControlEvents_OnEventEventHandler(this.pdfCtl_OnEvent);
			// 
			// label45
			// 
			this.label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label45.Location = new System.Drawing.Point(8, 468);
			this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(314, 1);
			this.label45.TabIndex = 64;
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(1756, 1167);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.tabCtl);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainFrm";
			this.Text = "PDF-XChange Editor Full DEMO";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.tabJS.ResumeLayout(false);
			this.tabJS.PerformLayout();
			this.tabCmds.ResumeLayout(false);
			this.tabCmds.PerformLayout();
			this.tabView.ResumeLayout(false);
			this.tabView.PerformLayout();
			this.tabDoc.ResumeLayout(false);
			this.tabDoc.PerformLayout();
			this.gboxPages.ResumeLayout(false);
			this.gboxPages.PerformLayout();
			this.gboxSave.ResumeLayout(false);
			this.gboxSave.PerformLayout();
			this.gboxOpen.ResumeLayout(false);
			this.gboxOpen.PerformLayout();
			this.gboxInfo.ResumeLayout(false);
			this.gboxInfo.PerformLayout();
			this.tabCtl.ResumeLayout(false);
			this.tabUILang.ResumeLayout(false);
			this.tabUILang.PerformLayout();
			this.tabOpers.ResumeLayout(false);
			this.tabOpers.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picDocReq)).EndInit();
			this.tabSettingsIO.ResumeLayout(false);
			this.gboxImpExp.ResumeLayout(false);
			this.gboxImpExp.PerformLayout();
			this.gboxProgramOpts.ResumeLayout(false);
			this.gboxProgramOpts.PerformLayout();
			this.tabCustomUI.ResumeLayout(false);
			this.gboxCustFonts.ResumeLayout(false);
			this.gboxCustFonts.PerformLayout();
			this.gboxCustColors.ResumeLayout(false);
			this.gboxCustColors.PerformLayout();
			this.tabHelp.ResumeLayout(false);
			this.tabHelp.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pdfCtl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabJS;
		private System.Windows.Forms.TabPage tabCmds;
		private System.Windows.Forms.CheckBox ckAllowShortcuts;
		private System.Windows.Forms.TabPage tabView;
		private System.Windows.Forms.CheckBox ckShowPagesLayoutBar;
		private System.Windows.Forms.CheckBox ckShowPagesNavBar;
		private System.Windows.Forms.CheckBox ckShowPageZoomBar;
		private System.Windows.Forms.CheckBox ckShowMeasureBar;
		private System.Windows.Forms.CheckBox ckShowContentEdtBar;
		private System.Windows.Forms.CheckBox ckShowCommentBar;
		private System.Windows.Forms.CheckBox ckShowPropBar;
		private System.Windows.Forms.CheckBox ckShowStdBar;
		private System.Windows.Forms.CheckBox ckShowMenu;
		private System.Windows.Forms.CheckBox ckShowFileBar;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.CheckBox ckShowPanZoom;
		private System.Windows.Forms.CheckBox ckShowStampsPalette;
		private System.Windows.Forms.CheckBox ckShowCommentStyles;
		private System.Windows.Forms.CheckBox ckShowSearchPane;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.CheckBox ckSyncDocPanesLayout;
		private System.Windows.Forms.CheckBox ckShowAttachments;
		private System.Windows.Forms.CheckBox ckShowSignatures;
		private System.Windows.Forms.CheckBox ckShowLayers;
		private System.Windows.Forms.CheckBox ckShowComments;
		private System.Windows.Forms.CheckBox ckShowBookm;
		private System.Windows.Forms.CheckBox ckShowThumbs;
		private System.Windows.Forms.CheckBox ckHideSb;
		private System.Windows.Forms.CheckBox ckShowCmdPanes;
		private System.Windows.Forms.CheckBox ckUnlockCmdBars;
		private System.Windows.Forms.TabPage tabDoc;
		private System.Windows.Forms.GroupBox gboxSave;
		private System.Windows.Forms.Button btnSimpleSave;
		private System.Windows.Forms.CheckBox ckIStreamDestDemo;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button btnShowSaveAsDlg;
		private System.Windows.Forms.Button btnBrowseForSaveAs;
		private System.Windows.Forms.Button btnSaveToCustDest;
		private System.Windows.Forms.TextBox tDestToSave;
		private System.Windows.Forms.GroupBox gboxInfo;
		private System.Windows.Forms.Label lbPDFSpecVer;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label lbPageRotation;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lbPageSize;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cbPagesZoom;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbPagesLayout;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tCurPage;
		private System.Windows.Forms.Label lbSrc;
		private System.Windows.Forms.Label lbPagesCnt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tCreator;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tProducer;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tKeyw;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tSubj;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tAuthor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tTitle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox ckModified;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabCtl;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button btnCmdOnOff;
		private System.Windows.Forms.Button btnCmdExec;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Button btnRunJS;
		private System.Windows.Forms.TextBox tOutputJS;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox tInputJS;
		private System.Windows.Forms.CheckBox ckLockCmdPanes;
		private System.Windows.Forms.CheckBox ckShowDocOptsBar;
		private System.Windows.Forms.CheckBox ckShowDocLaunchBar;
		private System.Windows.Forms.ListView lvCmds;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colTitle;
		private System.Windows.Forms.ColumnHeader colOffline;
		private System.Windows.Forms.ColumnHeader colAdobeName;
		private System.Windows.Forms.ColumnHeader colTip;
		private System.Windows.Forms.ColumnHeader colHidden;
		private System.Windows.Forms.Button btnCmdShowHide;
		private System.Windows.Forms.Label lbPDFForm;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label lbPDFA;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label lbModDate;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label lbCreatDate;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Button btnCloseDoc;
		private System.Windows.Forms.CheckBox ckAllowAskForSave;
		private System.Windows.Forms.GroupBox gboxPages;
		private System.Windows.Forms.GroupBox gboxOpen;
		private System.Windows.Forms.CheckBox ckIStreamSrcDemo;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnShowOpenDlg;
		private System.Windows.Forms.Button btnBrowseForOpen;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.TextBox tSrcToOpen;
		private System.Windows.Forms.SplitContainer splitContainer1;
		public AxPDFXEdit.AxPXV_Control pdfCtl;
		private System.Windows.Forms.Button btnZoomOut;
		private System.Windows.Forms.Button btnZoomIn;
		private System.Windows.Forms.CheckBox ckSwitchToDest;
		private System.Windows.Forms.TabPage tabUILang;
		private System.Windows.Forms.Button btnSetUILang;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbUILangs;
		private System.Windows.Forms.TabPage tabOpers;
		private System.Windows.Forms.Panel pnOpOpts;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.ComboBox cbOpers;
		private System.Windows.Forms.Button btnRunOp;
		private System.Windows.Forms.CheckBox ckShowOpDlg;
		private System.Windows.Forms.Label lbDocReq;
		private System.Windows.Forms.PictureBox picDocReq;
		private System.Windows.Forms.TabPage tabHelp;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.TabPage tabSettingsIO;
		private System.Windows.Forms.CheckBox ckKeepPrefs;
		private System.Windows.Forms.GroupBox gboxProgramOpts;
		private System.Windows.Forms.TextBox tPrefs_reg;
		private System.Windows.Forms.RadioButton rbPrefs_reg;
		private System.Windows.Forms.GroupBox gboxImpExp;
		private System.Windows.Forms.Button btnSettSave;
		private System.Windows.Forms.Button btnSettLoad;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Button btnBrowseForSettFile;
		private System.Windows.Forms.TextBox tSettFile;
		private System.Windows.Forms.Button btnBrowseForPrefsFile;
		private System.Windows.Forms.TextBox tPrefs_file;
		private System.Windows.Forms.RadioButton rbPrefs_file;
		private System.Windows.Forms.TabPage tabCustomUI;
		private System.Windows.Forms.GroupBox gboxCustFonts;
		private System.Windows.Forms.GroupBox gboxCustColors;
		private System.Windows.Forms.Button btnSelClr;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Button btnTextClr;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Button btnWndClr;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Button btnFaceClr;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Button btnDefaultFnt;
		private System.Windows.Forms.Label lbDefaultFnt;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Button btnMenuFnt;
		private System.Windows.Forms.Label lbMenuFnt;
		private System.Windows.Forms.Button btnResetUI;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.CheckBox ckSettIncHist;
		private System.Windows.Forms.Button btnBrowseForHistDir;
		private System.Windows.Forms.TextBox tHistDir;
		private System.Windows.Forms.CheckBox ckKeepHist;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.CheckBox ckHideSingleTab;
		private System.Windows.Forms.CheckBox ckMultDocs;
		private System.Windows.Forms.CheckBox ckShowRotateViewBar;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.CheckBox ckShowFormViewBar;
		private System.Windows.Forms.CheckBox ckRibbonUI;
		private MyTreeView cmdBarsTree;
		private Label label45;
	}
}

