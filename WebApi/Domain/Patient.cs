namespace WebApi.Domain;

public class Patient
{
    public Patient() : this(0, 0, "", "", null)
    {
    }

    public Patient(int id, int clinicId, string firstName, string lastName, DateTime? dateOfBirth)
    {
        Id = id;
        ClinicId = clinicId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public int Id { get; }
    public int ClinicId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime? DateOfBirth { get; }
}