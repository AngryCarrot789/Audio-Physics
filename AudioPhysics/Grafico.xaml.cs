using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AudioPhysics
{
    /// <summary>
    /// Logica di interazione per PopupGrafico.xaml
    /// </summary>
    public partial class Grafico : Window
    {
        
        private List<double> SommaValori = new List<double>(44100);

        public Grafico()
        {
            InitializeComponent();
        }

        public void AggiornaGrafico()
        {
            SommaValori.Clear();
            int y = 0;
            foreach (var OCV in MainWindow.MW.OC)
            {
                for (int i = 0; i < OCV.Valori.Count; i++)
                {
                    if (y == 0)
                        SommaValori.Add(OCV.Valori[i]);
                    else
                        SommaValori[i] += OCV.Valori[i];
                }
                y++;
            }


            Graph.Children.Clear();

            double canvasHeight = Graph.ActualHeight;
            double canvasWidth = Graph.ActualWidth;

            double xScale = canvasWidth / 800D;
            double yScale = (canvasHeight / 8);

            var graphLine = new Polyline();
            var LineaFendente = new Line();
            LineaFendente.Stroke = Brushes.Black;
            LineaFendente.StrokeThickness = 1;
            LineaFendente.X1 = 0;
            LineaFendente.X2 = canvasWidth;
            LineaFendente.Y1 = yScale * 4;
            LineaFendente.Y2 = yScale * 4;
            Graph.Children.Add(LineaFendente);
            graphLine.Stroke = Brushes.Red;
            graphLine.StrokeThickness = 2;

            for (int i = 0; i < 800; i++)
            {
                graphLine.Points.Add(new Point(xScale * i, (yScale * 4) - ((SommaValori[i] * yScale) * MainWindow.MW.GlobalMixer._volume / (double)MainWindow.MW.OC.Count * 3)));
            }

            Graph.Children.Add(graphLine);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.MW.IfWindowIsShown = false;
            Hide();
            e.Cancel = true;
        }

        private void Dothat()
        {
            if (Visibility == Visibility.Visible)
            {
                MainWindow.MW.IfWindowIsShown = true;
                MainWindow.MW.soWowThatEpicWhatTheSheep();
            }
        }

        private void Window_Visibility(object sender, DependencyPropertyChangedEventArgs e)
        {
            Dothat();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dothat();
        }
    }
}
