// TODO: create a class for tasks that stores whether or not they are completed
// TODO: refactor/comment
using static System.Collections.Specialized.BitVector32;
using System;

string [] todo = new string[10];
int counter = 0;
bool exit = false;

while (exit == false) {
    Console.Write("1: Add\n2: Complete Task\n3: Remove Task\n4: Quit\n: ");
    string selectStr = "";
    int selectInt = 0;
    // TODO: clean up while loop break condition
    bool isValid = false;
    while (isValid == false)
    {
        selectStr = Console.ReadLine();

        if (int.TryParse(selectStr, out selectInt) && int.Parse(selectStr) > 0 && int.Parse(selectStr) <= 4)
        {
            // set condition to break the loop
            isValid = true;
        }
        else
        {
            Console.WriteLine("Please input an integer between 1 and 4");
            Console.Write("1: Add\n2: Complete Task\n3: Remove Task\n4: Quit\n: ");
        }
    }

    switch (selectInt)
    {
        case 1:
            Console.Write("Task name: ");
            todo[counter] = "[ ] " + Console.ReadLine();
            counter++;
            break;
        case 2:
            for (int i = 1; i <= todo.Length; i++)
            {
                if (todo[i - 1] != null)
                {
                    Console.WriteLine(i + todo[i - 1]);
                }
            }
            int taskNum = 0;
            // TODO: clean up while loop break condition
            bool valid = false;
            while (valid == false)
            {
                Console.Write("Enter task number: ");
                string taskStr = Console.ReadLine();
                if (int.TryParse(taskStr, out taskNum) && int.Parse(taskStr) > 0 && int.Parse(taskStr) <= todo.Length)
                {
                    // set condition to break the loop
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Please input an integer between 1 and {todo.Length}");
                }
            }

            string completedTask = todo[taskNum - 1];
            completedTask = "[x]" + completedTask.Substring(3, (completedTask.Length - 3));
            todo[taskNum - 1] = completedTask;
            break;
        case 4:
            exit = true;
            break;
        default:
            Console.WriteLine("Please input one of the characters provided.");
            break;
    }
}
for (int i = 0; i < todo.Length; i++)
{
    if (todo[i] != null)
    {
        Console.WriteLine(todo[i]);
    }
}
Console.ReadLine();

