﻿#pragma checksum "..\..\Window8.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A5CF3783948207CA977E5DFE55E00BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Test;


namespace Test {
    
    
    /// <summary>
    /// Window8
    /// </summary>
    public partial class Window8 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbBMonat;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBBez;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBSatz;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbBStatus;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tlWarning;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvBonus;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bUeStdErs;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Window8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bMainWin;
        
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
            System.Uri resourceLocater = new System.Uri("/Test;component/window8.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window8.xaml"
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
            
            #line 8 "..\..\Window8.xaml"
            ((Test.Window8)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbBMonat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.tbBBez = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbBSatz = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbBStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.tlWarning = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lvBonus = ((System.Windows.Controls.ListView)(target));
            
            #line 41 "..\..\Window8.xaml"
            this.lvBonus.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvBonus_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.bUeStdErs = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\Window8.xaml"
            this.bUeStdErs.Click += new System.Windows.RoutedEventHandler(this.bUeStdErs_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.bMainWin = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Window8.xaml"
            this.bMainWin.Click += new System.Windows.RoutedEventHandler(this.bMainWin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
