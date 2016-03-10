using System;
using AudioPhysics.Provider;
using System.Windows;

namespace AudioPhysics
{
    public partial class PopupFrequency : Window
    {
        public PopupFrequency()
        {
            InitializeComponent();
        }

        public double ReturnFrequency
        {
            get
            {
                return Convert.ToDouble(tb_Frequency.Text);
            }
        }

        private void SetFrequency(double Frequency, double Multiplier)
        {
            tb_Frequency.Text = Convert.ToString(Frequency * Multiplier);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        #region Eventi buttoni
        private void btn_O1_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, (double)1 / 8); }
        private void btn_O1_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, (double)1 / 8); }
        private void btn_O1_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, (double)1 / 8); }
        private void btn_O1_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, (double)1 / 8); }
        private void btn_O1_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, (double)1 / 8); }
        private void btn_O1_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, (double)1 / 8); }
        private void btn_O1_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, (double)1 / 8); }
        private void btn_O1_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, (double)1 / 8); }
        private void btn_O1_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, (double)1 / 8); }
        private void btn_O1_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, (double)1 / 8); }
        private void btn_O1_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, (double)1 / 8); }
        private void btn_O1_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, (double)1 / 8); }

        private void btn_O2_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, (double)1 / 4); }
        private void btn_O2_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, (double)1 / 4); }
        private void btn_O2_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, (double)1 / 4); }
        private void btn_O2_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, (double)1 / 4); }
        private void btn_O2_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, (double)1 / 4); }
        private void btn_O2_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, (double)1 / 4); }
        private void btn_O2_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, (double)1 / 4); }
        private void btn_O2_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, (double)1 / 4); }
        private void btn_O2_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, (double)1 / 4); }
        private void btn_O2_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, (double)1 / 4); }
        private void btn_O2_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, (double)1 / 4); }
        private void btn_O2_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, (double)1 / 4); }

        private void btn_O3_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, (double)1 / 2); }
        private void btn_O3_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, (double)1 / 2); }
        private void btn_O3_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, (double)1 / 2); }
        private void btn_O3_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, (double)1 / 2); }
        private void btn_O3_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, (double)1 / 2); }
        private void btn_O3_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, (double)1 / 2); }
        private void btn_O3_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, (double)1 / 2); }
        private void btn_O3_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, (double)1 / 2); }
        private void btn_O3_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, (double)1 / 2); }
        private void btn_O3_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, (double)1 / 2); }
        private void btn_O3_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, (double)1 / 2); }
        private void btn_O3_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, (double)1 / 2); }

        private void btn_O4_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, 1); }
        private void btn_O4_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, 1); }
        private void btn_O4_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, 1); }
        private void btn_O4_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, 1); }
        private void btn_O4_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, 1); }
        private void btn_O4_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, 1); }
        private void btn_O4_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, 1); }
        private void btn_O4_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, 1); }
        private void btn_O4_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, 1); }
        private void btn_O4_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, 1); }
        private void btn_O4_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, 1); }
        private void btn_O4_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, 1); }

        private void btn_O5_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, 2); }
        private void btn_O5_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, 2); }
        private void btn_O5_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, 2); }
        private void btn_O5_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, 2); }
        private void btn_O5_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, 2); }
        private void btn_O5_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, 2); }
        private void btn_O5_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, 2); }
        private void btn_O5_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, 2); }
        private void btn_O5_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, 2); }
        private void btn_O5_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, 2); }
        private void btn_O5_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, 2); }
        private void btn_O5_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, 2); }

        private void btn_O6_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, 4); }
        private void btn_O6_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, 4); }
        private void btn_O6_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, 4); }
        private void btn_O6_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, 4); }
        private void btn_O6_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, 4); }
        private void btn_O6_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, 4); }
        private void btn_O6_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, 4); }
        private void btn_O6_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, 4); }
        private void btn_O6_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, 4); }
        private void btn_O6_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, 4); }
        private void btn_O6_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, 4); }
        private void btn_O6_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, 4); }

        private void btn_O7_C_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.C, 8); }
        private void btn_O7_D_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.D, 8); }
        private void btn_O7_E_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.E, 8); }
        private void btn_O7_F_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.F, 8); }
        private void btn_O7_G_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.G, 8); }
        private void btn_O7_A_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.A, 8); }
        private void btn_O7_B_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.B, 8); }
        private void btn_O7_CS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.CS, 8); }
        private void btn_O7_DS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.DS, 8); }
        private void btn_O7_FS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.FS, 8); }
        private void btn_O7_GS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.GS, 8); }
        private void btn_O7_AS_Click(object sender, RoutedEventArgs e) { SetFrequency(FrequenzeBase.FrequencyHerz.AS, 8); }
        #endregion

    }
}
