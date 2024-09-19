using InfoPortalWpf.Views.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace InfoPortalWpf.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "InfoPortalWpf";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems =
        [

            new NavigationViewItem("Тег", SymbolRegular.Book20, typeof(TagsPage), new List<object>
            {
                new NavigationViewItem("Создать тег", SymbolRegular.Document20, typeof(Views.Pages.CreateTagsPage)),
                new NavigationViewItem("Изменить тег", SymbolRegular.Document20, typeof(Views.Pages.EditTagsPage)),
                new NavigationViewItem("Удалить тег", SymbolRegular.Document20, typeof(Views.Pages.DeleteTagsPage)),
            }),
            new NavigationViewItem("Новость", SymbolRegular.Book20, typeof(NewsPage), new List<object>
            {
                new NavigationViewItem("Создать новость", SymbolRegular.Document20, typeof(Views.Pages.CreateNewsPage)),
                new NavigationViewItem("Изменить новость", SymbolRegular.Document20, typeof(Views.Pages.EditNewsPage)),
                new NavigationViewItem("Удалить новость", SymbolRegular.Document20, typeof(Views.Pages.DeleteNewsPage)),
                //new NavigationViewItem("Получить список новостей", SymbolRegular.Document20, typeof(Views.Pages.EditTagsPage)),
            })
        ];

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems =
        [
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        ];

        //[ObservableProperty]
        //private ObservableCollection<MenuItem> _trayMenuItems = new()
        //{
        //    new MenuItem { Header = "Home", Tag = "tray_home" }
        //};
    }
}
