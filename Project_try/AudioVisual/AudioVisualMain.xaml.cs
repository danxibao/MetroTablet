using Project_try.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_try
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AudioVisualMain : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }
        public AudioVisualMain()
        {
            this.InitializeComponent();
            // Setup the navigation helper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            // Setup the logical page navigation components that allow
            // the page to only show one pane at a time.
            this.navigationHelper.GoBackCommand = new Project_try.Common.RelayCommand(() => this.GoBack(), () => this.CanGoBack());

            // Start listening for Window size changes 
            // to change from showing two panes to showing a single pane
            Window.Current.SizeChanged += Window_SizeChanged;
            this.InvalidateVisualState();
        }

        private void self_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {
                case "Article":
                    Frame.Navigate(typeof(AudioVisual.Article));
                    break;
                case "Interview":
                    Frame.Navigate(typeof(AudioVisual.Interview));
                    break;
                case "Video":
                    Frame.Navigate(typeof(AudioVisual.Video));
                    break;
                case "Movie":
                    Frame.Navigate(typeof(AudioVisual.Movie));
                    break;
            }

        }

        private void self_Entered(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Article":
                    ArticleMask.Opacity = 0.31;
                    break;
                case "Interview":
                    InterviewMask.Opacity = 0.31;
                    break;
                case "Video":
                    VideoMask.Opacity = 0.31;
                    break;
                case "Movie":
                    MovieMask.Opacity = 0.31;
                    break;
            }
        }

        private void self_Exited(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Article":
                    ArticleMask.Opacity = 0;
                    Article.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case "Interview":
                    InterviewMask.Opacity = 0;
                    Interview.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case "Video":
                    VideoMask.Opacity = 0;
                    Video.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case "Movie":
                    MovieMask.Opacity = 0;
                    Movie.Margin = new Thickness(0, 0, 0, 0);
                    break;
            }
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        
        }

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            
        }

        #region Logical page navigation

        private const int MinimumWidthForSupportingTwoPanes = 768;

        private bool UsingLogicalPageNavigation()
        {
            return Window.Current.Bounds.Width < MinimumWidthForSupportingTwoPanes;
        }

        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            this.InvalidateVisualState();
        }


        private bool CanGoBack()
        {
            if (this.UsingLogicalPageNavigation())
            {
                return true;
            }
            else
            {
                return this.navigationHelper.CanGoBack();
            }
        }
        private void GoBack()
        {
            if (this.UsingLogicalPageNavigation())
            {

            }
            else
            {
                this.navigationHelper.GoBack();
            }
        }

        private void InvalidateVisualState()
        {
            var visualState = DetermineVisualState();
            VisualStateManager.GoToState(this, visualState, false);
            this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
        }

        private string DetermineVisualState()
        {
            if (!UsingLogicalPageNavigation())
                return "PrimaryView";

            // Update the back button's enabled state when the view state changes
            var logicalPageBack = this.UsingLogicalPageNavigation();

            return logicalPageBack ? "SinglePane_Detail" : "SinglePane";
        }

        #endregion




        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }

        private void self_Pressed(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Article":
                    Article.Margin = new Thickness(5, 5, 5, 5);
                    break;
                case "Interview":
                    Interview.Margin = new Thickness(5, 5, 5, 5);
                    break;
                case "Video":
                    Video.Margin = new Thickness(5, 5, 5, 5);
                    break;
                case "Movie":
                    Movie.Margin = new Thickness(5, 5, 5, 5);
                    break;
            }
        }

        private void self_Released(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Article":
                    Article.Margin = new Thickness(0,0,0,0);
                    break;
                case "Interview":
                    Interview.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case "Video":
                    Video.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case "Movie":
                    Movie.Margin = new Thickness(0, 0, 0, 0);
                    break;
            }
        }
    }
}
