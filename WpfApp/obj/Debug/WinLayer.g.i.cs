﻿#pragma checksum "..\..\WinLayer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C66F22BB6C40D54031778B0AF4E24C0F53D4977A"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
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
using WpfApp;


namespace WpfApp {
    
    
    /// <summary>
    /// WinLayer
    /// </summary>
    public partial class WinLayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToolbox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSolutionExplorer;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdLayer0;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdLayer1;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdPanelToolbox;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToolboxPin;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdLayer2;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdPanelSolutionExplorer;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\WinLayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSolutionExplorerPin;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/winlayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinLayer.xaml"
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
            
            #line 34 "..\..\WinLayer.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 36 "..\..\WinLayer.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 42 "..\..\WinLayer.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnToolbox = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\WinLayer.xaml"
            this.btnToolbox.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelButton_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSolutionExplorer = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\WinLayer.xaml"
            this.btnSolutionExplorer.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelButton_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grdLayer0 = ((System.Windows.Controls.Grid)(target));
            
            #line 64 "..\..\WinLayer.xaml"
            this.grdLayer0.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MainLayer_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grdLayer1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.grdPanelToolbox = ((System.Windows.Controls.Grid)(target));
            
            #line 102 "..\..\WinLayer.xaml"
            this.grdPanelToolbox.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelArea_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnToolboxPin = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\WinLayer.xaml"
            this.btnToolboxPin.Click += new System.Windows.RoutedEventHandler(this.PinButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.grdLayer2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.grdPanelSolutionExplorer = ((System.Windows.Controls.Grid)(target));
            
            #line 137 "..\..\WinLayer.xaml"
            this.grdPanelSolutionExplorer.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelArea_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnSolutionExplorerPin = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\WinLayer.xaml"
            this.btnSolutionExplorerPin.Click += new System.Windows.RoutedEventHandler(this.PinButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
