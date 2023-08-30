using System;

namespace HomeWork_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Федотов";
            string surname = "Александр";

            Console.WriteLine(name + " " + surname);
            (name, surname) = (surname, name);
            Console.WriteLine(name + " " + surname);
        }
    }
}