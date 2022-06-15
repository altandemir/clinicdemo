namespace WebApi.Domain;

public class Clinic 
{
    public Clinic() : this(0, "")
    {
    }

    public Clinic(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
    
}