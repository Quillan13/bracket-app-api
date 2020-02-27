using BracketApp.Api.Models.AppSettings;
using BracketApp.Api.Models.UserSettings;

namespace BracketApp.Api.Repositories
{
    public class UserSettingsRepository : DocumentRepository<UserSettings>
    {
        private const string COLLECTION_NAME = "User_Settings";

        public UserSettingsRepository(IMongoDBSettings mongoDBSettings) : base(COLLECTION_NAME, MongoDBSettings)
        {

        }
    }
}
