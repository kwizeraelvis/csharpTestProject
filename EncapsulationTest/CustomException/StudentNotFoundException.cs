using System;
namespace EncapsulationTest.CustomException
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message): base(message) 
        {

        }
    }
}
