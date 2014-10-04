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
using AODL.Document.Content.Charts;

namespace AODL.Document.Content.EmbedObjects
{
    /// <summary>
    /// Summary description for EmbedObjectHandler.
    /// </summary>
    public class EmbedObjectHandler
    {
        /// <summary>
        /// the document which contains the embed object
        /// </summary>
        private IDocument _document;

        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="document"></param>
        public EmbedObjectHandler(IDocument document)
        {
            Document = document;
        }

        public IDocument Document
        {
            get { return _document; }

            set { _document = value; }
        }

        /// <summary>
        /// create a embed object
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="mediaType"></param>
        /// <param name="objectRealPath"></param>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public EmbedObject CreateEmbedObject(XElement parentNode, string mediaType, string objectRealPath,
                                             string objectName)
        {
            switch (mediaType)
            {
                case "application/vnd.oasis.opendocument.chart":
                    return CreateChart(parentNode, objectRealPath, objectName);
                case "application/vnd.oasis.opendocument.text":
                    return null;
                case "application/vnd.oasis.opendocument.formula":
                    return null;
                case "application/vnd.oasis.opendocument.presentation":
                    return null;
                default:
                    return null;
            }
        }

        /// <summary>
        /// create the chart
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="objectRealPath"></param>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public Chart CreateChart(XElement parentNode, string objectRealPath, string objectName)
        {
            Chart chart = new Chart(_document, null, parentNode)
                              {
                                  ObjectType = "chart",
                                  ObjectName = objectName,
                                  ObjectRealPath = objectRealPath
                              };

            ChartImporter chartimporter = new ChartImporter(chart);

            chartimporter.Import();

            return chart;
        }
    }
}