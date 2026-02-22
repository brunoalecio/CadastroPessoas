using System;

public class EventStoreEntity
{
    public Guid Id { get; set; }
    public string EventType { get; set; } = null!;
    public string Data { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}