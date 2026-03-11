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

            InitializeMenu();
            OnCustomRegionsChanged();
        }

        private void InitializeMenu()
        {
            menuForm.Items.Clear();
            menuForm.Items.Add(new ToolStripMenuItem("Document"));
            menuForm.Items.Add(new ToolStripMenuItem("Tool"));

            var docMenu = menuForm.Items[(int)MenuItems.MI_Document] as ToolStripMenuItem;
            if (docMenu != null)
            {
                docMenu.DropDown.Items.Add(new ToolStripMenuItem("Open", null, btnOpen_Click));
                docMenu.DropDown.Items.Add("-");
                docMenu.DropDown.Items.Add(new ToolStripMenuItem("Close", null, btnCloseDoc_Click) { Enabled = false });
            }

            var toolMenu = menuForm.Items[(int)MenuItems.MI_Tool] as ToolStripMenuItem;
            if (toolMenu != null)
            {
                toolMenu.DropDown.Items.Add(new ToolStripMenuItem("Activate", null, btnMarkupTool_CheckedChanged) { Enabled = false });
                toolMenu.DropDown.Items.Add("-");
                toolMenu.DropDown.Items.Add(new ToolStripMenuItem("Save selected", null, btnProcessSelRegions_Click));
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                pdfCtl.OpenDocWithDlg();
                if (pdfCtl.Doc != null)
                {
                    SetMenuItemEnabled(MenuItems.MI_Document, MenuItems.MI_Doc_Close, true);
                    SetMenuItemEnabled(MenuItems.MI_Tool, MenuItems.MI_Tool_Activate, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            try
            {
                pdfCtl.Doc?.Close();
                var closeMenuItem = sender as ToolStripMenuItem;
                if (closeMenuItem != null)
                    closeMenuItem.Enabled = false;

                SetMenuItemChecked(MenuItems.MI_Tool, MenuItems.MI_Tool_Activate, false);
                SetMenuItemEnabled(MenuItems.MI_Tool, MenuItems.MI_Tool_Activate, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivateMarkupTool() =>
            pdfCtl.Doc?.ActivateTool(MarkupTool != null ? MarkupTool.ID : pdfCtl.Inst.Str2ID("tool.hand"));

        private void DeactivateMarkupTool() =>
            pdfCtl.Doc?.ActivateTool(pdfCtl.Inst.Str2ID("tool.hand"));

        private void btnProcessSelRegions_Click(object sender, EventArgs e) =>
            MarkupTool.ProcessSelRegions();

        public void OnCustomRegionsChanged()
        {
            SetMenuItemEnabled(MenuItems.MI_Tool, MenuItems.MI_Tool_Save, MarkupTool.PageRegions.Count != 0);
        }

        private void btnMarkupTool_CheckedChanged(object sender, EventArgs e)
        {
            var send = sender as ToolStripMenuItem;
            if (send == null) return;

            send.Checked = !send.Checked;
            if (!send.Checked)
                DeactivateMarkupTool();
            else
                ActivateMarkupTool();
        }

        private void SetMenuItemEnabled(MenuItems parent, MenuItems child, bool enabled)
        {
            var parentMenu = menuForm.Items[(int)parent] as ToolStripMenuItem;
            if (parentMenu != null && parentMenu.DropDown.Items.Count > (int)child)
            {
                var item = parentMenu.DropDown.Items[(int)child] as ToolStripMenuItem;
                if (item != null)
                    item.Enabled = enabled;
            }
        }

        private void SetMenuItemChecked(MenuItems parent, MenuItems child, bool checkedState)
        {
            var parentMenu = menuForm.Items[(int)parent] as ToolStripMenuItem;
            if (parentMenu != null && parentMenu.DropDown.Items.Count > (int)child)
            {
                var item = parentMenu.DropDown.Items[(int)child] as ToolStripMenuItem;
                if (item != null)
                    item.Checked = checkedState;
            }
        }
    }
}
