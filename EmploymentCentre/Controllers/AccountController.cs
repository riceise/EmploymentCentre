using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace EmploymentCentre.Controllers;


public class AccountController : Controller
{
    public IActionResult Registration()
    {
        return Registration();
    }

    public IActionResult Authorisation()
    {
        return Authorisation();
    }
}