using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DemoMVC.Models
{
    public class Logic
    {
        public Student GetDetails(int StudID)
        {
            Student s = new Student()
            {
                //StudentId =1,
                StudentId = StudID,
                Name = "Sree",
                Gender = "Female",
                Address = "Manassas"
            };
            return s;
        }

       
    }
}
