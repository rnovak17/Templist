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
            todo[counter] = Console.ReadLine();
            counter++;
            break;
        case 'c':
            // TODO: implement this case
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
        Console.WriteLine("[ ]" + todo[i]);
    }
}
Console.ReadLine();