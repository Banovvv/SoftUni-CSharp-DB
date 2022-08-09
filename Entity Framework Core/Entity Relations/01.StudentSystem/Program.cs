using P01_StudentSystem.Data;
using System;

namespace _01.StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var context = new StudentSystemContext())
                {
                    context.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
