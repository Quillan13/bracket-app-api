using BracketApp.Api.Models.AppSettings;
using BracketApp.Api.Models.Bracket;

namespace BracketApp.Api.Repositories
{
    public class BracketRepository : DocumentRepository<Bracket>
    {
        private const string COLLECTION_NAME = "Brackets";

        public BracketRepository(IMongoDBSettings mongoDBSettings) : base(COLLECTION_NAME, mongoDBSettings)
        {

        }
    }
}
