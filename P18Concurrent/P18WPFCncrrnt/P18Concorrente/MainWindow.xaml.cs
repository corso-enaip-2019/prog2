using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P18Concorrente
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMainButton_Click(object sender, RoutedEventArgs e)
        {
            BtnMainButton.Content = "... cªlculªting ...";
            double nmb = 500000227; // 500'000'227
            BtnMainButton.Content = (IsPrime(nmb)) ? $"{nmb} IS prime!" : "{nmb} is NOT prime!";
        }

        private void Btn2ndButtonn_Click(object sender, RoutedEventArgs e)
        {
            Btn2ndButtonn.Content = "... cªlculªting ...";
            double nmb = 500000227; // 500'000'227
            Btn2ndButtonn.Content = (IsPrime(nmb)) ? $"{nmb} IS prime!" : "{nmb} is NOT prime!";
        }

        private bool IsPrime(double inDouble)
        {
            bool res = false;
            for (int i = 0; i < inDouble; i++)
            {
                #region operazioni per perdere tempo
                string str;
                str = "efeefefe";
                str = ((i + 1) % 7777) == 0 ? $"{i} IS i!" : "{i} is i";
                str = str + str;
                res = !res; 
                #endregion
            }
            return true;
        }
    }
}