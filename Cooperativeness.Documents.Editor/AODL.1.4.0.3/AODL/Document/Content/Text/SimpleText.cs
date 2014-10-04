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
using System.Xml.Linq;
using AODL.Document.Import.OpenDocument.NodeProcessors;
using AODL.Document.Styles;

namespace AODL.Document.Content.Text
{
    /// <summary>
    /// The class SimpleText represent simple unformatted text
    /// that could be used within the spreadsheet cell content.
    /// </summary>
    public class SimpleText : IText, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleText"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="simpleText">The simple text.</param>
        public SimpleText(IDocument document, string simpleText)
        {
            Document = document;
            Node = new XText(simpleText ?? string.Empty);
        }

        #region IText Member

        /// <summary>
        /// The node that represent the text content.
        /// </summary>
        /// <value></value>
        public XText Node { get; set; }

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        XNode IContent.Node
        {
            get { return Node; }
            set { Node = (XText) value; }
        }

        /// <summary>
        /// The text.
        /// </summary>
        /// <value></value>
        public string Text
        {
            get { return Node.Value; }
            set { Node.Value = value; }
        }

        /// <summary>
        /// The document to which this text content belongs to.
        /// </summary>
        /// <value></value>
        public IDocument Document { get; set; }

        /// <summary>
        /// Is null no style is available.
        /// </summary>
        /// <value></value>
        public IStyle Style
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// No style name available
        /// </summary>
        /// <value></value>
        public string StyleName
        {
            get { return null; }
            set { }
        }

        #endregion

        #region ICloneable Member

        /// <summary>
        /// Create a deep clone of this SimpleText object.
        /// </summary>
        /// <remarks>A possible Attached Style wouldn't be cloned!</remarks>
        /// <returns>
        /// A clone of this object.
        /// </returns>
        public object Clone()
        {
            SimpleText simpleTextClone = null;

            if (Document != null && Node != null)
            {
                TextContentProcessor tcp = new TextContentProcessor();
                simpleTextClone = (SimpleText) tcp.CreateTextObject(
                                                   Document, new XText(Node));
            }

            return simpleTextClone;
        }

        #endregion
    }
}

/*
 * $Log: SimpleText.cs,v $
 * Revision 1.2  2008/04/29 15:39:46  mt
 * new copyright header
 *
 * Revision 1.1  2007/02/25 08:58:39  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.2  2006/02/02 21:55:59  larsbm
 * - Added Clone object support for many AODL object types
 * - New Importer implementation PlainTextImporter and CsvImporter
 * - New tests
 *
 * Revision 1.1  2006/01/29 11:28:22  larsbm
 * - Changes for the new version. 1.2. see next changelog for details
 *
 */