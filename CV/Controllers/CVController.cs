using Microsoft.AspNetCore.Mvc;
using CV.Models;
using CV.Data;

namespace CV.Controllers;

public class CVController : Controller
{
    private ApplicationDbContext _db;

    public CVController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public IActionResult Uploadfile(IFormFile file)
    {
        filetobeuploaded(file);
        return View();
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