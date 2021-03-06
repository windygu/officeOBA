﻿#pragma checksum "..\..\Window.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1E16C4A877C164836D744047954865E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18444
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Fluent;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Fluent.Sample.ColorGallery {
    
    
    /// <summary>
    /// Window
    /// </summary>
    public partial class Window : Fluent.RibbonWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.Sample.ColorGallery.Window window;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.RibbonGroupBox A;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.DropDownButton colorPickerStandard;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.ColorGallery colorGalleryStandard;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.DropDownButton colorPickerThemed;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.ColorGallery colorGalleryThemed;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.DropDownButton colorPickerHighlight;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.ColorGallery colorGalleryHighlight;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Fluent.Sample.ColorGallery;component/window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((Fluent.Sample.ColorGallery.Window)(target));
            return;
            case 2:
            this.A = ((Fluent.RibbonGroupBox)(target));
            return;
            case 3:
            this.colorPickerStandard = ((Fluent.DropDownButton)(target));
            return;
            case 4:
            this.colorGalleryStandard = ((Fluent.ColorGallery)(target));
            return;
            case 5:
            this.colorPickerThemed = ((Fluent.DropDownButton)(target));
            return;
            case 6:
            this.colorGalleryThemed = ((Fluent.ColorGallery)(target));
            return;
            case 7:
            this.colorPickerHighlight = ((Fluent.DropDownButton)(target));
            return;
            case 8:
            this.colorGalleryHighlight = ((Fluent.ColorGallery)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

