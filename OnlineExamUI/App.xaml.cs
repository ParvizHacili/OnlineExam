using Exam.Core.Domain.Enums;
using OnlineExamUI.ViewModels;
using OnlineExamUI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExamUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindow = new StartWindow();
            MainWindow.Show();


            LoginViewModel viewModel = new LoginViewModel();


            MainWindow.DataContext = viewModel;
            MainWindow.Show();
        }
    }
}
