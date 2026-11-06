namespace CampusPlacementManagement.Application.Exceptions;
public class NotFoundException : Exception { public NotFoundException(string message) : base(message) { } }
public class BadRequestException : Exception { public BadRequestException(string message) : base(message) { } }
public class ForbiddenAccessException : Exception { public ForbiddenAccessException() : base("Forbidden access.") { } }
public class EligibilityValidationException : Exception { public EligibilityValidationException(string message) : base(message) { } }
