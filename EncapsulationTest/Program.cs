using System;
using System.Collections.Generic;
using EncapsulationTest.models;
using EncapsulationTest.controllers;

namespace EncapsulationTest
{
    class Program
    {
        static void Main(string[]args)
        {
          StudentController controller = new StudentController();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Enter your choice of operation\n--------------------------------------\n" +
                	"1.Create Student\n" +
                	"2.Update Student\n" +
                	"3.Delete Student\n" +
                	"4.List all students\n" +
                	"5.Exit\n------------------------------------\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Student s = new Student();
                        Console.WriteLine("Enter student information\n-------------------------------------------\n");
                        Console.WriteLine("Enter student id\t");
                        s.StudentId = Console.ReadLine();
                        Console.WriteLine("Enter the students firstname");
                        s.firstName = Console.ReadLine();
                        Console.WriteLine("Enter students last name");
                        s.lastname = Console.ReadLine();
                        Console.WriteLine("Enter student Email");
                        s.email = Console.ReadLine();
                        controller.CreateStudent(s);
                        break;
                    case 2:
                        Student n = new Student();
                        Console.WriteLine("Enter new student information\n-------------------------------------------\n");
                        Console.WriteLine("Enter id of student to be updated\t");
                        n.StudentId = Console.ReadLine();
                        Console.WriteLine("Enter the students new  firstname\t");
                        n.firstName = Console.ReadLine();
                        Console.WriteLine("Enter students new  last name\t");
                        n.lastname = Console.ReadLine();
                        Console.WriteLine("Enter students new Email\t");
                        n.email = Console.ReadLine();
                        controller.UpdateStudent(n);
                        break;
                    case 3:
                        Console.WriteLine("Enter student id o fstudent to be deleted\t");
                        string studentIdtoBeDeleted = Console.ReadLine();
                        controller.DeleteStudent(studentIdtoBeDeleted);
                        break;
                    case 4:
                        List<Student> students = new List<Student>();
                        students = controller.ListStudents();
                        Console.WriteLine("StudentId\t\t\t\tFirstname\t\t\t\tLastName\t\t\t\t\tEmail\n-----------------\t\t\t-----------------\t\t\t-----------------\t\t\t-----------------\n");
                        foreach (Student a   in students)
                        {
                            Console.WriteLine(a.StudentId + "\t\t\t\t\t" + a.firstName + "\t\t\t\t\t" + a.lastname + "\t\t\t\t\t" + a.email);
                        }
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input choice");
                        break;
                }
            }
        }
    }
}
