using B3Digitas.Todo.Business.Interfaces;
using B3Digitas.Todo.Business.Services;
using B3Digitas.Todo.Domain;
using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Repositories;
using Moq;
using TechTalk.SpecFlow;

namespace B3Digitas.Todo.Tests.Steps;

public class TagServiceTests
{
    [Binding]
    public class TagServiceSteps
    {
        private readonly Mock<ITagRepository> _tagRepository;
        private readonly ITagService _tagService;
        private Result<Tag> _createResult;
        private Result<Tag> _getResult;
        private Result<IEnumerable<Tag>> _getAllResult;
        private Result<Tag> _updateResult;
        private Result<Tag> _deleteResult;
        private Guid _existingTagId;
        private Tag _existingTag;
        private List<Tag> _tagList;

        public TagServiceSteps()
        {
            _tagRepository = new Mock<ITagRepository>();
            _tagService = new TagService(_tagRepository.Object);
            _existingTagId = Guid.NewGuid();
            _existingTag = new Tag { Id = _existingTagId, Name = "ExistingTag" };
            _tagList = new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Name = "Tag1" },
                new Tag { Id = Guid.NewGuid(), Name = "Tag2" }
            };
        }

        

        [Given(@"an existing tag with name ""(.*)""")]
        public void GivenAnExistingTagWithName(string name)
        {
            _tagRepository.Setup(repo => repo.GetByTitleAsync(name))
                          .ReturnsAsync(new Result<Tag>
                          {
                              IsSuccess = true,
                              ResponseBody = _existingTag
                          });
        }

        [Given(@"no existing tag with name ""(.*)""")]
        public void GivenNoExistingTagWithName(string name)
        {
            _tagRepository.Setup(repo => repo.GetByTitleAsync(name))
                          .ReturnsAsync(new Result<Tag>
                          {
                              IsSuccess = false,
                              ResponseBody = null
                          });
        }

        [Given(@"an existing tag with ID ""(.*)""")]
        public void GivenAnExistingTagWithID(string id)
        {
            var tagId = Guid.Parse(id);
            _tagRepository.Setup(repo => repo.GetAsync(tagId))
                          .ReturnsAsync(new Result<Tag>
                          {
                              IsSuccess = true,
                              ResponseBody = _existingTag
                          });
        }

        [Given(@"no existing tag with ID ""(.*)""")]
        public void GivenNoExistingTagWithID(string id)
        {
            var tagId = Guid.Parse(id);
            _tagRepository.Setup(repo => repo.GetAsync(tagId))
                          .ReturnsAsync(new Result<Tag>
                          {
                              IsSuccess = false,
                              ResponseBody = null,
                              Message = "Tag não encontrada."
                          });
        }

        [Given(@"existing tags")]
        public void GivenExistingTags()
        {
            _tagRepository.Setup(repo => repo.GetAllAsync())
                          .ReturnsAsync(new Result<IEnumerable<Tag>>
                          {
                              IsSuccess = true,
                              ResponseBody = _tagList
                          });
        }

        [When(@"I try to create a tag with the same name")]
        public async Task WhenITryToCreateATagWithTheSameName()
        {
            var Tag = new Tag { Name = _existingTag.Name };
            _createResult = await _tagService.CreateAsync(Tag);
        }

        [When(@"I create a tag with name ""(.*)""")]
        public async Task WhenICreateATagWithName(string name)
        {
            var Tag = new Tag { Name = name };
            _createResult = await _tagService.CreateAsync(Tag);
        }

        [When(@"I get the tag by ID ""(.*)""")]
        public async Task WhenIGetTheTagByID(string id)
        {
            var tagId = Guid.Parse(id);
            _getResult = await _tagService.GetAsync(tagId);
        }

        [When(@"I get all tags")]
        public async Task WhenIGetAllTags()
        {
            _getAllResult = await _tagService.GetAllAsync();
        }

        [When(@"I update the tag with ID ""(.*)""")]
        public async Task WhenIUpdateTheTagWithID(string id)
        {
            var tagId = Guid.Parse(id);
            var Tag = new Tag { Id = tagId, Name = "UpdatedTag" };
            _updateResult = await _tagService.UpdateAsync(tagId, Tag);
        }

        [When(@"I delete the tag with ID ""(.*)""")]
        public async Task WhenIDeleteTheTagWithID(string id)
        {
            var tagId = Guid.Parse(id);
            _deleteResult = await _tagService.DeleteAsync(tagId);
        }

        [When(@"I get the tag by title ""(.*)""")]
        public async Task WhenIGetTheTagByTitle(string title)
        {
            _getResult = await _tagService.GetByTitleAsync(title);
        }

        [Then(@"the creation should fail with message ""(.*)""")]
        public void ThenTheCreationShouldFailWithMessage(string message)
        {
            Assert.False(_createResult.IsSuccess);
            Assert.Equal(message, _createResult.Message);
        }

        [Then(@"the creation should succeed")]
        public void ThenTheCreationShouldSucceed()
        {
            Assert.True(_createResult.IsSuccess);
        }

        [Then(@"the tag should be returned")]
        public void ThenTheTagShouldBeReturned()
        {
            Assert.True(_getResult.IsSuccess);
            Assert.NotNull(_getResult.ResponseBody);
        }

        [Then(@"the operation should fail with message ""(.*)""")]
        public void ThenTheOperationShouldFailWithMessage(string message)
        {
            Assert.False(_getResult.IsSuccess);
            Assert.Equal(message, _getResult.Message);
        }

        [Then(@"all tags should be returned")]
        public void ThenAllTagsShouldBeReturned()
        {
            Assert.True(_getAllResult.IsSuccess);
            Assert.NotNull(_getAllResult.ResponseBody);
            Assert.Equal(_tagList.Count, _getAllResult.ResponseBody.Count());
        }

        [Then(@"the update should succeed")]
        public void ThenTheUpdateShouldSucceed()
        {
            Assert.True(_updateResult.IsSuccess);
        }

        [Then(@"the deletion should succeed")]
        public void ThenTheDeletionShouldSucceed()
        {
            Assert.True(_deleteResult.IsSuccess);
        }

    }
}
