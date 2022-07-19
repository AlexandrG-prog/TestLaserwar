using System.Windows;
using TestLaserwar.UserControls;
using TestLaserwar.ViewModel;

namespace TestLaserwar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
