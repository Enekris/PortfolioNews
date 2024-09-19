using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class CreateTagsPage
    {
        public CreateTagsPage(ITagsService tagsService)
        {
            TagsViewModel viewModel = new TagsViewModel(new CreateTag(), tagsService);
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
