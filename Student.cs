using System.Linq;

namespace StudentAttendanceSystem;

public class Student
{
    public string Name { get; set; }
    public bool[] Attendance { get; set; }

    public Student(string name, int totalDays)
    {
        Name = name;
        Attendance = new bool[totalDays];
    }

    public double Percentage =>
        Attendance.Length == 0 ? 0 :
        (double)Attendance.Count(d => d) / Attendance.Length * 100;

    public override string ToString()
        => $"{Name}: {Percentage:F2}% присутствий";
}