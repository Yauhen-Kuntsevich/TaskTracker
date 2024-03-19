namespace TaskTracker.Models;

public class UserTask
{
    private int _taskId;
    private string _title;
    private string _description;
    private DateTime _dueDate;
    private PriorityLevel _priority;
    
    public int TaskId { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public DateTime TaskDueDate { get; set; }
    public PriorityLevel TaskPriority { get; set; }

    public UserTask(int taskId, string title, string description, DateTime dueDate, PriorityLevel priority)
    {
        _taskId = taskId;
        _title = title;
        _description = description;
        _dueDate = dueDate;
        _priority = priority;
    }

    public string FormatTaskOutput()
    {
        string priorityColor = GetPriorityColor(_priority);
        return $"-------------------------------------\n" +
               $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Due date: {_dueDate}\n" +
               $"Priority: {priorityColor}{_priority}\n";
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