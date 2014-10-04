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
using NUnit.Framework;
using AODL.Import;
using AODL.TextDocument;
using AODL.TextDocument.Content;
using AODL.TextDocument.Style;

namespace AODLTest
{
	[TestFixture]
	public class ImportTest
	{
		private string _testfile		=  Environment.CurrentDirectory+"\\OfferLongVersion.odt";
		private TextDocument _document	= null;

		[SetUp]
		public void Setup()
		{
			TestClass test		= new TestClass();
			test.LetterTestLongVersion();

			this._document		= new TextDocument();
			this._document.Load(this._testfile);
		}

		[Test]
		public void SimpleLoadTest()
		{	
			//File must exist to pass the test
			
			Assert.IsNotNull(this._document.DocumentConfigurations2, "DocumentConfigurations2 must exist!");
			Assert.IsNotNull(this._document.DocumentManifest, "DocumentManifest must exist!");
			Assert.IsNotNull(this._document.DocumentMetadata, "DocumentMetadat must exist!");
			Assert.IsNotNull(this._document.DocumentPictures, "DocumentPictures must exist!");
			Assert.IsNotNull(this._document.DocumentSetting, "DocumentSetting must exist!");
			Assert.IsNotNull(this._document.DocumentStyles, "DocumentStyles must exist!");
			Assert.IsNotNull(this._document.DocumentThumbnails, "DocumentThumbnails must exist!");

			File.Delete(this._testfile);
		}

		[Test]
		public void RealContentLoadTest()
		{
			Assert.IsNotNull(this._document.Content, "Content container must exist!");
			Assert.IsTrue(this._document.Content.Count > 0, "Must be content in their!");

			this._document.SaveTo("reloaded.odt");
			this._document.Dispose();
		}

		[Test]
		public void ReloadHeader()
		{
			TestClass test		= new TestClass();
			test.HeadingsTest();

			TextDocument doc	= new TextDocument();
			doc.Load("Heading.odt");
			doc.SaveTo("HeadingReloaded.odt");
			doc.Dispose();
		}

		[Test]
		public void ReloadXlink()
		{
			TestClass test		= new TestClass();
			test.XLinkTest();

			TextDocument doc	= new TextDocument();
			doc.Load("Xlink.odt");
			doc.SaveTo("XlinkReloaded.odt");
			doc.Dispose();
		}

		[Test]
		public void ReloadTableOfContents()
		{
			TextDocument doc	= new TextDocument();
			doc.Load("OpenOffice.net.odt");
			doc.SaveTo("OpenOffice.net.Reloaded.odt");
			doc.Dispose();
		}

		[Test]
		public void TableOfContentsHtmlExport()
		{
			TextDocument doc	= new TextDocument();
			doc.Load("OpenOffice.net.odt");
			doc.SaveTo("OpenOffice.net.html");
			doc.Dispose();
		}

		[Test]
		public void SaveAsHtml()
		{
			this._document.SaveTo("reloaded.html");
			this._document.Dispose();
		}

		[Test]
		public void SaveAsHtmlWithTable()
		{
			TextDocument document		= new TextDocument();
			document.Load("tablewithList.odt");
			document.SaveTo("tablewithList.html");
			document.Dispose();
		}

		[Test]
		public void ProgrammaticControl()
		{
			TextDocument document		= new TextDocument();
			document.Load("ProgrammaticControlOfMenuAndToolbarItems.odt");
			document.SaveTo("ProgrammaticControlOfMenuAndToolbarItems.html");
//			document.Load("AndrewMacroPart.odt");
//			document.SaveTo("AndrewMacro.html");
//			document.Load("OfferLongVersion.odt");
//			document.SaveTo("OfferLongVersion.html");
			document.Dispose();
		}

		[Test]
		public void Howto_special_char()
		{
			TextDocument document		= new TextDocument();
			document.Load("Howto_special_char.odt");
			document.SaveTo("Howto_special_char.html");
			document.Dispose();
		}

		[Test]
		public void Howto_special_charInch()
		{
			TextDocument document		= new TextDocument();
			document.Load(@"F:\odtFiles\Howto_special_char.odt");
			document.SaveTo(@"F:\odtFiles\Howto_special_char.html");
			document.Dispose();
		}

		[Test]
		public void ComplexTable()
		{
			TableTest tableTest	= new TableTest();
			tableTest.MergeCellsTest();

			TextDocument doc	= new TextDocument();
			doc.Load("tablemergedcell.odt");
			doc.SaveTo("tablemergedcellReloaded.odt");
			doc.Dispose();
		}

		[Test]
		public void MegaStressTest()
		{
//			TextDocument document		= new TextDocument();
//			document.Load("AndrewMacro.odt");
//			document.SaveTo("AndrewMacroFull.html");
		}
	}
}

