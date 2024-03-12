using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Models
{
    public class UserTable : Controller
    {
        public static string con_string = "Server=tcp:jacqueserver.database.windows.net,1433;Initial Catalog=JacquesDatabase;Persist Security Info=False;User ID=Jacques;Password=Deltacrest137;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public IActionResult Index()
        {
            return View();
        }
    }
}
