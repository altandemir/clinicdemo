namespace WebApi.Dto;

public class PatientDto
{
    public int Id { get; set; }
    public int ClinicId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
}