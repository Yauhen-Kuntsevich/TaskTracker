using TaskTracker.Data;

namespace TaskTracker.Models;

public class TaskStorage
{
    private readonly TaskTrackerContext _context;

    public TaskStorage(TaskTrackerContext context)
    {
        _context = context;
    }

    public void AddTask(UserTask task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public bool RemoveTask(int taskId)
    {
        var taskToRemove = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (taskToRemove is UserTask)
        {
            _context.Tasks.Remove(taskToRemove);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public List<UserTask> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }
}