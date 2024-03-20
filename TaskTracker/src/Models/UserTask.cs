namespace TaskTracker.Models;

public class UserTask
{
    private int _id;
    private string _title;
    private string _description;
    private DateTime _dueDate;
    private PriorityLevel _priority;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public PriorityLevel Priority { get; set; }

    public UserTask(int id, string title, string description, DateTime dueDate, PriorityLevel priority)
    {
        _id = id;
        _title = title;
        _description = description;
        _dueDate = dueDate;
        _priority = priority;
    }

    public string FormatTaskOutput()
    {
        string priorityColor = GetPriorityColor(_priority);
        string regularColor = "\x1b[0m";
        return $"\n{regularColor}==============================\n\n" +
               $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Due date: {_dueDate}\n" +
               $"Priority: {priorityColor}{_priority}{regularColor}";
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