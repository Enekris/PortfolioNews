using AutoMapper;
using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Application.Contracts.Logic.Services.News;
using InfoPortal.Application.Contracts.Logic.Services.News.Models;
using InfoPortal.Application.Exeptions;
using InfoPortal.Domains.Entities;

namespace InfoPortal.Logic.Services
{
    public class NewsService : INewsService
    {
        internal readonly INewsRepository _newsRepository;
        internal readonly ITagsRepository _tagsRepository;
        internal readonly IMapper _mapper;

        public NewsService(INewsRepository newsrepository, ITagsRepository tagsRepository,
            IMapper mapper)
        {
            _newsRepository = newsrepository;
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateNewsDto newsDto)
        {
            var tagsDb = new List<TagDb>();

            if (newsDto.TagsId.Count > 0)
            {
                foreach (var item in newsDto.TagsId)
                {
                    var tag = await _tagsRepository.GetAsync(item) ?? throw new NotFoundException();
                    tagsDb.Add(tag);
                }
            }

            var newsDb = new NewsDb()
            {
                Header = newsDto.Header,
                Text = newsDto.Text,
                Tags = tagsDb
            };
            try
            {
                await _newsRepository.CreateAsync(newsDb);
            }
            catch
            {
                throw new ConflictExeption(); //возможно не нужно
            }

        }

        public async Task DeleteAsync(Guid Id)
        {
            await _newsRepository.DeleteAsync(Id);
        }

        public async Task UpdateAsync(UpdateNewsDto updateNewsDto)
        {
            var newsDb = await _newsRepository.GetAsync(updateNewsDto.Id) ?? throw new NotFoundException();

            newsDb.Header = updateNewsDto.Header;
            newsDb.Text = updateNewsDto.Text;

            var allTags = await _tagsRepository.GetAllAsync();

            if (updateNewsDto.TagsId != null)
            {
                newsDb.Tags.Clear();
                foreach (var updateTagsId in updateNewsDto.TagsId)
                {
                    var tag = allTags.FirstOrDefault(p => p.Id == updateTagsId) ?? throw new NotFoundException(); 
                    newsDb.Tags.Add(tag);

                }
            }

            await _newsRepository.UpdateAsync(newsDb);

        }

        public async Task<List<NewsDto>> GetAllAsync()
        {
            var newsDb = await _newsRepository.GetAllAsync() ?? throw new NotFoundException();

            var newsDto = _mapper.Map<List<NewsDto>>(newsDb);
            return newsDto;
        }

        public async Task<List<NewsDto>> GetAllSortedAsync()
        {
            var newsDb = await _newsRepository.GetAllAsync() ?? throw new NotFoundException();

            var sortedNewsDb = newsDb.OrderBy(n => n.CreateDate).ThenBy(n => n.UpdateDate);
            var newsDto = _mapper.Map<List<NewsDto>>(newsDb);
            return newsDto;
        }

        public async Task<NewsDto> GetAsync(Guid Id)
        {
            var getNewsDb = await _newsRepository.GetAsync(Id) ?? throw new NotFoundException();

            var getNewsDto = _mapper.Map<NewsDto>(getNewsDb);
            return getNewsDto;
        }

    }
}
