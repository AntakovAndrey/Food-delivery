namespace IdentityService.Domain.Exceptions;

public class EmailAlreadyExistsException(string message) : Exception(message);
