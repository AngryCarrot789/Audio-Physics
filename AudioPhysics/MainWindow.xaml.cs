using AudioPhysics.Classi;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AudioPhysics
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IfWindowIsShown = false;
        private static int MaxControl = 2;
        public static MainWindow MW = new MainWindow();
        public static Grafico G = new Grafico();
        public List<Oscillatore> OC = new List<Oscillatore>(MaxControl);
        List<Shape> SH = new List<Shape>(MaxControl - 1);
        public Mixer GlobalMixer = new Mixer();
        private static bool AttivaAggiornamento = false;
        public bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
            MW = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrimaAggiunta();
            AttivaAggiornamento = true;
        }

        private void PrimaAggiunta()
        {
            for (int i = 0; i < MaxControl; i++)
            {
                AggiungiOscillatore(i);
                if (MaxControl != (i + 1))
                {
                    AggiungiSeparatore();
                }
            }
        }

        private void OCV_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as Oscillatore).Prepara();
        }

        private void AggiungiOscillatore(int progresso)
        {
            var OCV = new Oscillatore();
            OCV.Title = "CANALE " + (progresso + 1);
            OCV.Background = new SolidColorBrush(Color.FromRgb(0x30, 0x30, 0x30));
            OCV.Margin = new Thickness(0, 10, 0, 10);
            OC.Add(OCV);
            stackPanel.Children.Add(OCV);
            AnimationLib.OpacityControl(OCV, 0, 1, 0.5);
            AnimationLib.MoveToTargetX(OCV, -Width, 0.5);
            //RichiediAggiornamento();
            OCV.Loaded += OCV_Loaded;
        }

        private void AggiungiSeparatore()
        {
            var Rect = new Rectangle();
            Rect.Height = 1;
            Rect.Stroke = null;
            Rect.Fill = new SolidColorBrush(Color.FromRgb(0x25, 0xA5, 0x81));
            Rect.Margin = new Thickness(10, 0, 10, 0);
            SH.Add(Rect);
            stackPanel.Children.Add(Rect);
            
        }

        [Obsolete("Pirla, ho fatto di meglio", true)]
        private void RichiediAggiornamento()
        {
            //Troppo lento
            //if (AttivaAggiornamento) OC.ForEach(C => C.Aggiorna());
        }

        private void RimuoviOscillatore(int progresso)
        {
            stackPanel.Children.Remove(OC[progresso]);
            OC[progresso].Distruggi();
            GC.Collect();
            OC.RemoveAt(progresso);
            //RichiediAggiornamento();
            G.AggiornaGrafico();
        }

        private void RimuoviSeparatore(int progresso)
        {
            stackPanel.Children.Remove(SH[progresso - 1]);
            SH.RemoveAt(progresso - 1);
        }

        private void NumeroOndeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MaxControl < Math.Round(NumeroOndeSlider.Value))
            {
                for (int i = MaxControl; i < Math.Round(NumeroOndeSlider.Value); i++)
                {
                    if (MaxControl != (i + 1))
                    {
                        AggiungiSeparatore();
                    }
                    AggiungiOscillatore(i);
                }
                MaxControl = Convert.ToInt32(Math.Round(NumeroOndeSlider.Value));
            }
            else if (MaxControl > Math.Round(NumeroOndeSlider.Value))
            {
                for (int i = MaxControl - 1; i >= Convert.ToInt32(Math.Round(NumeroOndeSlider.Value)); i--)
                {
                    RimuoviOscillatore(i);
                    RimuoviSeparatore(i);
                }
                MaxControl = Convert.ToInt32(Math.Round(NumeroOndeSlider.Value));
            }
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlaying)
                { GlobalMixer.Play(); img_btn_Play.Source = new BitmapImage(new Uri("Assets/Stop.png", UriKind.Relative)); }
            else
                { GlobalMixer.Stop(); img_btn_Play.Source = new BitmapImage(new Uri("Assets/Play.png", UriKind.Relative)); }
            isPlaying = !isPlaying;
        }

        private void MasterSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalMixer.Volume((float)(MasterSlider.Value / 100D));
            soWowThatEpicWhatTheSheep();
        }

        public void soWowThatEpicWhatTheSheep()
        {
            if (G != null) if(AttivaAggiornamento) G.AggiornaGrafico();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void btn_Graph_Click(object sender, RoutedEventArgs e)
        {
            G.Show();
        }
    }
}
