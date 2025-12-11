using System;

namespace StudentAttendanceSystem;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Student Attendance System (.NET 6) ===");

        Console.Write("Введите количество студентов: ");
        int studentCount = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Введите количество дней: ");
        int dayCount = int.Parse(Console.ReadLine() ?? "0");

        AttendanceManager manager = new AttendanceManager(dayCount);

        for (int i = 0; i < studentCount; i++)
        {
            Console.Write($"Имя студента #{i + 1}: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = $"Student{i + 1}";
            manager.AddStudent(name);
        }

        for (int day = 0; day < dayCount; day++)
        {
            Console.Clear();
            Console.WriteLine($"=== День {day + 1} ===");
            manager.MarkAttendance(day);
        }

        Console.Clear();
        manager.DisplayReport();

        manager.SaveToFile("attendance_log.txt");
        Console.WriteLine("Файл сохранён: attendance_log.txt");
    }
}