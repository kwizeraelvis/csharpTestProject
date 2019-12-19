using System;
using System.ComponentModel.DataAnnotations;
namespace EncapsulationTest.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,AllowMultiple = true,Inherited =true)]
    public class Author : System.Attribute
    {
        private string AuthorName;
        public Author(string name)
        {
            this.AuthorName = name;
        }
        public Author()
        {
            this.AuthorName = "Kwizera Aime Elvis";
        }
    }
}
