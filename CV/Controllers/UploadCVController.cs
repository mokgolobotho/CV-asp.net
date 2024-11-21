using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CV.Models;
using CV.Data;

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
    public IActionResult Uploadfile(IFormFile file)
    {
        filetobeuploaded(file);
        return View("Index");
    }

    private void filetobeuploaded(IFormFile file)
    {
        string extension = Path.GetExtension(file.FileName);
        if (extension.Equals(".xls") || extension.Equals(".csv"))
        {
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files");
            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);
        }
    }
}