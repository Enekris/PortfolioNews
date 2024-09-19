using AutoMapper;
using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Application.Contracts.Logic.Services.News;
using Moq;
using NUnit.Framework;
using InfoPortal.Logic.Services;
using InfoPortal.Application.Contracts.Logic.Services.News.Models;
using InfoPortal.Domains.Entities;
using InfoPortal.Application.Exeptions;
using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;
using InfoPortal.Application.Contracts.Logic.Services.Tags;
using System;

namespace InfoPortal.Tests
{
    [TestFixture]
    public class TagServiceTests
    {
        private Mock<INewsRepository> _newsRepositoryMock;
        private Mock<ITagsRepository> _tagsRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private ITagsService _tagService;

        [SetUp]
        public void SetUp()
        {
            _newsRepositoryMock = new Mock<INewsRepository>();
            _tagsRepositoryMock = new Mock<ITagsRepository>();
            _mapperMock = new Mock<IMapper>();
            _tagService = new TagsService(_tagsRepositoryMock.Object, _newsRepositoryMock.Object,  _mapperMock.Object);
        }

        [Test]
        public async Task GetAllAsync_WhenNotFound()
        {
            _tagsRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync((List<TagDb>)null);

            Assert.ThrowsAsync<NotFoundException>(async () => await _tagService.GetAllAsync());
        }
        [Test]
        public async Task GetAllAsync_WhenFound()
        {
            var tagListDb = new List<TagDb>
        {
            new TagDb
            {
                Name = "Name",
            }
        };

            var tagListDto = new List<TagDto>
        {
            new TagDto
            {
                Name = "Name",
            }
        };

            _tagsRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tagListDb);
            _mapperMock.Setup(m => m.Map<List<TagDto>>(tagListDb)).Returns(tagListDto);

            var tagListDbFromRepo = await _tagService.GetAllAsync();

            Assert.NotNull(tagListDbFromRepo);

            Assert.AreEqual(tagListDbFromRepo, tagListDto);
        }
        [Test]
        public async Task GetEntity_WhenNotFound()
        {
            var guid = new Guid();

            _tagsRepositoryMock.Setup(repo => repo.GetAsync(guid)).ReturnsAsync((TagDb)null);

            Assert.ThrowsAsync<NotFoundException>(async () => await _tagService.GetAsync(guid));
        }
        [Test]
        public async Task GetEntity_WhenFound()
        {
            var guid = new Guid();

            var tagDb = new TagDb
            {
                Name = "Name",
            };

            var tagDto = new TagDto
            {
                Name = "Name",
            };

            _tagsRepositoryMock.Setup(repo => repo.GetAsync(guid)).ReturnsAsync(tagDb);
            _mapperMock.Setup(m => m.Map<TagDto>(tagDb)).Returns(tagDto);

            Assert.AreEqual(tagDto, await _tagService.GetAsync(guid));
        }
        [Test]
        public async Task Create_WhenConflictExeption()
        {
            var tagDto = new CreateTagDto
            {
                Name = "Name",
            };

            _tagsRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<TagDb>())).ThrowsAsync(new ConflictExeption());

            Assert.ThrowsAsync<ConflictExeption>(async () => await _tagService.CreateAsync(tagDto));

        }
        [Test]
        public async Task Create_WhenAllOk()
        {
            var tagDto = new CreateTagDto
            {
                Name = "Name",
            };
            var tagsDb = new TagDb()
            {
                Name = tagDto.Name,
            };
            _tagsRepositoryMock.Setup(r => r.CreateAsync(tagsDb)).Returns(Task.CompletedTask);

            await _tagService.CreateAsync(tagDto);

            _tagsRepositoryMock.Verify(r => r.CreateAsync(It.Is<TagDb>(n => n.Name == tagDto.Name)), Times.Once);
        }
            [Test]
        public async Task Update_WhenNotFoundException()
        {
            var tagDto = new UpdateTagDto
            {  
                Id = new Guid(),
                Name = "Name",
            };

            _tagsRepositoryMock.Setup(r => r.GetAsync(tagDto.Id)).ReturnsAsync((TagDb)null);
            Assert.ThrowsAsync<NotFoundException>(async () => await _tagService.UpdateAsync(tagDto));
           
        }

        [Test]
        public async Task Update_WhenConflictExeption()
        {
            var tagDto = new UpdateTagDto
            {
                Id = new Guid(),
                Name = "Name",
            };

            var tagDb = new TagDb
            {
                Id = tagDto.Id,
                Name = tagDto.Name,
            };

            _tagsRepositoryMock.Setup(r => r.GetAsync(tagDto.Id)).ReturnsAsync(tagDb);
            _tagsRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<TagDb>())).ThrowsAsync(new ConflictExeption());
            Assert.ThrowsAsync<ConflictExeption>(async () => await _tagService.UpdateAsync(tagDto));
        }
        [Test]
        public async Task Update_WhenNotFoundtag()
        {
            var tagDto = new UpdateTagDto
            {
                Id = new Guid(),
                Name = "Name",
                NewsId = new List<Guid>
                {
                    new Guid()
                }
            };

            _tagsRepositoryMock.Setup(r => r.GetAsync(tagDto.Id)).ReturnsAsync((TagDb)null);
            Assert.ThrowsAsync<NotFoundException>(async () => await _tagService.UpdateAsync(tagDto));
        }

        [Test]
        public async Task Update_WhenAllOk()
        {
            var tagDto = new UpdateTagDto
            {
                Id = new Guid(),
                Name = "Name1",
            };

            var tagDb = new TagDb
            {
                Id = tagDto.Id,
                Name = "Name2",

            };

            _tagsRepositoryMock.Setup(r => r.GetAsync(tagDto.Id)).ReturnsAsync(tagDb);
            _tagsRepositoryMock.Setup(repo => repo.UpdateAsync(tagDb)).Returns(Task.CompletedTask);

            await _tagService.UpdateAsync(tagDto);

            _tagsRepositoryMock.Verify(repo => repo.GetAsync(tagDto.Id), Times.Once);
            _tagsRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<TagDb>(n => n.Name == tagDto.Name )), Times.Once);
        }
    }

}