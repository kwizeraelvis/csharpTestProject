using System;
using Npgsql;
using System.Collections.Generic;
using EncapsulationTest.models;
using EncapsulationTest.utils;
using EncapsulationTest.Attributes;
namespace EncapsulationTest.controllers
{
    [Author("Kwizera Aime Elvis")]
    public class StudentController : Connector
    {
        public StudentController()
        {
            connect();
            try
            {
                const string sqlQuery = "create table if not exists students" +
                    "(" +
                    "id varchar(5) primary key," +
                    "firstname varchar(30)," +
                    "lastname varchar(30)," +
                    "email varchar(30)" +
                    ");";
                commmand = new NpgsqlCommand(sqlQuery, connection);
                string TableCreationStatus = (commmand.ExecuteNonQuery() >= 1) ? "Table Created" : "Table not created";
                Console.WriteLine(TableCreationStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                disconnect();
            }
        }

        public void CreateStudent(Student s)
        {
            connect();
            try
            {
                const string sqlQuery = "insert into students values(@id,@firstName,@lastname,@email);";
                commmand = new NpgsqlCommand(sqlQuery, connection);
                commmand.Parameters.AddWithValue("@id", s.StudentId);
                commmand.Parameters.AddWithValue("@firstname", s.firstName);
                commmand.Parameters.AddWithValue("@lastname", s.lastname);
                commmand.Parameters.AddWithValue("@email", s.email);
                string StudentCreationStatus = (commmand.ExecuteNonQuery() >= 1) ? "Student was created" : "Student was not created";
                Console.WriteLine(StudentCreationStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                disconnect();
            }
        }
        public void UpdateStudent(Student s)
        {
            connect();
            try
            {
                const string sqlQuery = "update students set firstname=@firstname, lastname=@lastname, email=@email where id = @ id";
                commmand = new NpgsqlCommand(sqlQuery, connection);
                commmand.Parameters.AddWithValue("@firstname", s.firstName);
                commmand.Parameters.AddWithValue("@lastname", s.lastname);
                commmand.Parameters.AddWithValue("@email", s.email);
                commmand.Parameters.AddWithValue("@id", s.StudentId);
                string StudentUpdateStatus = (commmand.ExecuteNonQuery() >= 1) ? "Student was updated" : "Student was not updated";
                Console.WriteLine(StudentUpdateStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                disconnect();
            }
        }
        public void DeleteStudent(String studentName)
        {
            connect();
            try
            {
                const string sqlQuery = "delete from students where id = @id";
                commmand = new NpgsqlCommand(sqlQuery, connection);
                commmand.Parameters.AddWithValue("@id", studentName);
                string StudentDeletionStatus = (commmand.ExecuteNonQuery() >= 1) ? "Student was Deleted" : "Student was not Deleted";
                Console.WriteLine(StudentDeletionStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                disconnect();
            }
        }
        public List<Student> ListStudents()
        {
            connect();
            List<Student> studentList = new List<Student>();
            try
            {
                const string sqlQuery = "select * from students";
                commmand = new NpgsqlCommand(sqlQuery, connection);
                reader = commmand.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student
                    {
                        StudentId = reader["id"].ToString(),
                        firstName = reader["firstname"].ToString(),
                        lastname = reader["lastname"].ToString(),
                        email = reader["email"].ToString()
                    };
                    studentList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                disconnect();
            }
            return studentList;
        }
    }
}
