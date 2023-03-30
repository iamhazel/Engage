// [FILE] Engage.Views.ChatPage.xaml.cs
using Engage.Views.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace Engage.Helpers
{
    public static class AlertManager
    {
        public delegate void AlertEventHandler(object sender, EventArgs e);
        public static event AlertEventHandler ShowAlertEvent;

        public static void RaiseShowAlertEvent(object sender)
        {
            ShowAlertEvent?.Invoke(sender, EventArgs.Empty);
        }

        public static void OnShowAlert(object sender, EventArgs e, Grid container, IDictionary<DependencyProperty, int> properties = null)
        {
            // Create an instance of your Alert control
            Alert alert = new Alert();

            // Set the Grid properties for the Alert control from the properties dictionary
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    alert.SetValue(property.Key, property.Value);
                }
            }

            // Remove any existing alerts from the container (optional)
            for (int i = container.Children.Count - 1; i >= 0; i--)
            {
                if (container.Children[i] is Alert)
                {
                    container.Children.RemoveAt(i);
                }
            }

            // Add the alert to the container
            container.Children.Add(alert);
        }

    }
}