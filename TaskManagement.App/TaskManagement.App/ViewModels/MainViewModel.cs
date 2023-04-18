using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.App.Dialogs;
using TaskManagement.App.Util;
using TaskManagement.Library.DTO;
using TaskManagement.Library.Models;

namespace TaskManagement.App.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<ToDoViewModel> ToDos
        {
            get
            {
                var payload = new WebRequestHandler().Get("http://localhost:5011/ToDo").Result;
                var returnVal = JsonConvert.DeserializeObject<List<ToDoDTO>>(payload).Select(d => new ToDoViewModel(d));
                
                return returnVal.OrderBy(t => t.Dto.Id);
            }
        }

        public ToDoViewModel SelectedToDo { get; set; }

        public MainViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshList()
        {
            NotifyPropertyChanged(nameof(ToDos));
        }

    }
}
