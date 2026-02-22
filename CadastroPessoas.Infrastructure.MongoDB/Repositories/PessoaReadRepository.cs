using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PessoaReadRepository : IPessoaReadRepository
{
    private readonly IMongoCollection<PessoaReadModel> _collection;

    public PessoaReadRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<PessoaReadModel>("Pessoas");
    }

    public async Task AddAsync(PessoaReadModel model)
        => await _collection.InsertOneAsync(model);

    public async Task<List<PessoaReadModel>> GetAllAsync()
        => await _collection.Find(_ => true).ToListAsync();
}