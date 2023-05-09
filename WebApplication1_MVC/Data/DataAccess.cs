using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApplication1_MVC.Models;



namespace WebApplication1_MVC.Data
{
    public class DataAccess
    {
        static void Main(string[] args)

        {
            String ConnectionStrings = "Data Source=.;Initial Catalog=TEACHER_STUDENT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            //SqlCommand cmd = new SqlCommand("SELECT TEACHER_NAME,STUDENT_NAME FROM TEACHER INNER JOIN TEACHER_COURSE ON TEACHER.TEACHER_ID=TEACHER_COURSE.TEACHER_ID INNER JOIN COURSE ON TEACHER_COURSE.COURSE_ID=COURSE.COURSE_ID INNER JOIN STUDENT_COURSE ON COURSE.COURSE_ID=STUDENT_COURSE.COURSE_ID INNER JOIN STUDENT ON STUDENT_COURSE.STUDENT_ID=STUDENT.STUDENT_ID", conn);
            //SqlCommand cmd = new SqlCommand("Select * from TEACHER", conn);

            //conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "dbo.spTeachernameStudentName";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Teacher> list = new List<Teacher>();
            while (dr.Read())
            {
                Teacher tdb = new Teacher();
                tdb.TEACHER_ID = Convert.ToInt32(dr[0]);
                tdb.COURSE_ID = Convert.ToInt32(dr[1]);
                tdb.STUDENT_ID = Convert.ToInt32(dr[2]);
                list.Add(tdb);
            }
            foreach (Teacher tdb in list)
            {
                Console.WriteLine(tdb.TEACHER_ID + " - " + tdb.COURSE_ID + " - " + tdb.STUDENT_ID);
            }

            //-------------------------------------------//

            //List<Teacher> list2 = new List<Teacher>();
            //while (dr.Read())
            //{
            //    Teacher t = new Teacher();
            //    t.TEACHER_NAME = dr[0].ToString();
            //    //t.STUDENT_NAME = dr[1].ToString();
            //    //t.COURSE_ID = Convert.ToInt32(dr[2]);

            //    list2.Add(t);
            //}
            //foreach (Teacher t in list2)
            //{
            //    Console.Write(t.TEACHER_NAME + " ");
            //    //Console.WriteLine(t.STUDENT_ID + " ");
            //    //Console.WriteLine(t.COURSE_ID + " ");
            //}
            //----------------------------------------//

            //cmd.CommandText = "dbo.spTeachernameStudentName";
            //cmd.ExecuteNonQuery();
            //List<Student> list = new List<Student>();

            //while (dr.Read())
            //{
            //    Student s = new Student();
            //    s.STUDENT_NAME = dr[0].ToString();
            //    s.TEACHER_NAME = dr[1].ToString();
            //    list.Add(s);
            //}
            //foreach (Student s in list)
            //{
            //    //Console.Write("Teacher_NAME" +" - "+"STUDENT_NAME");
            //    Console.Write(s.STUDENT_NAME + " - ");
            //    Console.WriteLine(s.TEACHER_NAME);
            //}



            //-----------READING DATA FROM TEACHER TABLE---------------------//////


            //cmd.CommandText = "SELECT [TEACHER_ID],[TEACHER_NAME],[AGE] FROM [dbo].[TEACHER]";

            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Teacher t = new Teacher();
            //    t.TEACHER_ID = reader[0].GetHashCode();
            //    t.TEACHER_NAME = reader[1].ToString();
            //    t.AGE = reader[2].GetHashCode();

            //    string row = reader.GetValue(0) + " - " + reader.GetValue(1);
            //    Console.WriteLine(row);
            //}
            //Console.ReadLine();
            //conn.Close();

            //-----------INSERT DATA INTO STUDENT TABLE-----------------------//


//            cmd.CommandText = @"INSERT INTO [dbo].[STUDENT] ([STUDENT_ID],[STUDENT_NAME],[MARKS])
//                                 VALUES(@STUDENT_ID,@STUDENT_NAME,@MARKS)";
//            Student student = new Student();

//            cmd.Parameters.AddWithValue("@STUDENT_ID", 7);
//            cmd.Parameters.AddWithValue("@STUDENT_NAME", "Mahesh");
//            cmd.Parameters.AddWithValue("@MARKS", 40);

//            try
//            {
//                conn.Open();
//                cmd.ExecuteNonQuery();
//            }
//            catch (Exception e)
//            {

//                Console.WriteLine("Error Generated. Details: " + e.ToString());
//            }
//            finally
//            {
//                conn.Close();
//                Console.Read();
//            }
//            Console.Read();


//            //--------------UPDATE VALUES IN COURSE TABLE-------------------//


//            cmd.CommandText = @"UPDATE [dbo].[COURSE]
//                                   SET [COURSE_ID] = @COURSE_ID
//                                      ,[COURSE_CODE] = @COURSE_CODE
//                                      ,[COURSE_NAME] = @COURSE_NAME
//                                 WHERE COURSE_ID=@COURSE_ID";

//            Course c = new Course();

//            cmd.Parameters.AddWithValue("@COURSE_ID", "203");
//            cmd.Parameters.AddWithValue("@COURSE_CODE", "1007");
//            cmd.Parameters.AddWithValue("@COURSE_NAME", "HTML");

//            try
//            {
//                conn.Open();
//                cmd.ExecuteNonQuery();
//            }
//            catch (Exception e)
//            {

//                Console.WriteLine("Error Generated. Details: " + e.ToString());
//            }
//            finally
//            {
//                conn.Close();
//                Console.Read();
//            }
//            Console.Read();

        }
    }
}
