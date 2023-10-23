namespace AutoCNC.Contracts.Workpiece
{
    public record WorkpieceResponse(
        Guid Id,
        string Name,
        string Description,
        string Material,
        DateTime LastModifiedDateTime);
}