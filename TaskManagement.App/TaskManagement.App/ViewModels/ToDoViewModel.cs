using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.App.Util;
using TaskManagement.Library.DTO;
using TaskManagement.Library.Models;

namespace TaskManagement.App.ViewModels
{
    public class ToDoViewModel
    {
        private MainViewModel parentViewModel;
        public ToDoDTO Dto { get; set; }
        public string Display
        {
            get
            {
                return $"[{Dto.Id}] {Dto.Name} - {Dto.Description}";
            }
        }

        public ToDoViewModel(ToDoDTO dto)
        {
            Dto = dto;
        }

        public ToDoViewModel(MainViewModel mvm) {
            parentViewModel = mvm;
            if (parentViewModel?.SelectedToDo?.Dto == null)
            {
                Dto = new ToDoDTO();
            }else
            {
                Dto = parentViewModel.SelectedToDo.Dto;
            }

        }
        //public ToDoViewModel(MainViewModel mvm, ToDoDTO dto)
        //{
        //    parentViewModel = mvm;
        //    Dto = dto;
        //}

        public async Task<ToDoDTO> AddToDo()
        {
            var handler = new WebRequestHandler();
            var returnVal = await handler.Post("http://localhost:5011/ToDo", Dto);
            var deserializedReturn = JsonConvert.DeserializeObject<ToDoDTO>(returnVal);
            parentViewModel.RefreshList();
            return deserializedReturn;
        }
    }
}
