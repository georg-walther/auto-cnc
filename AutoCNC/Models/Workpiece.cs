using AutoCNC.ServiceErrors;
using ErrorOr;

namespace AutoCNC.Models;

public class Workpiece
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Material { get; }
    public DateTime LastModifiedDateTime { get; }

    private Workpiece(Guid id, string name, string description, string material, DateTime lastModifiedDateTime)
    {
        Id = id;
        Name = name;
        Description = description;
        Material = material;
        LastModifiedDateTime = lastModifiedDateTime;
    }

    public static ErrorOr<Workpiece> Create(
        string name,
        string description,
        string material,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
           errors.Add(Errors.Workpiece.InvalidName);
        }
        
        if (errors.Count > 0)
        {
            return errors;
        }
        return new Workpiece(
            id ?? Guid.NewGuid(),
            name,
            description,
            material,
            DateTime.UtcNow);
    }
}