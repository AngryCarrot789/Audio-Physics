using AudioPhysics.ViewModels;
using System.Windows;

namespace AudioPhysics.Views
{
    public partial class MainWindow : Window
    {
        public MainViewModel Model
        {
            get => this.DataContext as MainViewModel;
            set => this.DataContext = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            Model = new MainViewModel();

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
