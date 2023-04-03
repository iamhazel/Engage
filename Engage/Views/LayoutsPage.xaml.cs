// [FILE] Engage.Views.LayoutsPage.xaml.cs

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using Engage.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Engage.Views
{
    public partial class LayoutsPage : Page
    {
        public ObservableCollection<LayoutsTabViewModel> Layouts { get; set; }

        public LayoutsPage()
        {
            InitializeComponent();
            Layouts = new ObservableCollection<LayoutsTabViewModel>();

            // Get list of XAML files in the Layouts directory
            string[] xamlFiles = Directory.GetFiles("C:\\Users\\heyze\\source\\repos\\Engage\\Engage\\Views\\Layouts");

            foreach (string xamlFile in xamlFiles)
            {
                // Create a new instance of the LayoutsTabViewModel class and bind the LayoutName property
                LayoutsTabViewModel tabViewModel = new LayoutsTabViewModel
                {
                    LayoutName = Path.GetFileNameWithoutExtension(xamlFile)
                };
                Layouts.Add(tabViewModel);
            }
        }
    }
}