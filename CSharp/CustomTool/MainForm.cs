using System;
using System.Windows.Forms;

namespace CustomTool
{
    public enum MenuItems : int
    {
        MI_Document = 0,
        MI_Tool = 1,
        MI_Doc_Open = MI_Document,
        MI_Doc_Close = 2,
        MI_Tool_Activate = 0,
        MI_Tool_Save = 2,
    }
    public partial class MainForm : Form
    {
        private readonly PagesMarkupTool MarkupTool;
        public MainForm()
        {
            InitializeComponent();

            MarkupTool = new PagesMarkupTool(this);
            pdfCtl.Inst.RegisterTool(MarkupTool);
            menuForm.Items.Clear();
            menuForm.Items.Add("Document");
            menuForm.Items.Add("Tool");

            var tmpItem = menuForm.Items[(int)MenuItems.MI_Document] as ToolStripMenuItem;
            tmpItem?.DropDown.Items.Add(new ToolStripMenuItem("Open", null, this.btnOpen_Click));
            tmpItem?.DropDown.Items.Add("-");
            tmpItem?.DropDown.Items.Add(new ToolStripMenuItem("Close", null, this.btnCloseDoc_Click));
            tmpItem.DropDown.Items[(int)MenuItems.MI_Doc_Close].Enabled = false;

            tmpItem = menuForm.Items[(int)MenuItems.MI_Tool] as ToolStripMenuItem;
            tmpItem?.DropDown.Items.Add(new ToolStripMenuItem("Activate", null, this.btnMarkupTool_CheckedChanged));
            tmpItem.DropDown.Items[(int)MenuItems.MI_Tool_Activate].Enabled = false;
            tmpItem?.DropDown.Items.Add("-");
            tmpItem?.DropDown.Items.Add(new ToolStripMenuItem("Save selected", null, this.btnProcessSelRegions_Click));

            OnCustomRegionsChanged();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                pdfCtl.OpenDocWithDlg();
                if (pdfCtl.Doc != null)
                {
                    (menuForm.Items[(int)MenuItems.MI_Document] as ToolStripMenuItem).DropDown.Items[(int)MenuItems.MI_Doc_Close].Enabled = true;
                    (menuForm.Items[(int)MenuItems.MI_Tool] as ToolStripMenuItem).DropDown.Items[(int)MenuItems.MI_Tool_Activate].Enabled = true;
                }                
            }
            catch { }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            try
            {
                pdfCtl.Doc?.Close();
                (sender as ToolStripMenuItem).Enabled = false;

                var item = (menuForm.Items[(int)MenuItems.MI_Tool] as ToolStripMenuItem);
                ToolStripMenuItem toolStripMenuItem = (item.DropDownItems[(int)MenuItems.MI_Tool_Activate] as ToolStripMenuItem);
                toolStripMenuItem.Checked = false;
                toolStripMenuItem.Enabled = false;
            }
            catch { }
        }

        private void ActivateMarkupTool() => pdfCtl.Doc?.ActivateTool(MarkupTool != null ? MarkupTool.ID : pdfCtl.Inst.Str2ID("tool.hand"));

        private void DeactivateMarkupTool() => pdfCtl.Doc?.ActivateTool(pdfCtl.Inst.Str2ID("tool.hand"));

        private void btnProcessSelRegions_Click(object sender, EventArgs e) => MarkupTool.ProcessSelRegions();

        public void OnCustomRegionsChanged()
        {
            var item = (menuForm.Items[(int)MenuItems.MI_Tool] as ToolStripMenuItem);
            item.DropDownItems[(int)MenuItems.MI_Tool_Save].Enabled = MarkupTool.PageRegions.Count != 0;
        }
        private void btnMarkupTool_CheckedChanged(object sender, EventArgs e)
        {
            var send = (sender as ToolStripMenuItem);
            send.Checked = !send.Checked;
            if (!send.Checked)
                DeactivateMarkupTool();
            else
                ActivateMarkupTool();
        }
    }
}
