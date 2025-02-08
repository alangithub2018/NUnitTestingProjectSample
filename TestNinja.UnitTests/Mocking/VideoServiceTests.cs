using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReaderMock;
        private Mock<IVideoRepository> _videoRepositoryMock;

        private VideoService _videoService;

        [SetUp]
        public void SetUp() 
        {
            _fileReaderMock = new Mock<IFileReader>();
            _videoRepositoryMock = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReaderMock.Object, _videoRepositoryMock.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {

            _fileReaderMock.Setup(fr => fr.Read("video.txt")).Returns(string.Empty);

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptystring()
        {
            _videoRepositoryMock.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _videoRepositoryMock.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 },
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
