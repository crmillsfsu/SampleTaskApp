using Microsoft.AspNetCore.Mvc;
using TaskManagement.Library.Models;
//using TaskManagement.Library.Database;
using TaskManagement.Api.EC;
using TaskManagement.Library.DTO;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController
    {
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ToDoDTO> Get()
        {
            return new ToDoEC().GetToDos();
        }

        [HttpPost]
        public ToDoDTO AddOrUpdate([FromBody] ToDoDTO dto)
        {
            return new ToDoEC().AddOrUpdateToDo(dto);
        }

    }
}
