using Models;
using Logic;
using Enums;
using System.Globalization;



namespace Xirake.TaskPlanner
{
    internal static class Programm
    {
        public static void Main(string[] args)
        {
            var workItems = new System.Collections.Generic.List<WorkItem>();

            while (true)
            {
                Console.WriteLine("Enter the details for a new WorkItem or type 'exit' to finish:");

                Console.Write("Title: ");
                var title = Console.ReadLine();
                if (title.ToLower() == "exit") break;

                Console.Write("Description: ");
                var description = Console.ReadLine();

                Console.Write("Creation Date (dd.MM.yyyy): ");
                var creationDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

                Console.Write("Due Date (dd.MM.yyyy): ");
                var dueDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

                Console.Write("Priority (None, Low, Medium, High, Urgent): ");
                var priority = Enum.Parse<Priority>(Console.ReadLine(), true);

                Console.Write("Complexity (None, Minutes, Hours, Days, Weeks): ");
                var complexity = Enum.Parse<Complexity>(Console.ReadLine(), true);

                workItems.Add(new WorkItem
                {
                    CreationDate = creationDate,
                    DueDate = dueDate,
                    Priority = priority,
                    Complexity = complexity,
                    Title = title,
                    Description = description,
                    IsCompleted = false
                });
            }

            var planner = new SimpleTaskPlanner();
            var sortedItems = planner.CreatePlan(workItems.ToArray());

            Console.WriteLine("\nSorted WorkItems:");
            foreach (var item in sortedItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}