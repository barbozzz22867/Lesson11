using System;
using System.Data;

namespace MyProgram
{
    class Program
    {
        static void Main()
        {
            DataTable students = new DataTable("Students");

            students.Columns.Add("Id", typeof(int));
            students.Columns.Add("Name", typeof(string));
            students.Columns.Add("Age", typeof(int));
            students.Columns.Add("GroupName", typeof(string));

            students.Rows.Add(1, "Микаелян Артур", 20, "РПО-101");
            students.Rows.Add(2, "Кузьмин Эдуард", 22, "РПО-102");
            students.Rows.Add(3, "Иван Иванов", 19, "РПО-101");
            students.Rows.Add(4, "Козлов Дмитрий", 23, "КГИД-103");
            students.Rows.Add(5, "Новиков Иван", 21, "РПО-102");

            Console.WriteLine("Таблица студентов:");
            Console.WriteLine(new string('-', 60));

            foreach (DataColumn column in students.Columns)
            {
                Console.Write($"{column.ColumnName,-15}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));

            foreach (DataRow row in students.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-15}");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 60));

            DataRow oldestStudent = students.Rows[0];

            for (int i = 1; i < students.Rows.Count; i++)
            {
                if ((int)students.Rows[i]["Age"] > (int)oldestStudent["Age"])
                {
                    oldestStudent = students.Rows[i];
                }
            }

            Console.WriteLine($"\nСамый старший студент: {oldestStudent["Name"]}, возраст: {oldestStudent["Age"]}, группа: {oldestStudent["GroupName"]}");
        }
    }
}