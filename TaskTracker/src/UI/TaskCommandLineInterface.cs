using TaskTracker.Models;

namespace TaskTracker.UI;

public class TaskCommandLineInterface
{
    private readonly TaskStorage _taskStorage;

    public TaskCommandLineInterface(TaskStorage taskStorage)
    {
        _taskStorage = taskStorage;
    }

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Write("\nEnter your command(add, alist, flist, remove, exit): ");
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "add":
                    AddTask(_taskStorage);
                    break;
                case "remove":
                    RemoveTask();
                    break;
                case "finish":
                    FinishTask();
                    break;
                case "alist":
                    ListActiveTasks();
                    break;
                case "flist":
                    ListFinishedTasks();
                    break;
                case "exit":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Unknown command!");
                    break;
            }
        }
    }

    void AddTask(TaskStorage taskStorage)
    {
        Console.Write("Enter a task title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter a task description: ");
        string? description = Console.ReadLine();

        Console.Write("Enter a task due date: ");
        DateOnly dueDate = DateOnly.Parse(Console.ReadLine());

        Console.Write("Enter a task priority: ");
        PriorityLevel priority = (PriorityLevel)Enum.Parse(typeof(PriorityLevel), Console.ReadLine(), true);

        var newTask = new UserTask(title, description, dueDate, priority);
        taskStorage.AddTask(newTask);
    }

    void RemoveTask()
    {
        Console.Write("Enter id of task you want to remove: ");
        int taskId = Convert.ToInt32(Console.ReadLine());

        if (_taskStorage.RemoveTask(taskId))
        {
            Console.WriteLine("The task was removed");
        }
        else
        {
            Console.WriteLine("The task is not found");
        }
    }

    void FinishTask()
    {
        Console.Write("Enter id of task you want to finish: ");
        int taskId = Convert.ToInt32(Console.ReadLine());

        var wasFinished = _taskStorage.FinishTask(taskId);

        if (wasFinished)
        {
            _taskStorage.FinishTask(taskId);
            Console.WriteLine($"Task {_taskStorage.GetAllFinishedTasks().FirstOrDefault(t => t.Id == taskId).Title} was finished!");
        }
        else
        {
            Console.WriteLine("This task is not found");
        }

    }

    void ListActiveTasks()
    {
        List<UserTask> activeTasks = _taskStorage.GetAllActiveTasks();

        if (activeTasks.Count == 0)
        {
            Console.WriteLine("Tasks list is empty!");
            return;
        }

        foreach (var task in activeTasks)
        {
            Console.WriteLine(task.FormatTaskOutput());
        }
    }

    void ListFinishedTasks()
    {
        List<UserTask> finishedTasks = _taskStorage.GetAllFinishedTasks();

        if (finishedTasks.Count == 0)
        {
            Console.WriteLine("\nFinished tasks list is empty!");
            return;
        }

        foreach (var task in finishedTasks)
        {
            Console.WriteLine(task.FormatTaskOutput());
        }
    }
}
