namespace N5.Domain.Eda.Interfaces.DTOs;

public interface IPayloadMessageDTO
{
    /// <summary>
    /// Session identifier
    /// </summary>
    public string EventId { get; set; }
}