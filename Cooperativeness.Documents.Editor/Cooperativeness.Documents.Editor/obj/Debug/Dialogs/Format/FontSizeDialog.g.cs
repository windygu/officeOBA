﻿#pragma checksum "..\..\..\..\Dialogs\Format\FontSizeDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F79F4F03958BE7E8C175A35EEDAFA791"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1022
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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




/// <summary>
/// FontSizeDialog
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
public partial class FontSizeDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
    
    
    #line 4 "..\..\..\..\Dialogs\Format\FontSizeDialog.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal Fluent.Spinner SizeBox;
    
    #line default
    #line hidden
    
    
    #line 5 "..\..\..\..\Dialogs\Format\FontSizeDialog.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal Fluent.Button CancelButton;
    
    #line default
    #line hidden
    
    
    #line 10 "..\..\..\..\Dialogs\Format\FontSizeDialog.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal Fluent.Button OKButton;
    
    #line default
    #line hidden
    
    private bool _contentLoaded;
    
    /// <summary>
    /// InitializeComponent
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public void InitializeComponent() {
        if (_contentLoaded) {
            return;
        }
        _contentLoaded = true;
        System.Uri resourceLocater = new System.Uri("/Cooperativeness.Documents.Editor;component/dialogs/format/fontsizedialog.xaml", System.UriKind.Relative);
        
        #line 1 "..\..\..\..\Dialogs\Format\FontSizeDialog.xaml"
        System.Windows.Application.LoadComponent(this, resourceLocater);
        
        #line default
        #line hidden
    }
    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
    void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
        this.SizeBox = ((Fluent.Spinner)(target));
        return;
            case 2:
        this.CancelButton = ((Fluent.Button)(target));
        return;
            case 3:
        this.OKButton = ((Fluent.Button)(target));
        return;
            }
        this._contentLoaded = true;
    }
}

