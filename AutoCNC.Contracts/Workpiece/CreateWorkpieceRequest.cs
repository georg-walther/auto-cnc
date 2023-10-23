namespace AutoCNC.Contracts.Workpiece
{
    public record CreateWorkpieceRequest(
        string Name,
        string Description,
        string Material);
}