using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPhysics.Generator
{
    /// <summary>
    /// A class for providing a way to mix audio streams and play them
    /// </summary>
    public class AudioMixer
    {
        public double Volume { get; set; }

        /// <summary>
        /// The thing that mixes together audio streams
        /// </summary>
        private MixingWaveProvider32 WaveProvider { get; }

        /// <summary>
        /// The thing that takes the WaveProvider and outputs it to your speakers
        /// </summary>
        private DirectSoundOut Output { get; }

        public AudioMixer()
        {
            WaveProvider = new MixingWaveProvider32();
            Output = new DirectSoundOut();
        }

        public void Play()
        {
            Output.Init(WaveProvider);
            Output.Play();
        }

        public void Stop()
        {
            Output.Stop();
        }

        public void AddAudioStream(IWaveProvider provider)
        {
            WaveProvider.AddInputStream(provider);
        }

        public void RemoveAudioStream(IWaveProvider provider)
        {
            WaveProvider.RemoveInputStream(provider);
        }

        public void SetVolume(double volume)
        {
            Volume = volume;
        }
    }
}
