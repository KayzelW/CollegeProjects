﻿#pragma checksum "..\..\..\..\Windows\AddMachine.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4C4A4A788FBB8FBCF6E9DF032DC1EE59DC5E5D3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ControlWork_Preview.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ControlWork_Preview.Windows {
    
    
    /// <summary>
    /// AddMachine
    /// </summary>
    public partial class AddMachine : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// Id Name Field
        /// </summary>
        
        #line 12 "..\..\..\..\Windows\AddMachine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox Id;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Model Name Field
        /// </summary>
        
        #line 14 "..\..\..\..\Windows\AddMachine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox Model;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Year Name Field
        /// </summary>
        
        #line 16 "..\..\..\..\Windows\AddMachine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox Year;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Color Name Field
        /// </summary>
        
        #line 18 "..\..\..\..\Windows\AddMachine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox Color;
        
        #line default
        #line hidden
        
        /// <summary>
        /// CountryPerformer Name Field
        /// </summary>
        
        #line 20 "..\..\..\..\Windows\AddMachine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox CountryPerformer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ControlWork_Preview;V1.0.0.0;component/windows/addmachine.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\AddMachine.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Model = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Year = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Color = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CountryPerformer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 21 "..\..\..\..\Windows\AddMachine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

