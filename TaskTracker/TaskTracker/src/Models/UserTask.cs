namespace TaskTracker.Models;

public class UserTask
{
    private int _taskId { get; set; }
    private string _taskTitle { get; set; }
    private string TaskDescription { get; set; }
    private DateTime _taskDueDate { get; set; }
    private PriorityLevel _taskPriority { get; set; }

    public UserTask(int taskId, string taskTitle, string taskDescription, DateTime taskDueDate, PriorityLevel taskPriority)
    {
        _taskId = taskId;
        _taskTitle = taskTitle;
        TaskDescription = taskDescription;
        _taskDueDate = taskDueDate;
        _taskPriority = taskPriority;
    }

    public string FormatTaskOutput()
    {
        string priorityColor = GetPriorityColor(_taskPriority);
        return $"Title: {_taskTitle}\n" +
               $"Description: {TaskDescription}\n" +
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