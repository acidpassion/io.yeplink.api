using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NotebookAppApi.Interfaces;
using NotebookAppApi.Model;
using MongoDB.Bson;

namespace NotebookAppApi.Data
{
    public class FilterRepository : IFilterRepository
    {
        private readonly NoteContext _context = null;

        public FilterRepository(IOptions<Settings> settings)
        {
            _context = new NoteContext(settings);
        }

        public async Task<IEnumerable<Filter>> GetAllFilters()
        {
            try
            {
                return await _context.Filters.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Filter> GetFilter(string id)
        {
            var filter = Builders<Filter>.Filter.Eq("Id", id);

            try
            {
                return await _context.Filters
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddFilter(Filter item)
        {
            try
            {
                await _context.Filters.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveFilter(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Filters.DeleteOneAsync(
                     Builders<Filter>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<bool> UpdateFilter(string id, Filter item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Filters
                                                              .ReplaceOneAsync(n => n.Id.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<bool> RemoveAllFilters()
        {
            try
            {
                DeleteResult actionResult = await _context.Filters.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<Filter>> GetFilter(BsonDocument filter)
        {
            var pipeline = new BsonDocument[] {
            new BsonDocument{ { "$sort", new BsonDocument("_id", 1) }},
            new BsonDocument{{"$unwind", "$scores"}},
            new BsonDocument{{"$group", new BsonDocument{
                        {"_id", "$_id"},
                        {"lowscore",new BsonDocument{
                                {"$min","$scores.score"}}
                        }}
                }}
            };
            return await _context.Filters.Aggregate<Filter>(pipeline).ToListAsync();

        }

        public Task<bool> UpdateFilter(string id, string body)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFilterDocument(string id, string body)
        {
            throw new NotImplementedException();
        }
    }
}
