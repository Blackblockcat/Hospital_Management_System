﻿#pragma checksum "..\..\Stafflock.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6E1DFF73E82FE3AB3A6B69B4C1DE06FA92024574B134066FA862D6C913A15BDC"
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
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// Stafflock
    /// </summary>
    public partial class Stafflock : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textManager_CoManager;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtManager_CoManager;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textMCPassword;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtMCPassword;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textMCID;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMCID;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Stafflock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToStaff;
        
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
            System.Uri resourceLocater = new System.Uri("/HSM;component/stafflock.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Stafflock.xaml"
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
            
            #line 18 "..\..\Stafflock.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 34 "..\..\Stafflock.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textManager_CoManager = ((System.Windows.Controls.TextBlock)(target));
            
            #line 46 "..\..\Stafflock.xaml"
            this.textManager_CoManager.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textManager_CoManager_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtManager_CoManager = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\Stafflock.xaml"
            this.txtManager_CoManager.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtManager_CoManager_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textMCPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 63 "..\..\Stafflock.xaml"
            this.textMCPassword.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textMCPassword_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtMCPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 64 "..\..\Stafflock.xaml"
            this.txtMCPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.txtMCPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textMCID = ((System.Windows.Controls.TextBlock)(target));
            
            #line 79 "..\..\Stafflock.xaml"
            this.textMCID.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textMCID_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtMCID = ((System.Windows.Controls.TextBox)(target));
            
            #line 80 "..\..\Stafflock.xaml"
            this.txtMCID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtMCID_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ToStaff = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\Stafflock.xaml"
            this.ToStaff.Click += new System.Windows.RoutedEventHandler(this.ToStaff_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
