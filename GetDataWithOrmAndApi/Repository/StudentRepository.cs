using DataBaseWork;
using GetDataWithOrmAndApi;
using Microsoft.EntityFrameworkCore;

public class StudentRepository : IStudentRepository
{
    private readonly MyContext _context;

    public StudentRepository(MyContext context)
    {
        _context = context;
    }

    public async Task InsertStudentAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(int id)
    {
        var studentsToDelete = await _context.Students.Where(x => x.Id == id).ToListAsync();
        _context.Students.RemoveRange(studentsToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<Student[]> GetStudentsAsync(int id)
    {
        return await _context.Students.Where(x => x.Id == id).ToArrayAsync();
    }
}