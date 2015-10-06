using Project_try.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Media;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Resources;
using Windows.System.Display;

using Windows.UI.Popups;
using Project_try.InterviewItem;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace Project_try.Music
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for
    /// the currently selected item.
    /// </summary>
    public sealed partial class SingAloud : Page
    {
        
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        private DisplayRequest displayRequestManager = null;

        private SystemMediaTransportControls systemControls;

        private ResourceLoader resourceLoader = new ResourceLoader();

        private ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

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

        public SingAloud()
        {
            this.InitializeComponent();

            SingAloudData data = new SingAloudData();
            itemListView.ItemsSource = data.Collection;
            MainImage.Height = 0;
            // Setup the navigation helper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            // App storage for saving app state
            roamingSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            DefaultViewModel["musicPlayer"] = musicPlayer;

            // Setup the logical page navigation components that allow
            // the page to only show one pane at a time.
            this.navigationHelper.GoBackCommand = new Project_try.Common.RelayCommand(() => this.GoBack(), () => this.CanGoBack());
            this.itemListView.SelectionChanged += itemListView_SelectionChanged;

            systemControls = SystemMediaTransportControls.GetForCurrentView();
            systemControls.ButtonPressed += SystemControls_ButtonPressed;
            systemControls.IsPlayEnabled = true;
            systemControls.IsPauseEnabled = true;
            systemControls.IsStopEnabled = true;
            systemControls.IsNextEnabled = true;
            systemControls.IsPreviousEnabled = true;

            systemControls.IsEnabled = true;

            // Create DisplayRequest object
            displayRequestManager = new DisplayRequest();
            // Start listening for Window size changes 
            // to change from showing two panes to showing a single pane
            Window.Current.SizeChanged += Window_SizeChanged;
            this.InvalidateVisualState();
        }

        #region MediaElement Media Event Handlers
        void itemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation())
            {
                this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
            }
            MediaItem a = (MediaItem)itemListView.SelectedItem;
            if (a != null)
            {
                musicPlayer.Source = a.Source;
            }

        }
        void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            itemListView.Items.Clear();
            StopMedia();
        }

        void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        bool ShufflePlay = false;
        bool RepeatAll = false;

        Random RandomCreator = new Random();
        //播放结束，设置下一首
        void musicPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (ShufflePlay)
            {
                int i = RandomCreator.Next(0, itemListView.Items.Count);
                if (itemListView.SelectedIndex == i)
                {
                    StopMedia();
                    PlayMedia();
                }
                itemListView.SelectedIndex = i;
            }

            else if (itemListView.SelectedIndex < itemListView.Items.Count - 1)
            {
                itemListView.SelectedIndex++;
            }
            else if (RepeatAll && itemListView.SelectedIndex == itemListView.Items.Count - 1)
            {
                itemListView.SelectedIndex = 0;
            }
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {

        }
        void Media_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            // Updates the media state for the SystemMediaTransportControls.
            // Updates button states for Play/Pause and Stop.
            UpdateMediaState();
        }


        #endregion

        #region Media Element and SystemMediaTransportControls State
        void SystemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs e)
        {
            switch (e.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    PlayMedia();
                    break;
                case SystemMediaTransportControlsButton.Stop:
                    StopMedia();
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    PauseMedia();
                    break;
                case SystemMediaTransportControlsButton.Next:
                    NextMedia();
                    break;
                case SystemMediaTransportControlsButton.Previous:
                    PreviousMedia();
                    break;
                default:
                    break;
            }
        }

        void UpdateMediaState()
        {
            switch (musicPlayer.CurrentState)
            {
                case MediaElementState.Playing:
                    // Update SystemMediaTransportControls to keep them in sync with the MediaElement.
                    systemControls.PlaybackStatus = MediaPlaybackStatus.Playing;

                    SetPlayPauseButton(PlayPauseButtonState.Pause);
                    appBarButtonStop.IsEnabled = true;

                    break;
                case MediaElementState.Paused:
                    // Update SystemMediaTransportControls to keep them in sync with the MediaElement.
                    systemControls.PlaybackStatus = MediaPlaybackStatus.Paused;

                    SetPlayPauseButton(PlayPauseButtonState.Play);
                    appBarButtonStop.IsEnabled = true;

                    break;
                case MediaElementState.Stopped:
                    // Update SystemMediaTransportControls to keep them in sync with the MediaElement.
                    systemControls.PlaybackStatus = MediaPlaybackStatus.Stopped;

                    // Set AppBar button state.
                    SetPlayPauseButton(PlayPauseButtonState.Play);
                    appBarButtonStop.IsEnabled = false;

                    break;
                case MediaElementState.Closed:
                    // Update SystemMediaTransportControls to keep them in sync with the MediaElement.
                    systemControls.PlaybackStatus = MediaPlaybackStatus.Closed;

                    // Set AppBar button state.
                    SetPlayPauseButton(PlayPauseButtonState.Play);
                    appBarButtonStop.IsEnabled = false;

                    break;
                case MediaElementState.Buffering:
                    // Handle buffering state tasks.
                    break;
                case MediaElementState.Opening:
                    // Handle Opening state tasks.
                    break;
                default:
                    break;
            }
        }

        private void SetPlayPauseButton(PlayPauseButtonState buttonState)
        {
            // The text name of the bottom and tooltip.
            //string buttonName;

            switch (buttonState)
            {
                case PlayPauseButtonState.Play:

                    // Update button icon.
                    AppBarButtonPlay.Icon = new SymbolIcon(Symbol.Play);

                    // Update button text.
                    //buttonName = resourceLoader.GetString("playSharedButton");
                    AppBarButtonPlay.Label = "播放";//buttonName;
                    ToolTipService.SetToolTip(AppBarButtonPlay, "播放");
                    break;
                case PlayPauseButtonState.Pause:

                    // Update button icon.
                    AppBarButtonPlay.Icon = new SymbolIcon(Symbol.Pause);

                    // Update button text.
                    //buttonName = resourceLoader.GetString("pauseSharedButton");
                    AppBarButtonPlay.Label = "暂停";//buttonName;
                    ToolTipService.SetToolTip(AppBarButtonPlay, "暂停");
                    break;
                default:
                    break;
            }
        }
        async void PlayMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                musicPlayer.Play();
            });
        }
        async void PauseMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                musicPlayer.Pause();
            });
        }
        async void StopMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                musicPlayer.Stop();
            });
        }
        async void NextMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (ShufflePlay)
                {
                    int i = RandomCreator.Next(0, itemListView.Items.Count);
                    if (itemListView.SelectedIndex == i)
                    {
                        StopMedia();
                        PlayMedia();
                    }
                    itemListView.SelectedIndex = i;
                }

                else if (itemListView.SelectedIndex < itemListView.Items.Count - 1)
                {
                    itemListView.SelectedIndex++;
                }
                else if (RepeatAll && itemListView.SelectedIndex == itemListView.Items.Count - 1)
                {
                    itemListView.SelectedIndex = 0;
                }
            });
        }

        async void PreviousMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (ShufflePlay)
                {
                    int i = RandomCreator.Next(0, itemListView.Items.Count);
                    if (itemListView.SelectedIndex == i)
                    {
                        StopMedia();
                        PlayMedia();
                    }
                    itemListView.SelectedIndex = i;
                }

                else if (itemListView.SelectedIndex > 0)
                {
                    itemListView.SelectedIndex--;
                }
                else if (RepeatAll && itemListView.SelectedIndex == 0)
                {
                    itemListView.SelectedIndex = itemListView.Items.Count - 1;
                }
            });
        }


        #endregion


        #region App and MedieElement State: Save and Restore
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Assign a bindable group to Me.DefaultViewModel("Group")
            // TODO: Assign a collection of bindable items to Me.DefaultViewModel("Items")

            if (e.PageState == null)
            {
                // When this is a new page, select the first item automatically unless logical page
                // navigation is being used (see the logical page navigation #region below.)
                if (!this.UsingLogicalPageNavigation() && this.itemsViewSource.View != null)
                {
                    this.itemsViewSource.View.MoveCurrentToFirst();
                }
            }
            else
            {
                // Restore the previously saved state associated with this page
                if (e.PageState.ContainsKey("SelectedItem") && this.itemsViewSource.View != null)
                {
                    // TODO: Invoke Me.itemsViewSource.View.MoveCurrentTo() with the selected
                    //       item as specified by the value of pageState("SelectedItem")

                }
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            if (this.itemsViewSource.View != null)
            {
                // TODO: Derive a serializable navigation parameter and assign it to
                //       pageState("SelectedItem")

            }
        }
        #endregion

        #region AppBar Event Handlers

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Instruct.CurrentState)
            {
                case MediaElementState.Playing:
                    Instruct.Pause();
                    appBarButtonHelp.Icon = new SymbolIcon(Symbol.Play);
                    break;
                case MediaElementState.Paused:
                    Instruct.Play();
                    appBarButtonHelp.Icon = new SymbolIcon(Symbol.Pause);
                    break;
            } 
        }
        private void Instruct_Ended(object sender, RoutedEventArgs e)
        {
            appBarButtonHelp.Icon = new SymbolIcon(Symbol.Help);
        }


        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (musicPlayer.CurrentState == MediaElementState.Playing)
            {
                PauseMedia();
            }
            else
            {
                PlayMedia();
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            StopMedia();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            PreviousMedia();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

            NextMedia();
        }


        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.IsMuted = !musicPlayer.IsMuted;
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            ShufflePlay = !ShufflePlay;

        }

        private void RepeatAll_Click(object sender, RoutedEventArgs e)
        {
            RepeatAll = !RepeatAll;
        }

        private void RepeatOne_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.IsLooping = !musicPlayer.IsLooping;
        }



        #endregion

        #region Helper Methods

        /// <summary>
        /// Helper method to display a message to the screen.
        /// The message is displayed in the TextBlock named txtDisplay.
        /// The textFade animation fades the text after a few seconds.
        /// </summary>
        /// <param name="msg">Message to display</param>
        private void DisplayMessage(string msg)
        {
            txtDisplay.Text = msg;
            textFade.Begin();
        }

        /// <summary>
        /// Helper method to convert an HRESULT into an error string.
        /// </summary>
        /// <param name="e">The Exception event arguments</param>
        /// <returns>The error string.</returns>
        private string GetHresultFromErrorMessage(ExceptionRoutedEventArgs e)
        {
            String hr = String.Empty;
            String token = "HRESULT - ";
            const int hrLength = 10;     // eg "0xFFFFFFFF"

            int tokenPos = e.ErrorMessage.IndexOf(token, StringComparison.Ordinal);
            if (tokenPos != -1)
            {
                hr = e.ErrorMessage.Substring(tokenPos + token.Length, hrLength);
            }

            return hr;
        }

        /// <summary>
        /// Displays an error message to the user regarding an invalid media file.
        /// </summary>
        async void ShowFileErrorMsg()
        {
            try
            {
                MessageDialog messageDialog = new MessageDialog(resourceLoader.GetString("exBadFileOrPathName"));
                await messageDialog.ShowAsync();
            }
            catch (Exception)
            {
                // handle exception
            }
        }

        #endregion

        #region Logical page navigation

        // The split page isdesigned so that when the Window does have enough space to show
        // both the list and the dteails, only one pane will be shown at at time.
        //
        // This is all implemented with a single physical page that can represent two logical
        // pages.  The code below achieves this goal without making the user aware of the
        // distinction.

        private const int MinimumWidthForSupportingTwoPanes = 768;

        /// <summary>
        /// Invoked to determine whether the page should act as one logical page or two.
        /// </summary>
        /// <returns>True if the window should show act as one logical page, false
        /// otherwise.</returns>
        private bool UsingLogicalPageNavigation()
        {
            return Window.Current.Bounds.Width < MinimumWidthForSupportingTwoPanes;
        }

        /// <summary>
        /// Invoked with the Window changes size
        /// </summary>
        /// <param name="sender">The current Window</param>
        /// <param name="e">Event data that describes the new size of the Window</param>
        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            this.InvalidateVisualState();
        }

        /// <summary>
        /// Invoked when an item within the list is selected.
        /// </summary>
        /// <param name="sender">The GridView displaying the selected item.</param>
        /// <param name="e">Event data that describes how the selection was changed.</param>
        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Invalidate the view state when logical page navigation is in effect, as a change
            // in selection may cause a corresponding change in the current logical page.  When
            // an item is selected this has the effect of changing from displaying the item list
            // to showing the selected item's details.  When the selection is cleared this has the
            // opposite effect.
            if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();
        }

        private bool CanGoBack()
        {
            if (this.UsingLogicalPageNavigation() && this.itemListView.SelectedItem != null)
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
            if (this.UsingLogicalPageNavigation() && this.itemListView.SelectedItem != null)
            {
                // When logical page navigation is in effect and there's a selected item that
                // item's details are currently displayed.  Clearing the selection will return to
                // the item list.  From the user's point of view this is a logical backward
                // navigation.
                this.itemListView.SelectedItem = null;
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

        /// <summary>
        /// Invoked to determine the name of the visual state that corresponds to an application
        /// view state.
        /// </summary>
        /// <returns>The name of the desired visual state.  This is the same as the name of the
        /// view state except when there is a selected item in portrait and snapped views where
        /// this additional logical page is represented by adding a suffix of _Detail.</returns>
        private string DetermineVisualState()
        {
            if (!UsingLogicalPageNavigation())
                return "PrimaryView";

            // Update the back button's enabled state when the view state changes
            var logicalPageBack = this.UsingLogicalPageNavigation() && this.itemListView.SelectedItem != null;

            return logicalPageBack ? "SinglePane_Detail" : "SinglePane";
        }

        #endregion

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }


    }
}
