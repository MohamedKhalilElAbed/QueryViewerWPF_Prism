﻿#pragma checksum "..\..\..\..\D_Views\QueryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "422B704E6DD753E17F09E2F9E846900FCDE7ABDC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Client.G_Converters;
using Client.GridAction;
using Interactivity;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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


namespace Client.D_Views {
    
    
    /// <summary>
    /// QueryView
    /// </summary>
    public partial class QueryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Client.D_Views.QueryView QueryDetail;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewColumnSummary;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewColumnUserDefinedName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewColumnUserDefinedPosition;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelContentOfTab;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelRefresh;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image refreshImage;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lastExecuted;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelPaginationOptions;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox paginateCheckBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pageSizeSuffixLabel;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pageSizeTextBox;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel resultsDisplayInfoslabel;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalNumberOfRowsLabelPrefix;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalNumberOfRowsLabel;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel pageNavigationGroup;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label previousPage;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentPagePrefix;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox currentPage;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pageSeparator;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentPageSuffix;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nextPage;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridContainingRequeteResults;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client.Views;V1.0.0.0;component/d_views/queryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\D_Views\QueryView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.QueryDetail = ((Client.D_Views.QueryView)(target));
            return;
            case 2:
            this.listViewColumnSummary = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.listViewColumnUserDefinedName = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.listViewColumnUserDefinedPosition = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.stackPanelContentOfTab = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.stackPanelRefresh = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.refreshImage = ((System.Windows.Controls.Image)(target));
            
            #line 44 "..\..\..\..\D_Views\QueryView.xaml"
            this.refreshImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.refreshImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lastExecuted = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.stackPanelPaginationOptions = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.paginateCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.pageSizeSuffixLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.pageSizeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.resultsDisplayInfoslabel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            this.totalNumberOfRowsLabelPrefix = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.totalNumberOfRowsLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            this.pageNavigationGroup = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 17:
            this.previousPage = ((System.Windows.Controls.Label)(target));
            return;
            case 18:
            this.currentPagePrefix = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.currentPage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 20:
            this.pageSeparator = ((System.Windows.Controls.Label)(target));
            return;
            case 21:
            this.currentPageSuffix = ((System.Windows.Controls.Label)(target));
            return;
            case 22:
            this.nextPage = ((System.Windows.Controls.Label)(target));
            return;
            case 23:
            this.gridContainingRequeteResults = ((System.Windows.Controls.DataGrid)(target));
            
            #line 136 "..\..\..\..\D_Views\QueryView.xaml"
            this.gridContainingRequeteResults.AutoGeneratedColumns += new System.EventHandler(this.gridContainingRequeteResults_AutoGeneratedColumns);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

