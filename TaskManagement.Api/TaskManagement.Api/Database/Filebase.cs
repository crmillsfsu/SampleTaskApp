using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Library.DTO;
using TaskManagement.Library.Models;

namespace TaskManagement.Api.Database
{
    public class Filebase
    {
        private string _root;
        private string _appointmentRoot;
        private string _todoRoot;
        private static Filebase _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = "C:\temp";
            _appointmentRoot = $"{_root}\\Appointments";
            _todoRoot = $"{_root}\\ToDos";
        }

        public Item AddOrUpdate(Item item)
        {
            //set up a new Id if one doesn't already exist
            if(string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }

            //go to the right place]
            string path;
            if (item is ToDo)
            {
                path = $"{_todoRoot}/{item.Id}.json";
            } else
            {
                path = $"{_appointmentRoot}/{item.Id}.json";
            }

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(item));

            //return the item, which now has an id
            return item;
        }

        public List<ToDo> ToDos
        {
            get
            {
                var root = new DirectoryInfo(_todoRoot);
                var _todos = new List<ToDo>();
                foreach(var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.DeserializeObject<ToDo>(File.ReadAllText(todoFile.FullName));
                    _todos.Add(todo);
                }
                return _todos;
            }
        }

        public List<Appointment> Appointments
        {
            get
            {
                var root = new DirectoryInfo(_appointmentRoot);
                var _apps = new List<Appointment>();
                foreach (var appFile in root.GetFiles())
                {
                    var app = JsonConvert.DeserializeObject<Appointment>(File.ReadAllText(appFile.FullName));
                    _apps.Add(app);
                }
                return _apps;
            }
        }

        public bool Delete(string type, string id)
        {
            //TODO: refer to AddOrUpdate for an idea of how you can implement this.
            return true;
        }
    }


    // ------------------- FAKE MODEL FILES, REPLACE THESE WITH A REFERENCE TO YOUR MODELS -------- //
    public class Item
    {
        public string Id { get; set; }
    }

    //public class ToDo : Item
    //{

    //}

    public class Appointment : Item
    {

    }
}
