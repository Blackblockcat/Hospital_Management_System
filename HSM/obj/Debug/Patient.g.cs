﻿#pragma checksum "..\..\Patient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "200053B651B2E7F458F2C4120F4E8F7DACA45AB25E672010FBE8E62AE15E88A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using HSM.Control;
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


namespace HSM {
    
    
    /// <summary>
    /// Patient
    /// </summary>
    public partial class Patient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Update;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid membersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Department;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Medical;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button search;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update1;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HSM.Control.MyTextBox ID;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\Patient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HSM.Control.MyTextBox name;
        
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
            System.Uri resourceLocater = new System.Uri("/HSM;component/patient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Patient.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 13 "..\..\Patient.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\Patient.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown_2);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 61 "..\..\Patient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Update = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.membersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 84 "..\..\Patient.xaml"
            this.membersDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.membersDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Department = ((System.Windows.Controls.DataGrid)(target));
            
            #line 99 "..\..\Patient.xaml"
            this.Department.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.membersDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Medical = ((System.Windows.Controls.DataGrid)(target));
            
            #line 109 "..\..\Patient.xaml"
            this.Medical.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.membersDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.search = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\Patient.xaml"
            this.search.Click += new System.Windows.RoutedEventHandler(this.search_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Update1 = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\Patient.xaml"
            this.Update1.Click += new System.Windows.RoutedEventHandler(this.Update1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ID = ((HSM.Control.MyTextBox)(target));
            return;
            case 10:
            this.name = ((HSM.Control.MyTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
