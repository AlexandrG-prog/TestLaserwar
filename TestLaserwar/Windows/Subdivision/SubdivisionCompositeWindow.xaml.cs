using System.Windows;
using TestLaserwar.UserControls;

namespace TestLaserwar.Windows.Subdivision
{
    /// <summary>
    /// Interaction logic for SubdivisionCompositeWindow.xaml
    /// </summary>
    public partial class SubdivisionCompositeWindow : Window
    {
        public SubdivisionCompositeWindow()
        {
            InitializeComponent();
            this.Content = new SubdivisionCompositeUserControl();
        }
    }
}
