﻿#region Copyright and License Information

// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg., Weegen Patrick 2009-2013.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license

#endregion

using System.Windows;
using Fluent.Sample.Mvvm.ViewModels;

namespace Fluent.Sample.Mvvm
{
    /// <summary>
    /// Represents the main window of the application
    /// </summary>
    public partial class Window : RibbonWindow
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Window()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}