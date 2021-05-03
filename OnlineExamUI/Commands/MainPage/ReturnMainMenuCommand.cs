using Exam.ViewModels.UserControls;
using OnlineExamUI.Commands.Subjects;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views;
using OnlineExamUI.Views.UserControls;

namespace OnlineExamUI.Commands.MainPage
{
    public class ReturnMainMenuCommand : BaseCommand
    {
        private readonly MainViewModel viewModel;
        public ReturnMainMenuCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            MainWindow mainWindow = (MainWindow)viewModel.Window;

            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(new MenuControl());
        }
    }
}
