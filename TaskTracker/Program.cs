using TaskTracker.Models;
using TaskTracker.UI;
using TaskTracker.Data;

namespace TaskTracker;

internal class Program
{
    static void Main()
    {
        TaskTrackerContext context = new TaskTrackerContext();
        TaskStorage taskStorage = new TaskStorage(context);
        var cli = new TaskCommandLineInterface(taskStorage);
        cli.Start();
    }
}

