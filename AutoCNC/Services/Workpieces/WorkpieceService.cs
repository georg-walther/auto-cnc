using AutoCNC.Models;
using AutoCNC.ServiceErrors;
using AutoCNC.Services.Workpieces;
using ErrorOr;

public class WorkpieceService : IWorkpieceService
{
    private static readonly Dictionary<Guid, Workpiece> _workpieces = new();

    public ErrorOr<Created> CreateWorkpiece(Workpiece workpiece)
    {
        // Store in database
        _workpieces.Add(workpiece.Id, workpiece);
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteWorkpiece(Guid id)
    {
        _workpieces.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Workpiece> GetWorkpiece(Guid id)
    {
        if (_workpieces.TryGetValue(id, out var workpiece))
        {
            return workpiece;
        }
        return Errors.Workpiece.NotFound;
    }

    public ErrorOr<UpsertedWorkpiece> UpsertWorkpiece(Workpiece workpiece)
    {
        var IsNewlyCreated = !_workpieces.ContainsKey(workpiece.Id);
        _workpieces[workpiece.Id] = workpiece;
        return new UpsertedWorkpiece(IsNewlyCreated);
    }
}