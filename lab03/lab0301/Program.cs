using System;

class Person
{
    public int Age { get; set; }

    public void Greet()
    {
        Console.WriteLine("Hello, I'm a person.");
    }

    public void SetAge(int age)
    {
        Age = age;
    }
}

class Student : Person
{
    public void Study()
    {
        Console.WriteLine("I'm studying.");
    }

    public void ShowAge()
    {
        Console.WriteLine("My age is: " + Age + " years old.");
    }
}

class Professor : Person
{
    public void Explain()
    {
        Console.WriteLine("I'm explaining.");
    }
}

class StudentProfessorTest
{
    static void Main()
    {
        Person person = new Person();
        person.Greet();

        Student student = new Student();
        student.SetAge(20);
        student.Greet();
        student.Study();
        student.ShowAge();

        Professor professor = new Professor();
        professor.SetAge(40);
        professor.Greet();
        professor.Explain();
    }
}
