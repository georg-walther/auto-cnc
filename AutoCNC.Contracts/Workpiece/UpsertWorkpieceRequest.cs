namespace AutoCNC.Contracts.Workpiece
{
    public record UpsertWorkpieceRequest(
        string Name,
        string Description,
        string Material);
}