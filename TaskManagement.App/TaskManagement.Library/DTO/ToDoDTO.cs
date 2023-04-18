using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Library.Models;

namespace TaskManagement.Library.DTO
{
    public class ToDoDTO
    {
        public ToDoDTO(ToDo t) {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
        }

        public ToDoDTO() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


    }
}
