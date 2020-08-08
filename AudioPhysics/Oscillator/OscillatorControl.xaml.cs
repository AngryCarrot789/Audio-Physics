using AudioPhysics.Helpers;
using System.Windows.Controls;

namespace AudioPhysics.Oscillator
{
    /// <summary>
    /// Interaction logic for OscillatorControl.xaml
    /// </summary>
    public partial class OscillatorControl : UserControl
    {
        public OscillatorViewModel Oscillator
        {
            get => this.DataContext as OscillatorViewModel;
            set => this.DataContext = value;
        }

        public OscillatorControl()
        {
            InitializeComponent();
            Loaded += OscillatorControl_Loaded;
        }

        private void OscillatorControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Animate();
        }

        public void Animate()
        {
            AnimationLib.OpacityControl(this, 0, 1, 0.5);
            AnimationLib.MoveToTargetX(this, -100, 0.5);
        }
    }
}
