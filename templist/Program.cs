// TODO: create a class for tasks that stores whether or not they are completed
using static System.Collections.Specialized.BitVector32;
using System;

// initialize task list array
string [] todo = new string[10];
// initialize task counter
int counter = 0;
// initialize exit condition for main loop
bool exit = false;

while (exit == false) {
    // print options to user
    Console.Write("1: Add\n2: Complete Task\n3: Remove Task\n4: Quit\n: ");
    int selectInt = 0;
    // prompt user until valid input is provided
    while (true)
    {
        string? selectStr = Console.ReadLine();
        // if input is valid, output integer to selectInt and exit
        if (int.TryParse(selectStr, out selectInt) && int.Parse(selectStr) > 0 && int.Parse(selectStr) <= 4)
        {
            break;
        }
        else
        {
            Console.WriteLine("Please input an integer between 1 and 4");
            Console.Write("1: Add\n2: Complete Task\n3: Remove Task\n4: Quit\n: ");
        }
    }

    // choose operation to perform based on user's input
    switch (selectInt)
    {
        // add task
        case 1:
            Console.Write("Task name: ");
            todo[counter] = "[ ] " + Console.ReadLine();
            counter++;
            break;

        // mark a task complete (x in [])
        case 2:
            for (int i = 1; i <= todo.Length; i++)
            {
                // check that the selected task exists
                if (todo[i - 1] != null)
                {
                    Console.WriteLine(i + todo[i - 1]);
                }
                // TODO: tell the user if the task doesn't exist
            }
            // initialize integer to store input string after int conversion
            int taskNum = 0;
            // prompt user until valid input is provided
            while (true)
            {
                Console.Write("Enter task number: ");
                string? taskStr = Console.ReadLine();

                // if input is valid, output integer to taskNum and exit
                if (int.TryParse(taskStr, out taskNum) && int.Parse(taskStr) > 0 && int.Parse(taskStr) <= todo.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Please input an integer between 1 and {todo.Length}");
                }
            }

            // check off the selected task
            string completedTask = todo[taskNum - 1];
            completedTask = "[x]" + completedTask.Substring(3, (completedTask.Length - 3));
            todo[taskNum - 1] = completedTask;
            break;

        // TODO: Add ability to re-print the list as an operation
        // exit the program and print your final list
        case 4:
            exit = true;
            break;
        default:
            Console.WriteLine("Please input one of the characters provided.");
            break;

    }
}

// print the final list
for (int i = 0; i < todo.Length; i++)
{
    if (todo[i] != null)
    {
        Console.WriteLine(todo[i]);
    }
}
// leave list displayed until key press
Console.ReadLine();

