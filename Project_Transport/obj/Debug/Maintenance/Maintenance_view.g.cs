﻿#pragma checksum "..\..\..\Maintenance\Maintenance_view.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DBBC0D1D97521F07CAD8931490DEF780"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Reporting.WinForms;
using Microsoft.Windows.Controls;
using Project_Transport;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using WpfTools;


namespace Project_Transport {
    
    
    /// <summary>
    /// Maintenance_view
    /// </summary>
    public partial class Maintenance_view : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Maintenance\Maintenance_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel maintenance_view_panel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Maintenance\Maintenance_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox maintenance_view_vehicle_number;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Maintenance\Maintenance_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox maintenance_view_month;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Maintenance\Maintenance_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox year_txt;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Maintenance\Maintenance_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkbox;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Maintenance\Maintenance_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Transport;component/maintenance/maintenance_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Maintenance\Maintenance_view.xaml"
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
            this.maintenance_view_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.maintenance_view_vehicle_number = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.maintenance_view_vehicle_number.KeyDown += new System.Windows.Input.KeyEventHandler(this.maintenance_view_vehicle_number_keydown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.maintenance_view_vehicle_number.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Maintenance_View_Vehicle_Number_PreviewKeydown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.maintenance_view_vehicle_number.GotFocus += new System.Windows.RoutedEventHandler(this.maintenance_view_vehicle_number_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.maintenance_view_month = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.maintenance_view_month.KeyDown += new System.Windows.Input.KeyEventHandler(this.maintenance_view_month_keydown);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.maintenance_view_month.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Maintenance_Month_PreviewKeydown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.year_txt = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.year_txt.KeyDown += new System.Windows.Input.KeyEventHandler(this.maintenance_year_keydown);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.year_txt.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Maintenance_Year_PreviewKeydown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.chkbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 63 "..\..\..\Maintenance\Maintenance_view.xaml"
            this.chkbox.Checked += new System.Windows.RoutedEventHandler(this.all_expense_bill_view);
            
            #line default
            #line hidden
            return;
            case 6:
            this.reportViewer = ((Microsoft.Reporting.WinForms.ReportViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

