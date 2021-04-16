using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kartk4
{
    public class Student
    {
        public int id { set; get; }
        public string name { set; get; }
    }

    public class University : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            int ans = 1;
            var context = new University();
            while (ans != 0)
            {
                Console.WriteLine("0 - zakoncz");
                Console.WriteLine("1 - dodaj obiekt");
                Console.WriteLine("2 - wypisz rekordy z bazy");

                ans = Convert.ToInt32(Console.ReadLine());

                //var context = new University(); 
                if (ans == 1)
                {
                    string tmpName;
                    Console.WriteLine("Podaj imie studenta");
                    tmpName = Console.ReadLine();
                    var s = new Student { name = tmpName };
                    context.Students.Add(s);
                    context.SaveChanges();
                }
                else if (ans == 2)
                {
                    var students = context.Students.Where(s => s.id != -1).ToList<Student>();
                    foreach (var s in students)
                        Console.WriteLine($"id: {s.id}  name: {s.name}");
                }
                else if (ans == 0)
                {
                    Console.WriteLine("KONIEC");
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy wybor, sprobuj ponownie");
                }
            }



        }
    }
}