using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CV.Data;
using CV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CV.Controllers;

public class UploadCVController : Controller
{
    private ApplicationDbContext _db;

    public UploadCVController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UploadFile(IFormFile file)
    {
        try
        {
            var cvEntities = FileToBeUploaded(file);
            return View("ViewCV", cvEntities);
        }
        catch (Exception e)
        {
            return View("NoFile");
        }
    }

    private List<CVEntity> FileToBeUploaded(IFormFile file)
    {
        string extension = Path.GetExtension(file.FileName);
        var cvEntities = new List<CVEntity>();
        if (extension.Equals(".xls") || extension.Equals(".csv"))
        {
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files");
            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);

            file.CopyTo(stream);
            cvEntities = SaveCv(file, fileName);
        }
        return cvEntities;
    }

    private List<CVEntity> SaveCv(IFormFile file, String fileName)
    {
        var cvEntities = new List<CVEntity>();
        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            stream.Position = 0;

            using (var reader = new StreamReader(stream))
            using (
                var csv = new CsvReader(
                    reader,
                    new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true,
                        HeaderValidated = null,
                        MissingFieldFound = null,
                    }
                )
            )
            {
                cvEntities = csv.GetRecords<CVEntity>().ToList();
            }
            Console.WriteLine(cvEntities.Count);
        }
        var fileEntity = new FilesEntity { FileName = fileName, Cvs = cvEntities };

        _db.Files.Add(fileEntity);
        _db.SaveChanges();

        return cvEntities;
    }
}
