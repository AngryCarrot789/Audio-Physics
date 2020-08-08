using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPhysics.Generator
{
    public static class GeneratorHelpers
    {
        public const double DoublePI = 6.283185307179586d;
        private static Random NumberGenerator { get; }

        static GeneratorHelpers()
        {
            NumberGenerator = new Random();
        }

        public static double GenerateSine(double frequency, WaveFormat waveFormat, double nSamples, double waveOffset, double volume)
        {
            double multiple = DoublePI * frequency / waveFormat.SampleRate;
            return volume * Math.Sin((nSamples * multiple) + waveOffset);
        }

        public static double GenerateCosine(double frequency, WaveFormat waveFormat, double nSamples, double waveOffset, double volume)
        {
            var multiple = DoublePI * frequency / waveFormat.SampleRate;
            return volume * Math.Cos((nSamples * multiple) + waveOffset);
        }

        public static double GenerateTriangle(double frequency, WaveFormat waveFormat, double nSamples, double waveOffset, double volume)
        {
            var multiple = 2 * frequency / waveFormat.SampleRate;
            var sampleSecond = (((nSamples * multiple) + Transform(waveOffset)) % 2);
            var sampleValue = 2 * sampleSecond;
            if (sampleValue > 1)
                sampleValue = 2 - sampleValue;
            if (sampleValue < -1)
                sampleValue = -2 - sampleValue;
            sampleValue *= volume;
            return sampleValue;
        }

        public static double GenerateSquare(double frequency, WaveFormat waveFormat, double nSamples, double waveOffset, double volume)
        {
            var multiple = 2 * frequency / waveFormat.SampleRate;
            var sampleSecond = (((nSamples * multiple) + Transform(waveOffset)) % 2) - 1;
            return sampleSecond > 0 ? volume : -volume;
        }

        public static double GenerateSawtooth(double frequency, WaveFormat waveFormat, double nSamples, double waveOffset, double volume)
        {
            var multiple = 2 * frequency / waveFormat.SampleRate;
            var sampleSecond = (((nSamples * multiple) + Transform(waveOffset)) % 2) - 1;
            return volume * sampleSecond;

        }

        public static double GenerateNoise(double volume)
        {
            return (volume * RandomNoise());
        }

        private static double RandomNoise()
        {
            return 2 * NumberGenerator.NextDouble() - 1;
        }

        private static double Transform(double number)
        {
            return (number / Math.PI) + 2;
        }
    }
}
