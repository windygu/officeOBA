/*************************************************************************
 *
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER
 * 
 * Copyright 2008 Sun Microsystems, Inc. All rights reserved.
 * 
 * Use is subject to license terms.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy
 * of the License at http://www.apache.org/licenses/LICENSE-2.0. You can also
 * obtain a copy of the License at http://odftoolkit.org/docs/license.txt
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * 
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 ************************************************************************/

using System;
using System.IO;
using AODL.Document.Export.Html;
using AODL.Document.Export.OpenDocument;
using AODL.Document.Import.PlainText;
using AODL.IO;
using NUnit.Framework;
using AODL.Document.TextDocuments;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.Content;
using AODL.Document.Content.Draw;
using AODL.Document.Content.Text;
using AODL.Document.Import.OpenDocument;

namespace AODLTest
{
	[TestFixture]
	public class DocumentImportTest
	{

		[Test]
		public void SimpleLoadTest()
		{
			string file							= AARunMeFirstAndOnce.inPutFolder+@"hallo.odt";
			FileInfo fInfo						= new FileInfo(file);
			//Load a text document
			TextDocument textDocument			= new TextDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                textDocument.Load(file, new OpenDocumentImporter(reader));

                Assert.IsTrue(textDocument.CommonStyles.Count > 0, "Common Styles must be read!");
                Console.WriteLine("Common styles: {0}", textDocument.CommonStyles.Count);
                //Save it back again
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    textDocument.Save(AARunMeFirstAndOnce.outPutFolder + fInfo.Name + ".rel.odt",
                                      new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test]
		public void SimpleLoad1Test()
		{
			string file							= AARunMeFirstAndOnce.inPutFolder+@"OpenOffice.net.odt";
			FileInfo fInfo						= new FileInfo(file);
			//Load a text document
			TextDocument textDocument			= new TextDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                textDocument.Load(file, new OpenDocumentImporter(reader));

                Assert.IsTrue(textDocument.CommonStyles.Count > 0, "Common Styles must be read!");
                Console.WriteLine("Common styles: {0}", textDocument.CommonStyles.Count);
                Assert.IsTrue(textDocument.Graphics.Count > 0, "There must exist images");
                //Save it back again
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    textDocument.Save(AARunMeFirstAndOnce.outPutFolder + fInfo.Name + ".rel.odt",
                                      new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test]
		public void SimpleTocLoadTest()
		{
			string file							= AARunMeFirstAndOnce.inPutFolder+@"simple_toc.odt";
			FileInfo fInfo						= new FileInfo(file);
			//Load a text document
			TextDocument textDocument			= new TextDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                textDocument.Load(file, new OpenDocumentImporter(reader));

                //Save it back again
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    textDocument.Save(AARunMeFirstAndOnce.outPutFolder + fInfo.Name + ".rel.odt",
                                      new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test]
		public void SimpleCalcLoadTest()
		{
			string file							= AARunMeFirstAndOnce.inPutFolder+@"simpleCalc.ods";
			FileInfo fInfo						= new FileInfo(file);
			//Load a spreadsheet document
			SpreadsheetDocument document		= new SpreadsheetDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(file, new OpenDocumentImporter(reader));

                Assert.IsTrue(document.CommonStyles.Count > 0, "Common Styles must be read!");
                Console.WriteLine("Common styles: {0}", document.CommonStyles.Count);
                //Save it back again
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + fInfo.Name + ".rel.ods",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test, IgnoreAttribute(@"file ""HazelHours.ods"" is not here:)")]
		public void ComplexCalcLoadTest()
		{
			string file							= AARunMeFirstAndOnce.inPutFolder+@"HazelHours.ods";
			FileInfo fInfo						= new FileInfo(file);
			//Load a spreadsheet document
			SpreadsheetDocument document		= new SpreadsheetDocument();

            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(file, new OpenDocumentImporter(reader));

                //Save it back again
                document.Save(AARunMeFirstAndOnce.outPutFolder + fInfo.Name + ".html", new OpenDocumentHtmlExporter());
            }
		}

		[Test]
		public void TextDocumentWithImgMapReload()
		{
			string file							= AARunMeFirstAndOnce.inPutFolder+@"imgmap.odt";
			FileInfo fInfo						= new FileInfo(file);
			//Load the text document
			TextDocument document				= new TextDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(file, new OpenDocumentImporter(reader));

                IContent iContent = document.Content[2];
                Assert.IsNotNull(iContent, "Must exist!");
                Assert.IsTrue(iContent is Paragraph,
                              "iContent have to be a paragraph! But is :" + iContent.GetType().Name);
                Assert.IsTrue(((Paragraph) iContent).Content[0] is Frame,
                              "Must be a frame! But is :" + ((Paragraph) iContent).Content[0].GetType().Name);
                Frame frame = ((Paragraph) iContent).Content[0] as Frame;
                Assert.IsTrue(frame.Content[1] is ImageMap,
                              "Must be a ImageMap! But is :" + frame.Content[1].GetType().Name);
                ImageMap imageMap = frame.Content[1] as ImageMap;
                Assert.IsTrue(imageMap.Content[0] is DrawAreaRectangle, "Must be a DrawAreaRectangle! But is :"
                                                                        + imageMap.Content[0].GetType().Name);
                //Save it back again
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + fInfo.Name + ".rel.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description="Convert a plain text file into an OpenDocument text document.")]
		public void TextToOpenDocumentText()
		{
			TextDocument document				= new TextDocument();
            document.Load(AARunMeFirstAndOnce.inPutFolder + "TextToOpenDocument.txt", new PlainTextImporter());
			Assert.IsNotNull(document.Content, "Must contain objects.");
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "TextToOpenDocument.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test (Description="Convert a csv text file into an OpenDocument spreadsheet document.")]
		public void CsvToOpenDocumentSpreadsheet()
		{
			SpreadsheetDocument document		= new SpreadsheetDocument();
            document.Load(AARunMeFirstAndOnce.inPutFolder + "CsvToOpenDocument.csv", new CsvImporter());
			Assert.IsTrue(document.Content.Count == 1, "Must contain objects.");
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "CsvToOpenDocument.ods", new OpenDocumentTextExporter(writer));
            }
		}
		
		#region old code delete
//		[Test]
//		public void RealContentLoadTest()
//		{
//			Assert.IsNotNull(this._document.Content, "Content container must exist!");
//			Assert.IsTrue(this._document.Content.Count > 0, "Must be content in their!");
//
//			this._document.Save("reloaded.odt");
//			this._document.Dispose();
//		}
//
//		[Test]
//		public void ReloadHeader()
//		{
//			TestClass test		= new TestClass();
//			test.HeadingsTest();
//
//			TextDocument doc	= new TextDocument();
//			doc.Load("Heading.odt");
//			doc.Save("HeadingReloaded.odt");
//			doc.Dispose();
//		}
//
//		[Test]
//		public void ReloadXlink()
//		{
//			TestClass test		= new TestClass();
//			test.XLinkTest();
//
//			TextDocument doc	= new TextDocument();
//			doc.Load("Xlink.odt");
//			doc.Save("XlinkReloaded.odt");
//			doc.Dispose();
//		}
//
//		[Test]
//		public void ReloadTableOfContents()
//		{
//			TextDocument doc	= new TextDocument();
//			doc.Load("OpenOffice.net.odt");
//			doc.Save("OpenOffice.net.Reloaded.odt");
//			doc.Dispose();
//		}
//
//		[Test]
//		public void TableOfContentsHtmlExport()
//		{
//			TextDocument doc	= new TextDocument();
//			doc.Load("OpenOffice.net.odt");
//			doc.Save("OpenOffice.net.html");
//			doc.Dispose();
//		}
//
//		[Test]
//		public void SaveAsHtml()
//		{
//			this._document.Save("reloaded.html");
//			this._document.Dispose();
//		}
//
//		[Test]
//		public void SaveAsHtmlWithTable()
//		{
//			TextDocument document		= new TextDocument();
//			document.Load("tablewithList.odt");
//			document.Save("tablewithList.html");
//			document.Dispose();
//		}
//
//		[Test]
//		public void ProgrammaticControl()
//		{
//			TextDocument document		= new TextDocument();
//			document.Load("ProgrammaticControlOfMenuAndToolbarItems.odt");
//			document.Save("ProgrammaticControlOfMenuAndToolbarItems.html");
		////			document.Load("AndrewMacroPart.odt");
		////			document.Save("AndrewMacro.html");
		////			document.Load("OfferLongVersion.odt");
		////			document.Save("OfferLongVersion.html");
//			document.Dispose();
//		}
//
//		[Test]
//		public void Howto_special_char()
//		{
//			TextDocument document		= new TextDocument();
//			document.Load("Howto_special_char.odt");
//			document.Save("Howto_special_char.html");
//			document.Dispose();
//		}
//
//		[Test]
//		public void Howto_special_charInch()
//		{
//			TextDocument document		= new TextDocument();
//			document.Load(@"F:\odtFiles\Howto_special_char.odt");
//			document.Save(@"F:\odtFiles\Howto_special_char.html");
//			document.Dispose();
//		}
//
//		[Test]
//		public void ComplexTable()
//		{
//			TableTest tableTest	= new TableTest();
//			tableTest.MergeCellsTest();
//
//			TextDocument doc	= new TextDocument();
//			doc.Load("tablemergedcell.odt");
//			doc.Save("tablemergedcellReloaded.odt");
//			doc.Dispose();
//		}
//
//		[Test]
//		public void MegaStressTest()
//		{
		////			TextDocument document		= new TextDocument();
		////			document.Load("AndrewMacro.odt");
		////			document.Save("AndrewMacroFull.html");
//		}
		#endregion
	}
}

/*
 * $Log: DocumentImportTest.cs,v $
 * Revision 1.3  2008/04/29 15:39:59  mt
 * new copyright header
 *
 * Revision 1.2  2008/02/08 07:12:18  larsbehr
 * - added initial chart support
 * - several bug fixes
 *
 * Revision 1.1  2007/02/25 09:01:26  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.7  2006/05/02 17:37:15  larsbm
 * - Flag added graphics with guid
 * - Set guid based read and write directories
 *
 * Revision 1.6  2006/02/21 19:34:54  larsbm
 * - Fixed Bug text that contains a xml tag will be imported  as UnknowText and not correct displayed if document is exported  as HTML.
 * - Fixed Bug [ 1436080 ] Common styles
 *
 * Revision 1.5  2006/02/16 18:35:40  larsbm
 * - Add FrameBuilder class
 * - TextSequence implementation (Todo loading!)
 * - Free draing postioning via x and y coordinates
 * - Graphic will give access to it's full qualified path
 *   via the GraphicRealPath property
 * - Fixed Bug with CellSpan in Spreadsheetdocuments
 * - Fixed bug graphic of loaded files won't be deleted if they
 *   are removed from the content.
 * - Break-Before property for Paragraph properties for Page Break
 *
 * Revision 1.4  2006/02/02 21:55:59  larsbm
 * - Added Clone object support for many AODL object types
 * - New Importer implementation PlainTextImporter and CsvImporter
 * - New tests
 *
 * Revision 1.3  2006/01/29 19:30:24  larsbm
 * - Added app config support for NUnit tests
 *
 * Revision 1.2  2006/01/29 18:52:14  larsbm
 * - Added support for common styles (style templates in OpenOffice)
 * - Draw TextBox import and export
 * - DrawTextBox html export
 *
 * Revision 1.1  2006/01/29 11:26:02  larsbm
 * - Changes for the new version. 1.2. see next changelog for details
 *
 */