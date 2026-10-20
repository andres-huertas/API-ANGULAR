namespace ApiAngular.Application.Requests;

public record PagedRequest
{
    private const int MaxPageSize = 100;

    public int PageNumber { get; init; } = 1;

    private int _pageSize = 10;
     public string? Search { get; set; }

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value > MaxPageSize
            ? MaxPageSize
            : value;
    }
}