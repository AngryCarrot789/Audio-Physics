using AudioPhysics.Helpers;
using AudioPhysics.Oscillator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AudioPhysics.Views
{
    /// <summary>
    /// Interaction logic for GraphWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        private List<double> SumValues { get; }

        public bool IsOpen { get; set; }

        public GraphWindow()
        {
            InitializeComponent();
            SumValues = new List<double>(44100);
        }

        public void UpdateChart(List<OscillatorViewModel> oscillators)
        {
            try
            {
                if (IsOpen)
                {
                    SumValues.Clear();
                    int y = 0;
                    foreach (OscillatorViewModel oscillator in oscillators)
                    {
                        for (int i = 0; i < oscillator.RawWaveData.Count; i++)
                        {
                            if (y == 0)
                                SumValues.Add(oscillator.RawWaveData[i]);
                            else
                                SumValues[i] += oscillator.RawWaveData[i];
                        }
                        y++;
                    }


                    Graph.Children.Clear();

                    double canvasHeight = Graph.ActualHeight;
                    double canvasWidth = Graph.ActualWidth;

                    double xScale = canvasWidth / 800D;
                    double yScale = (canvasHeight / 8);

                    var graphLine = new Polyline();
                    var SlashLine = new Line();
                    SlashLine.Stroke = Brushes.Black;
                    SlashLine.StrokeThickness = 1;
                    SlashLine.X1 = 0;
                    SlashLine.X2 = canvasWidth;
                    SlashLine.Y1 = yScale * 4;
                    SlashLine.Y2 = yScale * 4;
                    Graph.Children.Add(SlashLine);
                    graphLine.Stroke = Brushes.Red;
                    graphLine.StrokeThickness = 2;

                    for (int i = 0; i < 800; i++)
                    {
                        graphLine.Points.Add(new Point(xScale * i, (yScale * 4) - ((SumValues[i] * yScale) * GlobalVariables.MasterVolume / oscillators.Count * 3)));
                    }

                    Graph.Children.Add(graphLine);
                }
            }
            catch { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            IsOpen = false;
        }
    }
}
