using Exam.Core;
using Exam.Core.Enums;
using Exam.Core.Factories;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels;
using System;
using System.Collections.Generic;
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

namespace OnlineExamUI.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // CheckServer();
            Task.Run(() =>
            {
                CheckServer();
            });
        }

        private void btnConfigClick(object sender, RoutedEventArgs e)
        {
            ConfigurationViewModel configurationViewModel = new ConfigurationViewModel();
            configurationViewModel.DbSettings = DbSettings.Get();

            ConfigurationWindow configWindow = new ConfigurationWindow();
            configWindow.DataContext = configurationViewModel;
            configWindow.ShowDialog();

            firstPanel.Visibility = Visibility.Visible;
            secondPanel.Visibility = Visibility.Hidden;
            CheckServer();
        }

        private async void CheckServer()
        {
            DbSettings settings = DbSettings.Get();
            string connectionString = settings.GetConnectionString();
            Kernel.DB = DbFactory.Create(ServerType.SqlServer, connectionString);

            if (Kernel.DB == null) // configuration is incorrect
            {
                Application.Current.Dispatcher.Invoke(ShowErrorPanel);
            }
            else
            {
                bool connectionSucceed = Kernel.DB.CheckServer();

                if (connectionSucceed)
                {
                    await Task.Delay(2500);
                    Application.Current.Dispatcher.Invoke(() =>
                    {

                        LoginViewModel loginViewModel = new LoginViewModel();
                        LoginWindow loginWindow = new LoginWindow();

                        loginWindow.DataContext = loginViewModel;
                        loginViewModel.Window = loginWindow;

                        Close();
                        loginWindow.ShowDialog();

                    });

                }
                else
                {
                    Application.Current.Dispatcher.Invoke(ShowErrorPanel);
                }
            }
        }

        private void ShowErrorPanel()
        {
            firstPanel.Visibility = Visibility.Hidden;
            secondPanel.Visibility = Visibility.Visible;
        }
    }
}
