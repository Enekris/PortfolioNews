using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class NewsPage
    {
        public NewsViewModel ViewModel { get; }
        public NewsPage(INewsService newsService)
        {
            NewsViewModel viewModel = new NewsViewModel(new News(), newsService);
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();

        }
        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            News selectedEntity = (News)dataGrid.SelectedItem;
            if (selectedEntity != null)
            {
                ViewModel.SelectedNews = selectedEntity;
            }
        }
    }
}
