using System.Data.SqlClient;
using APBD4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD4;

[ApiController]
[Route("/api/student")]
public class StudentController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public StudentController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public IActionResult GetStudents()
    {
        using var connection = new SqlConnection(
            _configuration.GetConnectionString("DefaultConnection"));
        var students = Db.Students;
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Students", connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var student = new Student()
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString()!
            };
            students.Add(student);
        }
        
        
        return Ok(students);
    }
}