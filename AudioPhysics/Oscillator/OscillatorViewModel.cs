using AudioPhysics.Generator;
using AudioPhysics.Utilities;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AudioPhysics.Oscillator
{
    public class OscillatorViewModel : BaseViewModel
    {
        #region Generator Fields

        private string _channelName;
        public string ChannelName
        {
            get => _channelName;
            set => RaisePropertyChanged(ref _channelName, value);
        }

        private string _waveName;
        public string WaveName
        {
            get => _waveName;
            set => RaisePropertyChanged(ref _waveName, value);
        }

        private double _volume;
        public double Volume
        {
            get => _volume;
            set => RaisePropertyChanged(ref _volume, value, UpdateVolume);
        }

        private double _frequency;
        public double Frequency
        {
            get => _frequency;
            set => RaisePropertyChanged(ref _frequency, value, UpdateFrequency);
        }

        private double _deTune;
        public double DeTune
        {
            get => _deTune;
            set => RaisePropertyChanged(ref _deTune, value, UpdateDeTune);
        }

        private double _waveOffset;
        public double WaveOffset
        {
            get => _waveOffset;
            set => RaisePropertyChanged(ref _waveOffset, value, UpdateWaveOffset);
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => RaisePropertyChanged(ref _isEnabled, value, UpdateEnabledStatus);
        }

        private SignalType _signalWaveType;
        public SignalType SignalWaveType
        {
            get => _signalWaveType;
            set => RaisePropertyChanged(ref _signalWaveType, value, UpdateWaveType);
        }

        #endregion

        public List<double> RawWaveData { get; }
        private WaveFormat WaveFormat { get; }

        private const int SampleRate = 44100;
        private const int Channels = 2;

        public OscillatorSignalGenerator Generator { get; }
        public SampleToWaveProvider WaveProvider { get; }
        public AudioMixer Mixer { get; }

        public Action UpdateGraphCallback { get; set; }

        public ICommand SetOffsetCommand { get; }

        public OscillatorViewModel(AudioMixer mixer)
        {
            Mixer = mixer;

            RawWaveData = new List<double>(44100);
            WaveFormat = new WaveFormat(44100, 2);

            SetupDefaultValues();

            // Setup Sinewave
            Generator = new OscillatorSignalGenerator(
                SampleRate, Channels, SignalType.Sinewave, 
                Frequency, WaveOffset, Volume / 100d);

            WaveProvider = new SampleToWaveProvider(Generator);

            IsEnabled = true;

            UpdateGenerator(SignalType.Sinewave);

            SetOffsetCommand = new CommandParam<string>(SetWaveOffset);
        }

        public void SetupDefaultValues()
        {
            UpdateWaveName(SignalWaveType);
            Frequency = 440;
            Volume = 100;
            WaveOffset = 0;
            DeTune = 0;
        }

        public void AddGeneratorToAudioStream()
        {
            Mixer.AddAudioStream(WaveProvider);
        }

        public void RemoveGeneratorFromAudioStream()
        {
            Mixer.RemoveAudioStream(WaveProvider);
        }

        public void UpdateVolume(double newVolume)
        {
            if (Generator != null)
            {
                Generator.Volume = newVolume / 100d;
                UpdateGenerator(SignalWaveType);
            }
        }

        public void UpdateFrequency(double newFrequency)
        {
            if (Generator != null)
            {
                Generator.Frequency = newFrequency;
                UpdateGenerator(SignalWaveType);
            }
        }

        public void UpdateDeTune(double newDeTune)
        {
            // Not implemented
        }

        public void UpdateWaveOffset(double newWaveOffset)
        {
            if (Generator != null)
            {
                Generator.WaveOffset = newWaveOffset;
                UpdateGenerator(SignalWaveType);
            }
        }

        public void UpdateWaveType(SignalType type)
        {
            Generator.SignalWaveType = type;
            UpdateWaveName(type);
            UpdateGenerator(type);
        }

        public void UpdateWaveName(SignalType type)
        {
            switch (type)
            {
                case SignalType.Sinewave: WaveName = "Sine wave"; break;
                case SignalType.Cosinewave: WaveName = "Cosine wave"; break;
                case SignalType.Squarewave: WaveName = "Square wave"; break;
                case SignalType.Trianglewave: WaveName = "Triangle wave"; break;
                case SignalType.Sawtoothwave: WaveName = "Sawtooth wave"; break;
                case SignalType.Noisewave: WaveName = "Noise/Random"; break;
            }
        }

        private double _prevVolume;

        public void UpdateEnabledStatus(bool enabled)
        {
            if (enabled)
            {
                Volume = _prevVolume;
            }
            else
            {
                _prevVolume = Volume;
                Volume = 0.01;
            }
        }

        public void UpdateGenerator(SignalType type)
        {
            // Update Graph
            UpdateGraphCallback?.Invoke();

            RawWaveData.Clear();
            switch (type)
            {
                case SignalType.Sinewave:
                    for (int i = 0; i < WaveFormat.SampleRate; i++)
                        RawWaveData.Add(GeneratorHelpers.GenerateSine(Frequency, WaveFormat, i, WaveOffset, Volume / 100D));
                    break;

                case SignalType.Cosinewave:
                    for (int i = 0; i < WaveFormat.SampleRate; i++)
                        RawWaveData.Add(GeneratorHelpers.GenerateCosine(Frequency, WaveFormat, i, WaveOffset, Volume / 100D));
                    break;

                case SignalType.Squarewave:
                    for (int i = 0; i < WaveFormat.SampleRate; i++)
                        RawWaveData.Add(GeneratorHelpers.GenerateSquare(Frequency, WaveFormat, i, WaveOffset, Volume / 100D));
                    break;

                case SignalType.Trianglewave:
                    for (int i = 0; i < WaveFormat.SampleRate; i++)
                        RawWaveData.Add(GeneratorHelpers.GenerateTriangle(Frequency, WaveFormat, i, WaveOffset, Volume / 100D));
                    break;

                case SignalType.Sawtoothwave:
                    for (int i = 0; i < WaveFormat.SampleRate; i++)
                        RawWaveData.Add(GeneratorHelpers.GenerateSawtooth(Frequency, WaveFormat, i, WaveOffset, Volume / 100D));
                    break;

                case SignalType.Noisewave:
                    for (int i = 0; i < WaveFormat.SampleRate; i++)
                        RawWaveData.Add(GeneratorHelpers.GenerateNoise(Volume / 100D));
                    break;
            }
        }

        public void SetWaveOffset(string offsetType)
        {
            switch (offsetType)
            {
                case "2pi":   WaveOffset = 2D * Math.PI; break;
                case "32pi":  WaveOffset = (3D / 2D) * Math.PI; break;
                case "pi":    WaveOffset = Math.PI; break;
                case "pi2":   WaveOffset = Math.PI / 2D; break;
                case "0":     WaveOffset = 0; break;
                case "npi2":  WaveOffset = -Math.PI / 2D; break;
                case "npi":   WaveOffset = -Math.PI; break;
                case "n32pi": WaveOffset = -(3D / 2D) * Math.PI; break;
                case "n2pi":  WaveOffset = -2D * Math.PI; break;
            }
        }

        public void DestroyGenerator()
        {
            // Remove input stream
        }
    }
}