namespace ApiAngular.Application.Responses;

public record PagedResponse<T>(
    IReadOnlyList<T> Items,
   int PageNumber,
    int PageSize,
    int TotalRecords,
    int TotalPages
);