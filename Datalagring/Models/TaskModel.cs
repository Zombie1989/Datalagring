using Datalagring.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Windows.Controls;

namespace Datalagring.Models;
class TaskModel
{

    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime Created { get; set; }
    public string StatusModes { get; set; } = null!;


    public List<string> StatusList = new List<string>() { "NotStarted", "OnGoing", "Completed" };
}
