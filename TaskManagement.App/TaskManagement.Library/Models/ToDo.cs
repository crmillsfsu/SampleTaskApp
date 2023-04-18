using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Library.DTO;

namespace TaskManagement.Library.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ThingIDontCareAbout1 { get; set; }
        public int ThingIDontCareAbout2 { get; set; }
        public int ThingIDontCareAbout3 { get; set; }
        public int ThingIDontCareAbout4 { get; set; }
        public int ThingIDontCareAbout5 { get; set; }

        public ToDo(ToDoDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
        }

        public ToDo() { }

    }
}
