﻿using Jellyfin.Core;
using Windows.Graphics.Display.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Jellyfin.Views
{
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            btnSave.Click += BtnSave_Click;

            HdmiDisplayInformation hdmiDisplayInformation = HdmiDisplayInformation.GetForCurrentView();
            checkBoxAutoRefreshRate.IsEnabled = hdmiDisplayInformation != null;
            checkBoxAutoRefreshRate.IsChecked = Central.Settings.AutoRefreshRate;
            checkBoxAutoResolution.IsEnabled = hdmiDisplayInformation != null;
            checkBoxAutoResolution.IsChecked = Central.Settings.AutoResolution;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            NavigateToMainPage();
        }

        private void SaveSettings()
        {
            if (checkBoxAutoRefreshRate.IsEnabled)
            {
                Central.Settings.AutoRefreshRate = checkBoxAutoRefreshRate.IsChecked ?? false;
            }
            if (checkBoxAutoResolution.IsEnabled)
            {
                Central.Settings.AutoResolution = checkBoxAutoResolution.IsChecked ?? false;
            }
        }
        private static void NavigateToMainPage()
        {
            (Window.Current.Content as Frame).Navigate(typeof(MainPage));
        }
    }
}