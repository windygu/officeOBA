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
using AODL.Document.Styles.Properties;

namespace AODL.Document.Styles
{
    /// <summary>
    /// Summary description for AxesStyle.
    /// </summary>
    public class AxesStyle : AbstractStyle
    {
        /// <summary>
        /// the constructor of the axesStyle
        /// </summary>
        /// <param name="document"></param>
        public AxesStyle(IDocument document)
        {
            Document = document;
            Node = new XElement(Ns.Style + "style");
            InitStandards();
            AxesProperties.Origin = "0";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableStyle"/> class.
        /// </summary>
        /// <param name="document">The spreadsheet document.</param>
        /// <param name="styleName">Name of the style.</param>
        public AxesStyle(IDocument document, string styleName)
        {
            Document = document;
            Node = new XElement(Ns.Style + "style");
            InitStandards();
            StyleName = styleName;
            AxesProperties.Origin = "0";
        }

        /// <summary>
        /// gets and sets the chart graphic property
        /// </summary>
        public ChartGraphicProperties ChartGraphicProperties
        {
            get
            {
                foreach (IProperty property in PropertyCollection)
                    if (property is ChartGraphicProperties)
                        return (ChartGraphicProperties) property;
                ChartGraphicProperties chartGraphicProperties = new ChartGraphicProperties(this);
                PropertyCollection.Add(chartGraphicProperties);
                return ChartGraphicProperties;
            }
            set
            {
                if (PropertyCollection.Contains(value))
                    PropertyCollection.Remove(value);
                PropertyCollection.Add(value);
            }
        }

        /// <summary>
        /// gets and sets the text properties
        /// </summary>
        public TextProperties TextProperties
        {
            get
            {
                foreach (IProperty property in PropertyCollection)
                    if (property is TextProperties)
                        return (TextProperties) property;
                TextProperties textProperties = new TextProperties(this);
                PropertyCollection.Add(textProperties);
                return TextProperties;
            }
            set
            {
                if (PropertyCollection.Contains(value))
                    PropertyCollection.Remove(value);
                PropertyCollection.Add(value);
            }
        }

        /// <summary>
        /// gets and sets the axes properties
        /// </summary>
        public AxesProperties AxesProperties
        {
            get
            {
                foreach (IProperty property in PropertyCollection)
                {
                    if (property is AxesProperties)
                        return (AxesProperties) property;
                }
                AxesProperties axesProperties = new AxesProperties(this);
                PropertyCollection.Add(axesProperties);
                return axesProperties;
            }
            set
            {
                if (PropertyCollection.Contains(value))
                    PropertyCollection.Remove(value);
                PropertyCollection.Add(value);
            }
        }

        /// <summary>
        /// gets and sets the family style
        /// </summary>
        public string FamilyStyle
        {
            get { return (string) Node.Attribute(Ns.Style + "family"); }
            set { Node.SetAttributeValue(Ns.Style + "family", value); }
        }

        /// <summary>
        /// Inits the standards.
        /// </summary>
        private void InitStandards()
        {
            PropertyCollection = new IPropertyCollection();
            PropertyCollection.Inserted += PropertyCollection_Inserted;
            PropertyCollection.Removed += PropertyCollection_Removed;
            FamilyStyle = "chart";
            //			this.Document.Styles.Add(this);
        }

        /// <summary>
        /// Properties the collection_ inserted.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private void PropertyCollection_Inserted(int index, object value)
        {
            Node.Add(((IProperty) value).Node);
        }

        /// <summary>
        /// Properties the collection_ removed.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private static void PropertyCollection_Removed(int index, object value)
        {
            ((IProperty) value).Node.Remove();
        }
    }
}