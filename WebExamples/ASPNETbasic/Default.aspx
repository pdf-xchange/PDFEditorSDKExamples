<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <!CDATA[
    	function btnOpen_Click() {
    		try {
    			document.all.PDFView.Src = "http://docu-track.co.uk/FeatureChartEU.pdf";;
    			docID = document.all.PDFView.Doc.ID;
    			//alert(docID);
    		}
    		catch (err) { }
    	}

    	function btnClose_Click() {
    		try {
    			document.all.PDFView.Doc.Close();
    		}
    		catch (err) { }
    	}

    	function btnPrint_Click() {
    		try {
    			document.all.PDFView.PrintWithDlg(false, false);
    		}
    		catch (err) { }
    	}

    	function btnToolbars_Click() {
    		//PXV_VisibleCmdPanes_MainView = 1,
    		//PXV_VisibleCmdPanes_PagesView = 2,
    		//PXV_VisibleCmdPanes_All = 3
    		if (0 == document.all.PDFView.VisibleCmdPanes)
    			document.all.PDFView.VisibleCmdPanes = 3;
    		else
    			document.all.PDFView.VisibleCmdPanes = 0;
    	}
// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="btnOpen" type="button" value="Open doc" 
            onclick="return btnOpen_Click()" />
        <input id="btnClose" type="button" 
            value="Close doc" onclick="return btnClose_Click()" />
        <input id="btnPrint" onclick="return btnPrint_Click()"
                type="button" value="Print" />
        <input id="btnToolbars" type="button" 
            value="Toolbars" onclick="return btnToolbars_Click()" /><br />
		<object id="PDFView" classid="CLSID:A1149909-4EDC-4421-B9E5-E93C25A000A1" width="100%" height="600"></object>
    </div>
    </form>
</body>
</html>
