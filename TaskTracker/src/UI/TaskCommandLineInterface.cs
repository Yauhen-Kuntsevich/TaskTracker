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
            Console.Write("\nEnter your command(add, list, remove, exit): ");
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "add":
                    AddTask(_taskStorage);
                    break;
                case "remove":
                    RemoveTask();
                    break;
                case "list":
                    ListTasks();
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
        Console.Write("Enter a task id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter a task title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter a task description: ");
        string? description = Console.ReadLine();

        Console.Write("Enter a task due date: ");
        DateOnly dueDate = DateOnly.Parse(Console.ReadLine());

        Console.Write("Enter a task priority: ");
        PriorityLevel priority = (PriorityLevel)Enum.Parse(typeof(PriorityLevel), Console.ReadLine(), true);

        var newTask = new UserTask(id, title, description, dueDate, priority);
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

    void ListTasks()
    {
        List<UserTask> tasks = _taskStorage.GetAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Tasks list is empty!");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine(task.FormatTaskOutput());
        }
    }
}