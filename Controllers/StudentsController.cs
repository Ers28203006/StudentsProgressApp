using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    public class StudentsController<T> : IAdding<T>, IDisplay where T : Student
    {
        public static List<T> models = new List<T>();

        public StudentsController(List<T> m)
        {
            models = m;
        }

        public void Add(T model)
        {
            models.Add(model);
            Console.Clear();
            Console.WriteLine("Запись успешно добавлена!\n");
        }

        public void Show()
        {
            int count = 1;
            foreach (var item in models)
            {
                Console.WriteLine($"{count}. {item}\n");
                count++;
            }
        }

        public List<T> MaxValue(List<T> list)
        {
            var maxValue = models.Max(m => m.Mark);
            foreach (var item in models)
                if (item.Mark == maxValue)
                    list.Add(item);
            return list;
        }

        public List<T> MinValue(List<T> list)
        {
            var minValue = models.Min(m => m.Mark);
            foreach (var item in models)
                if (item.Mark == minValue)
                    list.Add(item);
            return list;
        }

        public double AverageValue()
        {
            return models.Average(a => a.Mark);
        }
    }
}
