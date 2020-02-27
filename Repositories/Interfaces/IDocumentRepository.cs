using System.Collections.Generic;
using BracketApp.Api.Models;

namespace BracketApp.Api.Repositories
{
    public interface IDocumentRepository<TDocument> where TDocument : Document
    {
        public List<TDocument> Get();
        public TDocument Get(string id);
        public List<TDocument> GetByOwnerId(string userId);
        public TDocument Create(TDocument document);
        public void Update(string id, TDocument document);
        public void Remove(string id);
        public void Remove(TDocument document);
    }
}
