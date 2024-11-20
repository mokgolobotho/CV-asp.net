namespace CV.Models;

public class FilesEntity
{
    public int id { get; set; }

    public string fileName { get; set; }

    public ICollection<CV.Models.CVEntity> cvs { get; set; }
}