using TaskManagement.Api.Database;
using TaskManagement.Api.Database.DEPRECATED;
using TaskManagement.Library.DTO;
using TaskManagement.Library.Models;

namespace TaskManagement.Api.EC
{
    public class ToDoEC
    {
        public List<ToDoDTO> GetToDos()
        {
            return FakeDatabaseContext.ToDos.Select(t => new ToDoDTO(t)).ToList();
        }

        public ToDoDTO AddOrUpdateToDo(ToDoDTO t)
        {

            if(t.Id > 0)
            {
                var itemToUpdate = FakeDatabaseContext.ToDos.FirstOrDefault(t => t.Id == t.Id);
               
                if (itemToUpdate != null)
                {
                    var indexOfItem = FakeDatabaseContext.ToDos.IndexOf(itemToUpdate);
                    FakeDatabaseContext.ToDos.RemoveAt(indexOfItem);
                    FakeDatabaseContext.ToDos.Insert(indexOfItem, new ToDo(t));
                }

            }else
            {
                var lastId = FakeDatabaseContext.ToDos.Select(t => t.Id).Max();
                t.Id = ++lastId;
                FakeDatabaseContext.ToDos.Add(new ToDo(t));
            }

            
            return t;
        }
    }
}
