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
        const string ESC = "\u001b[";
        const string RESET = ESC + "0m";
        const string BOLD = ESC + "1m";

        string priorityColor = GetPriorityColor(Priority);
        string regularColor = "\u001b[0m";

        return $"\n{regularColor}==============================\n\n" +
               $"{BOLD}Id{RESET}: {Id}{RESET}\n" +
               $"{BOLD}Title{RESET}: {Title}\n" +
               $"{BOLD}Description{RESET}: {Description}\n" +
               $"{BOLD}Due date{RESET}: {DueDate}\n" +
               $"{BOLD}Priority{RESET}: {priorityColor}{Priority}{regularColor}\n" +
               $"{BOLD}Status{RESET}: {Status}\n";
    }

    private string GetPriorityColor(PriorityLevel priority)
    {
        return priority switch
        {
            PriorityLevel.High => "\u001b[31m",
            PriorityLevel.Medium => "\u001b[33m",
            PriorityLevel.Low => "\u001b[32m",
            _ => "\u001b[0m",
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