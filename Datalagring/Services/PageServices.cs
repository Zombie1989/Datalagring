using Datalagring.Models.Entities;
using Datalagring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalagring.Contexts;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace Datalagring.Services
{
    internal class PageServices
    {
        private static DataContext _context = new DataContext();
        private ObservableCollection<TaskModel> taskmodels = new ObservableCollection<TaskModel>();

        

        public static async Task SaveAsync(TaskModel task)
        {
            var _taskEntity = new TaskEntity
            {
                Title = task.Title,
                Text = task.Text,
            };

            var _personEntity = await _context.Persons.FirstOrDefaultAsync(x => x.FirstName == task.FirstName && x.LastName == task.LastName && x.Email == task.Email);
            if (_personEntity != null)
                _taskEntity.PersonId = _personEntity.Id;
            else
                _taskEntity.Person = new PersonEntity
                {
                    FirstName = task.FirstName,
                    LastName = task.LastName,
                    Email = task.Email,
                };

                _context.Add(_taskEntity);
                await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<TaskEntity>> GetAsync(string email, string title)
        {
            
            var _task = await _context.Tasks.Where(x => x.Title == title && x.Person.Email == email).Include(x => x.Person).ToListAsync();

            List<TaskModel> tasks = new List<TaskModel>();
            foreach (var task in _task) 
            {
                TaskModel newTask = new TaskModel
                {
                    Title = task.Title,
                    Text = task.Text,
                    Email = task.Person.Email,
                    FirstName = task.Person.FirstName,
                    LastName = task.Person.LastName,
                };
                tasks.Add(newTask);
            }

            return _task;
        }



       public static async Task DeleteAsync(Func<TaskEntity, bool> predicate)
        {
            var data = await _context.Tasks.FindAsync(predicate);
            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task<TaskEntity> Change(int id, string status)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            task.StatusModes = status;
            await _context.SaveChangesAsync();

            return task!;
        }
    }
}
