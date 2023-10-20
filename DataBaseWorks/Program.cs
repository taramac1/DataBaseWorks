using System.Threading.Channels;
using DataBaseWork;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true)
    .Build();
    
var bd = new DataBase(configuration);
var student = new Student { Id = 1, Name = "name", Surname = "surname", Group = "AUBP" };
bd.Insert(student);
var studentFromBase = bd.Get(1);
Console.Write($"Name: {studentFromBase.Name}, Surname: {studentFromBase.Surname}, Group: {studentFromBase.Group}");
bd.Delete(1);