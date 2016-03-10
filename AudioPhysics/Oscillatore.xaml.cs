using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AudioPhysics.Provider;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using NAudio.Wave;
using System;

namespace AudioPhysics
{
    /// <summary>
    /// Logica di interazione per Oscillatore.xaml
    /// </summary>
    public partial class Oscillatore : UserControl
    {
        GeneratoreSegnale GS;
        SampleToWaveProvider SPZ;
        bool isPronto = false;
        public List<double> Valori = new List<double>(44100);
        WaveFormat WF = new WaveFormat(44100,2);
        int SampleRate = 44100;
        int Canali = 2;

        public Oscillatore()
        {
            InitializeComponent();
            SfasamentoSlider.Maximum = Funzioni.DoppioPi;
            SfasamentoSlider.Minimum = -Funzioni.DoppioPi;
        }

        ~Oscillatore()
        {
            try { Distruggi(); }
            catch { }
        }

        [Obsolete("Deprecato")]
        public void Aggiorna()
        {
            if (isPronto) RichiediAggiornamento(GS.Tipo);
        }

        public string Title
        {
            get { return lbl_Channel.Content.ToString(); }
            set { lbl_Channel.Content = value; }
        }

        public void Prepara()
        {
            GS = PreparaOnda();
            SPZ = new SampleToWaveProvider(GS);
            RichiediAggiornamento(GeneratoreSegnale.TipoSegnale.Seno);
            MainWindow.MW.GlobalMixer.Mw.AddInputStream(SPZ);
            isPronto = true;
        }

        private GeneratoreSegnale PreparaOnda()
        {
            lbl_Name.Content = "Onda sinusoidale";
            return new GeneratoreSegnale(SampleRate, Canali, GeneratoreSegnale.TipoSegnale.Seno,
                FrequencySlider.Value, SfasamentoSlider.Value, AmplitudeSlider.Value / 100D);
        }

        public void Distruggi()
        {
            MainWindow.MW.GlobalMixer.Mw.RemoveInputStream(SPZ);
            SPZ = null;
        }

        #region Metodi aggiornamento del generatore di segnale

        private void AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale tipo)
        {
            GS.Tipo = tipo;
            switch (tipo)
            {
                case GeneratoreSegnale.TipoSegnale.Seno: lbl_Name.Content = "Onda sinusoidale";
                    break;
                case GeneratoreSegnale.TipoSegnale.Coseno: lbl_Name.Content = "Onda cosinusoidale";
                    break;
                case GeneratoreSegnale.TipoSegnale.Quadro: lbl_Name.Content = "Onda quadra";
                    break;
                case GeneratoreSegnale.TipoSegnale.Triangolo: lbl_Name.Content = "Onda triangolare";
                    break;
                case GeneratoreSegnale.TipoSegnale.DenteDiSega: lbl_Name.Content = "Onda dente di sega";
                    break;
                case GeneratoreSegnale.TipoSegnale.Casuale: lbl_Name.Content = "Onda casuale";
                    break;
                default:
                    break;
            }
            RichiediAggiornamento(tipo);
        }

        private void AggiornaDati(GeneratoreSegnale.TipoSegnale tipo)
        {
            Valori.Clear();
            switch (tipo)
            {
                case GeneratoreSegnale.TipoSegnale.Seno:
                    for (int i = 0; i < WF.SampleRate; i++)
                    { Valori.Add(Funzioni.Seno(FrequencySlider.Value, WF, i, SfasamentoSlider.Value, ((AmplitudeSlider.Value / 100D)))); }
                    break;
                case GeneratoreSegnale.TipoSegnale.Coseno:
                    for (int i = 0; i < WF.SampleRate; i++)
                    { Valori.Add(Funzioni.Coseno(FrequencySlider.Value, WF, i, SfasamentoSlider.Value, ((AmplitudeSlider.Value / 100D)))); }
                    break;
                case GeneratoreSegnale.TipoSegnale.Quadro:
                    for (int i = 0; i < WF.SampleRate; i++)
                    { Valori.Add(Funzioni.Quadro(FrequencySlider.Value, WF, i, SfasamentoSlider.Value, ((AmplitudeSlider.Value / 100D)))); }
                    break;
                case GeneratoreSegnale.TipoSegnale.Triangolo:
                    for (int i = 0; i < WF.SampleRate; i++)
                    { Valori.Add(Funzioni.Triangolo(FrequencySlider.Value, WF, i, SfasamentoSlider.Value, ((AmplitudeSlider.Value / 100D)))); }
                    break;
                case GeneratoreSegnale.TipoSegnale.DenteDiSega:
                    for (int i = 0; i < WF.SampleRate; i++)
                    { Valori.Add(Funzioni.DenteDiSega(FrequencySlider.Value, WF, i, SfasamentoSlider.Value, ((AmplitudeSlider.Value / 100D)))); }
                    break;
                case GeneratoreSegnale.TipoSegnale.Casuale:
                    for (int i = 0; i < WF.SampleRate; i++)
                    { Valori.Add(Funzioni.Casuale(((AmplitudeSlider.Value / 100D)))); }
                    break;
                default:
                    break;
            }
        }

        private void RichiediAggiornamento(GeneratoreSegnale.TipoSegnale tipo)
        {
            AggiornaDati(tipo);
            MainWindow.G.AggiornaGrafico();
        }

        #endregion

        #region Evento doubleclick Label per reset valore

        private void lbl_FrequencyHz_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var PF = new PopupFrequency();
            PF.Owner = Window.GetWindow(this);
            if (PF.ShowDialog() == true)
            {
                FrequencySlider.Value = PF.ReturnFrequency;
            }
        }

        private void lbl_Gradi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SfasamentoSlider.Value = 0D;
        }

        private void lbl_Percentage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetuneSlider.Value = 100D;
        }

        private void lbl_A_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AmplitudeSlider.Value = 100D;
        }

        #endregion

        #region Evento valuechanged Slider per aggiornamento del generatore di segnale

        private void FrequencySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GS != null)
            {
                GS.Frequenza = (float)FrequencySlider.Value;
                RichiediAggiornamento(GS.Tipo);
            }
        }

        private void AmplitudeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GS != null)
            {
                GS.Volume = AmplitudeSlider.Value / 100D;
                RichiediAggiornamento(GS.Tipo);
            }
        }

        private void SfasamentoSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GS != null)
            {
                GS.Sfasamento = SfasamentoSlider.Value;
                RichiediAggiornamento(GS.Tipo);
            }
        }

        private void DetuneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        #endregion

        #region Evento checked RadioButton per tipo di onda 

        private void rb_Sin_Checked(object sender, RoutedEventArgs e)
        {
            if (GS != null) AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale.Seno);
        }

        private void rb_Tri_Checked(object sender, RoutedEventArgs e)
        {
            if (GS != null) AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale.Triangolo);
        }

        private void rb_Quad_Checked(object sender, RoutedEventArgs e)
        {
            if (GS != null) AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale.Quadro);
        }

        private void rb_Cos_Checked(object sender, RoutedEventArgs e)
        {
            if (GS != null) AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale.Coseno);
        }

        private void rb_Saw_Checked(object sender, RoutedEventArgs e)
        {
            if (GS != null) AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale.DenteDiSega);
        }

        private void rb_Random_Checked(object sender, RoutedEventArgs e)
        {
            if (GS != null) AggiornaTipoOnda(GeneratoreSegnale.TipoSegnale.Casuale);
        }

        #endregion

        private void m_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as MenuItem).Name)
            {
                case "m_dPI": SfasamentoSlider.Value = 2D * Math.PI; break;
                case "m_tdPI": SfasamentoSlider.Value = (3D / 2D) * Math.PI; break;
                case "m_PI": SfasamentoSlider.Value = Math.PI; break;
                case "m_hPI": SfasamentoSlider.Value = Math.PI / 2D; break;
                case "m_z": SfasamentoSlider.Value = 0; break;
                case "m_mhPI": SfasamentoSlider.Value = -Math.PI / 2D; break;
                case "m_mPI": SfasamentoSlider.Value = -Math.PI; break;
                case "m_mtdPI": SfasamentoSlider.Value = -(3D / 2D) * Math.PI; break;
                case "m_mdPI": SfasamentoSlider.Value = -2D * Math.PI; break;
                default: MessageBox.Show("Imbecille, dato non esistente"); break;
            }
        }
    }
}
