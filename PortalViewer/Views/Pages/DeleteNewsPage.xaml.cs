using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class DeleteNewsPage
    {
        public DeleteNewsPage(INewsService newsService)
        {
            NewsViewModel viewModel = new NewsViewModel(new Models.News(), newsService);
            DataContext = viewModel;
            InitializeComponent();
        }

    }

}
