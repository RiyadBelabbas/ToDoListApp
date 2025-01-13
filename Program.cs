using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    class Program
    {
        class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public bool IsCompleted { get; set; }

            public override string ToString()
            {
                return $"[ {(IsCompleted ? "X" : " ")} ] {Title} - {Description}";
            }
        }

        // Liste des taches
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestionnaire de taches ===");
                Console.WriteLine("1. Ajouter une tache");
                Console.WriteLine("2. Afficher les taches");
                Console.WriteLine("3. Marquer une tache comme terminee");
                Console.WriteLine("4. Supprimer une tache");
                Console.WriteLine("5. Quitter");
                Console.Write("Choisissez une option : ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ShowTasks();
                        break;
                    case "3":
                        CompleteTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        Console.WriteLine("Au revoir !");
                        return;
                    default:
                        Console.WriteLine("Option invalide. Appuyez sur une touche pour reessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter une tache ===");
            Console.Write("Titre : ");
            string title = Console.ReadLine();
            Console.Write("Description : ");
            string description = Console.ReadLine();

            tasks.Add(new Task { Title = title, Description = description, IsCompleted = false });

            Console.WriteLine("Tache ajoutee avec succes !");
            Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
        }

        static void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des taches ===");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Aucune tache disponible.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
        }

        static void CompleteTask()
        {
            Console.Clear();
            Console.WriteLine("=== Marquer une tache comme terminee ===");
            ShowTasks();

            if (tasks.Count == 0)
            {
                return;
            }

            Console.Write("Entrez le numero de la tache a marquer comme terminee : ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
            {
                tasks[index - 1].IsCompleted = true;
                Console.WriteLine("Tache marquee comme terminee !");
            }
            else
            {
                Console.WriteLine("Numero invalide.");
            }

            Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
        }

        static void DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("=== Supprimer une tache ===");
            ShowTasks();

            if (tasks.Count == 0)
            {
                return;
            }

            Console.Write("Entrez le numero de la tache a supprimer : ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Tache supprimee !");
            }
            else
            {
                Console.WriteLine("Numero invalide.");
            }

            Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
        }
    }
}