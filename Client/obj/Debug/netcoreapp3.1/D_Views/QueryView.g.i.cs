﻿#pragma checksum "..\..\..\..\D_Views\QueryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D7E0DFF12BF58AF751AA3491953A46EBA504DD02"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Client.D_Views;
using Client.G_Converters;
using Interactivity;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
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
        
        
        #line 20 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelContentOfTab;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelRefresh;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image refreshImage;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lastExecuted;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelPaginationOptions;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox paginateCheckBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pageSizeSuffixLabel;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pageSizeTextBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel resultsDisplayInfoslabel;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalNumberOfRowsLabelPrefix;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalNumberOfRowsLabel;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel pageNavigationGroup;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label previousPage;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentPagePrefix;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox currentPage;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pageSeparator;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentPageSuffix;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nextPage;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\D_Views\QueryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridContainingRequeteResults;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client.Module;component/d_views/queryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\D_Views\QueryView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.stackPanelContentOfTab = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.stackPanelRefresh = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.refreshImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.lastExecuted = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.stackPanelPaginationOptions = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.paginateCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.pageSizeSuffixLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.pageSizeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.resultsDisplayInfoslabel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.totalNumberOfRowsLabelPrefix = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.totalNumberOfRowsLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.pageNavigationGroup = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 13:
            this.previousPage = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.currentPagePrefix = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.currentPage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.pageSeparator = ((System.Windows.Controls.Label)(target));
            return;
            case 17:
            this.currentPageSuffix = ((System.Windows.Controls.Label)(target));
            return;
            case 18:
            this.nextPage = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.gridContainingRequeteResults = ((System.Windows.Controls.DataGrid)(target));
            
            #line 94 "..\..\..\..\D_Views\QueryView.xaml"
            this.gridContainingRequeteResults.AutoGeneratedColumns += new System.EventHandler(this.gridContainingRequeteResults_AutoGeneratedColumns);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

