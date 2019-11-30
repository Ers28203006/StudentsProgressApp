using Controllers;
using System;

namespace StudentsProgressApp
{
    public class Start
    {
        public static void StartOperation()
        {
            while (true)
            {
                Service.StartPage();
                int exit;
                Console.WriteLine("Хотите выйти из приложения? \n" +
                    "0 - нет;\n" +
                    "1 - да.\n");
                exit = int.Parse(Console.ReadLine());
                if (exit <= 1 && exit >= 0)
                {
                    if (exit == 1) break;
                    else Console.Clear();
                }
            }
        }
    }
}
