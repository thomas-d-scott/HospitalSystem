﻿#pragma checksum "..\..\..\View Model\RecordMeasurement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "485E366B2C9F8C71A87F9F49540837B1060A7DCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalSystemGUIApplication;
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


namespace HospitalSystemGUIApplication {
    
    
    /// <summary>
    /// RecordMeasurement
    /// </summary>
    public partial class RecordMeasurement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPatient;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkrMeasurementDate;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTime;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBloodPressureSystolic;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTemperature;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbNurse;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRecordMeasurement;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View Model\RecordMeasurement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBloodPressureDiastolic;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalSystemGUIApplication;component/view%20model/recordmeasurement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View Model\RecordMeasurement.xaml"
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
            this.cmbPatient = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.dpkrMeasurementDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.txtTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtBloodPressureSystolic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtTemperature = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmbNurse = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.btnRecordMeasurement = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\View Model\RecordMeasurement.xaml"
            this.btnRecordMeasurement.Click += new System.Windows.RoutedEventHandler(this.btnRecordMeasurement_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\View Model\RecordMeasurement.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtBloodPressureDiastolic = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

