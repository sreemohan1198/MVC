namespace CustomersMvc.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShipperID { get; set; }
    }
}
