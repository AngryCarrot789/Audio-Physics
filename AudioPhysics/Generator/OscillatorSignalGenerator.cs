using AudioPhysics.Helpers;
using AudioPhysics.Oscillator;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPhysics.Generator
{
    public class OscillatorSignalGenerator : ISampleProvider
    {
        private int nSample;

        public double Frequency { get; set; }

        public double Volume { get; set; }

        public double WaveOffset { get; set; }

        public SignalType SignalWaveType { get; set; }

        public WaveFormat WaveFormat { get; }

        public OscillatorSignalGenerator() : this(44100, 2) { }

        public OscillatorSignalGenerator(int sampleRate, int channels)
        {
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
            SignalWaveType = SignalType.Sinewave;
            Frequency = 440.0;
            WaveOffset = 0;
            Volume = 1;
        }

        public OscillatorSignalGenerator(int sampleRate, int channels, SignalType signalType, double frequency, double waveOffset, double volume)
        {
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
            SignalWaveType = signalType;
            Frequency = frequency;
            WaveOffset = waveOffset;
            Volume = volume;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int outIndex = offset;
            double sampleValues;

            for (int sampleCount = 0; sampleCount < count / WaveFormat.Channels; sampleCount++)
            {
                switch (SignalWaveType)
                {
                    case SignalType.Sinewave:
                        sampleValues = GeneratorHelpers.GenerateSine(Frequency, WaveFormat, nSample, WaveOffset, Volume);
                        nSample++;
                        break;

                    case SignalType.Cosinewave:
                        sampleValues = GeneratorHelpers.GenerateCosine(Frequency, WaveFormat, nSample, WaveOffset, Volume);
                        nSample++;
                        break;

                    case SignalType.Squarewave:
                        sampleValues = GeneratorHelpers.GenerateSquare(Frequency, WaveFormat, nSample, WaveOffset, Volume);
                        nSample++;
                        break;

                    case SignalType.Trianglewave:
                        sampleValues = GeneratorHelpers.GenerateTriangle(Frequency, WaveFormat, nSample, WaveOffset, Volume);
                        nSample++;
                        break;

                    case SignalType.Sawtoothwave:
                        sampleValues = GeneratorHelpers.GenerateSawtooth(Frequency, WaveFormat, nSample, WaveOffset, Volume);
                        nSample++;
                        break;

                    case SignalType.Noisewave:
                        sampleValues = GeneratorHelpers.GenerateNoise(Volume);
                        break;

                    default:
                        sampleValues = 0.0;
                        break;
                }
                for (int i = 0; i < WaveFormat.Channels; i++)
                {
                    buffer[outIndex++] = (float)(GlobalVariables.MasterVolume * sampleValues);
                }
            }
            return count;
        }
    }
}
