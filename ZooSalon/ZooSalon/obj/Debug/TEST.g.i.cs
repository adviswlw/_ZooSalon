﻿#pragma checksum "..\..\TEST.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A07917D0158D1670D97618163D6CFE72A49FA8BDE7AD31BB0075D1C44F7D81DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using ZooSalon;


namespace ZooSalon {
    
    
    /// <summary>
    /// TEST
    /// </summary>
    public partial class TEST : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZooSalon.TEST home;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMenu;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdHome;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdService;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdProduct;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdOrder;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdUsers;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdSettings;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRestore;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\TEST.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frameContent;
        
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
            System.Uri resourceLocater = new System.Uri("/ZooSalon;component/test.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TEST.xaml"
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
            this.home = ((ZooSalon.TEST)(target));
            return;
            case 2:
            this.gridMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.rdHome = ((System.Windows.Controls.RadioButton)(target));
            
            #line 49 "..\..\TEST.xaml"
            this.rdHome.Click += new System.Windows.RoutedEventHandler(this.rdHome_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rdService = ((System.Windows.Controls.RadioButton)(target));
            
            #line 53 "..\..\TEST.xaml"
            this.rdService.Click += new System.Windows.RoutedEventHandler(this.rdService_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rdProduct = ((System.Windows.Controls.RadioButton)(target));
            
            #line 57 "..\..\TEST.xaml"
            this.rdProduct.Click += new System.Windows.RoutedEventHandler(this.rdProduct_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rdOrder = ((System.Windows.Controls.RadioButton)(target));
            
            #line 61 "..\..\TEST.xaml"
            this.rdOrder.Click += new System.Windows.RoutedEventHandler(this.rdOrder_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rdUsers = ((System.Windows.Controls.RadioButton)(target));
            
            #line 65 "..\..\TEST.xaml"
            this.rdUsers.Click += new System.Windows.RoutedEventHandler(this.rdUsers_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.rdSettings = ((System.Windows.Controls.RadioButton)(target));
            
            #line 76 "..\..\TEST.xaml"
            this.rdSettings.Click += new System.Windows.RoutedEventHandler(this.rdSettings_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\TEST.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnRestore = ((System.Windows.Controls.Button)(target));
            
            #line 152 "..\..\TEST.xaml"
            this.btnRestore.Click += new System.Windows.RoutedEventHandler(this.btnRestore_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 167 "..\..\TEST.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.frameContent = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
