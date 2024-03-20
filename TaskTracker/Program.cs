using TaskTracker.Models;
using TaskTracker.UI;

namespace TaskTracker;

internal class Program
{
    static void Main()
    {
        TaskStorage taskStorage = new TaskStorage();
        var cli = new TaskCommandLineInterface(taskStorage);
        cli.Start();
    }
}

