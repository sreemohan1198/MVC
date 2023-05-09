using CustomersMvc.Models;
using System.Data.SqlClient;

namespace CustomersMvc.Data
{
    public class DataAccess
    {
        public List<CustomerModel> GetData_SqlDataReader()
        {           
            String ConnString = @"Data Source=.;Initial Catalog=CustomerOrders;Integrated Security=True";
            
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select CustomerID,CustomerName,ContactName,Address,City,PostalCode,Country  
                                    from [dbo].[Customers]";
            SqlDataReader reader = cmd.ExecuteReader();

            List<CustomerModel> lstCustomerModel = new List<CustomerModel>();
            CustomerModel customermodel = new CustomerModel();
            while (reader.Read())
            {
                customermodel = new CustomerModel();
                customermodel.CustomerID = Convert.ToInt32(reader[0]);
                customermodel.CustomerName = reader[1].ToString();
                customermodel.ContactName = reader[2].ToString();
                customermodel.Address = reader[3].ToString();
                customermodel.City = reader[4].ToString();
                customermodel.PostalCode = reader[5].ToString();
                customermodel.Country = reader[6].ToString();
                lstCustomerModel.Add(customermodel);
            }
            //conn.Close();
            return lstCustomerModel;
        }

        public void Insert(CustomerModel customer)
        {
            String ConnString = @"Data Source=.;Initial Catalog=CustomerOrders;Integrated Security=True";

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO [dbo].[Customers](CustomerID,CustomerName,ContactName,Address,City,PostalCode,Country)
                                VALUES(@CustomerID,@CustomerName,@ContactName,@Address,@City,@PostalCode,@Country)";

            cmd.Parameters.AddWithValue("@CustomerId",customer.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@ContactName",customer.ContactName);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmd.Parameters.AddWithValue("@Country",customer.Country);

            //conn.Close();
            //Exception Handling
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                conn.Close();
                Console.Read();
            }
        }

        public CustomerModel GetCustomerById(int CustomerID)
        {

            // Windows Authenticaion
            String ConnString = @"Data Source=.;Initial Catalog=CustomerOrders;Integrated Security=True";

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select CustomerID,CustomerName,ContactName,Address,City,PostalCode,Country  
                                    from [dbo].[Customers] WHERE CustomerID=@CustomerID";

            cmd.Parameters.AddWithValue("@CustomerID",CustomerID);
            SqlDataReader reader = cmd.ExecuteReader();
            CustomerModel custdetails=new CustomerModel();

            while (reader.Read())
            {
                custdetails = new CustomerModel();
                custdetails.CustomerID = Convert.ToInt32(reader[0]);
                custdetails.CustomerName = reader[1].ToString();
                custdetails.ContactName = reader[2].ToString();
                custdetails.Address = reader[3].ToString();
                custdetails.City = reader[4].ToString();
                custdetails.PostalCode = reader[5].ToString();
                custdetails.Country = reader[6].ToString();
                
            }
               //conn.Close();

            return custdetails;
        }


        public void Update(CustomerModel customer)
        {
            String ConnString = @"Data Source=.;Initial Catalog=CustomerOrders;Integrated Security=True";

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE [dbo].[Customers]
                                SET (CustomerID=@CustomerID,
                                    CustomerName=@CustomerName,  
                                    ContactName=@ContactName,    
                                    Address=@Address,    
                                    City=@City,
                                    PostalCode=@PostalCode,
                                    Country=@Country
                                WHERE CustomerID=@CustomerID";

            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmd.Parameters.AddWithValue("@Country", customer.Country);

            //conn.Close();
            //Exception Handling
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                conn.Close();
                Console.Read();
            }
        }

    }
}
