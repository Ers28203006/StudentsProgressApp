using Models;
using System;
using System.Collections.Generic;

namespace Controllers
{
    public class Service
    {
        static int choice = 0;
        static List<Student> students = new List<Student>()
        {
            new Student(){ Name="Билл", Mark=3},
            new Student(){ Name="Стив", Mark=3},
            new Student(){ Name="Макс", Mark=5},
            new Student(){ Name="Нурболат", Mark=4},
            new Student(){ Name="Александр", Mark=4},
            new Student(){ Name="Лев", Mark=5},
        };
        static StudentsController<Student> studentsController = new StudentsController<Student>(students);
        public static void StartPage()
        {
            Console.WriteLine("Добро пожаловать в приложение для оценки успеваемости студентов!\n");
            Console.WriteLine("Выберите желаемое действие: \n" +
                "1.Ввод данных студента (имя, средняя оценка);\n" +
                "2.Отобразить имя самого лучшего студента;\n" +
                "3.Отобразить имя самого худшего студента;\n" +
                "4.Отобразить общую среднюю оценку по группе;\n" +
                "5.Показать весь список студентов.");
            choice = int.Parse(Console.ReadLine());
            ChoiceAction();
        }
       
        static void ChoiceAction()
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Record();
                    break;
                case 2:
                    Display(studentsController.MaxValue(new List<Student>()));
                    break;
                case 3:
                    Display(studentsController.MinValue(new List<Student>()));
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine($"Средняя оценка группы: {studentsController.AverageValue()}.");
                    break;
                case 5:
                    Console.Clear();
                    studentsController.Show();
                    break;
            }
        }
        static void Record()
        {
            int output;
            while (true)
            {
                Student student = new Student();
                Console.Clear();
                while (true)
                {
                    Console.Write("Имя студента: ");
                    student.Name = Console.ReadLine();
                    Console.Write("Cредняя оценка студента: ");
                    double.TryParse(Console.ReadLine(), out double mark);
                    if (mark!= 0)
                    {
                        student.Mark = mark;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не верное значение оценки, вводите цифры");
                    }
                }
                Console.WriteLine("\nЧтобы сохранить введенные данные в коллекцию нажмите Enter, для выхода нажмите любую другую клавишу");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    studentsController.Add(student);

                else if (key.Key != ConsoleKey.Enter)
                {
                    int isSave;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы не сохранили введенные данные, сохранить? \n" +
                            "0 - нет;\n" +
                            "1 - да.");
                        isSave = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (isSave <= 1 && isSave >= 0) break;
                    }
                    switch (isSave)
                    {
                        case 1:
                            studentsController.Add(student);
                            break;
                        default: break;
                    }
                }

                Console.WriteLine("Выйти из окна записи?\n" +
                        "0 - нет;\n" +
                        "1 - да.\n");
                output = int.Parse(Console.ReadLine());
                if (output == 1) break;
            }

        }
        static void Display(List<Student> students)
        {
            Console.Clear();
            foreach (var s in students)
                Console.WriteLine($"Имя студента: {s.Name}, со средним баллом {s.Mark}");
        }
    }
}
