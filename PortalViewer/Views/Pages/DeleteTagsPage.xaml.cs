using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class DeleteTagsPage
    {
        public DeleteTagsPage(ITagsService tagsService)
        {
            TagsViewModel viewModel = new TagsViewModel(new Tag(), tagsService);
            DataContext = viewModel;
            InitializeComponent();

        }
    }
}
