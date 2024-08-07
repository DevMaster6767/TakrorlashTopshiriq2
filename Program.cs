class Program
{
    class Task
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Description} (Bajarilgan: {IsCompleted})";
        }
    }

    static void Main()
    {
        List<Task> tasks = new List<Task>();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Vazifalarni boshqarish dasturi");
            Console.WriteLine("1. Vazifa qo'shish");
            Console.WriteLine("2. Vazifani o'chirish");
            Console.WriteLine("3. Vazifani bajarilganligini belgilash");
            Console.WriteLine("4. Vazifalar ro'yxatini ko'rsatish");
            Console.WriteLine("5. Dasturdan chiqish");
            Console.Write("Tanlovingizni kiriting: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Vazifa qo'shish
                    Console.Write("Vazifa tavsifini kiriting: ");
                    string description = Console.ReadLine();
                    tasks.Add(new Task { Description = description, IsCompleted = false });
                    Console.WriteLine("Vazifa qo'shildi.");
                    break;

                case "2":
                    // Vazifani o'chirish
                    Console.WriteLine("O'chirilishi kerak bo'lgan vazifaning raqamini tanlang:");
                    DisplayTasks(tasks);
                    int taskIndexToRemove = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (taskIndexToRemove >= 0 && taskIndexToRemove < tasks.Count)
                    {
                        tasks.RemoveAt(taskIndexToRemove);
                        Console.WriteLine("Vazifa o'chirildi.");
                    }
                    else
                    {
                        Console.WriteLine("Noto'g'ri raqam.");
                    }
                    break;

                case "3":
                    // Vazifani bajarilganligini belgilash
                    Console.WriteLine("Bajarilganligini belgilash kerak bo'lgan vazifaning raqamni tanlang:");
                    DisplayTasks(tasks);
                    int taskIndexToComplete = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (taskIndexToComplete >= 0 && taskIndexToComplete < tasks.Count)
                    {
                        tasks[taskIndexToComplete].IsCompleted = true;
                        Console.WriteLine("Vazifa bajarilgan deb belgilandi.");
                    }
                    else
                    {
                        Console.WriteLine("Noto'g'ri raqam.");
                    }
                    break;

                case "4":
                    // Vazifalar ro'yxatini ko'rsatish
                    DisplayTasks(tasks);
                    break;

                case "5":
                    // Dasturdan chiqish
                    running = false;
                    Console.WriteLine("Dastur tugadi.");
                    break;

                default:
                    Console.WriteLine("Noto'g'ri tanlov. Iltimos, qayta urunib ko'ring.");
                    break;
            }

            // Qayta ishga tushish uchun foydalanuvchidan kirish
            if (running)
            {
                Console.WriteLine("Davom etish uchun biror tugmani bosing...");
                Console.ReadKey();
            }
        }
    }

    static void DisplayTasks(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Hozircha hech qanday vazifa mavjud emas.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
}