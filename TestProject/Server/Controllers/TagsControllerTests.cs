using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.TagsService;

namespace TestProject.Server.Controllers
{
    public class TagsControllerTests
    {
        private readonly ITagsService _tagsService;
        public TagsControllerTests()
        {
            _tagsService = A.Fake<ITagsService>();
        }

        [Fact]
        public async void GetAllTags_ReturnsCorrectTagAmmount()
        {
            // Arrange
            int count = 5;
            var TagsList = A.CollectionOfDummy<Tag>(count).ToList();
            A.CallTo(() => _tagsService.GetAllTags(true)).Returns(TagsList);
            var controller = new TagsController(_tagsService);

            // Act
            var actionResult = await controller.GetAllTags();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedTags = result.Value as List<Tag>;
            Assert.Equal(count, returnedTags.Count);
        }

        [Fact]
        public async Task GetTag_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeDescription = "Aprasas";
            var fakeTag = new Tag { Id = fakeId, Name = fakeName, Description = fakeDescription };
            A.CallTo(() => _tagsService.GetTag(fakeId)).Returns(Task.FromResult(fakeTag));
            var controller = new TagsController(_tagsService);

            // Act
            var actionResult = await controller.GetTag(fakeId);

            // Assert
            var result0 = actionResult.Result;
            var result = result0 as OkObjectResult;
            var actualValue = result.Value as Tag;
            Assert.Equal(fakeTag, actualValue);
        }

        [Fact]
        public async Task AddTag_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeDescription = "Aprasas";
            var fakeTag = new Tag { Id = fakeId, Name = fakeName, Description = fakeDescription };
            var fakeTagDto = new AddTagDto { Name = fakeName, Description = fakeDescription };
            A.CallTo(() => _tagsService.AddTag(fakeTagDto)).Returns(Task.FromResult(fakeTag));
            var controller = new TagsController(_tagsService);

            // Act
            var actionResult = await controller.AddTag(fakeTagDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedTag = result.Value as Tag;
            Assert.Equal(fakeTag, returnedTag);
        }

        [Fact]
        public async Task UpdateTag_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            string fakeDescription = "Aprasymas";
            var fakeTag = new Tag { Id = fakeId, Name = fakeName, Description = fakeDescription };
            var fakeTagDto = new UpdateTagDto { Name = fakeName, Description = fakeDescription };
            A.CallTo(() => _tagsService.UpdateTag(fakeTagDto, fakeId)).Returns(Task.FromResult(fakeTag));
            var controller = new TagsController(_tagsService);

            // Act
            var actionResult = await controller.UpdateTag(fakeTagDto, fakeId);

            // Assert
            var result0 = actionResult.Result;
            var result = result0 as ObjectResult;
            var returnedTag = result.Value as Tag;
            Assert.Equal(fakeTag, returnedTag);
        }

        [Fact]
        public async Task DeleteTag_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _tagsService.DeleteTag(fakeId)).Returns(Task.FromResult(new Tag()));
            var controller = new TagsController(_tagsService);

            // Act
            var actionResult = await controller.DeleteTag(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
