﻿#pragma checksum "..\..\..\Administration\AddEditOrderPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4792C293EC0173928DD0EA4752030B10A8E97685EA4B100A7A42F0325914E33F"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;
using ZooSalon.Administration;


namespace ZooSalon.Administration {
    
    
    /// <summary>
    /// AddEditOrderPage
    /// </summary>
    public partial class AddEditOrderPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\Administration\AddEditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxClient;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Administration\AddEditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxService;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Administration\AddEditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxEmployee;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Administration\AddEditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker datePickerDate;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Administration\AddEditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/ZooSalon;component/administration/addeditorderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Administration\AddEditOrderPage.xaml"
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
            this.comboBoxClient = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.comboBoxService = ((System.Windows.Controls.ComboBox)(target));
            
            #line 57 "..\..\..\Administration\AddEditOrderPage.xaml"
            this.comboBoxService.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxService_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxEmployee = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.datePickerDate = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 5:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Administration\AddEditOrderPage.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
