using CadastroPessoasApp.Repository;
using CadastroPessoasApp.Repository.Interface;
using CadastroPessoasApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CadastroPessoasApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IPeopleRepository, PeopleRepository>();

            services.AddSingleton<PeopleViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<PeopleViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
