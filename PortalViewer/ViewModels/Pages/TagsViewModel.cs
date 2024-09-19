using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Services.Interfaces;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace InfoPortalWpf.ViewModels.Pages
{
    public partial class TagsViewModel : DependencyObject, INotifyPropertyChanged
    {
        private readonly ITagsService _tagsService;
        private readonly Tag _tag;
        private readonly string _newName;
        private string _message;
        private string _errorMessage;
        private readonly CreateTag _createTag;
        private readonly UpdateTag _updateTag;
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

        public string CreateName
        {
            get { return _createTag.Name; }
            set
            {
                _createTag.Name = value;
                OnPropertyChanged(nameof(CreateName));
            }
        }
        public string DeleteId
        {
            get
            {
                if (_tag.Id == Guid.Empty)
                {
                    return "";
                }
                else
                {
                    return _tag.Id.ToString();
                }
            }
            set
            {
                _tag.Id = Guid.Parse(value);
                OnPropertyChanged(nameof(DeleteId));
            }
        }
        public string UpdateId
        {
            get
            {
                if (_updateTag.Id == Guid.Empty)
                {
                    return "";
                }
                else
                {
                    return _updateTag.Id.ToString();
                }
            }
            set
            {
                _updateTag.Id = Guid.Parse(value);
                OnPropertyChanged(nameof(DeleteId));
            }
        }
        public string UpdateName
        {
            get { return _updateTag.Name; }
            set
            {
                _updateTag.Name = value;
                OnPropertyChanged(nameof(UpdateName));
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

        public TagsViewModel(CreateTag createTag, ITagsService tagsService)
        {
            _tagsService = tagsService;
            _createTag = createTag;
            CreateCommand = new AsyncCommand(CreateAsync);
        }
        public TagsViewModel(UpdateTag updateTag, ITagsService tagsService)

        {
            _tagsService = tagsService;
            _updateTag = updateTag;
            UpdateCommand = new AsyncCommand(UpdateAsync);
        }
        public TagsViewModel(Tag tag, ITagsService tagsService)

        {
            _tagsService = tagsService;
            _tag = tag;
            TagsCollection = [];

            GetAllAsync();

            DeleteCommand = new AsyncCommand(DeleteAsync);
            UpdateTable = new AsyncCommand(GetAllAsync);
        }
        public async Task GetAllAsync()
        {
            TagsCollection = new ObservableCollection<Tag>(await _tagsService.GetAllAsync());
        }
        public async Task CreateAsync()
        {
            if (_createTag != null)
            {
                await _tagsService.CreateAsync(_createTag);
            }
        }
        public async Task UpdateAsync()
        {
            if (_updateTag != null)
            {
                await _tagsService.UpdateAsync(_updateTag);
            }
        }
        public async Task DeleteAsync()
        {
            await _tagsService.DeleteAsync(Guid.Parse(DeleteId));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

