using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CV.Data;
using CV.Models;
using Microsoft.AspNetCore.Mvc;

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
            FileToBeUploaded(file);
            return View("Index");
        }
        catch (Exception e)
        {
            return View("NoFile");
        }
    }

    private void FileToBeUploaded(IFormFile file)
    {
        string extension = Path.GetExtension(file.FileName);
        if (extension.Equals(".xls") || extension.Equals(".csv"))
        {
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files");
            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);
            SaveCv(file);
        }
    }

    private List<CVEntity> SaveCv(IFormFile file)
    {
        var cvEntities = new List<CVEntity>();
        try
        {
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
                        }
                    )
                )
                {
                    cvEntities = csv.GetRecords<CVEntity>().ToList();
                }
            }
            var fileEntity = new FilesEntity { fileName = file.FileName };
            _db.FilesEntity.Add(filesEntity);
            _db.SaveChanges();
            foreach (var cv in cvList)
            {
                cv.fileId = filesEntity.id;
            }

            _db.CVEntity.AddRange(cvList);
            _db.SaveChanges();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(
                "An error occurred while processing the CSV file.",
                ex
            );
        }
    }
}
