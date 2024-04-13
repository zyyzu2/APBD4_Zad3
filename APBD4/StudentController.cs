using Microsoft.AspNetCore.Mvc;

namespace APBD4;

[ApiController]
[Route("/api/student")]
public class StudentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = Db.Students;
        return Ok(students);
    }
}