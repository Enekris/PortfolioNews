using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class EditNewsPage
    {
        private NewsViewModel ViewModel { get; }
        public EditNewsPage(INewsService newsService, ITagsService tagsService)
        {
            NewsViewModel viewModel = new NewsViewModel(new Models.UpdateNews(), newsService, tagsService);
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();

        }
        private void AutoSuggestBox_SuggestionChosen(Wpf.Ui.Controls.AutoSuggestBox sender, Wpf.Ui.Controls.AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is Tag selectedTag)
            {
                ViewModel.SelectedTagUpdate = selectedTag;
            }
        }
    }
}
