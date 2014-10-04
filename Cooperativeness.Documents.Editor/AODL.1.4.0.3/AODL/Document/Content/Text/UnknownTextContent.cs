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

using System.Xml.Linq;
using AODL.Document.Styles;

namespace AODL.Document.Content.Text
{
    /// <summary>
    /// UnknownTextContent represent an unknown text element.
    /// </summary>
    public class UnknownTextContent : IText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownTextContent"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="node">The node.</param>
        public UnknownTextContent(IDocument document, XElement node)
        {
            Document = document;
            Node = node;
        }

        #region IContent Member

        private IStyle _style;

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        public XElement Node { get; set; }

        /// <summary>
        /// Return null, because the attribute name is unknown.
        /// </summary>
        /// <value></value>
        public string StyleName
        {
            get { return null; }
            set { }
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

        /// <summary>
        /// Gets the name of the get element.
        /// </summary>
        /// <value>The name of the get element.</value>
        public string GetElementName
        {
            get
            {
                if (Node != null)
                    return Node.Name.LocalName;
                return null;
            }
        }
    }
}

/*
 * $Log: UnknownTextContent.cs,v $
 * Revision 1.2  2008/04/29 15:39:46  mt
 * new copyright header
 *
 * Revision 1.1  2007/02/25 08:58:39  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.2  2006/02/05 20:02:25  larsbm
 * - Fixed several bugs
 * - clean up some messy code
 *
 * Revision 1.1  2006/01/29 11:28:22  larsbm
 * - Changes for the new version. 1.2. see next changelog for details
 *
 */