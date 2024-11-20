namespace CV.Models;

public class CVEntity
{

    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone_number { get; set; }
    public string id_number { get; set; }
    public string education { get; set; }
    public string gender { get; set; }
    public string skills { get; set; }
    public string experience { get; set; }

    public int fileId { get; set; }

    public CV.Models.FilesEntity File { get; set; }


}