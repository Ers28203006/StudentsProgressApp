namespace Models
{
    public class Student
    {
        public string Name { get; set; }
        public double Mark { get; set; }
        public override string ToString()
        {
            return $"Имя студента: {Name}, средняя оценка: {Mark}";
        }
    }
}
