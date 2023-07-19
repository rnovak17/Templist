using static System.Collections.Specialized.BitVector32;
using System;
using System.Xml;




namespace Templist
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: check if an xml file exists, create one if it does not
            MakeTaskFile();
            // TODO: import data from xml file into task list
            // initialize task list array
            Tasks[] todo = new Tasks[] { null };
            int taskCount = 0;

            string operations = "1: Add\n2: Complete Task\n3: Remove Task\n4: Show Tasks\n5: Quit\n: ";

            // initialize exit condition for main loop
            bool exit = false;


            while (exit == false)
            {
                // print options to user
                Console.Write(operations);
                int selectInt = 0;
                // prompt user until valid input is provided
                while (true)
                {
                    string? selectStr = Console.ReadLine();
                    // if input is valid, assign integer to selectInt and exit
                    if (int.TryParse(selectStr, out selectInt) && int.Parse(selectStr) > 0 && int.Parse(selectStr) <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please input an integer between 1 and 5");
                        Console.Write(operations);
                    }
                }

                // choose operation to perform based on user's input
                switch (selectInt)
                {
                    // add task
                    case 1:
                        // prompt user until task name is not blank
                        while (todo[taskCount] == null || todo[taskCount].TaskName == "")
                        {
                            Console.Write("Task name: ");
                            // create new task with user input as the TaskName
                            todo[taskCount] = new Tasks(Console.ReadLine());
                        }
                        taskCount++;
                        break;

                    // mark a task complete (x in [])
                    case 2:
                        // print numbered task list
                        for (int i = 1; i <= todo.Length; i++)
                        {
                            if (todo[i - 1] != null)
                            {
                                Console.WriteLine($"{i} {todo[i - 1].TaskName}");
                            }
                        }
                        // initialize integer to store input string after int conversion
                        int taskNum = 0;
                        // prompt user until valid input is provided
                        while (true)
                        {
                            Console.Write("Enter task number: ");
                            string? taskStr = Console.ReadLine();

                            // if input is valid, output integer to taskNum and exit
                            if (int.TryParse(taskStr, out taskNum) && int.Parse(taskStr) > 0 && int.Parse(taskStr) <= taskCount)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Please input an integer between 1 and {taskCount}");
                            }
                        }

                        // check off the selected task
                        todo[taskNum - 1].IsComplete = true;
                        break;

                    // print current list contents
                    case 4:
                        ShowList(todo);
                        Console.Write("Press enter to continue:");
                        Console.ReadLine();
                        break;

                    // exit the program and print your final list
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please input one of the characters provided.");
                        break;

                }
            }

            // print the final list
            ShowList(todo);
            AddTask("Test task");
            // leave list displayed until key press
            Console.ReadLine();
        }

        static void ShowList(Tasks[] items)
        {
            // iterate through all tasks and print them checked or open
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null && items[i].IsComplete == false)
                {
                    Console.WriteLine("[ ]" + items[i].TaskName);
                }
                else if (items[i] != null && items[i].IsComplete == true)
                {
                    Console.WriteLine("[x]" + items[i].TaskName);
                }
            }
            return;
        }

        static void MakeTaskFile()
        {
            // define the project directory to create the xml file in
            string workingDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(workingDir).Parent.Parent.Parent.FullName;

            // define a new xml document, taskList
            XmlDocument taskList = new XmlDocument();

            // create the root element in the new file
            XmlElement root = taskList.CreateElement("TASKS");
            taskList.AppendChild(root);

            // save the xml document in the directory specified above
            taskList.Save($"{projectDir}/tasks.xml");
            //Console.WriteLine(taskList.InnerXml);
        }

        static void AddTask(string taskInput)
        {
            // define the project directory to create the xml file in
            string workingDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(workingDir).Parent.Parent.Parent.FullName;

            XmlDocument taskList = new XmlDocument();

            taskList.Load($"{projectDir}/tasks.xml");
            XmlNode root = taskList.SelectSingleNode("TASKS");
            XmlElement task = taskList.CreateElement("TASK");
            root.AppendChild(task);

            XmlAttribute id = taskList.CreateAttribute("id");
            task.Attributes.Append(id);

            XmlElement taskName = taskList.CreateElement("TASKNAME");
            task.AppendChild(taskName);
            Console.WriteLine(taskList.InnerXml);
        }
    }


    public class Tasks
    {
        public string TaskName { get; set; }
        public bool IsComplete = false;

        // allow new tasks to be provided a string for their name
        public Tasks(string taskName)
        {
            TaskName = taskName;
        }
    }
}