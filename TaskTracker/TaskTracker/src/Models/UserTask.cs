namespace TaskTracker.Models;

public class UserTask
{
    private int _taskId;
    private string _taskTitle;
    private string _taskDescription;
    private DateTime _taskDueDate;
    private PriorityLevel _taskPriority;
    
    public int TaskId { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public DateTime TaskDueDate { get; set; }
    public PriorityLevel TaskPriority { get; set; }

    public UserTask(int taskId, string taskTitle, string taskDescription, DateTime taskDueDate, PriorityLevel taskPriority)
    {
        _taskId = taskId;
        _taskTitle = taskTitle;
        _taskDescription = taskDescription;
        _taskDueDate = taskDueDate;
        _taskPriority = taskPriority;
    }

    public string FormatTaskOutput()
    {
        string priorityColor = GetPriorityColor(_taskPriority);
        return $"Title: {_taskTitle}\n" +
               $"Description: {_taskDescription}\n" +
               $"Due date: {_taskDueDate}\n" +
               $"Priority: {priorityColor}{_taskPriority}";
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