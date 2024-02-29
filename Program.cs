using System;
using System.Collections.Generic;

class Student
{
    public string StudentNumber { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string studentNumber, string name, int age)
    {
        StudentNumber = studentNumber;
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        SortedDictionary<string, Student> studentDictionary = new SortedDictionary<string, Student>();

        studentDictionary.Add("S12345", new Student("S12345", "Mohamed Fadili", 21));
        studentDictionary.Add("S67890", new Student("S67890", "Marouane El Jaghnouni", 22));
        studentDictionary.Add("S11111", new Student("S11111", "Gurpreet Singh", 20));
        studentDictionary.Add("S22222", new Student("S23242", "Anwar Kabiri", 23));
        studentDictionary.Add("S35733", new Student("S35733", "Yassin Mounadi", 24));
        studentDictionary.Add("S33253", new Student("S33253", "Bahim Abbasi", 19));
        studentDictionary.Add("S43539", new Student("S43539", "Bahija Kadiri", 21));
        studentDictionary.Add("S43537", new Student("S43537", "Idris Mounadi", 20));
        studentDictionary.Add("S34343", new Student("S34343", "Samir Oulmamon", 22));
        studentDictionary.Add("S34832", new Student("S12661", "Yassin Faska", 24));

        Console.Write("Voer een studentnummer in: ");
        string userInput = Console.ReadLine();

        // Probeer een student te vinden
        if (studentDictionary.TryGetValue(userInput, out Student foundStudent))
        {
            Console.WriteLine($"Student gevonden - Studentnummer: {foundStudent.StudentNumber}, Naam: {foundStudent.Name}, Leeftijd: {foundStudent.Age} jaar");
        }
        else
        {
            Console.WriteLine($"Student met studentnummer {userInput} niet gevonden.");
        }

        // Druk een lijst met studentennummers en namen af
        Console.WriteLine("\nLijst met studentennummers en namen (gesorteerd op studentnummer):");
        foreach (var entry in studentDictionary)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value.Name}");
        }

        // Zoek de oudste student op
        Student oldestStudent = FindOldestStudent(studentDictionary);
        Console.WriteLine($"\nOudste student - Studentnummer: {oldestStudent.StudentNumber}, Naam: {oldestStudent.Name}, Leeftijd: {oldestStudent.Age} jaar");

        // Druk een lijst van studenten af gesorteerd op leeftijd
        Console.WriteLine("\nLijst van studenten gesorteerd op leeftijd:");
        foreach (var student in SortStudentsByAge(studentDictionary))
        {
            Console.WriteLine($"{student.StudentNumber}: {student.Name}, Leeftijd: {student.Age} jaar");
        }
    }

    static Student FindOldestStudent(SortedDictionary<string, Student> students)
    {
        Student oldestStudent = null;

        foreach (var student in students.Values)
        {
            if (oldestStudent == null || student.Age > oldestStudent.Age)
            {
                oldestStudent = student;
            }
        }

        return oldestStudent;
    }

    static List<Student> SortStudentsByAge(SortedDictionary<string, Student> students)
    {
        List<Student> sortedList = new List<Student>(students.Values);
        sortedList.Sort((s1, s2) => s1.Age.CompareTo(s2.Age));
        return sortedList;
    }
}