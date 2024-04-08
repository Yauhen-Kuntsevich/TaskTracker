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

        string rulesOfUse = "\n" + new string('=', 30) + "\n" +
                            "Available commands:\n" +
                            "\t'add' to add new task;\n" +
                            "\t'alist' to print list of active tasks;\n" +
                            "\t'flist' to print list of finished tasks;\n" +
                            "\t'remove' to remove task;\n" +
                            "\t'exit' to stop application.\n";
        Console.WriteLine(rulesOfUse);

        while (isRunning)
        {
            string command = ReadCorrectString("\nEnter your command (add, alist, flist, remove, exit): ").Trim().ToLower();

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

    private void AddTask(TaskStorage taskStorage)
    {
        string title = ReadCorrectString("Enter a task title: ");

        string description = ReadCorrectString("Enter a task description: ");

        DateOnly dueDate = ReadCorrectDate("Enter a task due date: ");

        PriorityLevel priority = ReadCorrectPriority("Enter a task priority: ");

        var newTask = new UserTask(title, description, dueDate, priority);
        taskStorage.AddTask(newTask);
    }

    private void RemoveTask()
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

    private void FinishTask()
    {
        Console.Write("Enter id of task you want to finish: ");
        int taskId = Convert.ToInt32(Console.ReadLine());

        var wasFinished = _taskStorage.FinishTask(taskId);

        if (wasFinished)
        {
            _taskStorage.FinishTask(taskId);
            Console.WriteLine($"Task was finished!");
        }
        else
        {
            Console.WriteLine("This task is not found");
        }

    }

    private void ListActiveTasks()
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

    private void ListFinishedTasks()
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

    private string ReadCorrectString(string prompt)
    {
        string? input;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    private DateOnly ReadCorrectDate(string prompt)
    {
        string? input;
        DateOnly date;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (!DateOnly.TryParse(input, out date));

        return date;
    }

    private PriorityLevel ReadCorrectPriority(string prompt)
    {
        string? input;
        PriorityLevel priority;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (!Enum.TryParse(input, true, out priority));

        return priority;
    }
}
