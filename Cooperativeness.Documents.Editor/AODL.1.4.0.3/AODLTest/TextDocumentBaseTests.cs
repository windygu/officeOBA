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

using AODL.Document.Export.OpenDocument;
using AODL.IO;
using NUnit.Framework;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;

namespace AODLTest
{
	[TestFixture]
	public class TextDocumentBaseTests
	{
		[Test]
		public void EmptyDocument()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			//Save empty
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "empty.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void ParagraphSimpleText()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			//Create a standard paragraph using the ParagraphBuilder
			Paragraph paragraph						= ParagraphBuilder.CreateStandardTextParagraph(document);
			//Add some simple text
			paragraph.TextContent.Add(new SimpleText(document, "Some simple text!"));
			//Add the paragraph to the document
			document.Content.Add(paragraph);
			//Save empty
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "simple.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void ParagraphFormatedText()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			//Create a standard paragraph using the ParagraphBuilder
			Paragraph paragraph						= ParagraphBuilder.CreateStandardTextParagraph(document);
			//Add some formated text
			FormatedText formText					= new FormatedText(document, "T1", "Some formated text!");
			formText.TextStyle.TextProperties.Bold	= "bold";
			paragraph.TextContent.Add(formText);
			//Add the paragraph to the document
			document.Content.Add(paragraph);
			//Save empty
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "formated.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void NumberedListTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			//Create a numbered list
			List li				= new List(document, "L1", ListStyles.Number, "L1P1");
			Assert.IsNotNull(li.Node, "Node object must exist!");
			Assert.IsNotNull(li.Style, "Style object must exist!");
			Assert.IsNotNull(li.ListStyle.ListlevelStyles, "ListLevelStyleCollection must exist!");
			Assert.IsTrue(li.ListStyle.ListlevelStyles.Count == 10, "Must exist exactly 10 ListLevelStyle objects!");
			Assert.IsNotNull(li.ListStyle.ListlevelStyles[1].ListLevelProperties, "ListLevelProperties object must exist!");
		}

		[Test]
		public void BulletListTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			//Create a bullet list
			List li				= new List(document, "L1", ListStyles.Bullet, "L1P1");
			Assert.IsNotNull(li.Node, "Node object must exist!");
			Assert.IsNotNull(li.Style, "Style object must exist!");
			Assert.IsNotNull(li.ListStyle.ListlevelStyles, "ListLevelStyleCollection must exist!");
			Assert.IsTrue(li.ListStyle.ListlevelStyles.Count == 10, "Must exist exactly 10 ListLevelStyle objects!");
			Assert.IsNotNull(li.ListStyle.ListlevelStyles[1].ListLevelProperties, "ListLevelProperties object must exist!");
		}

		[Test]
		public void ListItemTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			//Create a numbered list
			List li									= new List(document, "L1", ListStyles.Bullet, "L1P1");
			//Create a new list item
			ListItem lit							= new ListItem(li);
			Assert.IsNotNull(lit.Content, "Content object must exist!");
			//Create a paragraph	
			Paragraph paragraph						= ParagraphBuilder.CreateStandardTextParagraph(document);
			//Add some text
			paragraph.TextContent.Add(new SimpleText(document, "First item"));
			//Add paragraph to the list item
			lit.Content.Add(paragraph);
			//Add the list item
			li.Content.Add(lit);
			//Add the list
			document.Content.Add(li);
			//Save document
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "list.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void HeadingsTest()
		{
			//Create a new text document
			TextDocument document		= new TextDocument();
			document.New();
			//Create a new Heading
			Header header				= new Header(document, Headings.Heading);
			//Add some header text
			header.TextContent.Add(new SimpleText(document, "I'm the first headline"));
			//Add header
			document.Content.Add(header);
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "Heading.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void HeadingFilledWithTextBuilder()
		{
			string headingText			= "Some    Heading with\n styles\t and more";
			//Create a new text document
			TextDocument document		= new TextDocument();
			document.New();
			//Create a new Heading
			Header header				= new Header(document, Headings.Heading);
			//Create a TextCollection from headingText using the TextBuilder
			ITextCollection textCol		= TextBuilder.BuildTextCollection(document, headingText);
			//Add text collection
			header.TextContent			= textCol;
			//Add header
			document.Content.Add(header);
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "HeadingWithControlCharacter.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void XLinkTest()
		{
			//Create new TextDocument
			TextDocument document		= new TextDocument();
			document.New();
			//Create a new Paragraph
			Paragraph para				= new Paragraph(document, "P1");
			//Create some simple text
			SimpleText stext			= new SimpleText(document, "Some simple text ");
			//Create a XLink
			XLink xlink					= new XLink(document, "http://www.sourceforge.net", "Sourceforge");
			//Add the textcontent
			para.TextContent.Add(stext);
			para.TextContent.Add(xlink);
			//Add paragraph to the document content
			document.Content.Add(para);
			//Save
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "XLink.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void FootnoteText()
		{
			//Create new TextDocument
			TextDocument document		= new TextDocument();
			document.New();
			//Create a new Paragph
			Paragraph para				= ParagraphBuilder.CreateStandardTextParagraph(document);
			//Create some simple Text
			para.TextContent.Add(new SimpleText(document, "Some simple text. And I have a footnode"));
			//Create a Footnote
			para.TextContent.Add(new Footnote(document, "Footer Text", "1", FootnoteType.Footnode));			
			//Add the paragraph
			document.Content.Add(para);
			//Save
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "footnote.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void IParagraphCollectionBuilderTest()
		{
			//some text e.g read from a TextBox
			string someText		= "Max Mustermann\nMustermann Str. 300\n22222 Hamburg\n\n\n\n"
									+"Heinz Willi\nDorfstr. 1\n22225 Hamburg\n\n\n\n"
									+"Offer for 200 Intel Pentium 4 CPU's\n\n\n\n"
									+"Dear Mr. Willi,\n\n\n\n"
									+"thank you for your request. \tWe can     offer you the 200 Intel Pentium IV 3 Ghz CPU's for a price of 79,80 � per unit."
									+"This special offer is valid to 31.10.2005. If you accept, we can deliver within 24 hours.\n\n\n\n"
									+"Best regards \nMax Mustermann";

			//Create new TextDocument
			TextDocument document				= new TextDocument();
			document.New();
			//Use the ParagraphBuilder to split the string into ParagraphCollection
			ParagraphCollection pCollection		= ParagraphBuilder.CreateParagraphCollection(
													document,
													someText,
													true,
													ParagraphBuilder.ParagraphSeperator);
			//Add the paragraph collection
			foreach(Paragraph paragraph in pCollection)
				document.Content.Add(paragraph);
			//save
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "Letter.odt", new OpenDocumentTextExporter(writer));
            }
		}

		/// <summary>
		/// Manipulate a common style.
		/// </summary>
		[Test]
		public void ManipulateACommonStyle()
		{
			TextDocument document				= new TextDocument();
			document.New();
			Assert.IsTrue(document.CommonStyles.Count > 0, "Common style resp. style templates must be loaded");
			//Find a Header template
			IStyle style						= document.CommonStyles.GetStyleByName("Heading_20_1");
			Assert.IsNotNull(style, "Style with name Heading_20_1 must exist");
			Assert.IsTrue(style is ParagraphStyle, "style must be a ParagraphStyle");
			((ParagraphStyle)style).TextProperties.FontName	= FontFamilies.BroadwayBT;
			//Create a header that use the standard style Heading_20_1
			Header header						= new Header(document, Headings.Heading_20_1);
			//Add some text
			header.TextContent.Add(new SimpleText(document, "I am the header text and my style template is modified :)"));
			//Add header to the document
			document.Content.Add(header);
			//save the document
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "modifiedCommonStyle.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test]
		public void InsertAndRemoveTest()
		{
			//Create a new document
			TextDocument document				= new TextDocument();
			document.New();
			//Create a standard paragraph
			Paragraph paragraph					= ParagraphBuilder.CreateStandardTextParagraph(document);
			//Create some simple text
			SimpleText simpleText				= new SimpleText(document, "Some simple text");
			//Add the text
			paragraph.TextContent.Add(simpleText);
			Assert.IsNotNull(paragraph.TextContent, "Must be contain one element.");
			//Remove the simple text
			paragraph.TextContent.Remove(simpleText);
			Assert.IsNotNull(paragraph.TextContent, "Must be empty");
			Assert.IsTrue(paragraph.Node.Value.Length == 0, "Node from simple text must be removed.");
		}

		[Test]
		public void TestParagraphCloning()
		{
			
			TextDocument document				= new TextDocument();
			document.New();
			Paragraph paragraph					= ParagraphBuilder.CreateStandardTextParagraph(document);
			paragraph.TextContent.Add(new SimpleText(document, "Some text"));
			Paragraph paragraphClone			= (Paragraph)paragraph.Clone();
			Assert.AreNotEqual(paragraph.Node, paragraphClone.Node, "Should be cloned and not equal.");
			Assert.AreEqual(paragraph.TextContent[0].GetType(), paragraphClone.TextContent[0].GetType(), "Should be cloned and equal.");
		
		}
		
		[Test]
		public void TestCloning()
		{
			TextDocument document				= new TextDocument();
			document.New();
			Paragraph paragraph					= ParagraphBuilder.CreateStandardTextParagraph(document);
			paragraph.TextContent.Add(new SimpleText(document, "Some text"));
			Paragraph paragraphClone			= (Paragraph)paragraph.Clone();
			//Assert.AreEqual(paragraph.Node, paragraphClone.Node, "Should be cloned and not equal.");
			//Assert.AreEqual(paragraph.TextContent[0].GetType(), paragraphClone.TextContent[0].GetType(), "Should be cloned and equal.");
			ParagraphStyle paragraphStyle		= new ParagraphStyle(document, "P1");
			paragraphStyle.TextProperties.Bold	= "bold";
			//Add paragraph style to the document, 
			//only automaticaly created styles will be added also automaticaly
			document.Styles.Add(paragraphStyle);
			paragraphClone.ParagraphStyle		= paragraphStyle;
			//Clone the clone
			Paragraph paragraphClone2			= (Paragraph)paragraphClone.Clone();
			Assert.AreNotEqual(paragraphClone2.Node, paragraphClone.Node, "Should be cloned and not equal.");
			Assert.AreEqual(paragraphClone2.TextContent[0].GetType(), paragraphClone.TextContent[0].GetType(), "Should be cloned and equal.");
			//Cloning of styles isn't supported!
			Assert.AreSame(paragraphClone2.ParagraphStyle, paragraphClone.ParagraphStyle, "Must be same style object. Styles have to be cloned explicitly.");
			document.Content.Add(paragraph);
			document.Content.Add(paragraphClone);
			document.Content.Add(paragraphClone2);
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "clonedParagraphs.odt", new OpenDocumentTextExporter(writer));
            }
		}
	}
}

/*
 * $Log: TextDocumentBaseTests.cs,v $
 * Revision 1.5  2008/04/29 15:39:59  mt
 * new copyright header
 *
 * Revision 1.4  2008/02/08 07:12:18  larsbehr
 * - added initial chart support
 * - several bug fixes
 *
 * Revision 1.3  2007/04/08 16:51:09  larsbehr
 * - finished master pages and styles for text documents
 * - several bug fixes
 *
 * Revision 1.2  2007/03/15 15:29:03  larsbehr
 * - added IContent inserting/removing for page header/footer
 * - test for new masterpage styles
 *
 * Revision 1.1  2007/02/25 09:01:28  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.3  2006/02/02 21:55:59  larsbm
 * - Added Clone object support for many AODL object types
 * - New Importer implementation PlainTextImporter and CsvImporter
 * - New tests
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
