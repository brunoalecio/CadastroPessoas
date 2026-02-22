using System.Text.Json;
using CadastroPessoas.Infrastructure.SqlServer;

public class EventStoreRepository : IEventStoreRepository
{
    private readonly AppDbContext _context;

    public EventStoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveEventAsync(object @event)
    {
        var entity = new EventStoreEntity
        {
            Id = Guid.NewGuid(),
            EventType = @event.GetType().Name,
            Data = JsonSerializer.Serialize(@event),
            CreatedAt = DateTime.UtcNow
        };

        await _context.Events.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}