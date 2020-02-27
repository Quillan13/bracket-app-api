using System.Collections.Generic;
using MongoDB.Driver;
using BracketApp.Api.Models;
using BracketApp.Api.Models.AppSettings;

namespace BracketApp.Api.Repositories
{
    public class DocumentRepository<TDocument> : IDocumentRepository<TDocument> where TDocument : Document
    {
        protected readonly IMongoCollection<TDocument> documents;

        public DocumentRepository(string collectionName, IMongoDBSettings mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.DatabaseName);

            documents = database.GetCollection<TDocument>(collectionName);
        }

        public virtual List<TDocument> Get() => documents.Find(d => true).ToList();

        public virtual TDocument Get(string id) => documents.Find(d => d.Id == id).FirstOrDefault();
        public virtual List<TDocument> GetByOwnerId(string ownerId) => documents.Find(d => d.OwnerId == ownerId).ToList();

        public virtual void Update(string id, TDocument document) => documents.ReplaceOne(d => d.Id == id, document);

        public virtual void Remove(string id) => documents.DeleteOne(d => d.Id == id);

        public virtual void Remove(TDocument document) => documents.DeleteOne(d => d.Id == document.Id);

        public virtual TDocument Create(TDocument document)
        {
            documents.InsertOne(document);
            return document;
        }
    }
}
