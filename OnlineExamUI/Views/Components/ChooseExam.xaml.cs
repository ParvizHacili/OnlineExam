using System;
using System.Collections.Generic;
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

namespace OnlineExamUI.Views.Components
{
    /// <summary>
    /// Interaction logic for ChooseExam.xaml
    /// </summary>
    public partial class ChooseExam : Window
    {
        public ChooseExam()
        {
            InitializeComponent();
        }

        private void ChooseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void RejectClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
