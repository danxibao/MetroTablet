﻿

#pragma checksum "E:\GIT\减压包\Project_try\AudioVisual\Video.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF91B1B2AB84CABEC187D252A49F24EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_try.AudioVisual
{
    partial class Video : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 11 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.PageRoot_Loaded;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 81 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.itemListView_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 129 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.MediaContainer_Loaded;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 134 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.MediaElement)(target)).MediaOpened += this.Media_MediaOpened;
                 #line default
                 #line hidden
                #line 135 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.MediaElement)(target)).MediaEnded += this.Media_MediaEnded;
                 #line default
                 #line hidden
                #line 136 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.MediaElement)(target)).MediaFailed += this.Media_MediaFailed;
                 #line default
                 #line hidden
                #line 137 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.MediaElement)(target)).CurrentStateChanged += this.Media_CurrentStateChanged;
                 #line default
                 #line hidden
                #line 141 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.MediaElement)(target)).RateChanged += this.Media_RateChanged;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 224 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.BackButton_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 238 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.AppBar)(target)).Opened += this.BottomAppBar_Opened;
                 #line default
                 #line hidden
                #line 238 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.AppBar)(target)).Closed += this.BottomAppBar_Closed;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 313 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Repeat_Click;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 306 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.PictureSize_Click;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 307 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Zoom_Click;
                 #line default
                 #line hidden
                break;
            case 10:
                #line 308 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.FullWindow_Click;
                 #line default
                 #line hidden
                break;
            case 11:
                #line 284 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Mute_Click;
                 #line default
                 #line hidden
                break;
            case 12:
                #line 297 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AudioTracksComboBox_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 13:
                #line 266 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.PlayPause_Click;
                 #line default
                 #line hidden
                break;
            case 14:
                #line 267 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Stop_Click;
                 #line default
                 #line hidden
                break;
            case 15:
                #line 258 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Rewind_Click;
                 #line default
                 #line hidden
                break;
            case 16:
                #line 259 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Forward_Click;
                 #line default
                 #line hidden
                break;
            case 17:
                #line 260 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Previous_Click;
                 #line default
                 #line hidden
                break;
            case 18:
                #line 261 "..\..\..\AudioVisual\Video.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Next_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


