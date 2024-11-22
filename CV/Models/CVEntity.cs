using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Models;

public class CVEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string IdNumber { get; set; }
    public required string Education { get; set; }
    public required string Gender { get; set; }
    public string? Skills { get; set; }
    public string? Experience { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int FileId { get; set; }

    public required FilesEntity File { get; set; } = null!;
}
