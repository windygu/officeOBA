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

/*
 * initial Author: Kristy Saunders, ksaunders@eduworks.com
 */

using System;
using System.IO;
using System.Text;
using AODL.Document.Export.OpenDocument;
using AODL.Document.Import.OpenDocument;
using AODL.IO;
using NUnit.Framework;
using AODL.Document.TextDocuments;
using AODL.Document.Content.Text;
using AODL.Document.Content.Draw;
using AODL.Document.Styles;
using AODL.Document.Styles.Properties;
using AODL.Document.Content.OfficeEvents;

namespace AODLTest
{
	[TestFixture]
	public class FrameTest
	{
		private string _imagefile = Path.Combine(AARunMeFirstAndOnce.inPutFolder , "Eclipse_add_new_Class.jpg");
		private readonly string _framefile = AARunMeFirstAndOnce.outPutFolder + @"frame.odt";
		private readonly string _framefileSave = AARunMeFirstAndOnce.outPutFolder + @"frameSave.odt";
		private readonly string _framefile2 = AARunMeFirstAndOnce.outPutFolder + @"frame2.odt";
		private readonly string _framefile3 = AARunMeFirstAndOnce.outPutFolder + @"frame3.odt";

		[TestFixtureSetUp]
		public void Initialize()
		{
			// Used when running this text fixture alone.
//			if (Directory.Exists(AARunMeFirstAndOnce.outPutFolder))
//				Directory.Delete(AARunMeFirstAndOnce.outPutFolder, true);
//			Directory.CreateDirectory(AARunMeFirstAndOnce.outPutFolder);
		}

		[Test(Description="Write an image with image map to a frame")]
		public void FrameWriteTest()
		{
			TextDocument textdocument = new TextDocument();
			textdocument.New();

			// Create a frame incl. graphic file
			Frame frame					= FrameBuilder.BuildStandardGraphicFrame(
				textdocument, "frame1", "graphic1", new DiskFile(_imagefile));
			
			// Create some event listeners (using OpenOffice friendly syntax).
			EventListener script1 = new EventListener(textdocument,
			                                          "dom:mouseover", "javascript",
			                                          "vnd.sun.star.script:HelloWorld.helloworld.js?language=JavaScript&location=share");
			EventListener script2 = new EventListener(textdocument,
			                                          "dom:mouseout", "javascript",
			                                          "vnd.sun.star.script:HelloWorld.helloworld.js?language=JavaScript&location=share");
			EventListeners listeners = new EventListeners(textdocument, new EventListener[] { script1, script2 });
			
			// Create and add some area rectangles
			DrawAreaRectangle[] rects = new DrawAreaRectangle[2];
			rects[0] = new DrawAreaRectangle(textdocument, "4cm", "4cm", "2cm", "2cm");
			rects[0].Href = @"http://www.eduworks.com";
			rects[1] = new DrawAreaRectangle(textdocument, "1cm", "1cm", "2cm", "2cm", listeners);

			// Create and add an image map, referencing the area rectangles
			ImageMap map = new ImageMap(textdocument, rects);
			frame.Content.Add(map);

			// Add the frame to the text document
			textdocument.Content.Add(frame);

			// Save the document
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                textdocument.Save(_framefile3, new OpenDocumentTextExporter(writer));
            }
			textdocument.Dispose();
		}

		[Test(Description="Read back elements written by FrameWriteTest")]
		public void FrameTestRead()
		{
			TextDocument document = new TextDocument();
            using (IPackageReader reader = new OnDiskPackageReader())
            {
                document.Load(_framefile, new OpenDocumentImporter(reader));
                Assert.IsTrue(document.Content[1].GetType() == typeof (Frame));
                Frame frame = (Frame) document.Content[1];
                Assert.IsNotNull(frame);
                using (IPackageWriter writer = new OnDiskPackageWriter())
                {
                    document.Save(_framefileSave, new OpenDocumentTextExporter(writer));
                }
            }
		}

		[Test(Description="Write an image with image map; reuse event listeners")]
		public void EventListenerTest()
		{
			TextDocument textdocument = new TextDocument();
			textdocument.New();

			// Create a frame (GraphicName == name property of frame)
			Frame frame						= new Frame(textdocument, "frame1", "img1", new DiskFile(_imagefile));

			// Create some event listeners (using OpenOffice friendly syntax).
			EventListener script1 = new EventListener(textdocument,
			                                          "dom:mouseover", "javascript",
			                                          "vnd.sun.star.script:HelloWorld.helloworld.js?language=JavaScript&location=share");
			EventListener script2 = new EventListener(textdocument,
			                                          "dom:mouseout", "javascript",
			                                          "vnd.sun.star.script:HelloWorld.helloworld.js?language=JavaScript&location=share");
			EventListeners listeners = new EventListeners(textdocument, new EventListener[] { script1, script2 });

			// Create and add some area rectangles; reuse event listeners
			DrawAreaRectangle[] rects = new DrawAreaRectangle[2];
			rects[0] = new DrawAreaRectangle(textdocument, "4cm", "4cm", "2cm", "2cm", listeners);
			//Reuse a clone of the EventListener
			rects[1] = new DrawAreaRectangle(textdocument, "1cm", "1cm", "2cm", "2cm", (EventListeners)listeners.Clone());

			// Create and add an image map, referencing the area rectangles
			ImageMap map = new ImageMap(textdocument, rects);
			frame.Content.Add(map);

			// Add the frame to the text document
			textdocument.Content.Add(frame);

			// Save the document
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                textdocument.Save(_framefile, new OpenDocumentTextExporter(writer));
            }
			textdocument.Dispose();
		}

		[Test]
		public void DrawTextBox()
		{
			//New TextDocument
			TextDocument textdocument = new TextDocument();
			textdocument.New();
			//Standard Paragraph
			Paragraph paragraphOuter = new Paragraph(textdocument, ParentStyles.Standard.ToString());
			//Create Frame for DrawTextBox
			Frame frameOuter = new Frame(textdocument, "frame1");
			//Create DrawTextBox
			DrawTextBox drawTextBox = new DrawTextBox(textdocument);
			//Create a paragraph for the drawing frame
			Paragraph paragraphInner = new Paragraph(textdocument, ParentStyles.Standard.ToString());
			//Create the frame with the Illustration resp. Graphic
			Frame frameIllustration = new Frame(textdocument, "frame2", "graphic1", new DiskFile(_imagefile));
			//Add Illustration frame to the inner Paragraph
			paragraphInner.Content.Add(frameIllustration);
			//Add inner Paragraph to the DrawTextBox
			drawTextBox.Content.Add(paragraphInner);
			//Add the DrawTextBox to the outer Frame
			frameOuter.Content.Add(drawTextBox);
			//Add the outer Frame to the outer Paragraph
			paragraphOuter.Content.Add(frameOuter);
			//Add the outer Paragraph to the TextDocument
			textdocument.Content.Add(paragraphOuter);
			//Save the document
            using (IPackageWriter writer = new OnDiskPackageWriter())
            {
                textdocument.Save(_framefile2, new OpenDocumentTextExporter(writer));
            }
		}
	}
}

/*
 * $Log: FrameTest.cs,v $
 * Revision 1.3  2008/04/29 15:39:59  mt
 * new copyright header
 *
 * Revision 1.2  2007/08/15 11:53:17  larsbehr
 * - Optimized Mono related stuff
 *
 * Revision 1.1  2007/02/25 09:01:27  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.2  2006/02/21 19:34:54  larsbm
 * - Fixed Bug text that contains a xml tag will be imported  as UnknowText and not correct displayed if document is exported  as HTML.
 * - Fixed Bug [ 1436080 ] Common styles
 *
 * Revision 1.1  2006/02/02 21:55:59  larsbm
 * - Added Clone object support for many AODL object types
 * - New Importer implementation PlainTextImporter and CsvImporter
 * - New tests
 *
 */
