using System;
using System.Collections.Generic;

// Base class representing a generic person
public class Person
{
    // Properties for all persons
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor for Person
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual method that can be overridden in derived classes
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

// Derived class: Student inherits from Person
public class Student : Person
{
    // Additional property specific to students
    public string Major { get; set; }

    // Constructor for Student that uses base constructor
    public Student(string name, int age, string major)
        : base(name, age)
    {
        Major = major;
    }

    // Override the base class DisplayInfo method
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // Call base version to show name and age
        Console.WriteLine($"Major: {Major}");
    }
}

// Derived class: Teacher inherits from Person
public class Teacher : Person
{
    // Additional property specific to teachers
    public string Subject { get; set; }

    // A sample salary field (used in overloaded methods)
    private int baseSalary = 3000;

    // Constructor for Teacher that uses base constructor
    public Teacher(string name, int age, string subject)
        : base(name, age)
    {
        Subject = subject;
    }

    // Override the base class DisplayInfo method
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // Call base version to show name and age
        Console.WriteLine($"Subject: {Subject}");
    }

    // Overloaded method: Calculate salary with no bonus
    public int CalculateSalary()
    {
        return baseSalary;
    }

    // Overloaded method: Calculate salary with a bonus
    public int CalculateSalary(int bonus)
    {
        return baseSalary + bonus;
    }
}

// Main entry point
class Program
{
    static void Main()
    {
        // Create a Student object
        Student student = new Student("Alice", 20, "Computer Science");
        Console.WriteLine("Student Info:");
        student.DisplayInfo(); // Calls overridden method in Student

        Console.WriteLine();

        // Create a Teacher object
        Teacher teacher = new Teacher("Mr. Smith", 45, "Mathematics");
        Console.WriteLine("Teacher Info:");
        teacher.DisplayInfo(); // Calls overridden method in Teacher

        Console.WriteLine();

        // Demonstrate method overloading with Teacher
        Console.WriteLine($"Base Salary: ${teacher.CalculateSalary()}");
        Console.WriteLine($"Salary with Bonus: ${teacher.CalculateSalary(500)}");
    }
}