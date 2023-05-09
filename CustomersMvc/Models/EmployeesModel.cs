namespace CustomersMvc.Models
{
    public class EmployeesModel
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; } = string.Empty;
        public TextReader? Notes { get; set; }
    }
}
