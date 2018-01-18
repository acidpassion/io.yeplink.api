using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotebookAppApi.Interfaces;
using NotebookAppApi.Model;
using NotebookAppApi.Infrastructure;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace NotebookAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        private readonly IFilterRepository _filterRepository;

        public FiltersController(IFilterRepository noteRepository)
        {
            _filterRepository = noteRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Filter>> Get()
        {
            return GetFilterInternal();
        }

        private async Task<IEnumerable<Filter>> GetFilterInternal()
        {
            return await _filterRepository.GetAllFilters();
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public Task<Filter> Get(string id)
        {
            return GetFilterByIdInternal(id);
        }

        private async Task<Filter> GetFilterByIdInternal(string id)
        {
            return await _filterRepository.GetFilter(id) ?? new Filter();
        }

        // POST api/notes
        [HttpPost]
        public void Post([FromBody] Filter filter)
        {
            if (filter.Id == null || filter.Id =="") filter.Id = ObjectId.GenerateNewId().ToString();
            _filterRepository.AddFilter(filter);
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Filter filter)
        {
            filter.Id = id;
            _filterRepository.UpdateFilter(id, filter);
        }

        // DELETE api/notes/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _filterRepository.RemoveFilter(id);
        }
    }
}
