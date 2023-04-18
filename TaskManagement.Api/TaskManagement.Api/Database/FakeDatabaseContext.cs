using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Library.Models;

namespace TaskManagement.Api.Database.DEPRECATED
{
    public static class FakeDatabaseContext
    {
        public static List<ToDo> ToDos = new List<ToDo> {
                new ToDo{Id = 1, Name = "First Task", Description = "The first thing to do" },
                new ToDo{Id = 2, Name = "Second Task", Description = "The second thing to do" },
                new ToDo { Id = 3, Name = "Third Task", Description = "The third thing to do" }
             };
    }
}
