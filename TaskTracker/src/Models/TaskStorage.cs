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

    public bool FinishTask(int taskId)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);

        if (task is UserTask)
        {
            task.Status = TaskStatus.Finished;
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public List<UserTask> GetAllActiveTasks()
    {
        return _context.Tasks.Where(t => t.Status == TaskStatus.Active).ToList();
    }

    public List<UserTask> GetAllFinishedTasks()
    {
        return _context.Tasks.Where(t => t.Status == TaskStatus.Finished).ToList();
    }
}