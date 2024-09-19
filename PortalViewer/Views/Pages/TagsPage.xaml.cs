using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class TagsPage
    {
        public TagsViewModel ViewModel { get; }
        public TagsPage(ITagsService tagsService)
        {
            TagsViewModel viewModel = new TagsViewModel(new Tag(), tagsService);
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
