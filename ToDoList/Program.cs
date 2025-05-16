var todoList = new List<string>();
string? menuOptionSelected = string.Empty;
string menu =
    @$"
    *********************
    Menu:

     0 - Exit
     1 - Add Task
     2 - Remove Task
     3 - Update Task
     4 - List Tasks
    *********************
    ";

while (menuOptionSelected != "0")
{
    Console.WriteLine(menu);
    Console.Write("Choose a menu option: ");
    menuOptionSelected = Console.ReadLine();
    Console.Clear();

    switch (menuOptionSelected)
    {
        case "0": Environment.Exit(0); break;
        case "1":
            {
                listTasks();
                Console.WriteLine("Describe your new task: ");
                var newTask = Console.ReadLine();
                //todoList.Add(newTask ?? string.Empty);
                if (newTask != "" && newTask != null)
                {
                    todoList.Add(newTask);
                }
                else
                {
                    Console.WriteLine("Please, write a name for the task.");
                    Console.ReadKey(true);
                }

                Console.Clear();
                break;
            };
        case "2":
            {
                listTasks();
                Console.WriteLine("Task to delete: ");
                var taskToDelete = Console.ReadLine();
                int taskNumber = getTaskNumber(taskToDelete, todoList.Count);

                if (taskNumber > 0)
                {
                    todoList.RemoveAt(taskNumber - 1);
                }

                Console.Clear();
                break;
            };
        case "3":
            {
                listTasks();
                Console.WriteLine("Task to update: ");
                var taskToUpdate = Console.ReadLine();
                int taskNumber = getTaskNumber(taskToUpdate, todoList.Count);

                if (taskNumber > 0)
                {
                    Console.WriteLine("New task description: ");
                    var newDescription = Console.ReadLine();
                    todoList[taskNumber - 1] = newDescription ?? string.Empty;
                }

                Console.Clear();
                break;
            }
        case "4": break;
        default: Environment.Exit(0); break;
    }

    listTasks();
    Console.WriteLine("Press a key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}

void listTasks()
{
    if (todoList.Count > 0)
    {
        Console.WriteLine("To-Do List");

        for (int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($@"Task {i + 1}: {todoList[i]}");
        }
    }
    else
    { 
        Console.WriteLine("[Empty List]"); 
    }

    Console.WriteLine("\n");
}

int getTaskNumber(string? taskNumber, int listCount)
{
    if (int.TryParse(taskNumber, out int number) && number > 0 && number <= listCount)
    {
        return number;
    }
    else
    {
        Console.WriteLine("Incorrect Task Number. Not items were modified.");
        Console.ReadKey(true);
        return 0;
    }
}

