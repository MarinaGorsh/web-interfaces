using System;
using System.Reflection;

public class MyClass
{
    public string name;
    public object surname;
    private int age;
    protected double height;
    internal bool legalAge;

    public MyClass(string name, object surname, int age, double height, bool legalAge)
    {
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.height = height;
        this.legalAge = legalAge;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Surname: {surname}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Height: {height}");
        Console.WriteLine($"LegalAge: {legalAge}");
    }

    public void ChangeHeight(double newHeight)
    {
        height = newHeight;
        Console.WriteLine($"Height has been changed to {newHeight}");
    }

    public bool CheckLegalAge()
    {
        return age >= 18;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);
        TypeInfo typeInfo = type.GetTypeInfo();
        Console.WriteLine($"Type Name: {type.FullName}");
        Console.WriteLine($"Is Abstract?: {typeInfo.IsAbstract}");
        Console.WriteLine($"Is Class?: {typeInfo.IsClass}");
        Console.WriteLine($"Is Public?: {typeInfo.IsPublic}");

        MemberInfo[] members = type.GetMembers();
        Console.WriteLine("\nMembers:");
        foreach (var member in members)
        {
            Console.WriteLine($"{member.MemberType}: {member.Name}");
        }

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("\nFields:");
        foreach (var field in fields)
        {
            Console.WriteLine($"{field.FieldType} {field.Name} public? {field.IsPublic}");

        }

        MethodInfo methodInfo = type.GetMethod("Display");
        if (methodInfo != null)
        {
            Console.WriteLine($"\nMethod: {methodInfo.Name}");
            MyClass me = new MyClass("Maryna", "Horshevska", 19, 160, true);
            methodInfo.Invoke(me, null);
        }
    }
}
