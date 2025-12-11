using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StudentAttendanceSystem;

public class AttendanceManager
{
    private readonly List<Student> _students = new();
    private readonly int _days;

    public AttendanceManager(int days)
    {
        _days = days;
    }

    public void AddStudent(string name)
    {
        _students.Add(new Student(name, _days));
    }

    public void MarkAttendance(int day)
    {
        foreach (var s in _students)
        {
            Console.Write($"Присутствует {s.Name}? (y/n): ");
            string? input = Console.ReadLine()?.Trim().ToLower();
            s.Attendance[day] = (input == "y" || input == "д" || input == "да");
        }
    }

    public void DisplayReport()
    {
        Console.WriteLine("=== Отчёт по посещаемости ===");
        foreach (var s in _students) Console.WriteLine(s);
    }

    public void SaveToFile(string filePath)
    {
        using StreamWriter sw = new(filePath);
        foreach (var s in _students)
        {
            sw.WriteLine(s.Name + "," + string.Join(",", s.Attendance.Select(a => a.ToString())));
        }
    }
}