using OnlineExamUI.ViewModels.Windows;
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
using System.Windows.Shapes;

namespace OnlineExamUI.Views
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }
        private void rdbChecked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;

            grdSqlServer.IsEnabled = button != rdbWindows;
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            ConfigurationViewModel viewModel = (ConfigurationViewModel)DataContext;

            viewModel.DbSettings.SaveConfig();

            Close();
        }
    }
}
