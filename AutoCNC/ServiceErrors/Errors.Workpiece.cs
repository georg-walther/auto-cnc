using ErrorOr;

namespace AutoCNC.ServiceErrors;

public static class Errors
{
    public static class Workpiece
    {
        public static Error InvalidName => Error.Validation(
            code: "Workpiece.InvalidName.",
            description: $"The workpiece name must be at least {Models.Workpiece.MinNameLength}" +
            $" characters long and at most {Models.Workpiece.MaxNameLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Workpiece.NotFound.",
            description: "The workpiece was not found.");
    }
}