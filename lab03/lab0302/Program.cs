using System;

public class User
{
    protected string name;
    protected int age;

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setAge(int age)
    {
        this.age = age;
    }

    public int getAge()
    {
        return age;
    }
}

public class Worker : User
{
    private double salary;

    public void setSalary(double salary)
    {
        this.salary = salary;
    }

    public double getSalary()
    {
        return salary;
    }
}

public class Student : User
{
    private double scholarship;
    private int course;

    public void setScholarship(double scholarship)
    {
        this.scholarship = scholarship;
    }

    public double getScholarship()
    {
        return scholarship;
    }

    public void setCourse(int course)
    {
        this.course = course;
    }

    public int getCourse()
    {
        return course;
    }
}

public class Driver : Worker
{
    private int drivingExperience;
    private string drivingCategory;

    public void setDrivingExperience(int drivingExperience)
    {
        this.drivingExperience = drivingExperience;
    }

    public int getDrivingExperience()
    {
        return drivingExperience;
    }

    public void setDrivingCategory(string drivingCategory)
    {
        this.drivingCategory = drivingCategory;
    }

    public string getDrivingCategory()
    {
        return drivingCategory;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker ivan = new Worker();
        ivan.setName("Iван");
        ivan.setAge(25);
        ivan.setSalary(1000);

        Worker vasya = new Worker();
        vasya.setName("Вася");
        vasya.setAge(26);
        vasya.setSalary(2000);

        double totalSalary = ivan.getSalary() + vasya.getSalary();
        Console.WriteLine($"Сума зарплат Iвана та Васi: {totalSalary}");

        Driver driver = new Driver();
        driver.setName("Олексiй");
        driver.setAge(30);
        driver.setSalary(3000);
        driver.setDrivingExperience(5);
        driver.setDrivingCategory("B");

        Console.WriteLine($"Водiй {driver.getName()} має зарплату {driver.getSalary()}, водiйський стаж {driver.getDrivingExperience()} та категорiю водiння {driver.getDrivingCategory()}");
    }
}
