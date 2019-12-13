
import org.eclipse.swt.SWT;
import org.eclipse.swt.layout.FillLayout;
import org.eclipse.swt.ole.win32.OLE;
import org.eclipse.swt.ole.win32.OleAutomation;
import org.eclipse.swt.ole.win32.OleControlSite;
import org.eclipse.swt.ole.win32.OleFrame;
import org.eclipse.swt.ole.win32.Variant;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;

public class PDFEditSDKSimple {

	public static void main(String[] args) {
		final Display display = new Display();
		Shell shell = new Shell(display);
		shell.setSize(600, 400);
		shell.setLayout(new FillLayout());

		OleControlSite oleControlSite;
		OleFrame oleFrame = new OleFrame(shell, SWT.NONE);

		oleControlSite = new OleControlSite(oleFrame, SWT.NONE, "PDFXEdit.PXV_Control.1");
		oleControlSite.doVerb(OLE.OLEIVERB_INPLACEACTIVATE);
		shell.open();

		OleAutomation viewer = new OleAutomation(oleControlSite);
		
		try {			
			// prepare parameters Inst			
			int[] opPropIDs = viewer.getIDsOfNames(new String[] {"Inst"});
			Variant resInst = viewer.getProperty(opPropIDs[0]);
			OleAutomation gInst = resInst.getAutomation();
			// prepare parameters CreateOpenDocParams
			int[] opInstIDs = gInst.getIDsOfNames(new String[] {"CreateOpenDocParams"});
			Variant resCab = gInst.invoke(opInstIDs[0]);
			OleAutomation cab1 = resCab.getAutomation();
			// lookup method to open document --> returns null, no such method can be found
			int[] opIDs = viewer.getIDsOfNames(new String[] { "OpenDocFromPath", "sSrcPath", "pOpenParams"});
			// prepare parameters
			Variant[] address = new Variant[] { new Variant("http://www.dpconline.org/docs/reports/dpctw08-02.pdf"), new Variant(cab1)};
			// invoke method
			viewer.invoke(opIDs[0], address, new int[] { opIDs[1], opIDs[2] });
			
	/*		int[] opIDs = viewer.getIDsOfNames(new String[] { "CreateNewBlankDoc", "nPageWidth", "nPageHeight", "nPagesCount", "nPageRotation"});
			// prepare parameters
			Variant[] address = new Variant[] { new Variant((double)600.0), new Variant((double)800.0), new Variant((long)2), new Variant((long)0)};
			// invoke method
			//Variant res = viewer.invoke(opIDs[0], address, new int[] { opIDs[1], opIDs[2], opIDs[3], opIDs[4]});
			Variant res = viewer.invoke(opIDs[0], address);
	*/		
			System.out.println(viewer.getName(opIDs[0]));		
			System.out.println(viewer.getLastError());
			System.out.println("Hello, World!");
		}
		catch(Exception e)
		{
			System.out.println("eRROR");
		}	
		
		while (!shell.isDisposed()) {
		if (!display.readAndDispatch())
		display.sleep();
		}
		viewer.dispose();
		display.dispose();
	}
}
