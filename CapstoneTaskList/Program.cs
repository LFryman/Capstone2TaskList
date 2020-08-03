using System;
using System.Collections.Generic;
using System.Linq;

namespace CapstoneTaskList
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>
        {
            new Task("Tommy", "Go over Lists agian.", DateTime.Parse("7/31/2020")),
            new Task("Joshua", "Show off the snazzy methods is Movie List", DateTime.Parse("8/3/2020")),
            new Task("Anna", "Have her cat teach a class.", DateTime.Parse("9/1/2020")),
            new Task("Sean", "Take out the trash.", DateTime.Parse("9/16/2030")),
            new Task("Ramez", "Run through the last three labs", DateTime.Parse("8/3/2020")),
            new Task("Justin", "Take point on themed music for Mondays.", DateTime.Parse("8/10/2020")),

        };
            bool lContinue = true;
            while (lContinue)
            {
                Console.WriteLine("Welcome to task manager.");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1.) List Tasks.");
                Console.WriteLine("2.) Add Task.");
                Console.WriteLine("3.) Delete Task.");
                Console.WriteLine("4.) Mark Task Complete.");
                Console.WriteLine("5.) Quit.");

                #region main code
                try
                {
                    string input = Console.ReadLine();
                    int input1 = int.Parse(input);

                    if (input1 > 0 && input1 < 6)
                    {

                        if (input1 == 1)
                        {
                            PrintTasks(taskList);
                            Console.WriteLine("Press any key to return to the main menue.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (input1 == 2)
                        {
                            AddTask(taskList);
                            PrintTasks(taskList);
                            Console.WriteLine("Press any key to return to the main menue.");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if (input1 == 3)
                        {
                            DeleteTask(taskList);
                            Console.WriteLine($"Here is your new Task List.");
                            PrintTasks(taskList);
                            Console.WriteLine("Press any key to return to the main menue.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (input1 == 4)
                        {
                            MarkComplete(taskList);
                            Console.WriteLine("Press any key to return to the main menue.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (input1 == 5)
                        {
                            Console.WriteLine("Thanks for using the program.");
                            lContinue = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That input was not a an option.");
                        Console.WriteLine("Press any key to try again");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("That input was not a number");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            #endregion End of main code
        }
        #region List Tasks
        public static void PrintTasks(List<Task> taskLists)
        {
            int counter = 1;
            foreach (Task list in taskLists)
            {
                Console.WriteLine($"{counter}\tName: {list.Name}");
                Console.WriteLine($"\tTask: {list.Description}");
                Console.WriteLine($"\tDue Date: {list.DueDate.ToShortDateString()}");
                counter++;
            }
        }
        #endregion
        #region PrintOneTask
        public static void PrintOneTask(List<Task> taskList, int index)
        {
            Task list = taskList[index];
            Console.WriteLine($"\tName: {list.Name}");
            Console.WriteLine($"\tTask: {list.Description}");
            Console.WriteLine($"\tDue Date: {list.DueDate.ToShortDateString()}");
        }
        #endregion
        #region AddTaskMethod
        public static List<Task> AddTask(List<Task> taskList)
        {
            Console.WriteLine("ADD TASK.");
            Console.WriteLine("Please input the name, the task description, date due (mm/dd/yyyy).");
            string TeamMemberName = Console.ReadLine();
            string TaskDescription = Console.ReadLine();
            DateTime DueDate = DateTime.Parse(Console.ReadLine());

            taskList.Add(new Task(TeamMemberName, TaskDescription, DueDate));

            return taskList;
        }
        #endregion

        #region DeleteTask
        public static List<Task> DeleteTask(List<Task> taskList)
        {
            const int offset = 1;
            Console.WriteLine("DELETE TASK.");

            bool a = true;
            while (a)
            {
                Console.WriteLine("What task would you like to delete?");
                PrintTasks(taskList);
                try
                {

                    string choice = Console.ReadLine();
                    int deleteChoice = int.Parse(choice);
                    int index = deleteChoice - offset;

                    if (index < taskList.Count && index >= 0)
                    {
                        Console.WriteLine("Are you sure you wish to delete this task? y/n");
                        PrintOneTask(taskList, index);

                        string x = YesNoChecker(Console.ReadLine());
                        if (x == "y")
                        {
                            taskList.RemoveAt(index);
                            a = false;
                        }
                        else
                        {
                            a = false; 
                        }
                    }
                    else
                    {
                        Console.WriteLine("That input was not an option. Please try agian.");
                        a = true;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("That input was not a number.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            return taskList;
        }
        #endregion

        #region MarkComplete
        public static void MarkComplete(List<Task> taskList)
        {
            const int offset = 1;
            Console.WriteLine("COMPLETE TASK.");
            bool b = true;
            while (b)
            {
                Console.WriteLine("What task would you like to Mark Complete?");
                PrintTasks(taskList);
                try
                {
                    int completeChoice = int.Parse(Console.ReadLine());
                    int index = completeChoice - offset;

                    if (index <= taskList.Count && index >= 0)
                    {
                        Console.WriteLine("Are you sure you wish to Complete this task? y/n");
                        PrintOneTask(taskList, index);

                        string x = YesNoChecker(Console.ReadLine());
                        if (x == "y")
                        {
                            Task task = taskList[index];
                            task.Completed = true;
                            Console.WriteLine("Your task has been marked complete.");
                            b = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That input was not an option. Please try agian.");
                        b = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("That input was not a number");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
        #endregion

        #region YesNoChecker 
        public static string YesNoChecker(string input)
        {
            while (input != "y" && input != "n")
            {
                Console.Write("Invalid input. Please enter either \"y\" or \"n\": ");
                input = Console.ReadLine();
            }
            return input;
        }
        #endregion
     
    }

}