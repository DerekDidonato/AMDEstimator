
using System.Windows;
using AMDEstimator.ViewModels;

namespace AMDEstimator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
