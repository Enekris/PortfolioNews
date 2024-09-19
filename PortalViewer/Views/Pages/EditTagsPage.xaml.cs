using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Pages;
using InfoPortalWpf.ViewModels.Services.Interfaces;

namespace InfoPortalWpf.Views.Pages
{
    public partial class EditTagsPage
    {

        public EditTagsPage(ITagsService tagsService)
        {
            TagsViewModel viewModel = new TagsViewModel(new UpdateTag(), tagsService);
            DataContext = viewModel;
            InitializeComponent();

        }
    }
}
