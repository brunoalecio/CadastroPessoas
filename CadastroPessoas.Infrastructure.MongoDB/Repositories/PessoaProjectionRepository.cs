using MongoDB.Driver;

public class PessoaProjectionRepository : IPessoaProjectionRepository
{
    private readonly IMongoCollection<PessoaReadModel> _collection;

    public PessoaProjectionRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<PessoaReadModel>("Pessoas");
    }

    public async Task UpdateAsync(PessoaReadModel pessoa)
    {
        await _collection.ReplaceOneAsync(
            x => x.Id == pessoa.Id,
            pessoa);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

}