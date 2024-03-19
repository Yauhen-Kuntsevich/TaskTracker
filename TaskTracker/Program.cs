using TaskTracker.Models;
using TaskTracker.UI;

namespace TaskTracker;

internal class Program
{
    static void Main()
    {
        TaskList taskList = new TaskList();
        var cli = new TaskCommandLineInterface(taskList);
        cli.Start();
    }
}

