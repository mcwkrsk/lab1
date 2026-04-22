using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("========== ЗАДАНИЕ 1 – RGBA пиксель ==========\n");
        // Тесты RGBa
        var p1 = new RGBAPixel(255, 100, 50, 0.7);
        Console.WriteLine($"p1 = {p1}");
        Console.WriteLine($"HEX: {p1.ToHex()}");

        var a = new RGBAPixel(100, 150, 200, 0.5);
        var b = new RGBAPixel(50, 100, 30, 0.3);
        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * 2 = {a * 2}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        Console.WriteLine($"{a} / 2 = {a / 2}");

        Console.WriteLine("\n========== ЗАДАНИЕ 2 – Фабрика логгеров ==========\n");
        // Тесты фабрики
        var consoleLog = LoggerFactory.CreateLogger(LoggerFactory.LoggerType.Console);
        consoleLog.Log("Тест консоли");

        var fileLog = LoggerFactory.CreateLogger(LoggerFactory.LoggerType.File, "app.log");
        fileLog.Log("Тест файла");

        var remoteLog = LoggerFactory.CreateLogger(LoggerFactory.LoggerType.Remote, "http://test.com");
        remoteLog.Log("Тест удалённого");

        Console.WriteLine("\n========== ЗАДАНИЕ 3 – Дерево ==========\n");
        // Тесты дерева 
        var root = new TreeNode<string>("Корень");
        var child1 = new TreeNode<string>("Ветка 1");
        var child2 = new TreeNode<string>("Ветка 2");
        root.AddChild(child1);
        root.AddChild(child2);
        child1.AddChild(new TreeNode<string>("Лист 1.1"));
        child1.AddChild(new TreeNode<string>("Лист 1.2"));
        child2.AddChild(new TreeNode<string>("Лист 2.1"));
        root.PrintAllValues();
    }
}