// Engage.Helpers.SignalManager.cs
using Engage.Views;
using Engage.Views.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace Engage.Helpers
{
    public class SignalManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Func<Frame> _getSignalFrame;

        public SignalManager(IServiceProvider serviceProvider, Func<Frame> getSignalFrame)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _getSignalFrame = getSignalFrame ?? throw new ArgumentNullException(nameof(getSignalFrame));
        }

        private Frame _signalFrame => _getSignalFrame();

        public void ShowSignal(
            string title,
            string message,
            Signal.SignalType signalType,
            bool isClosable = true,
            bool isIconVisible = true,
            string actionContent = null,
            RoutedEventHandler actionClickHandler = null,
            IDictionary<DependencyProperty, int> properties = null)
        {
            // Create an instance of your Signal control
            Signal signal = new Signal
            {
                Title = title,
                Message = message,
                Type = signalType,
                IsClosable = isClosable,
                IsIconVisible = isIconVisible,
                ActionContent = actionContent
            };

            // Attach the button click event handler if provided
            if (actionClickHandler != null)
            {
                signal.SetSignalClickHandler(actionClickHandler);
            }

            // Set the properties for the Signal control from the properties dictionary
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    signal.SetValue(property.Key, property.Value);
                }
            }

            // Remove any existing signals from the signal frame (optional)
            if (_signalFrame != null)
            {
                for (int i = _signalFrame.BackStack.Count - 1; i >= 0; i--)
                {
                    if (_signalFrame.BackStack[i].SourcePageType == typeof(Signal))
                    {
                        _signalFrame.BackStack.RemoveAt(i);
                    }
                }
            }

            // Show the signal in the signal frame
            _signalFrame.Navigate(typeof(Signal), signal);
        }
    }
}
