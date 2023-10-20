using DataBaseWork;
using GetDataWithOrmAndApi;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpPost("Insert")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task Insert(Student student)
    {
        await _studentRepository.InsertStudentAsync(student);
    }

    [HttpPost("Delete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task Delete(int id)
    {
        await _studentRepository.DeleteStudentAsync(id);
    }

    [HttpPost("Get")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<Student[]> Get(int id)
    {
        return await _studentRepository.GetStudentsAsync(id);
    }
}