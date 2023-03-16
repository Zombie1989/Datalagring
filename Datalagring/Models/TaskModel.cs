using System;
using System.ComponentModel;

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
    public Status StatusModes { get; set; } = Status.NotStarted;

    public string DisplayName => $"{FirstName} {LastName}";

    public enum Status
    {
        NotStarted,
        Ongoing,
        Completed
    }
}
