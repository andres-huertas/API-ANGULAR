namespace ApiAngular.Api.Models;

public record ErrorResponse
(
   int StatusCode,
    string Message,
    DateTime Timestamp
);
