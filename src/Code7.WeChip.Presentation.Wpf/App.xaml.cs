using Code7.WeChip.Application.AutoMapper;
using Code7.WeChip.Application.Contracts;
using Code7.WeChip.IoC;
using SimpleInjector;
using System.Windows;

namespace Code7.WeChip.Presentation.Wpf
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly Container _container = BootStrapper.RegisterServices();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AutoMapperConfig.ResgiterMappings();

            MainWindow = _container.GetInstance<MainWindow>();

            MainWindow.Show();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _container.Dispose();
        }
    }

    public class MainWindowViewModel
    {
        private readonly ICustomerApp queryProcessor;

        public MainWindowViewModel(ICustomerApp queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }
    }
}
