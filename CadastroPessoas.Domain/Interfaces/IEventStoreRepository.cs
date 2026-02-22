using System.Threading.Tasks;

public interface IEventStoreRepository
{
    Task SaveEventAsync(object @event);
}