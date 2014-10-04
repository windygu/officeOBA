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
using AODL.Document.Export.Html;
using AODL.Document.Export.OpenDocument;
using AODL.Document.Import.OpenDocument;
using AODL.IO;
using NUnit.Framework;
using System.Xml;
using AODL.Document.Content.Tables;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.Styles.MasterStyles;
using AODL.Document.Forms;
using AODL.Document.Forms.Controls;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.Helper;
using AODL.Document;
using AODL.Document.Content.Fields;

namespace AODLTest
{
	[TestFixture]
	public class FieldsTest
	{
		[Test (Description="Test for DateField")]
		public void SimpleDateFieldTest()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
			// Create a new paragraph
			Paragraph p = new Paragraph(td);
			DateField df = new DateField(td);
			// Set fixed to false whch means that the current date is displayed
			df.Fixed = false;
			// add the date field to content
			p.Content.Add(df);
			td.Content.Add(p);
			
			// test import/export
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "field_date.odt", new OpenDocumentTextExporter(writer));
            }
			//td.Load(AARunMeFirstAndOnce.outPutFolder + "field_date.odt");
			//td.Fields.RemoveAt(0);			
			// this document should be empty now!!!
			//td.Save(AARunMeFirstAndOnce.outPutFolder + "field_date2.odt");
		}

		[Test (Description="A test to check placeholder functionality")]
		public void PlaceholderTest()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
            
			// Add paragraph 1 with a text placeholder in it
			Paragraph p1 = new Paragraph(td);
			p1.TextContent.Add(new SimpleText(td, "Insert text here: "));
			Placeholder plch1 = new Placeholder(td, PlaceholderType.Text, "A text placeholder");
			plch1.Value = "Text";
			p1.Content.Add(plch1);
			td.Content.Add(p1);

			// Add paragraph 2 with a text-box placeholder in it
			Paragraph p2 = new Paragraph(td);
			p2.TextContent.Add(new SimpleText(td, "Insert text-box here: "));
			Placeholder plch2 = new Placeholder(td, PlaceholderType.TextBox, "A text-box placeholder");
			plch2.Value = "Text-Box";
			p2.Content.Add(plch2);
			td.Content.Add(p2);

			// Add paragraph 3 with a table placeholder in it
			Paragraph p3 = new Paragraph(td);
			p3.TextContent.Add(new SimpleText(td, "Insert table here: "));
			Placeholder plch3 = new Placeholder(td, PlaceholderType.Table, "A table placeholder");
			plch3.Value = "Table";
			p3.Content.Add(plch3);
			td.Content.Add(p3);

			// Add paragraph 4 with an object placeholder in it
			Paragraph p4 = new Paragraph(td);
			p4.TextContent.Add(new SimpleText(td, "Insert object here: "));
			Placeholder plch4 = new Placeholder(td, PlaceholderType.Object, "An object placeholder");
			plch4.Value = "Object";
			p4.Content.Add(plch4);
			td.Content.Add(p4);

			// Add paragraph 5 with an image placeholder in it
			Paragraph p5 = new Paragraph(td);
			p5.TextContent.Add(new SimpleText(td, "Insert image here: "));
			Placeholder plch5 = new Placeholder(td, PlaceholderType.Image, "An image placeholder");
			plch5.Value = "Image";
			p5.Content.Add(plch5);
			td.Content.Add(p5);

			// test save/load
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "placeholder.odt", new OpenDocumentTextExporter(writer));
            }

			// find a field in the fields collection and change its value
			td.Fields.FindFieldByValue("Image").Value = "There should be an image here";
			
			// test html export!
            td.Save(AARunMeFirstAndOnce.outPutFolder + "placeholder.html", new OpenDocumentHtmlExporter());
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                td.Load(AARunMeFirstAndOnce.outPutFolder + "placeholder.odt", new OpenDocumentImporter(reader));

                // resave it
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    td.Save(AARunMeFirstAndOnce.outPutFolder + "placeholder2.odt", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description="A test to check text input fields")]
		public void TextInputTest()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
            
			// Create two paragraphs with text inputs in them
			Paragraph p1 = new Paragraph(td);
			p1.TextContent.Add(new SimpleText(td, "Your name: "));
			TextInput ti = new TextInput(td, "<Name>", "Enter your name here!");
			p1.Content.Add(ti);
			td.Content.Add(p1);

			Paragraph p2 = new Paragraph(td);
			p2.TextContent.Add(new SimpleText(td, "Your surname: "));
			ti = new TextInput(td, "<Surname>", "Enter your surname here!");
			p2.Content.Add(ti);
			td.Content.Add(p2);
                       
			// test save/load
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "textinput.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                td.Load(AARunMeFirstAndOnce.outPutFolder + "textinput.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    td.Save(AARunMeFirstAndOnce.outPutFolder + "textinput2.odt", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description="A test to page numbers")]
		public void PageNumberTest()
		{
			TextDocument td = new TextDocument();
			td.New();
            
			Paragraph p1 = new Paragraph(td);
			p1.TextContent.Add(new SimpleText(td, "This is a current page number: "));
			PageNumber pn = new PageNumber(td);
			p1.Content.Add(pn);
			td.Content.Add(p1);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "page_number.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                td.Load(AARunMeFirstAndOnce.outPutFolder + "page_number.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    td.Save(AARunMeFirstAndOnce.outPutFolder + "page_number2.odt", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test(Description = "A test to check variable declarations")]
		public void VariableDeclTest()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();

			// Declare two variables
			VariableDecl vd = new VariableDecl(td, VariableValueType.String, "test");
			VariableDecl vd2 = new VariableDecl(td, VariableValueType.Float, "12.3");
			td.VariableDeclarations.Add(vd);
			td.VariableDeclarations.Add(vd2);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "vardecls.odt", new OpenDocumentTextExporter(writer));
            }

			TextDocument td2 = new TextDocument();
			
			// Reload the document and make some changes
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                td2.Load(AARunMeFirstAndOnce.outPutFolder + "vardecls.odt", new OpenDocumentImporter(reader));
                td2.VariableDeclarations[0].Name = "xyz";
                td2.VariableDeclarations.Add(new VariableDecl(td, VariableValueType.String, "test222"));

                // Unzip the document and check its content.xml file!
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    td2.Save(AARunMeFirstAndOnce.outPutFolder + "vardecls2.odt", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test(Description = "A test to check variable-set fields")]
		public void VariableSetTest()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
            
			// Create a variable declaration
			VariableDecl vd = new VariableDecl(td, VariableValueType.String, "test");
			td.VariableDeclarations.Add(vd);
			// add a variable-set field
			Paragraph p1 = new Paragraph(td);
			p1.Content.Add(new VariableSet(td, vd, "test variable-set"));
			td.Content.Add(p1);

			// saveload test
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "varset.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                td.Load(AARunMeFirstAndOnce.outPutFolder + "varset.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    td.Save(AARunMeFirstAndOnce.outPutFolder + "varset2.odt", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test(Description = "A test that checks connection between Fields property and Content")]
		public void ContentFieldsBindingTest()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
            
			// Create a variable declaration
			Paragraph p1 = new Paragraph(td);
			p1.TextContent.Add(new SimpleText(td, "Insert text here: "));
			Placeholder plch1 = new Placeholder(td, PlaceholderType.Text, "A text placeholder");
			plch1.Value = "Text";
			p1.Content.Add(plch1);
			td.Content.Add(p1);

			// Add paragraph 2 with a text-box placeholder in it
			Paragraph p2 = new Paragraph(td);
			p2.TextContent.Add(new SimpleText(td, "Insert text-box here: "));
			Placeholder plch2 = new Placeholder(td, PlaceholderType.TextBox, "A text-box placeholder");
			plch2.Value = "Text-Box";
			p2.Content.Add(plch2);
			td.Content.Add(p2);

			Placeholder placeholder = td.Fields[1] as Placeholder;
			Assert.IsNotNull(placeholder);
			placeholder.PlaceholderType = PlaceholderType.Table;
			placeholder.Value = "Now this is a table placeholder: ";

			td.Fields.RemoveAt(0);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "connection.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test(Description = "A test that checks connection between Fields property and Content")]
		public void ContentFieldsBindingTest2()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
            
			// Create a variable declaration
			Paragraph p1 = new Paragraph(td);
			p1.TextContent.Add(new SimpleText(td, "Insert text here: "));
			Placeholder plch1 = new Placeholder(td, PlaceholderType.Text, "A text placeholder");
			plch1.Value = "Text";
			p1.Content.Add(plch1);
			td.Content.Add(p1);

			// Add paragraph 2 with a text-box placeholder in it
			Paragraph p2 = new Paragraph(td);
			p2.TextContent.Add(new SimpleText(td, "Insert text-box here: "));
			Placeholder plch2 = new Placeholder(td, PlaceholderType.TextBox, "A text-box placeholder");
			plch2.Value = "Text-Box";
			p2.Content.Add(plch2);
			td.Content.Add(p2);

			p1.Content.Clear();
			p2.Content.Clear();

			// The Fields container should be empty!
			Console.WriteLine(td.Fields.Count);
		}

		[Test(Description = "A test that checks connection between Fields property and Content")]
		public void ContentFieldsBindingTest3()
		{
			// Create a new text document
			TextDocument td = new TextDocument();
			td.New();
            
			// Create a variable declaration
			Paragraph p1 = new Paragraph(td);
			p1.TextContent.Add(new SimpleText(td, "Insert text here: "));
			Placeholder plch1 = new Placeholder(td, PlaceholderType.Text, "A text placeholder");
			plch1.Value = "Text";
			p1.Content.Add(plch1);
			td.Content.Add(p1);

			// Add paragraph 2 with a text-box placeholder in it
			Paragraph p2 = new Paragraph(td);
			p2.TextContent.Add(new SimpleText(td, "Insert text-box here: "));
			Placeholder plch2 = new Placeholder(td, PlaceholderType.TextBox, "A text-box placeholder");
			plch2.Value = "Text-Box";
			p2.Content.Add(plch2);
			td.Content.Add(p2);
			
			
			Console.WriteLine("Before deleting there were {0} fields...", td.Fields.Count);
			td.Fields.Clear();

			// The document should not contain any fields!
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                td.Save(AARunMeFirstAndOnce.outPutFolder + "connection3.odt", new OpenDocumentTextExporter(writer));
            }
		}
	}


}
