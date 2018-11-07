using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboReader
{
	public partial class Form1 : Form
	{
		private int curPage = -1;
		private int curWord = -1;
		private int curWordLen = -1;
		private PDFXEdit.INumArray wordsRanges = null;
		private PDFXEdit.INumArray wordRange = null;
		private PDFXEdit.IPXV_DocHighlighter docHighlighter = null;
		private PDFXEdit.IPXV_DocHighlightItem pageSolidHighlight = null;
		private bool solidHighlight = false;
		private bool smoothHighlight = false;
		private bool endReached = false;
		private bool blueHighlight = false;
		private bool useDocHighlighter = true;
		private PDFXEdit.PXV_DocHighlightAdvanced dha;
		private PDFXEdit.IUIX_Brush brush = null;
		private PDFXEdit.IUIX_Pen pen = null;
		public PDFXEdit.IMathHelper mh = null;


		public partial class DrawHighlightOnPagesCallback : PDFXEdit.IPXV_PagesViewDrawCallback
		{
			public PDFXEdit.IPXV_Document doc = null;
			public PDFXEdit.IPXC_QuadsF quads = null;
			public PDFXEdit.IUIX_PolyPolygonSrc poly = null;
			public PDFXEdit.IUIX_Brush brush = null;
			public PDFXEdit.IUIX_Pen pen = null;
			public PDFXEdit.PXC_RectF bbox;
			public PDFXEdit.IMathHelper mh = null;
			public int page = -1;

			public void Start(PDFXEdit.IPXV_Inst inst, PDFXEdit.IPXV_Document doc_)
			{
				Stop(false);

				doc = doc_;

				if (quads == null)
				{
					PDFXEdit.IPXC_Inst pxcInst = (PDFXEdit.IPXC_Inst)inst.GetExtension("PXC");
					quads = pxcInst.CreateQuads();
				}

				if (poly == null)
				{
					PDFXEdit.IUIX_Inst uiInst = (PDFXEdit.IUIX_Inst)inst.GetExtension("UIX");
					poly = uiInst.CreatePolyPolygonSrc();
				}
						
				doc.RegisterPagesViewDrawCallback(PDFXEdit.PXV_PagesViewDrawStage.PXV_PagesViewDraw_Foreground, this, 0);
			}

			public void Stop(bool bFinal)
			{
				if (doc != null)
				{
					doc.UnregisterPagesViewDrawCallback(PDFXEdit.PXV_PagesViewDrawStage.PXV_PagesViewDraw_Foreground, this);
					doc = null;
				}

				if (bFinal)
				{
					quads = null;
					poly = null;
					brush = null;
					pen = null;
				}
			}

			// PDFXEdit.IPXV_PagesViewDrawCallback
			public void OnDrawPagesView(PDFXEdit.IPXV_PagesView pView, PDFXEdit.PXV_PagesViewDrawStage nStage, PDFXEdit.IUIX_RenderContext pRC, PDFXEdit.IPXV_PagesLayoutRegions pPageRegions)
			{
				PDFXEdit.PXV_PagesLayoutRegion plr = pPageRegions.Find((uint)page);
				if (plr.nPage < 0)
					return; // this page isn't visible now

				PDFXEdit.tagRECT stub;
				PDFXEdit.tagRECT clipRect = pRC.GetUpdateRegion(out stub, 0);

				PDFXEdit.PXC_Matrix m = pView.Layout.GetPageToDeviceMatrix((uint)page, true);

				poly.Clear();
				uint cnt = quads.Count;
				for (uint i = 0; i < cnt; i++)
				{
					PDFXEdit.PXC_QuadF q = quads.get_Item(i);

					mh.Quad_TransformDF(m, ref q);

					PDFXEdit.tagPOINTF pt0, pt1, pt2, pt3;
					pt0.x = q.pt[0].x;
					pt0.y = q.pt[0].y;
					pt1.x = q.pt[1].x;
					pt1.y = q.pt[1].y;
					pt2.x = q.pt[2].x;
					pt2.y = q.pt[2].y;
					pt3.x = q.pt[3].x;
					pt3.y = q.pt[3].y;

					poly.AddQuad(pt0, pt1, pt2, pt3);
				}
				
				pRC.DrawPolyPolygon(poly, brush, pen, ref clipRect, 2); // works since 6.0.322.4 build
			}
		}

		private DrawHighlightOnPagesCallback dhp = new DrawHighlightOnPagesCallback();
				
		public Form1()
		{
			InitializeComponent();

			dha.nSize = System.Runtime.InteropServices.Marshal.SizeOf(dha);
			dha.nRoundRadius = 2;

			PDFXEdit.IUIX_Inst uiInst = (PDFXEdit.IUIX_Inst)pdfCtl.Inst.GetExtension("UIX");

			brush = uiInst.CreateNewBrush();
			pen = uiInst.CreateNewPen();
			brush.Color0 = (uint)ColorTranslator.ToWin32(Color.Blue) | 0xFF000000;
			brush.Opacity = 0.3;
			brush.BlendType = PDFXEdit.UIX_BlendType.UIX_BlendType_Multiply;
			pen.Brush.Color0 = brush.Color0;
			pen.Brush.Opacity = 0.9;
			pen.Brush.BlendType = PDFXEdit.UIX_BlendType.UIX_BlendType_Multiply;

			PDFXEdit.IAUX_Inst auxInst = (PDFXEdit.IAUX_Inst)pdfCtl.Inst.GetExtension("AUX");
			mh = auxInst.MathHelper;

			dhp = new DrawHighlightOnPagesCallback();
			dhp.brush = brush;
			dhp.pen = pen;
			dhp.mh = mh;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			/////////////////////////////////////////////////////////////////////////////////////
			// Forced release of all COM-objects that may still captured by Garbage Collector. //
			// It is critical to release them before destroying of pdfCtl!                     //
			/////////////////////////////////////////////////////////////////////////////////////
			wordsRanges = null;
			docHighlighter = null;
			brush = null;
			pen = null;
			dhp.Stop(true);
			dhp = null;
			mh = null;

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		private void UpdateStartBtn()
		{
			bool hasDoc = pdfCtl.HasDoc;
			bool started = timer1.Enabled;

			btnStart.Enabled = hasDoc;
			btnStart.Text = started ? "Stop" : "Start";

			bool b = hasDoc && !started;

			ckUseDocHighlighter.Enabled = b;
			ckSolid.Enabled = b;
			ckBlue.Enabled = b;
			ckSmooth.Enabled = b;
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			bool timerStarted = timer1.Enabled;
			timer1.Stop();

			uint oldDocId = 0;
			if (pdfCtl.HasDoc)
				oldDocId = pdfCtl.Doc.ID;

			pdfCtl.OpenDocWithDlg();

			uint newDocId = 0;
			if (pdfCtl.HasDoc)
				newDocId = pdfCtl.Doc.ID;

			if (wordsRanges == null)
			{
				PDFXEdit.IAUX_Inst auxInst = (PDFXEdit.IAUX_Inst)pdfCtl.Inst.GetExtension("AUX");
				wordsRanges = auxInst.CreateNumArray();
				wordRange = auxInst.CreateNumArray();
			}

			if (newDocId != oldDocId) // new document opened
			{
				// restart
				endReached = false;
				curPage = -1;
				curWord = -1;
				docHighlighter = null;
				pageSolidHighlight = null;
				dhp.Stop(false);
			}

			if (pdfCtl.HasDoc)
			{
				if (timerStarted)
					timer1.Start();
			}

			UpdateStartBtn();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled || !pdfCtl.HasDoc)
			{
				timer1.Stop();
			}
			else
			{
				PDFXEdit.IPXV_Document doc = pdfCtl.Doc;

				bool solid = ckSolid.Checked;
				bool smooth = ckSmooth.Checked;
				bool useDH = ckUseDocHighlighter.Checked;

				blueHighlight = ckBlue.Checked;

				if (endReached || solidHighlight != solid || smoothHighlight != smooth || useDocHighlighter != useDH) // can continue?
				{
					// restart
					endReached = false;
					curPage = -1;
					curWord = -1;
					pageSolidHighlight = null;
					if (docHighlighter != null)
					{
						doc.RemoveHighlighter(docHighlighter);
						docHighlighter = null;
					}
				}

				dhp.Stop(false);

				doc.ActiveView.PagesView.Redraw();

				useDocHighlighter = useDH;
				solidHighlight = solid;
				smoothHighlight = smooth;

				timer1.Interval = smoothHighlight ? 40 : 260;

				timer1.Start();
			}

			UpdateStartBtn();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			PDFXEdit.IPXC_Document cdoc = doc.CoreDoc;

			do
			{
				bool newPage = curPage < 0;
				bool newWord = true;
				if (!newPage)
				{
					uint wordsCnt = wordsRanges.Count / 2;

					if (smoothHighlight && (curWord >= 0) && ((uint)curWord < wordsCnt))
					{
						int wl = wordsRanges[(uint)curWord * 2 + 1];
						if ((curWordLen + 1) <= wl)
							newWord = false;
					}

					if (newWord && ((uint)(curWord + 1) >= wordsCnt))
						newPage = true;
				}

				if (newPage)
				{
					if ((uint)(curPage + 1) >= cdoc.Pages.Count)
					{
						timer1.Stop();
						endReached = true;
						UpdateStartBtn();
						return;
					}

					endReached = false;
					curPage++;

					PDFXEdit.IPXC_Page page = cdoc.Pages[(uint)curPage];

					PDFXEdit.IPXC_PageText pageText = page.GetText(null);

					pageSolidHighlight = null;
					if (docHighlighter == null)
						docHighlighter = doc.AddNewHighlighter(PDFXEdit.PXV_DocHighlightType.PXV_DocHighlight_Page);
					else
						docHighlighter.Clear();

					wordsRanges.Clear();
					
					uint charsCnt = pageText.CharsCount;
					int wb = -1;
					int we = 0;
					for (uint i = 0; i < charsCnt; i++)
					{
						ushort ch = pageText.CharCode[i];
						uint flg = pageText.CharFlags[i];
						bool lineBegin = ((flg & (uint)(PDFXEdit.PXC_TextCharFlags.TCF_LineBegin)) != 0);
						// bool wordSep = ((flg & (uint)(PDFXEdit.PXC_TextCharFlags.TCF_SearchWordSeparator)) != 0);
						bool wordSep = ch <= 32 || ch == 160;
						if (!wordSep && !lineBegin)
						{
							if (wb < 0)
								wb = (int)i;
							we = (int)i;
						}
						else
						{
							if (wb >= 0)
							{
								wordsRanges.Insert(wb);
								wordsRanges.Insert(we - wb + 1);
							}
							if (wordSep)
								wb = -1;
							else // lineBegin==true
								wb = we = (int)i;
						}
					}
					if (wb >= 0)
					{
						wordsRanges.Insert(wb);
						wordsRanges.Insert(we - wb + 1);
					}

					curWord = -1;
					curWordLen = 0;
					continue;
				}

				if (newWord)
				{
					curWord++;
					curWordLen = 0;
				}

				int wordBegin = wordsRanges[(uint)curWord * 2];
				int wordLen = wordsRanges[(uint)curWord * 2 + 1];
				
				if (smoothHighlight)
					curWordLen++;
				else
					curWordLen = wordLen;

				{
					int wb = wordBegin;
					int wl = curWordLen;

					if (solidHighlight)
					{
						wb = 0;
						wl = wordBegin + curWordLen;
					}

					if (useDocHighlighter)
					{
						wordRange.Clear();
						wordRange.Insert(wb);
						wordRange.Insert(wl);

						if (pageSolidHighlight != null)
						{
							pageSolidHighlight.Remove();
							pageSolidHighlight = null;
						}

						PDFXEdit.IUIX_Brush br = null;
						PDFXEdit.IUIX_Pen pn = null;

						if (blueHighlight)
						{
							br = brush;
							pn = pen;
						}

						PDFXEdit.IPXC_Page pg = cdoc.Pages[(uint)curPage];
						PDFXEdit.IPXC_PageText pgText = pg.GetText(null);

						PDFXEdit.IPXV_DocHighlightItem itm = docHighlighter.Add(pg, wordRange, br, pn, ref dha, (uint)(PDFXEdit.PXV_DocHighlightFlags.PXV_DocHighlightFlag_ShareBrush | PDFXEdit.PXV_DocHighlightFlags.PXV_DocHighlightFlag_SharePen));

						// doc.ActiveView.PagesView.Obj.Redraw(); // this line is required for build <= 6.0.322.3. Look for actual dev. build: http://docu-track.co.uk/devbuilds/latest/DevRelease.x32.zip

						if (solidHighlight || smoothHighlight)
							pageSolidHighlight = itm;

					}
					else
					{
						HighlightQuads(doc, curPage, wb, wl);
					}

					// ensure visible last selected symbol
					EnsureVisibleChar(doc, (uint)curPage, (uint)(wb + wl - 1));
				}

				break;
			}
			while (true);
		}

		private void HighlightQuads(PDFXEdit.IPXV_Document doc, int page, int wb, int wl)
		{
			if (dhp.doc != null)
				dhp.doc.InvalidatePageRects((uint)dhp.page, dhp.bbox, 1);

			PDFXEdit.IPXC_Document cdoc =  doc.CoreDoc;
			if (dhp.doc != doc)
				dhp.Start(pdfCtl.Inst, doc);

			dhp.page = page;
			dhp.quads.Clear();

			PDFXEdit.IPXC_PageText pageText = cdoc.Pages[(uint)page].GetText(null);
			if (pageText != null)
				pageText.GetTextQuads3((uint)wb, (uint)wl, dhp.quads, out dhp.bbox); // method added in build 6.0.322.4

			if (dhp.doc != null)
				dhp.doc.InvalidatePageRects((uint)dhp.page, dhp.bbox, 1);
		}

		private void EnsureVisibleChar(PDFXEdit.IPXV_Document doc, uint page, uint charIndex)
		{
			PDFXEdit.IPXC_PageText pgText = doc.CoreDoc.Pages[(uint)page].GetText(null);
			if (pgText == null)
				return;
			PDFXEdit.PXC_RectF bboxOnThePage = mh.Quad_To_RectF(pgText.CharQuad[charIndex]);
			PDFXEdit.PXC_Rect t;
			t.left = bboxOnThePage.left;
			t.right = bboxOnThePage.right;
			t.top = bboxOnThePage.top;
			t.bottom = bboxOnThePage.bottom;
			doc.ActiveView.PagesView.Layout.EnsureVisible(page, t, false);
		}

		private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
