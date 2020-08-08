using AudioPhysics.Generator;
using AudioPhysics.Helpers;
using AudioPhysics.Oscillator;
using AudioPhysics.Utilities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TheRThemes;

namespace AudioPhysics.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set => RaisePropertyChanged(ref _isPlaying, value);
        }

        private double _masterVolume;
        public double MasterVolume
        {
            get => _masterVolume;
            set => RaisePropertyChanged(ref _masterVolume, value, RefreshMasterVolume);
        }

        private OscillatorViewModel _selectedOscillator;
        public OscillatorViewModel SelectedOscillator
        {
            get => _selectedOscillator;
            set => RaisePropertyChanged(ref _selectedOscillator, value);
        }

        public ObservableCollection<OscillatorViewModel> Oscillators { get; set; }

        public ICommand AddOscillatorCommand { get; }
        public ICommand RemoveOscillatorCommand { get; }

        public ICommand PlayStopCommand { get; }

        public ICommand ShowGraphCommand { get; }

        public ICommand SetThemeCommand { get; }

        /// <summary>
        /// The thing that combines audio streams abd outputs them.
        /// </summary>
        public AudioMixer MainMixer { get; }

        public MainViewModel()
        {
            MainMixer = new AudioMixer();

            Oscillators = new ObservableCollection<OscillatorViewModel>();

            SetupDefaultValues();

            AddOscillatorCommand = new Command(CreateAndAddNewOscillator);
            RemoveOscillatorCommand = new Command(RemoveSelectedOscillator);

            ShowGraphCommand = new Command(ShowGraph);

            SetThemeCommand = new CommandParam<string>(SetTheme);

            PlayStopCommand = new Command(AutoPlayStop);
        }

        public void ShowGraph()
        {
            App.ShowGraph();
        }

        public void UpdateGraph()
        {
            App.Graph.UpdateChart(Oscillators.ToList());
        }

        public void SetTheme(string themeLetter)
        {
            if (themeLetter == "l")
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            if (themeLetter == "d")
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        }

        public void SetupDefaultValues()
        {
            MasterVolume = 100;
        }

        public void AutoPlayStop()
        {
            if (!IsPlaying)
            {
                Play();
            }
            else
            {
                Stop();
            }

            IsPlaying = !IsPlaying;
        }

        public void Play()
        {
            MainMixer?.Play();
        }

        public void Stop()
        {
            MainMixer?.Stop();
        }

        public void RefreshMasterVolume(double newVolume)
        {
            MainMixer?.SetVolume(newVolume / 100d);
            GlobalVariables.MasterVolume = newVolume / 100d;
            UpdateGraph();
            // idk if doing the above, or the below is better.
            // adjusting volume on multiple audio streams but having
            // it multiplied by the "MasterVolume" might be better
            // sound-wise than the volume of every audio stream's volume
            // being decreases. but im pretty sure changing the volume
            // on all the audio streams is the exact same as a global master volume.
            // idk

            //foreach(OscillatorViewModel oscillator in Oscillators)
            //{
            //    oscillator.Volume = newVolume;
            //}
        }

        public void CreateAndAddNewOscillator()
        {
            OscillatorViewModel oscillator = CreateOscillator();
            AddOscillator(oscillator);
        }

        public OscillatorViewModel CreateOscillator()
        {
            OscillatorViewModel oscillator = new OscillatorViewModel(MainMixer);
            oscillator.RemoveCallback = RemoveOscillator;
            oscillator.UpdateGraphCallback = UpdateGraph;
            oscillator.Volume = MasterVolume;
            oscillator.ChannelName = $"Oscillator {Oscillators.Count}";
            return oscillator;
        }

        public void RemoveSelectedOscillator()
        {
            if (SelectedOscillator != null)
            {
                RemoveOscillator(SelectedOscillator);
            }
        }

        public void AddOscillator(OscillatorViewModel oscillator)
        {
            Oscillators?.Add(oscillator);
            oscillator.AddGeneratorToAudioStream();
            UpdateGraph();
        }

        public void RemoveOscillator(OscillatorViewModel oscillator)
        {
            Oscillators?.Remove(oscillator);
            oscillator.RemoveGeneratorFromAudioStream();
            UpdateGraph();
        }
    }
}
