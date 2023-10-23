using AutoCNC.Contracts.Workpiece;
using AutoCNC.Models;
using AutoCNC.Services.Workpieces;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace AutoCNC.Controllers;

[Route("/workpieces")]
public class WorkpiecesController : ApiController
{
    private readonly IWorkpieceService _workpieceService;

    public WorkpiecesController(IWorkpieceService workpieceService)
    {
        _workpieceService = workpieceService;
    }

    [HttpPost]
    public IActionResult CreateWorkpiece(CreateWorkpieceRequest request)
    {
        ErrorOr<Workpiece> requestToWorkpieceResult = Workpiece.Create(
            name: request.Name,
            description: request.Description,
            material: request.Material);

        if (requestToWorkpieceResult.IsError)
        {
            return Problem(requestToWorkpieceResult.Errors);
        }

        var workpiece = requestToWorkpieceResult.Value;
        ErrorOr<Created> createWorkpieceResult = _workpieceService.CreateWorkpiece(workpiece);
        return createWorkpieceResult.Match(
            created => CreatedAsGetWorkpiece(workpiece),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetWorkpiece(Guid id)
    {
        ErrorOr<Workpiece> getWorkpieceResult = _workpieceService.GetWorkpiece(id);

        return getWorkpieceResult.Match(
            workpiece => Ok(MapWorkpieceResponse(workpiece)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertWorkpiece(Guid id, UpsertWorkpieceRequest request)
    {
        ErrorOr<Workpiece> requestToWorkpieceResult = Workpiece.Create(
            name: request.Name,
            description: request.Description,
            material: request.Material,
            id: id);

        if (requestToWorkpieceResult.IsError)
        {
            return Problem(requestToWorkpieceResult.Errors);
        }

        var workpiece = requestToWorkpieceResult.Value;
        ErrorOr<UpsertedWorkpiece> upsertedWorkpieceResult = _workpieceService.UpsertWorkpiece(workpiece);
        
        return upsertedWorkpieceResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAsGetWorkpiece(workpiece) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteWorkpiece(Guid id)
    {
        ErrorOr<Deleted> deletedWorkpieceResult = _workpieceService.DeleteWorkpiece(id);

        return deletedWorkpieceResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static WorkpieceResponse MapWorkpieceResponse(Workpiece workpiece)
    {
        return new WorkpieceResponse(
            Id: workpiece.Id,
            Name: workpiece.Name,
            Description: workpiece.Description,
            Material: workpiece.Material,
            LastModifiedDateTime: workpiece.LastModifiedDateTime);
    }

    private IActionResult CreatedAsGetWorkpiece(Workpiece workpiece)
    {
        return CreatedAtAction(
            actionName: nameof(GetWorkpiece),
            routeValues: new { id = workpiece.Id },
            value: MapWorkpieceResponse(workpiece));
    }
}