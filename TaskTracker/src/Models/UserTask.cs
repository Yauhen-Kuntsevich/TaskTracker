namespace TaskTracker.Models;

public class UserTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public PriorityLevel Priority { get; set; }

    public UserTask(int id, string title, string description, DateTime dueDate, PriorityLevel priority)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
    }

    public string FormatTaskOutput()
    {
        string priorityColor = GetPriorityColor(Priority);
        string regularColor = "\x1b[0m";
        return $"\n{regularColor}==============================\n\n" +
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
        };
    }
}

public enum PriorityLevel
{
    Low,
    Medium,
    High,
}