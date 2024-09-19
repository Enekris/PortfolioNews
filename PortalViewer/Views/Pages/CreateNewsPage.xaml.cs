// This Source Code Form is subject to the terms of the MIT License.
using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class CreateNewsPage
    {
        private NewsViewModel ViewModel { get; }
        public CreateNewsPage(INewsService newsService, ITagsService tagsService)
        {
            NewsViewModel viewModel = new NewsViewModel(new Models.CreateNews(), newsService, tagsService);
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();

        }
        private void AutoSuggestBox_SuggestionChosen(Wpf.Ui.Controls.AutoSuggestBox sender, Wpf.Ui.Controls.AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is Tag selectedTag)
            {
                ViewModel.SelectedTagCreate = selectedTag;
            }
        }
    }
}
