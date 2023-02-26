using Avalonia.Controls;
using StudentControl.ViewModels;

namespace StudentControl.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            {
                InitializeComponent();
                DataContext = new MainWindowViewModel();
            }
        }
    }
}