using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace YYMDotNetInternshipTraining.EFCoreSample1;

public class EFCoreSample1
{
    private readonly AppDbContext _db;

    public EFCoreSample1()
    {
        _db = new AppDbContext();
    }

    public void Read()
    {
        List<Student> lst = _db.Students.ToList();
        foreach (Student s in lst)
        {
            Console.WriteLine(s.FatherName);
        }
    }

    public void Edit()
    {
        var student = _db.Students.FirstOrDefault(s => s.StudentId == 1);
        if (student is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        Console.WriteLine(JsonConvert.SerializeObject(student));
        Console.WriteLine(JsonConvert.SerializeObject(student, Newtonsoft.Json.Formatting.Indented));
    }

    public void Create()
    {
        Student item = new Student
        {
            StudentNo = "STU016",
            StudentName = "Su Mon",
            FatherName = "U Mya Maung",
            Address = "Yangon, Myanmar",
            DateOfBirth = new DateTime(2002, 5, 21),
            IsDelete = false,
            CreatedDateTime = DateTime.Now,
            CreatedBy = "admin"
        };

        _db.Students.Add(item);
        int result = _db.SaveChanges();
        Console.WriteLine(result > 0 ? "Saving Successful." : "Saving Failed.");
    }

    public void Update()
    {
        var student = _db.Students.FirstOrDefault(s => s.StudentId == 1);
        if (student is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        student.FatherName = "U Kyaw Aung";
        int result = _db.SaveChanges();
        Console.WriteLine(result > 0 ? "Updating Successful." : "Updating Failed.");
    }

    public void Delete()
    {
        var student = _db.Students.FirstOrDefault(s => s.StudentId == 1);
        if (student is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        student.IsDelete = true;

        //_db.Students.Remove(student);

        int result = _db.SaveChanges();
        Console.WriteLine(result > 0 ? "Deleting Successful." : "Deleting Failed.");
    }
}