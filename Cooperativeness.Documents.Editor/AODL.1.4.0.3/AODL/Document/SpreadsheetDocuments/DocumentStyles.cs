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

using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace AODL.Document.SpreadsheetDocuments
{
    /// <summary>
    /// DocumentStyles represent the styles.xml file of a file in the
    /// OpenDocument format.
    /// </summary>
    public class DocumentStyles : TextDocuments.DocumentStyles
    {
        /// <summary>
        /// Load the style from assmebly resource.
        /// </summary>
        public override void New()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            Stream str = ass.GetManifestResourceStream("AODL.Resources.OD.spreadsheetstyles.xml");
            using (XmlReader reader = XmlReader.Create(str))
            {
                Styles = XDocument.Load(reader);
            }
        }
    }
}

/*
 * $Log: DocumentStyles.cs,v $
 * Revision 1.2  2008/04/29 15:39:53  mt
 * new copyright header
 *
 * Revision 1.1  2007/02/25 08:58:47  larsbehr
 * initial checkin, import from Sourceforge.net to OpenOffice.org
 *
 * Revision 1.2  2006/02/05 20:03:32  larsbm
 * - Fixed several bugs
 * - clean up some messy code
 *
 * Revision 1.1  2006/01/29 11:28:23  larsbm
 * - Changes for the new version. 1.2. see next changelog for details
 *
 */