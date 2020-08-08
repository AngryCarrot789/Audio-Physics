using AudioPhysics.Helpers;
using AudioPhysics.Interfaces;
using System.Windows.Controls;

namespace AudioPhysics.Oscillator
{
    /// <summary>
    /// Interaction logic for OscillatorControl.xaml
    /// </summary>
    public partial class OscillatorControl : UserControl, IOscillator, IAnimatable
    {
        public OscillatorViewModel Oscillator
        {
            get => this.DataContext as OscillatorViewModel;
            set => this.DataContext = value;
        }

        public OscillatorControl()
        {
            InitializeComponent();
        }

        public void Animate(int viewWidth)
        {
            AnimationLib.OpacityControl(this, 0, 1, 0.5);
            AnimationLib.MoveToTargetX(this, -viewWidth, 0.5);
        }
    }
}
