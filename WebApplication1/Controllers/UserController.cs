

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

public class UserController : Controller
{
    public UserTable usrtbl = new UserTable();

    [HttpPost]

    public ActionResult About(UserTable Users)
    {
        var result = usrtbl.insert_User(Users);
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public ActionResult About()
    {
        return View(usrtbl);
    }
}