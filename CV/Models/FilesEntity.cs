namespace CV.Models;

public class FilesEntity
{
    public int Id { get; set; }

    public required string  FileName { get; set; }

    public required ICollection<CVEntity> Cvs { get; set; }
}