using OnlineExamUI.Commands;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OnlineExamUI.ViewModels.Windows
{
    public class ConfigurationViewModel : BaseViewModel
    {
        public ConfigurationViewModel()
        {
            //DbSettings = new DbSettings();
        }
        public DbSettings DbSettings { get; set; }
    }
}
