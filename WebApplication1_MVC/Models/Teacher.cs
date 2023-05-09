using System.ComponentModel.DataAnnotations;

namespace WebApplication1_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int TEACHER_ID { get; set; }

        [Required(ErrorMessage = "Teacher Name is Required")]
        [Display(Name = "Employee Name")]
        public String TEACHER_NAME{ get; set; }
        public int AGE { get; set; }

    }
}
