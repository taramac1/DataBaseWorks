using DataBaseWork;
using Microsoft.EntityFrameworkCore;

namespace GetDataWithOrmAndApi;

public class MyContext:DbContext
{
    private readonly IConfiguration _configuration;

    public MyContext(DbContextOptions<MyContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var settings = _configuration.GetSection("DataBaseSettings");
        var dataBaseSettings = new DataBaseSettings
        {
            Server = settings["Server"],
            Port = settings["Port"],
            UserId = settings["UserId"],
            Password = settings["Password"],
            Database = settings["DataBase"]
        };
        var connectionString =
            $"Server={dataBaseSettings.Server};Port={dataBaseSettings.Port};UserId={dataBaseSettings.UserId};" +
            $"Password={dataBaseSettings.Password};Database={dataBaseSettings.Database}";
        
        optionsBuilder.UseNpgsql(connectionString);
    }
    public DbSet<Student> Students { get; set; }
}