using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataBaseWork;

public class DataBase
{
    private readonly string _connectionString;

    public DataBase(IConfiguration configuration)
    {
        var settings = configuration.GetSection("DataBaseSettings");
        var dataBaseSettings = new DataBaseSettings
        {
            Server = settings["Server"],
            Port = settings["Port"],
            UserId = settings["UserId"],
            Password = settings["Password"],
            Database = settings["DataBase"]
        };
        _connectionString = $"Server={dataBaseSettings.Server};Port={dataBaseSettings.Port};UserId={dataBaseSettings.UserId};" +
                            $"Password={dataBaseSettings.Password};Database={dataBaseSettings.Database}";
    }

    public void Insert(Student student)
    {
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            const string commandText = "INSERT INTO public.\"Students\"(\"Id\", \"Name\", \"Surname\", \"Group\") VALUES (@Id, @Name, @Surname, @Group)";
            using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@Surname", student.Surname);
            command.Parameters.AddWithValue("@Group", student.Group);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);   
        }
    }

    public void Delete(int id)
    {
        try
        {
            using var connection = new NpgsqlConnection(connectionString:_connectionString);
            {
                connection.Open();
                var commandText = $"DELETE FROM public.\"Students\" WHERE \"Id\" = {id}";
                using var command = new NpgsqlCommand(commandText,connection);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(value: e);
        }
    }
    
    public Student Get(int id)
    {
        var student = new Student();
        try
        {
            using var connection = new NpgsqlConnection(connectionString:_connectionString);
            {
                connection.Open();
                var commandText = $"SELECT * FROM public.\"Students\" WHERE \"Id\" = {id}";
                using var command = new NpgsqlCommand(commandText,connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.Id = reader.GetInt32(0);
                    student.Name = reader.GetString(1);
                    student.Surname = reader.GetString(2);
                    student.Group = reader.GetString(3);
                }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(value: e);
        }
        return student;
    }
}