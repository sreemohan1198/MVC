using DemoMVC.Models;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoMVC.Data
{
    public class DataAccess
    {
        public List<Employee> GetEmployeeData()
        {

            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
           
            SqlConnection conn = new SqlConnection(connString);            
            conn.open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT [ENAME] FROM [dbo].[EMP]";
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee>lstemp=new List<Employee>();
            Employee emp=new Employee();
            while (reader.Read())
            {
                emp=new Employee();
                emp.ENAME = reader.GetValue(0);
               
                lstemp.Add( emp );                
            }
            conn.Close();
            return lstemp;

        }
    }
}
