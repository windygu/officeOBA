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
using AODL.Document.Content;

namespace AODL.Document.Forms.Controls
{
    public class ODFListBox : ODFFormControl
    {
        private ODFOptionCollection _options;

        /// <summary>
        /// Creates an ODFListBox
        /// </summary>
        /// <param name="parentForm">Parent form that the control belongs to</param>
        /// <param name="contentCollection">Collection of content where the control will be referenced</param>
        /// <param name="id">Control ID. Please specify a unique ID!</param>
        public ODFListBox(ODFForm parentForm, ContentCollection contentCollection, string id)
            : base(parentForm, contentCollection, id)
        {
            _options = new ODFOptionCollection();
            RestoreOptionEvents();
        }

        /// <summary>
        /// Creates an ODFListBox
        /// </summary>
        /// <param name="parentForm">Parent form that the control belongs to</param>
        /// <param name="contentCollection">Collection of content where the control will be referenced</param>
        /// <param name="id">Control ID. Please specify a unique ID!</param>
        /// <param name="x">X coordinate of the control in ODF format (eg. "1cm", "15mm", 3.2cm" etc)</param>
        /// <param name="y">Y coordinate of the control in ODF format (eg. "1cm", "15mm", 3.2cm" etc)</param>
        /// <param name="width">Width of the control in ODF format (eg. "1cm", "15mm", 3.2cm" etc)</param>
        /// <param name="height">Height of the control in ODF format (eg. "1cm", "15mm", 3.2cm" etc)</param>
        public ODFListBox(ODFForm parentForm, ContentCollection contentCollection, string id, string x, string y,
                          string width, string height) : base(parentForm, contentCollection, id, x, y, width, height)
        {
            _options = new ODFOptionCollection();
            RestoreOptionEvents();
        }

        public ODFListBox(ODFForm parentForm, XElement node) : base(parentForm, node)
        {
            _options = new ODFOptionCollection();
            RestoreOptionEvents();
        }

        /// <summary>
        /// The collection of the ODFOptions (each option stand for a list box element)
        /// </summary>
        public ODFOptionCollection Options
        {
            get { return _options; }
            set { _options = value; }
        }

        public override string Type
        {
            get { return "listbox"; }
        }

        /// <summary>
        /// Specifies whether or not a control can accept user input
        /// </summary>
        public bool? Disabled
        {
            get { return (bool?) Node.Attribute(Ns.Form + "disabled"); }
            set { Node.SetAttributeValue(Ns.Form + "disabled", value); }
        }

        /// <summary>
        /// Contains additional information about a control.
        /// </summary>
        public string Title
        {
            get { return (string) Node.Attribute(Ns.Form + "title"); }
            set { Node.SetAttributeValue(Ns.Form + "title", value); }
        }

        /// <summary>
        /// Specifies the source used to populate the list in a list box or
        /// combo box. The first column of the list source result set populates the list.
        /// </summary>
        public string ListSource
        {
            get { return (string) Node.Attribute(Ns.Form + "list-source"); }
            set { Node.SetAttributeValue(Ns.Form + "list-source", value); }
        }

        /// <summary>
        /// Specifies the column values of the list source result set that
        /// are used to fill the data field values
        /// </summary>
        public string BoundColumn
        {
            get { return (string) Node.Attribute(Ns.Form + "bound-column"); }
            set { Node.SetAttributeValue(Ns.Form + "bound-column", value); }
        }

        /// <summary>
        /// Specifies the name of a result set column. The result set is
        /// determined by the form which the control belongs to
        /// </summary>
        public string DataField
        {
            get { return (string) Node.Attribute(Ns.Form + "data-field"); }
            set { Node.SetAttributeValue(Ns.Form + "data-field", value); }
        }

        /// <summary>
        /// Specifies the type of data source that is used to
        /// populate the list data in a list box or combo box
        /// </summary>
        public ListSourceType? ListSourceType
        {
            get
            {
                string s = (string) Node.Attribute(Ns.Form + "list-source-type");
                if (s == null) return null;

                switch (s)
                {
                    case "table":
                        return Forms.ListSourceType.Table;
                    case "query":
                        return Forms.ListSourceType.Query;
                    case "sql":
                        return Forms.ListSourceType.Sql;
                    case "sql-pass-through":
                        return Forms.ListSourceType.SqlPassThrough;
                    case "value-list":
                        return Forms.ListSourceType.ValueList;
                    case "table-fields":
                        return Forms.ListSourceType.TableFields;
                    default:
                        return null;
                }
            }
            set
            {
                string s = null;
                if (value.HasValue)
                {
                    switch (value.Value)
                    {
                        case Forms.ListSourceType.Table:
                            s = "table";
                            break;
                        case Forms.ListSourceType.Query:
                            s = "query";
                            break;
                        case Forms.ListSourceType.Sql:
                            s = "sql";
                            break;
                        case Forms.ListSourceType.SqlPassThrough:
                            s = "sql-pass-through";
                            break;
                        case Forms.ListSourceType.ValueList:
                            s = "value-list";
                            break;
                        case Forms.ListSourceType.TableFields:
                            s = "table-fields";
                            break;
                        default:
                            break;
                    }
                }
                Node.SetAttributeValue(Ns.Form + "list-source-type", s);
            }
        }

        /// <summary>
        /// Specifies the tabbing navigation order of a control within a form
        /// </summary>
        public int TabIndex
        {
            get { return (int) Node.Attribute(Ns.Form + "tab-index"); }
            set { Node.SetAttributeValue(Ns.Form + "tab-index", value); }
        }

        /// <summary>
        /// Specifies whether or not a control is included in the tabbing
        /// navigation order
        /// </summary>
        public bool? TabStop
        {
            get { return (bool?) Node.Attribute(Ns.Form + "tab-stop"); }
            set { Node.SetAttributeValue(Ns.Form + "tab-stop", value); }
        }

        /// <summary>
        /// Specifies whether or not a control is printed when a user prints
        /// the document in which the control is contained
        /// </summary>
        public bool? Printable
        {
            get { return (bool?) Node.Attribute(Ns.Form + "printable"); }
            set { Node.SetAttributeValue(Ns.Form + "printable", value); }
        }

        /// <summary>
        /// Specifies whether or not a user can modify the value of a control
        /// </summary>
        public bool? ReadOnly
        {
            get { return (bool?) Node.Attribute(Ns.Form + "readonly"); }
            set { Node.SetAttributeValue(Ns.Form + "readonly", value); }
        }

        /// <summary>
        /// Specifies whether the list in a combo box or list box is always
        /// visible or is only visible when the user clicks the drop-down button
        /// </summary>
        public bool? DropDown
        {
            get { return (bool?) Node.Attribute(Ns.Form + "dropdown"); }
            set { Node.SetAttributeValue(Ns.Form + "dropdown", value); }
        }

        /// <summary>
        /// specifies the number of rows that are visible at a time in a combo box
        /// list or a list box list
        /// </summary>
        public int Size
        {
            get { return (int?) Node.Attribute(Ns.Form + "size") ?? -1; }
            set
            {
                if (value <= 0)
                    return;
                Node.SetAttributeValue(Ns.Form + "size", value);
            }
        }

        /// <summary>
        /// specifies whether or not empty current values are regarded as NULL
        /// </summary>
        public bool? ConvertEmptyToNull
        {
            get { return (bool?) Node.Attribute(Ns.Form + "convert-empty-to-null"); }
            set { Node.SetAttributeValue(Ns.Form + "convert-empty-to-null", value); }
        }

        public void SuppressOptionEvents()
        {
            _options.Inserted -= OptionCollection_Inserted;
            _options.Removed -= OptionCollection_Removed;
        }

        public void RestoreOptionEvents()
        {
            _options.Inserted += OptionCollection_Inserted;
            _options.Removed += OptionCollection_Removed;
        }

        private void OptionCollection_Inserted(int index, object value)
        {
            ODFOption opt = (ODFOption) value;
            Node.Add(opt.Node);
        }

        private static void OptionCollection_Removed(int index, object value)
        {
            ODFOption opt = value as ODFOption;
            if (opt != null)
                opt.Node.Remove();
        }

        /// <summary>
        /// Looks for a specified option by its value
        /// </summary>
        /// <param name="val">Option value</param>
        /// <returns></returns>
        public ODFOption GetOptionByValue(string val)
        {
            foreach (ODFOption opt in _options)
            {
                if (opt.Value == val)
                {
                    return opt;
                }
            }
            return null;
        }

        /// <summary>
        /// Looks for a specified option by its label
        /// </summary>
        /// <param name="lbl">Option label</param>
        /// <returns></returns>
        public ODFOption GetOptionByLabel(string lbl)
        {
            foreach (ODFOption opt in _options)
            {
                if (opt.Label == lbl)
                {
                    return opt;
                }
            }
            return null;
        }

        public void FixOptionCollection()
        {
            _options.Clear();
            SuppressOptionEvents();
            foreach (XElement nodeChild in Node.Elements())
            {
                if (nodeChild.Name == Ns.Form + "option" && nodeChild.Parent == Node)
                {
                    ODFOption sp = new ODFOption(_document, nodeChild);
                    _options.Add(sp);
                }
            }
            RestoreOptionEvents();
        }


        protected override void CreateBasicNode()
        {
            XElement xe = new XElement(Ns.Form + "listbox");
            Node.Add(xe);
            Node = xe;
            ControlImplementation = "ooo:com.sun.star.form.component.ListBox";
        }
    }
}