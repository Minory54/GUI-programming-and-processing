﻿#pragma checksum "..\..\AddTimer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B20151B19A87665D51F616D20ED4EC8B7B3B68A8BECE462CDB91DF0F8C0F868"
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
using Timer;


namespace Timer {
    
    
    /// <summary>
    /// AddTimer
    /// </summary>
    public partial class AddTimer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_timerName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_timerHour;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_timerMinute;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_timerSecond;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar cal_timerCalendar;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_addTimer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddTimer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Timer;component/addtimer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTimer.xaml"
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
            this.tb_timerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tb_timerHour = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tb_timerMinute = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_timerSecond = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cal_timerCalendar = ((System.Windows.Controls.Calendar)(target));
            return;
            case 6:
            this.bt_addTimer = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\AddTimer.xaml"
            this.bt_addTimer.Click += new System.Windows.RoutedEventHandler(this.bt_addTimer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bt_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\AddTimer.xaml"
            this.bt_cancel.Click += new System.Windows.RoutedEventHandler(this.bt_cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

