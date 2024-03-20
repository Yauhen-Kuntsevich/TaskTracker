namespace TaskTracker.Models;

public class TaskStorage
{
    private readonly List<UserTask> _tasks = new List<UserTask>();

    public void AddTask(UserTask task)
    {
        _tasks.Add(task);
    }

    public bool RemoveTask(int taskId)
    {
        var taskToRemove = _tasks.FirstOrDefault(t => t.Id == taskId);
        if (taskToRemove != null)
        {
            _tasks.Remove(taskToRemove);
            return true;
        }
        return false;
    }
    
    public List<UserTask> GetAllTasks()
    {
        return _tasks;
    }
}