using DataBaseWork;

namespace GetDataWithOrmAndApi;

public interface IStudentRepository
{
    Task InsertStudentAsync(Student student);
    Task DeleteStudentAsync(int id);
    Task<Student[]> GetStudentsAsync(int id);
}