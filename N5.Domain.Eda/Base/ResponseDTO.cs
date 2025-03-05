namespace N5.Domain.Eda.Base;

/// <summary>
/// Response Base DTO
/// </summary>
public class ResponseDTO
{
    public string EventId { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;

    public string Topic { get; set; }
}
