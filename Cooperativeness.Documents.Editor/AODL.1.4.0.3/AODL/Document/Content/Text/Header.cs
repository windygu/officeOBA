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
using System.Linq;
using System.Xml.Linq;
using AODL.Document.Import.OpenDocument.NodeProcessors;
using AODL.Document.Styles;
using AODL.Document.TextDocuments;

namespace AODL.Document.Content.Text
{
    /// <summary>
    /// Header represent a header.
    /// </summary>
    public class Header : IContent, IHtml, ITextContainer, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="heading">The heading.</param>
        public Header(IDocument document, Headings heading)
        {
            Document = document;
            Node = new XElement(Ns.Text + "h");
            StyleName = GetHeading(heading);
            InitStandards();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        /// <param name="headernode">The headernode.</param>
        /// <param name="document">The document.</param>
        public Header(XElement headernode, IDocument document)
        {
            Document = document;
            Node = headernode;
            InitStandards();
        }

        /// <summary>
        /// Gets or sets the out line level.
        /// e.g
        /// start header = "1"
        /// some paragraphs here
        /// subheader	 = "2"
        /// some paragraphs here
        /// start header = "1"
        /// will result in:
        /// 1. a header
        /// some text
        /// 1.1 a subheader
        /// some text
        /// 2. a header
        /// </summary>
        /// <value>The out line level.</value>
        public string OutLineLevel
        {
            get { return (string) Node.Attribute(Ns.Text + "outline-level"); }
            set { Node.SetAttributeValue(Ns.Text + "outline-level", value); }
        }

        /// <summary>
        /// Inits the standards.
        /// </summary>
        private void InitStandards()
        {
            TextContent = new ITextCollection();

            TextContent.Inserted += TextContent_Inserted;
            TextContent.Removed += TextContent_Removed;
        }

        /// <summary>
        /// Gets the heading.
        /// </summary>
        /// <param name="heading">The heading.</param>
        /// <returns>The heading stylename</returns>
        private static string GetHeading(Headings heading)
        {
            if (heading == Headings.Heading)
                return "Heading";
            if (heading == Headings.Heading_20_1)
                return "Heading_20_1";
            if (heading == Headings.Heading_20_2)
                return "Heading_20_2";
            if (heading == Headings.Heading_20_3)
                return "Heading_20_3";
            if (heading == Headings.Heading_20_4)
                return "Heading_20_4";
            if (heading == Headings.Heading_20_5)
                return "Heading_20_5";
            if (heading == Headings.Heading_20_6)
                return "Heading_20_6";
            if (heading == Headings.Heading_20_7)
                return "Heading_20_7";
            if (heading == Headings.Heading_20_8)
                return "Heading_20_8";
            if (heading == Headings.Heading_20_9)
                return "Heading_20_9";
            if (heading == Headings.Heading_20_10)
                return "Heading_20_10";
            return "Heading";
        }

        /// <summary>
        /// Append the xml from added IText object.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void TextContent_Inserted(int index, object value)
        {
            Node.Add(((IText) value).Node);

            if (((IText) value).Text != null)
            {
                try
                {
                    if (Document is TextDocument)
                    {
                        string text = ((IText) value).Text;
                        Document.DocumentMetadata.CharacterCount += text.Length;
                        string[] words = text.Split(' ');
                        Document.DocumentMetadata.WordCount += words.Length;
                    }
                }
                catch (Exception)
                {
                    //unhandled, only word and character count wouldn' be correct
                }
            }
        }

        /// <summary>
        /// Texts the content_ removed.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private static void TextContent_Removed(int index, object value)
        {
            ((IText) value).Node.Remove();
        }

        #region IHtml Member

        /// <summary>
        /// Return the content as Html string
        /// </summary>
        /// <returns>The html string</returns>
        public string GetHtml()
        {
            try
            {
                string html = GetAnchor() + "<p ";
                string style = GetHtmlStyle(StyleName);

                if (style.Length > 0)
                    html += style;
                html += ">\n";

                //Check numbering
                string number = GetHeadingNumber();
                if (number.Length > 0)
                    html += number + "&nbsp;&nbsp;";

                foreach (IText itext in TextContent)
                    if (itext is IHtml)
                        html += ((IHtml) itext).GetHtml();

                html += "</p>\n";

                return html;
            }
            catch (Exception)
            {
            }

            return "";
        }

        /// <summary>
        /// Gets the HTML style.
        /// </summary>
        /// <param name="headingname">The headingname.</param>
        /// <returns>The css style element</returns>
        private string GetHtmlStyle(string headingname)
        {
            try
            {
                string style = "style=\"margin-left: 0.5cm; margin-top: 0.5cm; margin-bottom: 0.5cm; ";
                string fontname = "";
                string fontsize = "";
                string bold = "";
                string italic = "";

                if (Document is TextDocument)
                {
                    TextDocument doc = (TextDocument) Document;
                    XElement stylenode = doc.DocumentStyles.Styles.Descendants(Ns.Style + "style")
                        .Where(
                        e =>
                        headingname.Equals((string) e.Attribute(Ns.Style + "name"), StringComparison.InvariantCulture))
                        .FirstOrDefault();
                    XElement propertynode = null;

                    if (stylenode != null)
                        propertynode = stylenode.Element(Ns.Style + "text-properties");

                    if (propertynode != null)
                    {
                        string attribute = (string) propertynode.Attribute(Ns.Fo + "font-name");
                        if (attribute != null)
                            fontname = string.Format("font-family:{0}; ", attribute);

                        attribute = (string) propertynode.Attribute(Ns.Fo + "font-size");
                        if (attribute != null)
                            fontsize = string.Format("font-size:{0}; ", attribute);

                        if (propertynode.ToString().IndexOf("bold") != -1)
                            bold = "font-weight: bold; ";

                        if (propertynode.ToString().IndexOf("italic") != -1)
                            italic = "font-style: italic; ";
                    }

                    if (fontname.Length > 0)
                        style += fontname;
                    if (fontsize.Length > 0)
                        style += fontsize;
                    if (bold.Length > 0)
                        style += bold;
                    if (italic.Length > 0)
                        style += italic;

                    if (style.EndsWith(" "))
                        style += "\"";
                    else
                        style = "";

                    return style;
                }
            }
            catch (Exception ex)
            {
                string exs = ex.Message;
            }

            return "";
        }

        /// <summary>
        /// Gets the html anchor, if the document use a table of contents
        /// </summary>
        /// <returns></returns>
        private static string GetAnchor()
        {
            const string anchor = "";

//			try
//			{
//				if (this.Document.TableofContentsCount > 0)
//				{
//					anchor		+= "<a name=\"";
//					anchor		+= this.Node.InnerText;
//					anchor		+= "\"> </a>\n";
//				}
//			}
//			catch(Exception ex)
//			{
//			}

            return anchor;
        }

        /// <summary>
        /// Gets the heading number, if used via Outline-Level.
        /// Support for outline numbering up to deepth of 6, yet.
        /// </summary>
        /// <returns>The number string.</returns>
        private string GetHeadingNumber()
        {
            try
            {
                int outline1 = 0;
                int outline2 = 0;
                int outline3 = 0;
                int outline4 = 0;
                int outline5 = 0;
                int outline6 = 0;

                foreach (IContent content in Document.Content)
                    if (content is Header)
                        if (((Header) content).OutLineLevel != null)
                        {
                            int no = Convert.ToInt32(((Header) content).OutLineLevel);
                            if (no == 1)
                            {
                                outline1++;
                                outline2 = 0;
                                outline3 = 0;
                                outline4 = 0;
                                outline5 = 0;
                                outline6 = 0;
                            }
                            else if (no == 2)
                                outline2++;
                            else if (no == 3)
                                outline3++;
                            else if (no == 4)
                                outline4++;
                            else if (no == 5)
                                outline5++;
                            else if (no == 6)
                                outline6++;

                            if (content == this)
                            {
                                string sNumber = string.Format("{0}.", outline1);
                                string sNumber1 = "";
                                if (outline6 != 0)
                                    sNumber1 = string.Format(".{0}.", outline6);
                                if (outline5 != 0)
                                    sNumber1 = string.Format("{0}.{1}.", sNumber1, outline5);
                                if (outline4 != 0)
                                    sNumber1 = string.Format("{0}.{1}.", sNumber1, outline4);
                                if (outline3 != 0)
                                    sNumber1 = string.Format("{0}.{1}.", sNumber1, outline3);
                                if (outline2 != 0)
                                    sNumber1 = string.Format("{0}.{1}.", sNumber1, outline2);

                                sNumber += sNumber1;

                                return sNumber.Replace("..", ".");
                            }
                        }
            }
            catch (Exception)
            {
                //unhandled, only the numbering will maybe incorrect
            }
            return "";
        }

        #endregion

        #region ITextContainer Member

        private ITextCollection _textContent;

        /// <summary>
        /// All Content objects have a Text container. Which represents
        /// his Text this could be SimpleText, FormatedText or mixed.
        /// </summary>
        /// <value></value>
        public ITextCollection TextContent
        {
            get { return _textContent; }
            set
            {
                if (_textContent != null)
                    foreach (IText text in _textContent)
                        text.Node.Remove();

                _textContent = value;

                if (_textContent != null)
                    foreach (IText text in _textContent)
                        Node.Add(text.Node);
            }
        }

        #endregion

        #region ICloneable Member

        /// <summary>
        /// Create a deep clone of this Header object.
        /// </summary>
        /// <remarks>A possible Attached Style wouldn't be cloned!</remarks>
        /// <returns>
        /// A clone of this object.
        /// </returns>
        public object Clone()
        {
            Header headerClone = null;

            if (Document != null && Node != null)
            {
                MainContentProcessor mcp = new MainContentProcessor(Document);
                headerClone = mcp.CreateHeader(new XElement(Node));
            }

            return headerClone;
        }

        #endregion

        #region IContent Member

        private IStyle _style;

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        public XElement Node { get; set; }

        /// <summary>
        /// Gets or sets the name of the style.
        /// </summary>
        /// <value>The name of the style.</value>
        public string StyleName
        {
            get { return (string) Node.Attribute(Ns.Text + "style-name"); }
            set { Node.SetAttributeValue(Ns.Text + "style-name", value); }
        }

        /// <summary>
        /// Every object (typeof(IContent)) have to know his document.
        /// </summary>
        /// <value></value>
        public IDocument Document { get; set; }

        /// <summary>
        /// A Style class wich is referenced with the content object.
        /// If no style is available this is null.
        /// </summary>
        /// <value></value>
        public IStyle Style
        {
            get { return _style; }
            set
            {
                StyleName = value.StyleName;
                _style = value;
            }
        }

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        XNode IContent.Node
        {
            get { return Node; }
            set { Node = (XElement) value; }
        }

        #endregion
    }

    /// <summary>
    /// All possible Standard Headings
    /// </summary>
    public enum Headings
    {
        /// <summary>
        /// Standard Heading
        /// </summary>
        Heading,
        /// <summary>
        /// Heading 1
        /// </summary>
        Heading_20_1,
        /// <summary>
        /// Heading 2
        /// </summary>
        Heading_20_2,
        /// <summary>
        /// Heading 3
        /// </summary>
        Heading_20_3,
        /// <summary>
        /// Heading 4
        /// </summary>
        Heading_20_4,
        /// <summary>
        /// Heading 5
        /// </summary>
        Heading_20_5,
        /// <summary>
        /// Heading 6
        /// </summary>
        Heading_20_6,
        /// <summary>
        /// Heading 7
        /// </summary>
        Heading_20_7,
        /// <summary>
        /// Heading 8
        /// </summary>
        Heading_20_8,
        /// <summary>
        /// Heading 9
        /// </summary>
        Heading_20_9,
        /// <summary>
        /// Heading 10
        /// </summary>
        Heading_20_10
    }
}

/*
 * $Log: Header.cs,v $
 * Revision 1.3  2008/04/29 15:39:46  mt
 * new copyright header
 *
 * Revision 1.2  2007/04/08 16:51:23  larsbehr
 * - finished master pages and styles for text documents
 * - several bug fixes
 *
 * Revision 1.1  2007/02/25 08:58:38  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.3  2006/02/05 20:02:25  larsbm
 * - Fixed several bugs
 * - clean up some messy code
 *
 * Revision 1.2  2006/02/02 21:55:59  larsbm
 * - Added Clone object support for many AODL object types
 * - New Importer implementation PlainTextImporter and CsvImporter
 * - New tests
 *
 * Revision 1.1  2006/01/29 11:28:22  larsbm
 * - Changes for the new version. 1.2. see next changelog for details
 *
 * Revision 1.2  2006/01/05 10:31:10  larsbm
 * - AODL merged cells
 * - AODL toc
 * - AODC batch mode, splash screen
 *
 * Revision 1.1  2005/12/12 19:39:17  larsbm
 * - Added Paragraph Header
 * - Added Table Row Header
 * - Fixed some bugs
 * - better whitespace handling
 * - Implmemenation of HTML Exporter
 *
 */