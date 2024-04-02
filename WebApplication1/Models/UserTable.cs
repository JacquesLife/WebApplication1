using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Models
{
    public class UserTable 
    {
        public static string con_string = "Server=tcp:jacqueserver.database.windows.net,1433;Initial Catalog=JacquesDatabase;Persist Security Info=False;User ID=Jacques;Password=Deltacrest137;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public String Name { get; set; }

        public String Surname { get; set; }

        public String Email { get; set; }

        public int insert_User(UserTable m) {
            string sql = "INSERT INTO UserTable (userName, userSurname, userEmail) VALUES (@userName, @userSurname, @userEmail)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userName", m.Name);
            cmd.Parameters.AddWithValue("@userSurname", m.Surname);
            cmd.Parameters.AddWithValue("@userEmail", m.Email);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;

        }
    }
}