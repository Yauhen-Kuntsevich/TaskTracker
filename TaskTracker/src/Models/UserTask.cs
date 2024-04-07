namespace TaskTracker.Models;

public class UserTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly DueDate { get; set; }
    public PriorityLevel Priority { get; set; }
    public TaskStatus Status { get; set; }

    public UserTask(string title, string description, DateOnly dueDate, PriorityLevel priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        Status = TaskStatus.Active;
    }

    public string FormatTaskOutput()
    {
        string priorityColor = GetPriorityColor(Priority);
        string regularColor = "\x1b[0m";
        return $"\n{regularColor}==============================\n\n" +
               $"Id: {Id}\n" +
               $"Title: {Title}\n" +
               $"Description: {Description}\n" +
               $"Due date: {DueDate}\n" +
               $"Priority: {priorityColor}{Priority}{regularColor}";
    }

    private string GetPriorityColor(PriorityLevel priority)
    {
        return priority switch
        {
            PriorityLevel.High => "\x1b[31m",
            PriorityLevel.Medium => "\x1b[33m",
            PriorityLevel.Low => "\x1b[32m",
            _ => "\x1b[0m",
        };
    }
}

public enum PriorityLevel
{
    Low,
    Medium,
    High,
}

public enum TaskStatus
{
    Active,
    Finished,
}