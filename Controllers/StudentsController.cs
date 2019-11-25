using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class StudentsController <T> : IAdding<T>, IDisplay
    {
        List<T> models;
        public StudentsController()
        {
            models = new List<T>();
        }

        public void Add(T model)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
