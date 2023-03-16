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

namespace Datalagring.Services
{
    internal class PageServices
    {
        private static DataContext _context = new DataContext();


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





        public static async Task<List<TaskEntity>> GetAsync(string email, string title)
        {
            var _task = await _context.Tasks.Where(x => x.Title == title && x.Person.Email == email).ToListAsync();
            var person = _context.Persons.ToList();

            return _task;
        }
    }
}
