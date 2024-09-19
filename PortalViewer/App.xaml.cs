using AutoMapper;
using InfoPortalWpf.Models;
using InfoPortalWpf.Services;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services;
using InfoPortalWpf.ViewModels.Windows;
using InfoPortalWpf.Views.Pages;
using InfoPortalWpf.Views.Windows;
using InfoPortal.Api.Client.Configuration;
using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Wpf.Ui;


namespace InfoPortalWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

        private readonly string appSettingsFilePath = "appsettings.json";
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();

                // Page resolver service
                services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                //services.AddAutoMapper(typeof(WpfMappingProfile));
                // Main window with navigation
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();

                services.AddWpfServices(); //сюда смотри
                services.AddAutoMapper(typeof(WpfMappingProfile));
                //services.AddSingleton<IApiClient,ApiClient>(); //сюда смотри
                var configuration = context.Configuration;
                services.AddClient(configuration);
                services.AddSingleton<TagsPage>();
                services.AddSingleton<CreateTagsPage>();
                services.AddSingleton<EditTagsPage>();
                services.AddSingleton<DeleteTagsPage>();
                services.AddSingleton<TagsViewModel>();

                services.AddSingleton<NewsPage>();
                services.AddSingleton<CreateNewsPage>();
                services.AddSingleton<EditNewsPage>();
                services.AddSingleton<DeleteNewsPage>();
                services.AddSingleton<NewsViewModel>();

            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            //  DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var uiMessageBox = new Wpf.Ui.Controls.MessageBox
            {
                Title = "Unexpected Error",
                Content =
       e.Exception.Message,
            };
            uiMessageBox.ShowDialogAsync();
            e.Handled = true;
        }

        private class WpfMappingProfile : Profile  //не знаю куда покрасивее вставить
        {
            public WpfMappingProfile()
            {
                CreateMap<CreateNewsModel, CreateNews>().ReverseMap();
                CreateMap<CreateTagModel, CreateTag>().ReverseMap();
                CreateMap<UpdateNewsModel, UpdateNews>().ReverseMap();
                CreateMap<UpdateTagModel, UpdateTag>().ReverseMap();
                CreateMap<NewsModel, News>().ReverseMap();
                CreateMap<TagModel, Tag>().ReverseMap();
            }
        }
    }
}
