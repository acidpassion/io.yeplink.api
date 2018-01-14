using System.Collections.Generic;
using System.Threading.Tasks;
using NotebookAppApi.Model;
using MongoDB.Driver;
using MongoDB.Bson;

namespace NotebookAppApi.Interfaces
{
    public interface IFilterRepository
    {
        Task<IEnumerable<Filter>> GetAllFilters();
        Task<Filter> GetFilter(string id);
        Task<IEnumerable<Filter>> GetFilter(BsonDocument filter);

        // add new Filter document
        Task AddFilter(Filter item);

        // remove a single document / Filter
        Task<bool> RemoveFilter(string id);

        // update just a single document / Filter
        Task<bool> UpdateFilter(string id, Filter body);

        // demo interface - full document update
        Task<bool> UpdateFilterDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllFilters();
    }
}
