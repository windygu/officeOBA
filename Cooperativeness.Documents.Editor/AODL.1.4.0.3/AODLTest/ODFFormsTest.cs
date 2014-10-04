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
using System.Drawing;
using AODL.Document.Export.Html;
using AODL.Document.Export.OpenDocument;
using AODL.Document.Import.OpenDocument;
using AODL.IO;
using NUnit.Framework;
using System.Xml;
using AODL.Document.Content.Tables;
using AODL.Document;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.Styles.MasterStyles;
using AODL.Document.Forms;
using AODL.Document.Forms.Controls;
using AODL.Document.SpreadsheetDocuments;

namespace AODLTest
{
	[TestFixture]
	public class ODFFormsTest
	{
		[Test (Description = "A test to check ODFFrame functionality")]
		public void ODFFrameTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create a frame
			ODFFrame frm = new ODFFrame(main_form, p.Content, "frm", "5mm", "5mm", "5cm", "3cm");
			frm.Label = "ODFFrame test";
			// Add the frame to the form control list
			main_form.Controls.Add (frm);
			
			// Create a button
			ODFButton butt = new ODFButton(main_form, p.Content, "butt", "1cm", "15mm", "4cm", "1cm");
			butt.Label = "A simple button :)";
			// Add the button to the form control list
			main_form.Controls.Add (butt);

			// Add the forms to the document!
			document.Forms.Add(main_form);
			// Add the paragraph to the content list
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "frame_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "frame_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "frame_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check nested forms functionality")]
		public void NestedFormTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			ODFForm child_form = new ODFForm(document, "childform");

			main_form.Method = Method.Get;
			main_form.Method = Method.Get;
			
			// Create a frame
			ODFFrame frm = new ODFFrame(main_form, p.Content, "frm", "5mm", "5mm", "5cm", "3cm");
			frm.Label = "Main form";
			// Add the frame to the form control list
			main_form.Controls.Add (frm);
			
			// Create a button
			ODFButton butt = new ODFButton(main_form, p.Content, "butt", "1cm", "15mm", "4cm", "1cm");
			butt.Label = "This is a main form";
			// Add the button to the form control list
			main_form.Controls.Add (butt);

			// Add the forms to the main form!
			document.Forms.Add(main_form);
			// Add the paragraph to the content list
			document.Content.Add(p);

			
			// adding controls to the nested form
			ODFFrame frm_child = new ODFFrame(child_form, p.Content, "frm_child", "5mm", "35mm", "5cm", "3cm");
			frm_child.Label = "Child form";
			child_form.Controls.Add (frm_child);
			
			ODFButton butt_child = new ODFButton(child_form, p.Content, "butt_child", "1cm", "45mm", "4cm", "1cm");
			butt_child.Label = "This is a child form";
			child_form.Controls.Add (butt_child);
			main_form.ChildForms.Add(child_form);

			ODFButton b = document.FindControlById("butt_child") as ODFButton;
			Assert.IsNotNull(b, "Error! could not find the specified control");
			b.Label = "Child form:)";

			
			// Add the forms to the main form!
			document.Forms.Add(main_form);
            // Add the paragraph to the content list
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "nested_forms_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "nested_forms_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "nested_forms_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check ODFHidden functionality and form submissions")]
		public void ODFHiddenAndFormActionTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			// Create a main form
			
			// Create the first form (Method = GET)
			ODFForm form1 = new ODFForm(document, "form1");
			form1.Method = Method.Get;
			form1.Href = "http://foo.foo";
			
			// Create all the controls for form1
			ODFFrame frm1 = new ODFFrame(form1, p.Content, "frm1", "5mm", "5mm", "11cm", "3cm");
			frm1.Label = "Form submission test (Method = GET, Hidden name = hid)";
			form1.Controls.Add (frm1);
			ODFButton butt1 = new ODFButton(form1, p.Content, "butt1", "2cm", "15mm", "8cm", "1cm");
			butt1.Label = "Submit to foo.foo!";
			butt1.ButtonType = ButtonType.Submit;
			butt1.Name = "butt1";
			form1.Controls.Add (butt1);
			ODFHidden hid1 = new ODFHidden(form1, p.Content, "hid1", "0cm", "0cm", "0cm", "0cm");
			hid1.Value = "hello!";
			hid1.Name = "hid1";
			form1.Controls.Add(hid1);

			// Create the second form (Method = POST)
			ODFForm form2 = new ODFForm(document, "form2");
			form2.Method = Method.Post;
			form2.Href = "http://foo.foo.2";
			ODFFrame frm2 = new ODFFrame(form2, p.Content, "frm2", "5mm", "45mm", "11cm", "3cm");
			frm2.Label = "Form submission test (Method = POST, Hidden name = hid)";
			form2.Controls.Add (frm2);
			
			// Create all the controls for form2
			ODFButton butt2 = new ODFButton(form2, p.Content, "butt2", "2cm", "55mm", "8cm", "1cm");
			butt2.Label = "Submit to foo.foo!";
			butt2.ButtonType = ButtonType.Submit;
			butt2.Name = "butt2";
			form2.Controls.Add (butt2);
			ODFHidden hid2 = new ODFHidden(form2, p.Content, "hid2", "0cm", "0cm", "0cm", "0cm");
			hid2.Value = "hello!";
			hid2.Name = "hid2";
			form2.Controls.Add (hid2);

			document.Forms.Add(form1);
			document.Forms.Add(form2);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "hidden_subm_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "hidden_subm_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "hidden_subm_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check ODFButton functionality")]
		public void ODFButtonTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// The first button. It doesn't get a focus on click
			ODFButton butt = new ODFButton(main_form, p.Content, "butt1", "0cm", "0mm", "4cm", "1cm");
			butt.Label = "Button one";
			butt.Title = "First button.";
			butt.FocusOnClick = false;
			butt.ButtonType = ButtonType.Push;
			main_form.Controls.Add (butt);

			// The second button. It is disabled
			butt = new ODFButton(main_form, p.Content, "butt2", "0cm", "2cm", "4cm", "1cm");
			butt.Label = "Button two";
			butt.Title = "Second button.";
			butt.FocusOnClick = true;
			butt.Disabled = true;
			main_form.Controls.Add (butt);

			// The third button with "toggle" behaviour
			butt = new ODFButton(main_form, p.Content, "butt3", "0cm", "4cm", "4cm", "1cm");
			butt.Label = "Button three";
			butt.Title = "Third button.";
			butt.Toggle = true;
			main_form.Controls.Add (butt);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Button import/export test
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "button_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "button_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "button_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check ODFCheckBox functionality")]
		public void ODFCheckBoxTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			ODFCheckBox cb = new ODFCheckBox(main_form, p.Content, "cb1", "0cm", "0mm", "4cm", "5mm");
			cb.Label = "Checkbox 1 (flat)";
			cb.VisualEffect = VisualEffect.Flat;
			cb.IsTristate = true;
			cb.Value = "some_value";
			cb.Title = "The first checkbox";
			main_form.Controls.Add(cb);

			cb = new ODFCheckBox(main_form, p.Content, "cb2", "0cm", "5mm", "4cm", "5mm");
			cb.Label = "Checkbox 2 (3d)";
			cb.VisualEffect = VisualEffect.ThreeD;
			cb.IsTristate = false;
			cb.Value = "some_value_number_two";
			cb.Title = "The second checkbox";
			cb.CurrentState = State.Checked;
			main_form.Controls.Add(cb);

			cb = new ODFCheckBox(main_form, p.Content, "cb3", "0cm", "10mm", "4cm", "5mm");
			cb.Label = "Checkbox 3 (grayed)";
			cb.VisualEffect = VisualEffect.Flat;
			cb.IsTristate = true;
			cb.Value = "some_value_three";
			cb.Title = "The third checkbox";
			cb.CurrentState = State.Unknown;
			main_form.Controls.Add(cb);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Button import/export test
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "checkbox_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "checkbox_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "checkbox_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check ODFRadioButton functionality")]
		public void ODFRadioButtonTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create two radio buttons with the same name - they will be in one "group"
			ODFRadioButton rb = new ODFRadioButton(main_form, p.Content, "rb1", "0cm", "0mm", "4cm", "5mm");
			rb.Label = "Radio Button One";
			rb.VisualEffect = VisualEffect.Flat;
			rb.CurrentSelected = true;
			rb.Name = "radio";
			main_form.Controls.Add(rb);

			rb = new ODFRadioButton(main_form, p.Content, "rb2", "0cm", "1cm", "4cm", "5mm");
			rb.Label = "Radio Button Two";
			rb.VisualEffect = VisualEffect.ThreeD;
			rb.CurrentSelected = false;
			rb.Name = "radio";
			main_form.Controls.Add(rb);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Button import/export test
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "radio_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "radio_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "radio_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check ODFComboBox functionality")]
		public void ODFComboBoxTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create a first combo box - a drop down one 
			ODFComboBox cb = new ODFComboBox(main_form, p.Content, "cb1", "0cm", "0mm", "4cm", "6mm");
			cb.AutoComplete = true;
			cb.DropDown = true;
			cb.Title = "A test combobox number one";
			cb.Items.Add(new ODFItem(document, "Bill"));
			cb.Items.Add(new ODFItem(document, "Gates"));
			cb.Items.Add(new ODFItem(document, "Melinda"));
			cb.Items.Add(new ODFItem(document, "Gilbert"));
			cb.Items.Add(new ODFItem(document, "Bates"));
			cb.CurrentValue = "Select an item...";
			main_form.Controls.Add(cb);

			// Second combo box
			cb = new ODFComboBox(main_form, p.Content, "cb2", "0cm", "10mm", "4cm", "25mm");
			cb.AutoComplete = false;
			cb.DropDown = false;
			cb.CurrentValue = "Alt";
			cb.Title = "A test combobox number two";
			cb.Items.Add(new ODFItem(document, "Control"));
			cb.Items.Add(new ODFItem(document, "Alt"));
			cb.Items.Add(new ODFItem(document, "Delete"));
			cb.Items.Add(new ODFItem(document, "Enter"));
			cb.Items.Add(new ODFItem(document, "Escape"));
			main_form.Controls.Add(cb);


			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Button import/export test
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "combobox_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "combobox_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "combobox_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check ODFListBox functionality")]
		public void ODFListBoxTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			ODFListBox lb = new ODFListBox(main_form, p.Content, "lb1", "0cm", "0mm", "4cm", "6mm");
			lb.DropDown = true;
			lb.Title = "A test listbox number one";
			lb.Options.Add(new ODFOption(document, "Bill"));
			lb.Options.Add(new ODFOption(document, "Gates"));
			lb.Options.Add(new ODFOption(document, "Melinda"));
			lb.Options.Add(new ODFOption(document, "Bates"));
			lb.Options.Add(new ODFOption(document, "Gilbert"));
			main_form.Controls.Add(lb);

			lb = new ODFListBox(main_form, p.Content, "lb2", "0cm", "10mm", "4cm", "25mm");
			lb.DropDown = false;
			lb.Title = "A test listbox number two";
			lb.Options.Add(new ODFOption(document, "Bill"));
			lb.Options.Add(new ODFOption(document, "Gates"));
			lb.Options.Add(new ODFOption(document, "Melinda"));
			lb.Options.Add(new ODFOption(document, "Bates"));
			lb.Options.Add(new ODFOption(document, "Gilbert"));
			main_form.Controls.Add(lb);


			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Button import/export test
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "listbox_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "listbox_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "listbox_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test for ODFFile control")]
		public void ODFFileTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create an ODFFile
			ODFFile file= new ODFFile(main_form, p.Content, "file", "5mm", "5mm", "5cm", "1cm");
			file.Title = "File control";
			// This control will not be printable!
			file.Printable = false;
			main_form.Controls.Add (file);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "file_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "file_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "file_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test for ODFFixedText control")]
		public void ODFFixedTextTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create three different pieces of text at different positions
			ODFFixedText ft= new ODFFixedText(main_form, p.Content, "ft1", "5mm", "5mm", "5cm", "1cm");
			ft.Label = "Fixed text one";
			ft.Disabled = true;
			main_form.Controls.Add (ft);

			ft= new ODFFixedText(main_form, p.Content, "ft2", "15mm", "25mm", "5cm", "1cm");
			ft.Label = "Fixed text two";
			main_form.Controls.Add (ft);

			ft= new ODFFixedText(main_form, p.Content, "ft3", "35mm", "15mm", "5cm", "1cm");
			ft.Label = "Fixed text three";
			main_form.Controls.Add (ft);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "fixedtext_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "fixedtext_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "fixedtext_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test for ODFFormattedText control")]
		public void ODFFormattedTextTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create the formatted text control. Possible value range is 0-100
			ODFFormattedText ft= new ODFFormattedText(main_form, p.Content, "ft1", "5mm", "5mm", "5cm", "1cm");
			ft.MaxValue = 100;
			ft.MinValue = 0;
			ft.Validation = true;
			ft.Title = "A very good FT control";
			ft.Name = "formatted_text";
			main_form.Controls.Add (ft);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "formatted_text_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "formatted_text_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "formatted_text_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test for ODFTextArea control")]
		public void ODFTextAreaTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create the text area control
			ODFTextArea ta= new ODFTextArea(main_form, p.Content, "ft1", "5mm", "5mm", "7cm", "4cm");
			ta.Title = "Some text area";
			main_form.Controls.Add (ta);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "textarea_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "textarea_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "textarea_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test for ODFValueRange control")]
		public void ODFValueRangeTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create the ODFValueRange as a scroll bar(see the contol implementation)
			ODFValueRange vr= new ODFValueRange(main_form, p.Content, "vr1", "5mm", "5mm", "7cm", "5mm");
			vr.ControlImplementation = "ooo:com.sun.star.form.component.ScrollBar";
			vr.Orientation = Orientation.Horizontal;
			vr.RepeatDelay = "PT0.50S";
			vr.MinValue = 0;
			vr.MaxValue = 100;
            vr.Title = "A scroll bar";
			vr.Properties.Add(new SingleFormProperty(document, PropertyValueType.Boolean, "LiveScroll", "true"));
			main_form.Controls.Add (vr);

			// Create the ODFValueRange as a spin button(see the contol implementation)
			vr= new ODFValueRange(main_form, p.Content, "vr2", "5mm", "2cm", "8mm", "15mm");
			vr.ControlImplementation = "ooo:com.sun.star.form.component.SpinButton";
			vr.Orientation = Orientation.Vertical;
			vr.RepeatDelay = "PT0.50S";
			vr.MinValue = 0;
			vr.MaxValue = 100;
			vr.Title = "A scroll bar";
			main_form.Controls.Add (vr);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "valuerange_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "valuerange_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "valuerange_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}


		[Test (Description = "A test for Grid control")]
		public void ODFGridTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create an ODFGrid
			ODFGrid grd = new ODFGrid(main_form, p.Content, "grd", "5mm", "5mm", "7cm", "5cm");
			grd.Columns.Add(new ODFGridColumn(document, "col1", "One"));
			grd.Columns.Add(new ODFGridColumn(document, "col1", "Two"));
			grd.Columns.Add(new ODFGridColumn(document, "col1", "Three"));
			main_form.Controls.Add (grd);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "grid_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "grid_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "grid_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test for ODFImage control")]
		public void ODFImageTest()
		{
			//Create a new text document
			TextDocument document = new TextDocument();
			document.New();
			
			// Create a new paragraph
			Paragraph p =new Paragraph(document);
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// Create an ODFGrid
			ODFImage img = new ODFImage(main_form, p.Content, "grd", "5mm", "5mm", "10cm", "6cm");
			img.ImageData = AARunMeFirstAndOnce.inPutFolder+"Eclipse_add_new_Class.jpg";
			main_form.Controls.Add (img);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "image_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "image_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "image_test2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
		}


		[Test(Description="A test to check import/export to ODT")]
		public void SaveLoadTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			Paragraph p =new Paragraph(document);
			p.StyleName = "Standard";
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			ODFFrame frm = new ODFFrame(main_form, p.Content, "frm", "5mm", "5mm", "5cm", "3cm");
			frm.Label = "Save and Load test";
			main_form.Controls.Add (frm);
			
			ODFButton butt = new ODFButton(main_form, p.Content, "butt", "1cm", "15mm", "4cm", "1cm");
			butt.Label = "A simple button :)";
			main_form.Controls.Add (butt);

			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "saveload.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "saveload.odt", new OpenDocumentImporter(reader));
                ODFButton bt = document.FindControlById("butt") as ODFButton;
                Assert.IsNotNull(bt, "Could not find control with >butt< ID");
                bt.Label = "This label has chanhed";
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "saveload2.odt",
                                  new OpenDocumentTextExporter(writer));
                }
            }
			
		}

		[Test(Description="A test to check listbox and combobox implementation")]
		public void ODFListBoxAndComboBoxTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			Paragraph p =new Paragraph(document);
			p.StyleName = "Standard";
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			ODFFrame frm = new ODFFrame(main_form, p.Content, "frm", "5mm", "5mm", "5cm", "7cm");
			frm.Label = "List- and ComboBox test";
			main_form.Controls.Add (frm);
			
			ODFListBox lb = new ODFListBox(main_form, p.Content, "lb", "1cm", "15mm", "4cm", "5cm");
			lb.Options.Add(new ODFOption(document, "Charlie"));
			lb.Options.Add(new ODFOption(document, "John"));
			lb.Options.Add(new ODFOption(document, "Dieter"));
			lb.Options.Add(new ODFOption(document, "Bill"));
			lb.Options.Add(new ODFOption(document, "Oleg"));
			lb.Options.Add(new ODFOption(document, "Lars"));
			main_form.Controls.Add (lb);

			ODFComboBox cb = new ODFComboBox(main_form, p.Content, "cb", "1cm", "65mm", "4cm", "6mm");
			cb.Items.Add(new ODFItem(document, "Charlie"));
			cb.Items.Add(new ODFItem(document, "John"));
			cb.Items.Add(new ODFItem(document, "Dieter"));
			cb.Items.Add(new ODFItem(document, "Bill"));
			cb.Items.Add(new ODFItem(document, "Oleg"));
			cb.Items.Add(new ODFItem(document, "Lars"));
			cb.CurrentValue = "Please select a value...";
			cb.DropDown = true;

			main_form.Controls.Add (cb);

			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "listbox_combobox.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test(Description="Generic properties test")]
		public void GenericPropertiesTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			Paragraph p =new Paragraph(document);
			p.StyleName = "Standard";
			ODFForm main_form = new ODFForm(document, "mainform");
			
			// add form:properties to the form
			main_form.Properties.Add(new SingleFormProperty(document, PropertyValueType.String, "name", "Oleg Yegorov"));
			main_form.Properties.Add(new SingleFormProperty(document, PropertyValueType.String, "comment", "ODF rulezz!"));
			main_form.Properties.Add(new SingleFormProperty(document, PropertyValueType.Boolean, "some_bool_value", "true"));
			// please check content.xml file to see that they were really added :)

			main_form.Method = Method.Get;
			ODFFrame frm = new ODFFrame(main_form, p.Content, "frm", "5mm", "5mm", "5cm", "7cm");
			frm.Label = "Generic properties test.";
			main_form.Controls.Add (frm);
			
			document.Forms.Add(main_form);
			document.Content.Add(p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "generic_prop.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test(Description="HTML export test")]
		public void HTMLExportTest()
		{
			//Create a new text document
			TextDocument document					= new TextDocument();
			document.New();
			
			Paragraph p =new Paragraph(document);
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			main_form.Href="http://hello.foo.com";
			
			ODFComboBox	ccb = new ODFComboBox(main_form, p.Content, "ccb", "0mm", "0mm", "3cm", "1cm");
			ccb.Size = 5;
			ccb.DropDown = true;
			ccb.Items.Add(new ODFItem(document, "Charlie"));
			ccb.Items.Add(new ODFItem(document, "John"));
			ccb.Items.Add(new ODFItem(document, "Dieter"));
			ccb.Items.Add(new ODFItem(document, "Bill"));
			ccb.Items.Add(new ODFItem(document, "Oleg"));
			ccb.Items.Add(new ODFItem(document, "Lars"));
			main_form.Controls.Add (ccb);
			
			ODFButton butt = new ODFButton(main_form, p.Content, "butt", "5mm", "15mm", "4cm", "1cm");
			butt.Label = "A simple button :)";
			main_form.Controls.Add (butt);

			ODFCheckBox cb = new ODFCheckBox(main_form, p.Content, "cbx", "5mm", "25mm", "4cm", "5mm");
			cb.Label = "check it!";
			cb.Name = "cbx";
			cb.Value = "cbx_value";
			
			main_form.Controls.Add (cb);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			Paragraph text_p = new Paragraph(document);
			text_p.TextContent.Add(new SimpleText(document, "This is a simple text content that is located in the next paragraph after the form!"));
			document.Content.Add(text_p);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "html_test.odt", new OpenDocumentTextExporter(writer));
            }
            document.Save(AARunMeFirstAndOnce.outPutFolder + "html_test.html", new OpenDocumentHtmlExporter());
		}

		[Test(Description="Test for forms support in spreadsheet documents"),
		 IgnoreAttribute("Form support in spreadsheet documents is suppressed" +
		                 " at the moment")]
		public void SpreadSheetFormsTest()
		{
			//Create new spreadsheet document
			SpreadsheetDocument spreadsheetDocument		= new SpreadsheetDocument();
			spreadsheetDocument.New();
			//Create a new table
			Table table					= new Table(spreadsheetDocument, "First", "tablefirst");
			//Create a new cell, without any extra styles 
			Cell cell								= new Cell(spreadsheetDocument, "cell001");
			cell.OfficeValueType					= "string";
			//Set full border
			cell.CellStyle.CellProperties.Border	= Border.NormalSolid;			
			//Add a paragraph to this cell
			Paragraph paragraph						= ParagraphBuilder.CreateSpreadsheetParagraph(
				spreadsheetDocument);
			//Add some text content
			paragraph.TextContent.Add(new SimpleText(spreadsheetDocument, "Some text"));
			//Add paragraph to the cell
			cell.Content.Add(paragraph);
			//Insert the cell at row index 2 and column index 3
			//All need rows, columns and cells below the given
			//indexes will be build automatically.
			table.Rows.Add(new Row(table, "Standard"));
			table.Rows.Add(new Row(table, "Standard"));
			table.Rows.Add(new Row(table, "Standard"));
			table.InsertCellAt(3, 2, cell);
			//Insert table into the spreadsheet document
			
			ODFForm main_form = new ODFForm(spreadsheetDocument, "mainform");
			main_form.Method = Method.Get;
			ODFButton butt = new ODFButton(main_form, cell.Content, "butt", "0cm", "0cm", "15mm", "8mm");
			butt.Label = "test :)";
			main_form.Controls.Add (butt);
			spreadsheetDocument.TableCollection.Add(table);
			table.Forms.Add(main_form);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                spreadsheetDocument.Save(AARunMeFirstAndOnce.outPutFolder + "spreadsheet_forms.ods", new OpenDocumentTextExporter(writer));
            }

			SpreadsheetDocument spreadsheetDocument2		= new SpreadsheetDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                spreadsheetDocument2.Load(AARunMeFirstAndOnce.outPutFolder + "spreadsheet_forms.ods",
                                          new OpenDocumentImporter(reader));

                ODFButton b = spreadsheetDocument2.TableCollection[0].FindControlById("butt") as ODFButton;
                Assert.IsNotNull(b);
                b.Label = "it works!";
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    spreadsheetDocument2.Save(AARunMeFirstAndOnce.outPutFolder + "spreadsheet_forms2.ods",
                                              new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test(Description="Test for spreadsheet import/export")]
		public void SpreadSheetImportExportTest()
		{
			//Create new spreadsheet document
			SpreadsheetDocument spreadsheetDocument		= new SpreadsheetDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                spreadsheetDocument.Load(AARunMeFirstAndOnce.inPutFolder + @"bigtable.ods",
                                         new OpenDocumentImporter(reader));
                ODFForm f = new ODFForm(spreadsheetDocument, "mainform");
                ODFButton butt = new ODFButton(f, spreadsheetDocument.TableCollection[0].Rows[1].Cells[1].Content,
                                               "butt", "5mm", "15mm", "4cm", "1cm");
                f.Controls.Add(butt);
                spreadsheetDocument.TableCollection[0].Forms.Add(f);
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    spreadsheetDocument.Save(AARunMeFirstAndOnce.outPutFolder + "bigtable2.ods", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "Tests style support in the Forms implementation")]
		public void StyleTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			
			ParagraphStyle ps1 = new ParagraphStyle(document, "style1");
			ps1.Family = "paragraph";
			ps1.TextProperties.FontName = FontFamilies.Arial;
			ps1.TextProperties.FontColor = GetColor(System.Drawing.Color.Blue);
			ps1.TextProperties.Bold = "bold";
			ps1.TextProperties.FontSize = "18pt";
			document.Styles.Add(ps1);
			
			ParagraphStyle ps2 = new ParagraphStyle(document, "style2");
			ps2.Family = "paragraph";
			ps2.TextProperties.FontName = FontFamilies.CourierNew;
			ps2.TextProperties.Italic = "italic";
			ps2.TextProperties.FontSize = "14pt";
			ps2.TextProperties.Underline = "dotted";
			document.Styles.Add(ps2);

			ParagraphStyle ps3 = new ParagraphStyle(document, "style3");
			ps3.Family = "paragraph";
			ps3.TextProperties.FontName = FontFamilies.Wingdings;
			ps3.TextProperties.FontColor = GetColor(System.Drawing.Color.Red);
			ps3.TextProperties.FontSize = "16pt";
			document.Styles.Add(ps3);

			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// The first button. It doesn't get a focus on click
			ODFButton butt = new ODFButton(main_form, p.Content, "butt1", "0cm", "0mm", "7cm", "1cm");
			butt.TextStyle = ps1;
			butt.Label = "Button one";
			butt.Title = "This button uses Arial font.";
			butt.FocusOnClick = false;
			butt.ButtonType = ButtonType.Push;
			main_form.Controls.Add (butt);

			// The second button. It is disabled
			butt = new ODFButton(main_form, p.Content, "butt2", "0cm", "2cm", "7cm", "1cm");
			butt.Label = "Button two";
			butt.Title = "Second button.";
			butt.FocusOnClick = true;
			butt.Disabled = true;
			butt.TextStyle = ps2;
			main_form.Controls.Add (butt);

			// The third button with "toggle" behaviour
			butt = new ODFButton(main_form, p.Content, "butt3", "0cm", "4cm", "7cm", "1cm");
			butt.Label = "Button three";
			butt.Title = "Third button.";
			butt.Toggle = true;
			butt.TextStyle = ps3;
			main_form.Controls.Add (butt);


			
			document.Forms.Add(main_form);
			document.Content.Add(p);


            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "style_test.odt", new OpenDocumentTextExporter(writer));
            }
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(AARunMeFirstAndOnce.outPutFolder + "style_test.odt", new OpenDocumentImporter(reader));
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(AARunMeFirstAndOnce.outPutFolder + "style_test2.odt", new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test (Description = "A test to check if the Controls collection can be cleared correctly")]
		public void ControlsClearTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			p.TextContent.Add(new SimpleText(document, "This document should contain no controls!"));
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
            // The first button. It doesn't get a focus on click
			ODFButton butt = new ODFButton(main_form, p.Content, "butt1", "0cm", "0mm", "4cm", "1cm");
			butt.Label = "Button one";
			butt.Title = "First button.";
			butt.FocusOnClick = false;
			butt.ButtonType = ButtonType.Push;
			main_form.Controls.Add (butt);

			// The second button. It is disabled
			butt = new ODFButton(main_form, p.Content, "butt2", "0cm", "2cm", "4cm", "1cm");
			butt.Label = "Button two";
			butt.Title = "Second button.";
			butt.FocusOnClick = true;
			butt.Disabled = true;
			main_form.Controls.Add (butt);

			// The third button with "toggle" behaviour
			butt = new ODFButton(main_form, p.Content, "butt3", "0cm", "4cm", "4cm", "1cm");
			butt.Label = "Button three";
			butt.Title = "Third button.";
			butt.Toggle = true;
			main_form.Controls.Add (butt);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			//// Clear ALL the controls in the form
			document.Forms[0].Controls.Clear();

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "no_controls.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test (Description = "A test to check if the Forms collection can be cleared correctly")]
		public void FormsClearTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			p.TextContent.Add(new SimpleText(document, "This document should contain no forms!"));
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// The first button. It doesn't get a focus on click
			ODFButton butt = new ODFButton(main_form, p.Content, "butt1", "0cm", "0mm", "4cm", "1cm");
			butt.Label = "Button one";
			butt.Title = "First button.";
			butt.FocusOnClick = false;
			butt.ButtonType = ButtonType.Push;
			main_form.Controls.Add (butt);

			// The second button. It is disabled
			butt = new ODFButton(main_form, p.Content, "butt2", "0cm", "2cm", "4cm", "1cm");
			butt.Label = "Button two";
			butt.Title = "Second button.";
			butt.FocusOnClick = true;
			butt.Disabled = true;
			main_form.Controls.Add (butt);

			// The third button with "toggle" behaviour
			butt = new ODFButton(main_form, p.Content, "butt3", "0cm", "4cm", "4cm", "1cm");
			butt.Label = "Button three";
			butt.Title = "Third button.";
			butt.Toggle = true;
			main_form.Controls.Add (butt);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Clear all the forms within the document!
			document.Forms.Clear();

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "no_forms.odt", new OpenDocumentTextExporter(writer));
            }
		}

		[Test (Description = "A test to check if the Forms collection elements can be removed correctly")]
		public void FormsRemoveTest()
		{
			// Create a new document
			TextDocument document	= new TextDocument();
			document.New();
			
			// Create a main paragraph
			Paragraph p =new Paragraph(document);
			p.TextContent.Add(new SimpleText(document, "This document should contain no forms!"));
			
			// Create a main form
			ODFForm main_form = new ODFForm(document, "mainform");
			main_form.Method = Method.Get;
			
			// The first button. It doesn't get a focus on click
			ODFButton butt = new ODFButton(main_form, p.Content, "butt1", "0cm", "0mm", "4cm", "1cm");
			butt.Label = "Button one";
			butt.Title = "First button.";
			butt.FocusOnClick = false;
			butt.ButtonType = ButtonType.Push;
			main_form.Controls.Add (butt);

			// The second button. It is disabled
			butt = new ODFButton(main_form, p.Content, "butt2", "0cm", "2cm", "4cm", "1cm");
			butt.Label = "Button two";
			butt.Title = "Second button.";
			butt.FocusOnClick = true;
			butt.Disabled = true;
			main_form.Controls.Add (butt);

			// The third button with "toggle" behaviour
			butt = new ODFButton(main_form, p.Content, "butt3", "0cm", "4cm", "4cm", "1cm");
			butt.Label = "Button three";
			butt.Title = "Third button.";
			butt.Toggle = true;
			main_form.Controls.Add (butt);

			document.Forms.Add(main_form);
			document.Content.Add(p);

			// Remove the form from the document!
			document.Forms.RemoveAt(0);

            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                document.Save(AARunMeFirstAndOnce.outPutFolder + "no_forms.odt", new OpenDocumentTextExporter(writer));
            }
		}

        private static string GetColor(Color color)
        {
            int argb = color.ToArgb();

            return "#" + argb.ToString("x").Substring(2);
        }
	}
}
