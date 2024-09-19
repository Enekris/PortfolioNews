using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Services.Interfaces;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace InfoPortalWpf.ViewModels.Pages
{
    public partial class NewsViewModel : DependencyObject, INotifyPropertyChanged
    {
        private readonly INewsService _newsService;
        private readonly ITagsService _tagsService;
        private readonly string _newName;
        private string _message;
        private string _errorMessage;
        private readonly CreateNews _createNews;
        private readonly UpdateNews _updateNews;
        private readonly News _news;
        private ObservableCollection<News> newsCollection { get; set; }
        public ObservableCollection<News> NewsCollection
        {
            get { return newsCollection; }
            set
            {
                newsCollection = value;
                OnPropertyChanged(nameof(newsCollection));
            }
        }

        private News selectedNews { get; set; }

        public News SelectedNews
        {
            get
            {
                return selectedNews;
            }
            set
            {
                selectedNews = value;
                OnPropertyChanged(nameof(SelectedNews));
            }
        }

        private ObservableCollection<Tag> tagsCollection { get; set; }

        public ObservableCollection<Tag> TagsCollection
        {
            get
            {
                return tagsCollection;
            }
            set
            {
                tagsCollection = value;
                OnPropertyChanged(nameof(tagsCollection));
            }
        }
        private ObservableCollection<Tag> showTagsCollection { get; set; }

        public ObservableCollection<Tag> ShowTagsCollection
        {
            get
            {
                return showTagsCollection;
            }
            set
            {
                showTagsCollection = value;
                OnPropertyChanged(nameof(ShowTagsCollection));
            }
        }
        private ObservableCollection<Tag> _tagsSuggestionsCollection;
        public ObservableCollection<Tag> TagsSuggestionsCollection
        {
            get { return _tagsSuggestionsCollection; }
            set
            {
                _tagsSuggestionsCollection = value;
                OnPropertyChanged(nameof(TagsSuggestionsCollection));
            }
        }

        private ObservableCollection<Tag> _tagsCreateSelectedSuggestionsCollection;
        public ObservableCollection<Tag> TagsCreateSelectedSuggestionsCollection
        {
            get { return _tagsCreateSelectedSuggestionsCollection; }
            set
            {
                _tagsCreateSelectedSuggestionsCollection = value;
                OnPropertyChanged(nameof(TagsCreateSelectedSuggestionsCollection));
            }
        }
        private Tag _selectedTagCreate;
        public Tag SelectedTagCreate
        {
            get { return _selectedTagCreate; }
            set
            {
                _selectedTagCreate = value;
                OnPropertyChanged(nameof(SelectedTagCreate));
            }
        }

        private ObservableCollection<Tag> _tagsUpdateSelectedSuggestionsCollection;
        public ObservableCollection<Tag> TagsUpdateSelectedSuggestionsCollection
        {
            get { return _tagsUpdateSelectedSuggestionsCollection; }
            set
            {
                _tagsUpdateSelectedSuggestionsCollection = value;
                OnPropertyChanged(nameof(TagsUpdateSelectedSuggestionsCollection));
            }
        }
        private Tag _selectedTagUpdate;
        public Tag SelectedTagUpdate
        {
            get { return _selectedTagUpdate; }
            set
            {
                _selectedTagUpdate = value;
                OnPropertyChanged(nameof(SelectedTagUpdate));
            }
        }
        public string CreateHeader
        {
            get { return _createNews.Header; }
            set
            {
                _createNews.Header = value;
                OnPropertyChanged(nameof(CreateHeader));
            }
        }
        public string CreateText
        {
            get { return _createNews.Text; }
            set
            {
                _createNews.Text = value;
                OnPropertyChanged(nameof(CreateText));
            }
        }

        public List<Guid?>? CreateTagsId
        {
            get { return _createNews.TagsId; }
            set
            {
                _createNews.TagsId = value;
                OnPropertyChanged(nameof(CreateTagsId));
            }
        }
        public string DeleteId
        {
            get
            {
                if (_news.Id == Guid.Empty)
                {
                    return "";
                }
                else
                {
                    return _news.Id.ToString();
                }
            }
            set
            {
                _news.Id = Guid.Parse(value);
                OnPropertyChanged(nameof(DeleteId));
            }
        }
        public string UpdateId
        {
            get
            {
                if (_updateNews.Id == Guid.Empty)
                {
                    return "";
                }
                else
                {
                    return _updateNews.Id.ToString();
                }
            }
            set
            {
                _updateNews.Id = Guid.Parse(value);
                OnPropertyChanged(nameof(DeleteId));
            }
        }
        public string UpdateHeader
        {
            get { return _updateNews.Header; }
            set
            {
                _updateNews.Header = value;
                OnPropertyChanged(nameof(UpdateHeader));
            }
        }
        public string UpdateText
        {
            get { return _updateNews.Text; }
            set
            {
                _updateNews.Text = value;
                OnPropertyChanged(nameof(UpdateText));
            }
        }

        public List<Guid> UpdateTagsId
        {
            get { return _updateNews.TagsId; }
            set
            {
                _updateNews.TagsId = value;
                OnPropertyChanged(nameof(UpdateTagsId));
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public IAsyncCommand CreateCommand { get; }
        public IAsyncCommand UpdateCommand { get; }
        public IAsyncCommand DeleteCommand { get; }
        public IAsyncCommand UpdateTable { get; }
        public ICommand CreateAddTagCommand { get; }
        public ICommand UpdateAddTagCommand { get; }
        public IAsyncCommand ShowTagsCommand { get; }

        public NewsViewModel(CreateNews createNews, INewsService newsService, ITagsService tagsService)
        {
            _newsService = newsService;
            _tagsService = tagsService;
            _createNews = createNews;
            TagsSuggestionsCollection = [];
            TagsCreateSelectedSuggestionsCollection = [];
            GetAllTagsAsync();
            CreateAddTagCommand = new RelayCommand(CreateAddTag);
            CreateCommand = new AsyncCommand(CreateAsync);
        }

        private void CreateAddTag()
        {
            if (SelectedTagCreate is not null)
            {
                TagsCreateSelectedSuggestionsCollection.Add(SelectedTagCreate);
            }
        }

        public NewsViewModel(UpdateNews updateNews, INewsService newsService, ITagsService tagsService)
        {
            _newsService = newsService;
            _updateNews = updateNews;
            _tagsService = tagsService;
            TagsSuggestionsCollection = [];
            TagsUpdateSelectedSuggestionsCollection = [];
            GetAllTagsAsync();
            UpdateAddTagCommand = new RelayCommand(UpdateAddTag);
            UpdateCommand = new AsyncCommand(UpdateAsync);
        }
        private void UpdateAddTag()
        {
            if (SelectedTagUpdate is not null)
            {
                TagsUpdateSelectedSuggestionsCollection.Add(SelectedTagUpdate);
            }
        }
        public NewsViewModel(News news, INewsService newsService)
        {
            _newsService = newsService;
            _news = news;
            NewsCollection = [];
            ShowTagsCollection = [];
            GetAllAsync();
            ShowTagsCommand = new AsyncCommand(ShowTags);
            UpdateTable = new AsyncCommand(GetAllAsync);
            DeleteCommand = new AsyncCommand(DeleteAsync);
        }
        public async Task ShowTags()
        {
            ShowTagsCollection = new ObservableCollection<Tag>(selectedNews.Tags);
        }
        public async Task GetAllAsync()
        {
            NewsCollection = new ObservableCollection<News>(await _newsService.GetAllAsync());
        }
        public async Task GetAllTagsAsync()
        {
            TagsSuggestionsCollection = new ObservableCollection<Tag>(await _tagsService.GetAllAsync());
        }
        public async Task GetAllSortedAsync()
        {
            await _newsService.GetAllSortedAsync();
        }

        public async Task CreateAsync()
        {

            if (_createNews != null)
            {
                if (TagsCreateSelectedSuggestionsCollection.Count > 0)
                {
                    _createNews.TagsId = [];
                    foreach (var tag in TagsCreateSelectedSuggestionsCollection)
                    {
                        _createNews.TagsId.Add(tag.Id);
                    }
                }
                await _newsService.CreateAsync(_createNews);
            }
        }
        public async Task UpdateAsync()
        {
            if (_updateNews != null)
            {
                if (TagsUpdateSelectedSuggestionsCollection.Count > 0)
                {
                    _updateNews.TagsId = [];
                    foreach (var tag in TagsUpdateSelectedSuggestionsCollection)
                    {
                        _updateNews.TagsId.Add(tag.Id);
                    }
                }
                await _newsService.UpdateAsync(_updateNews);
            }
        }
        public async Task DeleteAsync()
        {
            await _newsService.DeleteAsync(Guid.Parse(DeleteId));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

