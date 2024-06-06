using B3Digitas.Todo.Business.Services;
using B3Digitas.Todo.Domain;
using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Interfaces.Repositories;
using B3Digitas.Todo.Domain.Interfaces.Services;
using Moq;
using TechTalk.SpecFlow;

namespace MyTodoApp.Tests
{
    [Binding]
    public class TodoServiceSteps
    {
        private readonly Mock<ITodoRepository> _todoRepository;
        private readonly Mock<ITagRepository> _tagRepository;
        private readonly ITodoService _todoService;
        private Result<Todo> _createResult;
        private Result<Todo> _getResult;
        private Result<IEnumerable<Todo>> _getAllResult;
        private Result<Todo> _updateResult;
        private Result<Todo> _deleteResult;
        private Guid _existingTodoId;
        private Todo _existingTodo;
        private List<Todo> _todoList;

        public TodoServiceSteps()
        {
            _todoRepository = new Mock<ITodoRepository>();
            _tagRepository = new Mock<ITagRepository>();
            _todoService = new TodoService(_todoRepository.Object, _tagRepository.Object);
            _existingTodoId = Guid.NewGuid();
            _existingTodo = new Todo { Id = _existingTodoId, Title = "ExistingTodo" };
            _todoList = new List<Todo>
            {
                new Todo { Id = Guid.NewGuid(), Title = "Todo1" },
                new Todo { Id = Guid.NewGuid(), Title = "Todo2" }
            };
        }

        #region Create a todo that already exists

        [Given(@"an existing todo with title ""(.*)""")]
        public void GivenAnExistingTodoWithTitle(string title)
        {
            _todoRepository.Setup(repo => repo.GetByTitleAsync(title))
                          .ReturnsAsync(new Result<Todo>
                          {
                              IsSuccess = true,
                              ResponseBody = _existingTodo
                          });
        }

        [When(@"I try to create a todo with the same title")]
        public async Task WhenITryToCreateATodoWithTheSameTitle()
        {
            var Todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = _existingTodo.Title,
                Description = _existingTodo.Description,
            };
            _createResult = await _todoService.CreateAsync(Todo);
        }

        [Then(@"the creation should fail with message ""(.*)""")]
        public void ThenTheCreationShouldFailWithMessage(string message)
        {
            Assert.False(_createResult.IsSuccess);
            Assert.Equal(message, _createResult.Message);
        }
        #endregion

        #region Create a new todo
        [Given(@"no existing todo with title ""(.*)""")]
        public void GivenNoExistingTodoWithTitle(string title)
        {
            _todoRepository.Setup(repo => repo.GetByTitleAsync(title))
                          .ReturnsAsync(new Result<Todo>
                          {
                              IsSuccess = false,
                              ResponseBody = null
                          });
        }

        [When(@"I create a todo with title ""(.*)""")]
        public async Task WhenICreateATodoWithTitle(string title)
        {
            var Todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = "New Description"
            };
            _createResult = await _todoService.CreateAsync(Todo);
        }

        [Then(@"the creation should succeed")]
        public void ThenTheCreationShouldSucceed()
        {
            Assert.True(_createResult.IsSuccess);
        }


        #endregion

        #region Get a todo by ID that exists
        
        [Given(@"an existing todo with ID ""(.*)""")]
        public void GivenAnExistingTodoWithID(string id)
        {
            var todoId = Guid.Parse(id);
            _todoRepository.Setup(repo => repo.GetAsync(todoId))
                          .ReturnsAsync(new Result<Todo>
                          {
                              IsSuccess = true,
                              ResponseBody = _existingTodo
                          });
        }

        [When(@"I get the todo by ID ""(.*)""")]
        public async Task WhenIGetTheTodoByID(string id)
        {
            var todoId = Guid.Parse(id);
            _getResult = await _todoService.GetAsync(todoId);
        }
        
        [Then(@"the todo should be returned")]
        public void ThenTheTodoShouldBeReturned()
        {
            Assert.True(_getResult.IsSuccess);
            Assert.NotNull(_getResult.ResponseBody);
        }

        #endregion

        #region  Get a todo by ID that does not exist
        [Given(@"no existing todo with ID ""(.*)""")]
        public void GivenNoExistingTodoWithID(string id)
        {
            var todoId = Guid.Parse(id);
            _todoRepository.Setup(repo => repo.GetAsync(todoId))
                          .ReturnsAsync(new Result<Todo>
                          {
                              IsSuccess = false,
                              ResponseBody = null,
                              Message = "Tarefa não encontrada."
                          });
        }

        [Then(@"the operation should fail with message ""(.*)""")]
        public void ThenTheOperationShouldFailWithMessage(string message)
        {
            Assert.False(_getResult.IsSuccess);
            Assert.Equal(message, _getResult.Message);
        }

        #endregion

        #region Get all todos

        [Given(@"existing todos")]
        public void GivenExistingTodos()
        {
            _todoRepository.Setup(repo => repo.GetAllAsync())
                          .ReturnsAsync(new Result<IEnumerable<Todo>>
                          {
                              IsSuccess = true,
                              ResponseBody = _todoList
                          });
        }

        [When(@"I get all todos")]
        public async Task WhenIGetAllTodos()
        {
            _getAllResult = await _todoService.GetAllAsync();
        }

        [Then(@"all todos should be returned")]
        public void ThenAllTodosShouldBeReturned()
        {
            Assert.True(_getAllResult.IsSuccess);
            Assert.NotNull(_getAllResult.ResponseBody);
            Assert.Equal(_todoList.Count, _getAllResult.ResponseBody.Count());
        }

        #endregion

        #region Update a todo that exists

        [When(@"I update the todo with ID ""(.*)""")]
        public async Task WhenIUpdateTheTodoWithID(string id)
        {
            var todoId = Guid.Parse(id);
            var Todo = new Todo { Id = todoId, Title = "UpdatedTodo" };
            _updateResult = await _todoService.UpdateAsync(todoId, Todo);
        }

        [Then(@"the update should succeed")]
        public void ThenTheUpdateShouldSucceed()
        {
            Assert.True(_updateResult.IsSuccess);
        }

        #endregion

        #region Delete a todo that exists
        
        [When(@"I delete the todo with ID ""(.*)""")]
        public async Task WhenIDeleteTheTodoWithID(string id)
        {
            var todoId = Guid.Parse(id);
            _deleteResult = await _todoService.DeleteAsync(todoId);
        }

        [Then(@"the deletion should succeed")]
        public void ThenTheDeletionShouldSucceed()
        {
            Assert.True(_deleteResult.IsSuccess);
        }
        
        #endregion

    }
}
