using AutoMapper;
using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Application.Contracts.Logic.Services.Tags;
using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;
using InfoPortal.Application.Exeptions;
using InfoPortal.Domains.Entities;

namespace InfoPortal.Logic.Services
{
    public class TagsService : ITagsService
    {
        internal readonly INewsRepository _newsRepository;
        internal readonly ITagsRepository _tagsRepository;
        internal readonly IMapper _mapper;

        public TagsService(ITagsRepository tagsRepository, INewsRepository newsRepository,
            IMapper mapper)
        {
            _tagsRepository = tagsRepository;
            _mapper = mapper;
            _newsRepository = newsRepository;
        }

        public async Task CreateAsync(CreateTagDto tagDto)
        {
            var tagsDb = new TagDb()
            {
                Name = tagDto.Name,
            };
            try
            {
                await _tagsRepository.CreateAsync(tagsDb);
            }
            catch
            {
                throw new ConflictExeption(); 
            }

        }

        public async Task DeleteAsync(Guid Id)
        {
            await _tagsRepository.DeleteAsync(Id);
        }

        public async Task UpdateAsync(UpdateTagDto updateTagDto)
        {
            var tagDb = await _tagsRepository.GetAsync(updateTagDto.Id) ?? throw new NotFoundException();

            tagDb.Name = updateTagDto.Name;

            try
            {
                await _tagsRepository.UpdateAsync(tagDb);
            }
            catch
            {
                throw new ConflictExeption();
            }
        }

        public async Task<TagDto?> GetAsync(Guid Id)
        {
            var tagDb = await _tagsRepository.GetAsync(Id) ?? throw new NotFoundException();
            var tagDto = _mapper.Map<TagDto>(tagDb);
            return tagDto;
        }

        public async Task<List<TagDto>> GetAllAsync()
        {
            var getTagsDb = await _tagsRepository.GetAllAsync() ?? throw new NotFoundException();
            var getTagsDto = _mapper.Map<List<TagDto>>(getTagsDb);
            return getTagsDto;
        }
    }
}
