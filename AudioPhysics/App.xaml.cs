using AudioPhysics.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AudioPhysics
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static GraphWindow Graph { get; private set; }

        public App()
        {
            Graph = new GraphWindow();
        }

        public static void ShowGraph()
        {
            Graph.Show();
            Graph.IsOpen = true;
        }
    }
}
