﻿#pragma checksum "..\..\WinPhotoGalleryBinding.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7FF73F3A0051B44784DC115A5D4C85B1624603EA"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
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
using WpfPhotoGallery;
using WpfPhotoGallery.ViewModel;


namespace WpfPhotoGallery {
    
    
    /// <summary>
    /// WinPhotoGalleryBinding
    /// </summary>
    public partial class WinPhotoGalleryBinding : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuAdd;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuDelete;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuRename;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuRefresh;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuExit;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuFix;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuPrint;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuEdit;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView trvFolderExplorer;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeViewItem trvItmFavorites;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeViewItem trvItmFolder;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxPicture;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel pnlImageView;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel pnlFixbar;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRotateCW;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRotateCCW;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRotateSave;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgViewer;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnZoom;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popZoom;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sldZoom;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDefaultSize;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrev;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSlideShow;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCounterClockWise;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClockWise;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\WinPhotoGalleryBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfPhotoGallery;component/winphotogallerybinding.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinPhotoGalleryBinding.xaml"
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
            
            #line 10 "..\..\WinPhotoGalleryBinding.xaml"
            ((WpfPhotoGallery.WinPhotoGalleryBinding)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mnuAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 47 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuAdd.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mnuDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 48 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuDelete.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mnuRename = ((System.Windows.Controls.MenuItem)(target));
            
            #line 49 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuRename.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mnuRefresh = ((System.Windows.Controls.MenuItem)(target));
            
            #line 51 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuRefresh.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mnuExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 53 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuExit.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.mnuFix = ((System.Windows.Controls.MenuItem)(target));
            
            #line 55 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuFix.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mnuPrint = ((System.Windows.Controls.MenuItem)(target));
            
            #line 56 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuPrint.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mnuEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 57 "..\..\WinPhotoGalleryBinding.xaml"
            this.mnuEdit.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.trvFolderExplorer = ((System.Windows.Controls.TreeView)(target));
            
            #line 66 "..\..\WinPhotoGalleryBinding.xaml"
            this.trvFolderExplorer.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.TreeView_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.trvItmFavorites = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 13:
            this.trvItmFolder = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 83 "..\..\WinPhotoGalleryBinding.xaml"
            this.trvItmFolder.Expanded += new System.Windows.RoutedEventHandler(this.TreeViewItem_Expanded);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lbxPicture = ((System.Windows.Controls.ListBox)(target));
            
            #line 86 "..\..\WinPhotoGalleryBinding.xaml"
            this.lbxPicture.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.pnlImageView = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 16:
            this.pnlFixbar = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 17:
            this.btnRotateCW = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnRotateCW.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.btnRotateCCW = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnRotateCCW.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.btnRotateSave = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnRotateSave.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.imgViewer = ((System.Windows.Controls.Image)(target));
            return;
            case 21:
            this.btnZoom = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnZoom.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.popZoom = ((System.Windows.Controls.Primitives.Popup)(target));
            
            #line 124 "..\..\WinPhotoGalleryBinding.xaml"
            this.popZoom.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Popup_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 23:
            this.sldZoom = ((System.Windows.Controls.Slider)(target));
            
            #line 127 "..\..\WinPhotoGalleryBinding.xaml"
            this.sldZoom.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ZoomSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 24:
            this.btnDefaultSize = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnDefaultSize.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.btnPrev = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnPrev.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.btnSlideShow = ((System.Windows.Controls.Button)(target));
            
            #line 139 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnSlideShow.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            this.btnCounterClockWise = ((System.Windows.Controls.Button)(target));
            
            #line 147 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnCounterClockWise.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            this.btnClockWise = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnClockWise.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 153 "..\..\WinPhotoGalleryBinding.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
