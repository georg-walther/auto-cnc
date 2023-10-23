using AutoCNC.Models;
using AutoCNC.Services.Workpieces;
using ErrorOr;

public interface IWorkpieceService
{
    ErrorOr<Created> CreateWorkpiece(Workpiece workpiece);
    ErrorOr<Deleted> DeleteWorkpiece(Guid id);
    ErrorOr<Workpiece> GetWorkpiece(Guid id);
    ErrorOr<UpsertedWorkpiece> UpsertWorkpiece(Workpiece workpiece);
}