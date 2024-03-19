namespace TaskTracker.Models;

public class TaskManager
{
    private List<UserTask> tasks = new List<UserTask>();

    public void AddTask(UserTask task)
    {
        tasks.Add(task);
    }

    public bool RemoveTask(int taskId)
    {
        UserTask? taskToRemove = tasks.FirstOrDefault(t => t.TaskId == taskId);
        return false;
    }
    
    public List<UserTask> GetAllTasks()
    {
        return tasks;
    }
}