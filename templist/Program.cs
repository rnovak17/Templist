// TODO: create a class for tasks that stores whether or not they are completed
// TODO: refactor/comment
string [] todo = new string[10];
int counter = 0;
bool exit = false;

while (exit == false) {
    Console.Write("Add (a), Complete Task (c), Remove (r) Quit (q): ");
    // TODO: Make sure this only accepts options given
    char operation = Convert.ToChar(Console.ReadLine());
    switch (operation)
    {
        case 'a':
            Console.Write("Task name: ");
            todo[counter] = "[ ] " + Console.ReadLine();
            counter++;
            break;
        case 'c':
            for (int i = 1; i <= todo.Length; i++)
            {
                if (todo[i - 1] != null)
                {
                    Console.WriteLine(i + todo[i - 1]);
                }
            }
            Console.Write("Enter task number: ");
            int  taskNum = Convert.ToInt32(Console.ReadLine()) - 1;
            string completedTask = todo[taskNum];
            completedTask = "[x]" + completedTask.Substring(3, (completedTask.Length - 3));
            todo[taskNum] = completedTask;
            break;
        case 'q':
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