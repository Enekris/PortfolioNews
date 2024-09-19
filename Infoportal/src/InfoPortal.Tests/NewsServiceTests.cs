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

namespace InfoPortal.Tests
{
    [TestFixture]
    public class NewsServiceTests
    {
        private Mock<INewsRepository> _newsRepositoryMock;
        private Mock<ITagsRepository> _tagsRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private INewsService _newsService;

        [SetUp]
        public void SetUp()
        {
            _newsRepositoryMock = new Mock<INewsRepository>();
            _tagsRepositoryMock = new Mock<ITagsRepository>();
            _mapperMock = new Mock<IMapper>();
            _newsService = new NewsService(_newsRepositoryMock.Object, _tagsRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetAllAsync_WhenNotFound()
        {
            // var nullList = new List<NewsDb>();
            _newsRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync((List<NewsDb>)null);

            // NUnit.Framework.Assert.Equals(nullList, await newsService.GetAllAsync());
            Assert.ThrowsAsync<NotFoundException>(async () => await _newsService.GetAllAsync());
        }
        [Test]
        public async Task GetAllAsync_WhenFound()
        {
            var newsListDb = new List<NewsDb>
        {
            new NewsDb
            {
                Header = "header",
                Text = "text"
            }
        };

            var newsListDto = new List<NewsDto>
        {
            new NewsDto
            {
                Header = "header",
                Text = "text"
            }
        };

            _newsRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(newsListDb);
            _mapperMock.Setup(m => m.Map<List<NewsDto>>(newsListDb)).Returns(newsListDto);

            var newsListDbFromRepo = await _newsService.GetAllAsync();

            // var newsListDto1=_mapperMock.Setup(m => m.Map<List<NewsDto>>(newsListDb));
            Assert.NotNull(newsListDbFromRepo);

            Assert.AreEqual(newsListDbFromRepo, newsListDto);
        }
        [Test]
        public async Task GetEntity_WhenNotFound()
        {
            var guid = new Guid();

            _newsRepositoryMock.Setup(repo => repo.GetAsync(guid)).ReturnsAsync((NewsDb)null);

            Assert.ThrowsAsync<NotFoundException>(async () => await _newsService.GetAsync(guid));
        }
        [Test]
        public async Task GetEntity_WhenFound()
        {
            var guid = new Guid();

            var newsDb = new NewsDb
            {
                Header = "header",
                Text = "text"
            };

            var newsDTo = new NewsDto
            {
                Header = "header",
                Text = "text"
            };

            _newsRepositoryMock.Setup(repo => repo.GetAsync(guid)).ReturnsAsync(newsDb);
            _mapperMock.Setup(m => m.Map<NewsDto>(newsDb)).Returns(newsDTo);

            Assert.AreEqual(newsDTo, await _newsService.GetAsync(guid));
        }
        [Test]
        public async Task Update_WhenNotFoundTags()
        {
            var newsDTo = new UpdateNewsDto
            {  
                Id = new Guid(),
                Header = "header1",
                Text = "text1",
                TagsId = new List<Guid>
                {
                    new Guid()
                }
            };

            var newsDb = new NewsDb
            {
                Id = newsDTo.Id,
                Header = newsDTo.Header,
                Text = newsDTo.Text,

            };

           // _newsRepositoryMock.Setup(r => r.UpdateAsync(newsDb));
            _tagsRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync((List<TagDb>)null);
            Assert.ThrowsAsync<NotFoundException>(async () => await _newsService.UpdateAsync(newsDTo));
        }
        [Test]
        public async Task Update_WhenNotFoundNews()
        {
            var newsDTo = new UpdateNewsDto
            {
                Id = new Guid(),
                Header = "header1",
                Text = "text1",
                TagsId = new List<Guid>
                {
                    new Guid()
                }
            };

            _newsRepositoryMock.Setup(r => r.GetAsync(newsDTo.Id)).ReturnsAsync((NewsDb)null);
            Assert.ThrowsAsync<NotFoundException>(async () => await _newsService.UpdateAsync(newsDTo));
        }

        [Test]
        public async Task Update_WhenAllOk()
        {
            var newsDTo = new UpdateNewsDto
            {
                Id = new Guid(),
                Header = "header1",
                Text = "text1",
                TagsId = new List<Guid>
                {
                    new Guid()
                }
            };

            var newsDb = new NewsDb
            {
                Id = newsDTo.Id,
                Header = "header2",
                Text = "text2",

            };
            var newsDbList = new List<NewsDb>() { newsDb };

            _newsRepositoryMock.Setup(r => r.GetAsync(newsDTo.Id)).ReturnsAsync(newsDb);
            _tagsRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<TagDb>() { new TagDb() { Id= newsDTo.TagsId[0] } } );
            _newsRepositoryMock.Setup(repo => repo.UpdateAsync(newsDb)).Returns(Task.CompletedTask);

            await _newsService.UpdateAsync(newsDTo);

            _newsRepositoryMock.Verify(repo => repo.GetAsync(newsDTo.Id), Times.Once);
            _tagsRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _newsRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<NewsDb>(n => n.Header == newsDTo.Header && n.Text == newsDTo.Text && n.Tags.Count == 1)), Times.Once);
        }
    }

}