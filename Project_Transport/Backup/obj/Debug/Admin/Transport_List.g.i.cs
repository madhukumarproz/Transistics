﻿#pragma checksum "..\..\..\Admin\Transport_List.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A0BFB86F33D478A95222327F526B984"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// transport_list_Panel
    /// </summary>
    public partial class transport_list_Panel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// transport_name_entry_panel Name Field
        /// </summary>
        
        #line 12 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.StackPanel transport_name_entry_panel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton transport_name_insert;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton transport_name_edit;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox v_code;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox vv_code;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox trans_name;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox o_name;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Admin\Transport_List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid translistgrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Transport;component/admin/transport_list.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Admin\Transport_List.xaml"
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
            this.transport_name_entry_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.transport_name_insert = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\Admin\Transport_List.xaml"
            this.transport_name_insert.Checked += new System.Windows.RoutedEventHandler(this.transport_name_insert_checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.transport_name_edit = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\Admin\Transport_List.xaml"
            this.transport_name_edit.Checked += new System.Windows.RoutedEventHandler(this.transport_name_edit_checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.v_code = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\Admin\Transport_List.xaml"
            this.v_code.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.vendor_code_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Admin\Transport_List.xaml"
            this.v_code.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.vendor_code_Textchanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.vv_code = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\Admin\Transport_List.xaml"
            this.vv_code.KeyDown += new System.Windows.Input.KeyEventHandler(this.vv_code_keydown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.trans_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Admin\Transport_List.xaml"
            this.trans_name.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.trans_name_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Admin\Transport_List.xaml"
            this.trans_name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.trans_name_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.o_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\Admin\Transport_List.xaml"
            this.o_name.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.owner_name_PreviewKeydown);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\Admin\Transport_List.xaml"
            this.o_name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.owner_name_Textchanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 24 "..\..\..\Admin\Transport_List.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.transport_name_entry_click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 29 "..\..\..\Admin\Transport_List.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.transport_list_back_click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.translistgrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\..\Admin\Transport_List.xaml"
            this.translistgrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.translistgrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

