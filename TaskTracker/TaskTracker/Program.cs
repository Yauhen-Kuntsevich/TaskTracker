using TaskTracker.Models;

namespace TaskTracker;

internal class Program
{
    static void Main()
    {
        UserTask testTask = new UserTask(1, "Title", "Description", DateTime.Now, PriorityLevel.Medium);
        Console.WriteLine(testTask.FormatTaskOutput());
    }
}

