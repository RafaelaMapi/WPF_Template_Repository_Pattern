using Caliburn.Micro;
using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using MainDesktopUI.ViewModels;

using Core.Interfaces.Services.Domain;
using Core.Services.Domain;

using DatabaseManager.DBConfiguration.SQLite;
using DatabaseManager.Interfaces.DBConfigurations;
using DatabaseManager.Interfaces.Repositories.Domain;
using DatabaseManager.Repositories.Domain;
using DatabaseManager.Repositories.Domain.SQLite;
using SQLite;

namespace MainDesktopUI
{
    

    public class Bootstrapper : BootstrapperBase
    {
        /// <summary>
        /// The diretory Log.
        /// </summary>
        private readonly string DBPath = System.IO.Directory.GetCurrentDirectory() + "\\Resources\\Database.db3";


        private SimpleContainer container;
        private  Serilog.ILogger serilog;
        private string dirlog = System.IO.Directory.GetCurrentDirectory() + "\\Resources\\logs.json";
        public Bootstrapper()
        {
            Initialize();
        }


       

        protected override void Configure()
        {
            container = new SimpleContainer();

            // Config the serilog
            serilog = ConfigureLogger();

            container.Instance(container);
            container.Instance(serilog);

            container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();





            // Path to the database file
            SQLiteAsyncConnection setSoftware = new SQLiteAsyncConnection(DBPath);


            // Add dependency injection for the repository. Pass the DBPath for the repo.
            container
                .Handler<IClientRepository>(_ => new ClientRepository(setSoftware));

            // Add dependency injection for the service.
            container
                .PerRequest<IClientService, ClientService>();





            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                base.OnStartup(sender, e);
                DisplayRootViewFor<MainViewModel>();
            }
            catch (Exception ex)
            {
                serilog.Fatal(ex.Message);
                serilog.Fatal(ex.StackTrace);               
            }
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs ex)
        {
            ex.Handled = true;
            serilog.Fatal(ex.Exception.Message);
            serilog.Fatal(ex.Exception.StackTrace);
            //MessageBox.Show(e.Exception.Message, "An error as occurred", MessageBoxButton.OK);
        }

        /// <summary>
        /// The configure logger.
        /// </summary>
        /// <returns>
        /// The <see cref="ILogger"/>.
        /// </returns>
        private static Serilog.ILogger ConfigureLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(new CompactJsonFormatter(), Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\GILI\\Logs\\logs.json")
                .CreateLogger();
        }

    }
}
